
"use strict";

document.addEventListener("DOMContentLoaded", () => {
    const byId = id => document.getElementById(id);

    const typeSelect = byId("specificAmenityType");
    const roomSelect = byId("specificAmenityRoom");
    const list = byId("specificAmenityCheckboxes");
    const save = byId("saveSpecificAmenities");
    const message = byId("specificAmenityMessage");

    if (!typeSelect || !roomSelect || !list || !save || !message) {
        return;
    }

    let rooms = [];
    let amenities = [];
    let selectedIds = [];
    let loadSerial = 0;

    const api = async (url, options = {}) => {
        const response = await fetch(url, {
            credentials: "same-origin",
            ...options
        });

        const data = await response.json().catch(() => ({}));

        if (!response.ok) {
            throw new Error(
                data.message || `Lỗi HTTP ${response.status}`
            );
        }

        return data;
    };

    const notify = (text, error = false) => {
        message.textContent = text;
        message.style.color = error ? "#b42318" : "#75502e";
    };

    const draw = () => {
        list.replaceChildren();

        for (const amenity of amenities) {
            const label = document.createElement("label");
            label.className = "room-checkbox-line";

            const input = document.createElement("input");
            input.type = "checkbox";
            input.value = amenity.id;
            input.checked = selectedIds.includes(amenity.id);
            input.disabled = !amenity.active;

            const name = document.createElement("span");
            name.textContent =
                amenity.name +
                (amenity.active ? "" : " (Tạm ngừng)");

            label.append(input, name);
            list.appendChild(label);
        }
    };

    const loadRoom = async () => {
        const serial = ++loadSerial;
        const roomId = Number(roomSelect.value);

        list.replaceChildren();
        save.disabled = true;

        if (!roomId) {
            notify("Chọn phòng để xem tiện nghi.");
            return;
        }

        try {
            const data = await api(
                `/api/admin/room-amenities/${roomId}`
            );

            if (serial !== loadSerial) {
                return;
            }

            selectedIds = data.amenityIds;

            draw();

            save.disabled = false;

            notify(
                `Đang chỉnh tiện nghi phòng ${data.roomNumber}.`
            );
        } catch (error) {
            if (serial === loadSerial) {
                notify(error.message, true);
            }
        }
    };

    const selectType = () => {
        const typeId = Number(typeSelect.value);

        roomSelect.replaceChildren();

        roomSelect.add(
            new Option("Chọn phòng", "")
        );

        for (const room of rooms.filter(
            item => item.roomTypeId === typeId
        )) {
            roomSelect.add(
                new Option(
                    `Phòng ${room.roomNumber}`,
                    String(room.id)
                )
            );
        }

        loadRoom();
    };

    typeSelect.addEventListener("change", selectType);
    roomSelect.addEventListener("change", loadRoom);

    save.addEventListener("click", async () => {
        const roomId = Number(roomSelect.value);

        if (!roomId) {
            return;
        }

        save.disabled = true;

        try {
            const token = await api(
                "/api/account/csrf-token"
            );

            const result = await api(
                `/api/admin/room-amenities/${roomId}`,
                {
                    method: "PUT",
                    headers: {
                        "Content-Type": "application/json",
                        "X-CSRF-TOKEN": token.csrfToken
                    },
                    body: JSON.stringify({
                        amenityIds: [
                            ...list.querySelectorAll(
                                'input[type="checkbox"]:checked'
                            )
                        ].map(input => Number(input.value))
                    })
                }
            );

            notify(result.message);
        } catch (error) {
            notify(error.message, true);
        } finally {
            save.disabled = false;
        }
    });

    Promise.all([
        api("/api/admin/room-management/types"),
        api("/api/admin/room-management/rooms"),
        api("/api/admin/room-management/amenities")
    ])
        .then(([types, roomData, amenityData]) => {
            rooms = roomData;
            amenities = amenityData;

            typeSelect.replaceChildren(
                new Option("Chọn loại phòng", "")
            );

            for (const type of types) {
                typeSelect.add(
                    new Option(
                        type.name,
                        String(type.id)
                    )
                );
            }

            selectType();
        })
        .catch(error => {
            notify(error.message, true);
        });
});
