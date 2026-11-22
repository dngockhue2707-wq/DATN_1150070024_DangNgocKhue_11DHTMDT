
using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyKhachSan.API.Data;

namespace QuanLyKhachSan.API.Controllers;

[ApiController]
[Route("api/admin/room-amenities")]
[Authorize(Roles = "Admin")]
public class RoomAmenitiesController : ControllerBase
{
    private readonly HotelDbContext _db;

    public RoomAmenitiesController(HotelDbContext db)
    {
        _db = db;
    }

    public sealed class SaveRequest
    {
        public List<int> AmenityIds { get; set; } = new();
    }

    [HttpGet("{roomId:int}")]
    public async Task<IActionResult> Get(int roomId)
    {
        var room = await _db.Phongs.AsNoTracking()
            .Where(p => p.MaPhong == roomId)
            .Select(p => new
            {
                p.MaPhong,
                p.SoPhong
            })
            .FirstOrDefaultAsync();

        if (room == null)
            return NotFound(new
            {
                message = "Phòng không tồn tại."
            });

        var ids = new List<int>();
        var connection = _db.Database.GetDbConnection();

        await connection.OpenAsync();

        try
        {
            await using var command = connection.CreateCommand();

            command.CommandText =
                "SELECT MaTienNghi FROM dbo.PhongTienNghiChiTiet WHERE MaPhong = @roomId";

            var parameter = command.CreateParameter();
            parameter.ParameterName = "@roomId";
            parameter.Value = roomId;

            command.Parameters.Add(parameter);

            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                ids.Add(reader.GetInt32(0));
            }
        }
        finally
        {
            await connection.CloseAsync();
        }

        return Ok(new
        {
            roomId,
            roomNumber = room.SoPhong,
            amenityIds = ids
        });
    }

    [HttpPut("{roomId:int}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Save(
        int roomId,
        SaveRequest request)
    {
        if (!await _db.Phongs.AnyAsync(p => p.MaPhong == roomId))
        {
            return NotFound(new
            {
                message = "Phòng không tồn tại."
            });
        }

        var ids = (request.AmenityIds ?? new List<int>())
            .Distinct()
            .ToList();

        if (ids.Any(id => id <= 0) ||
            await _db.TienNghis.CountAsync(
                a => ids.Contains(a.MaTienNghi)) != ids.Count)
        {
            return BadRequest(new
            {
                message = "Danh sách tiện nghi không hợp lệ."
            });
        }

        var connection = _db.Database.GetDbConnection();

        await connection.OpenAsync();

        try
        {
            await using var transaction =
                await connection.BeginTransactionAsync(
                    IsolationLevel.Serializable);

            try
            {
                await using (var delete = connection.CreateCommand())
                {
                    delete.Transaction = transaction;

                    delete.CommandText =
                        "DELETE FROM dbo.PhongTienNghiChiTiet WHERE MaPhong = @roomId";

                    var param = delete.CreateParameter();
                    param.ParameterName = "@roomId";
                    param.Value = roomId;

                    delete.Parameters.Add(param);

                    await delete.ExecuteNonQueryAsync();
                }

                foreach (var id in ids)
                {
                    await using var insert = connection.CreateCommand();

                    insert.Transaction = transaction;

                    insert.CommandText =
                        "INSERT INTO dbo.PhongTienNghiChiTiet (MaPhong, MaTienNghi) VALUES (@roomId, @amenityId)";

                    var roomParam = insert.CreateParameter();
                    roomParam.ParameterName = "@roomId";
                    roomParam.Value = roomId;

                    insert.Parameters.Add(roomParam);

                    var amenityParam = insert.CreateParameter();
                    amenityParam.ParameterName = "@amenityId";
                    amenityParam.Value = id;

                    insert.Parameters.Add(amenityParam);

                    await insert.ExecuteNonQueryAsync();
                }

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        finally
        {
            await connection.CloseAsync();
        }

        return Ok(new
        {
            success = true,
            message = "Đã lưu tiện nghi riêng của phòng."
        });
    }
}
