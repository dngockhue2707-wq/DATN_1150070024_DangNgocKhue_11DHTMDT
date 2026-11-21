HƯỚNG DẪN CÀI ĐẶT, CẤU HÌNH VÀ CHẠY CHƯƠNG TRÌNH

1. GIỚI THIỆU
Chương trình được xây dựng nhằm hỗ trợ quản lý hoạt động khách sạn và giúp khách hàng tìm kiếm, lựa chọn phòng phù hợp với nhu cầu.
Website cung cấp các chức năng tìm kiếm phòng, xem thông tin phòng, đặt phòng trực tuyến, thanh toán, quản lý đặt phòng và hóa đơn. Bên cạnh đó, chương trình tích hợp chức năng gợi ý phòng dựa trên các tiêu chí như ngân sách, sức chứa, tiện nghi, diện tích và đánh giá.

Chương trình gồm ba nhóm người dùng:
- Khách hàng: Tìm kiếm phòng, xem thông tin, nhận gợi ý phòng, đặt phòng, thanh toán và quản lý lịch sử đặt phòng.
- Nhân viên: Quản lý đặt phòng, thực hiện nhận phòng, trả phòng, quản lý hóa đơn và xử lý yêu cầu khách hàng.
- Quản trị viên: Quản lý phòng, loại phòng, tài khoản, nhân viên và theo dõi hoạt động kinh doanh.

2. CÔNG NGHỆ SỬ DỤNG
- Backend: ASP.NET Core Web API.
- Ngôn ngữ lập trình: C#.
- Frontend: HTML, CSS, JavaScript.
- Cơ sở dữ liệu: Microsoft SQL Server.
- Công cụ lập trình: Visual Studio Code.
- Công cụ quản lý cơ sở dữ liệu: SQL Server Management Studio.
- Thanh toán trực tuyến: VNPay Sandbox.
- Phương pháp gợi ý phòng: Content-Based Recommendation kết hợp Weighted Scoring.

3. YÊU CẦU CÀI ĐẶT
Trước khi chạy chương trình, cần cài đặt các phần mềm sau:
1. .NET SDK 8.0: Sử dụng để biên dịch và chạy Backend ASP.NET Core Web API.
2. Visual Studio Code: Công cụ mở, chỉnh sửa và chạy mã nguồn.
3. Microsoft SQL Server 2022: Hệ quản trị cơ sở dữ liệu.
4. SQL Server Management Studio (SSMS) 20: Công cụ quản lý, truy vấn và khôi phục cơ sở dữ liệu.
5. Google Chrome hoặc Microsoft Edge: Trình duyệt để truy cập và kiểm thử website.
6. Live Server: Tiện ích trong Visual Studio Code dùng để chạy giao diện HTML, CSS và JavaScript.
7. Git: Công cụ hỗ trợ tải mã nguồn từ GitHub, không bắt buộc nếu tải bằng ZIP.

3.1. Kiểm tra .NET SDK
Sau khi cài đặt .NET SDK, mở Terminal hoặc Command Prompt và nhập:
dotnet --version

Nếu kết quả hiển thị phiên bản 8.0.xxx, máy đã cài đặt .NET SDK 8.0.
Để kiểm tra tất cả phiên bản SDK đã cài đặt:
dotnet --list-sdks

3.2. Kiểm tra SQL Server
1. Mở SQL Server Management Studio (SSMS).
2. Nhập tên SQL Server tại mục Server name.
3. Chọn phương thức xác thực phù hợp.
4. Nhấn Connect để kết nối.
5. Kiểm tra SQL Server hoạt động bình thường.

4. HƯỚNG DẪN TẢI VÀ MỞ MÃ NGUỒN
Bước 1: Tải mã nguồn từ GitHub
Truy cập repository GitHub chứa mã nguồn chương trình.
Chọn Code → Download ZIP.
Sau đó giải nén mã nguồn vào thư mục mong muốn trên máy tính.
Ngoài ra, có thể sử dụng Git:
git clone <DUONG_DAN_REPOSITORY>
Thay <escape><DUONG_DAN_REPOSITORY></escape> bằng địa chỉ repository GitHub.

Bước 2: Mở dự án bằng Visual Studio Code
1. Khởi động Visual Studio Code.
2. Chọn File → Open Folder.
3. Chọn thư mục chứa mã nguồn đã giải nén.
4. Nhấn Select Folder để mở dự án.
Thư mục QuanLyKhachSan.API chứa mã nguồn Backend của chương trình.

5. HƯỚNG DẪN CÀI ĐẶT CƠ SỞ DỮ LIỆU
Bước 1: Khởi động SQL Server
Mở SQL Server Management Studio và kết nối đến SQL Server trên máy tính.

Bước 2: Tạo hoặc khôi phục cơ sở dữ liệu
Trường hợp sử dụng tệp .sql:
1. Mở SQL Server Management Studio.
2. Chọn File → Open → File.
3. Chọn tệp SQL được cung cấp cùng mã nguồn.
4. Nhấn Execute để thực thi tập lệnh.
5. Kiểm tra cơ sở dữ liệu và các bảng sau khi thực thi.

Trường hợp sử dụng tệp sao lưu .bak:
1. Nhấp chuột phải vào Databases.
2. Chọn Restore Database.
3. Chọn Device và tìm đến tệp .bak.
4. Thiết lập tên cơ sở dữ liệu cần khôi phục.
5. Nhấn OK để hoàn tất.

Bước 3: Kiểm tra dữ liệu
Sau khi tạo hoặc khôi phục thành công:
1. Mở danh sách Databases.
2. Chọn cơ sở dữ liệu của chương trình.
3. Mở mục Tables.
4. Kiểm tra các bảng dữ liệu và dữ liệu có sẵn.
Lưu ý: Cần sử dụng đúng cơ sở dữ liệu được cung cấp kèm theo mã nguồn để các chức năng hoạt động chính xác.

6. HƯỚNG DẪN CẤU HÌNH BACKEND
Bước 1: Mở thư mục Backend
Trong Visual Studio Code, chọn Terminal → New Terminal.
Di chuyển vào thư mục Backend:
cd QuanLyKhachSan.API

Nếu Terminal đã nằm trong thư mục QuanLyKhachSan.API thì không cần thực hiện lệnh trên.

Bước 2: Cấu hình kết nối cơ sở dữ liệu
Mở tệp:
appsettings.json

Tìm phần cấu hình ConnectionStrings và cập nhật thông tin kết nối SQL Server phù hợp.
Ví dụ sử dụng Windows Authentication:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=TEN_CSDL;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}


Trong đó:
- Server: Tên SQL Server của máy tính.
- Database: Tên cơ sở dữ liệu đã tạo hoặc khôi phục.
- Trusted_Connection=True: Sử dụng tài khoản Windows để kết nối.
- TrustServerCertificate=True: Cho phép kết nối với chứng chỉ SQL Server trong môi trường phát triển.

Nếu sử dụng SQL Server Authentication, chuỗi kết nối có thể có dạng:
Server=localhost;Database=TEN_CSDL;User Id=TEN_DANG_NHAP;Password=MAT_KHAU;TrustServerCertificate=True;

Cần sử dụng đúng tên chuỗi kết nối mà mã nguồn Backend đang đọc. Không thay thế toàn bộ nội dung appsettings.json nếu tệp còn chứa các cấu hình khác.

Bước 3: Khôi phục thư viện
Trong Terminal, chạy:
dotnet restore

Lệnh này sẽ tải và khôi phục các thư viện NuGet cần thiết cho chương trình.

Bước 4: Biên dịch chương trình
Chạy lệnh:
dotnet build
Nếu chương trình biên dịch thành công và không xuất hiện lỗi, có thể tiếp tục khởi động Backend.

Bước 5: Chạy Backend
Nhập lệnh:
dotnet run
Sau khi khởi động thành công, Terminal sẽ hiển thị địa chỉ localhost của Backend.

Ví dụ:
Now listening on: http://localhost:5068

Địa chỉ và cổng thực tế phụ thuộc vào cấu hình của chương trình.
Giữ Terminal hoạt động trong suốt quá trình sử dụng website.

7. HƯỚNG DẪN CHẠY GIAO DIỆN FRONTEND

Bước 1: Cài đặt Live Server
Trong Visual Studio Code:
1. Chọn mục Extensions.
2. Tìm kiếm Live Server.
3. Chọn tiện ích của Ritwick Dey.
4. Nhấn Install để cài đặt.

Bước 2: Mở giao diện website
1. Mở thư mục chứa mã nguồn Frontend.
2. Tìm tệp HTML trang chủ.
3. Nhấp chuột phải vào tệp HTML.
4. Chọn Open with Live Server.
5. Trình duyệt sẽ tự động mở website.

Ví dụ, Live Server có thể sử dụng địa chỉ:
http://127.0.0.1:5500
Địa chỉ này có thể thay đổi tùy theo cấu hình và cổng đang sử dụng.

Bước 3: Kiểm tra kết nối Backend
Đảm bảo Backend đã được khởi động trước khi sử dụng các chức năng của website.
Kiểm tra địa chỉ API được khai báo trong JavaScript và bảo đảm địa chỉ này trùng với địa chỉ Backend đang chạy.
Nếu giao diện không hiển thị dữ liệu, cần kiểm tra:
- Backend đã khởi động hay chưa.
- SQL Server đã hoạt động hay chưa.
- Chuỗi kết nối cơ sở dữ liệu đã chính xác chưa.
- Địa chỉ API và cổng kết nối có đúng không.
- Trình duyệt có thông báo lỗi kết nối hoặc CORS hay không.

8. HƯỚNG DẪN CẤU HÌNH THANH TOÁN VNPAY
Website tích hợp VNPay Sandbox nhằm phục vụ kiểm thử chức năng thanh toán trực tuyến.
Bước 1: Chuẩn bị thông tin VNPay
Sử dụng thông tin được cấp từ môi trường VNPay Sandbox, bao gồm:
- TmnCode: Mã website hoặc mã đơn vị chấp nhận thanh toán.
- HashSecret: Khóa bí mật dùng để tạo và kiểm tra chữ ký giao dịch.
- PaymentUrl: Địa chỉ cổng thanh toán thử nghiệm.
- ReturnUrl: Địa chỉ nhận kết quả sau khi thanh toán.

Bước 2: Cập nhật cấu hình
Mở tệp cấu hình VNPay trong Backend.
Cập nhật các thông tin Sandbox tương ứng với tài khoản thử nghiệm.
Đảm bảo địa chỉ trả về sau thanh toán phù hợp với cổng website đang chạy.
Ví dụ địa chỉ kết quả thanh toán:
http://localhost:5068/payment-result.html

Đây là địa chỉ được sử dụng khi chương trình chạy trên cổng 5068. Nếu chạy bằng cổng khác, cần cập nhật lại cho phù hợp.

Bước 3: Kiểm thử thanh toán
1. Khởi động Backend và Frontend.
2. Truy cập website bằng trình duyệt.
3. Đăng nhập tài khoản khách hàng.
4. Tìm kiếm và chọn phòng.
5. Nhập thông tin đặt phòng.
6. Chọn phương thức thanh toán VNPay.
7. Thực hiện thanh toán bằng thông tin thử nghiệm được VNPay Sandbox hỗ trợ.
8. Kiểm tra kết quả thanh toán và trạng thái đơn đặt phòng.

Lưu ý: VNPay Sandbox là môi trường thử nghiệm, không thực hiện giao dịch bằng tiền thật. Không công khai HashSecret, mật khẩu SQL Server hoặc các thông tin nhạy cảm trên GitHub.

9. HƯỚNG DẪN SỬ DỤNG CÁC CHỨC NĂNG CHÍNH

9.1. Chức năng khách hàng
1. Đăng ký và đăng nhập tài khoản.
2. Tìm kiếm phòng theo ngày nhận, ngày trả và số lượng khách.
3. Xem danh sách phòng và thông tin chi tiết.
4. Sử dụng chức năng gợi ý phòng phù hợp.
5. Chọn phòng và thực hiện đặt phòng.
6. Thanh toán trực tuyến thông qua VNPay Sandbox.
7. Xem và quản lý lịch sử đặt phòng.
8. Theo dõi thông tin tài khoản cá nhân.

9.2. Chức năng nhân viên
1. Xem danh sách đặt phòng.
2. Kiểm tra thông tin khách hàng.
3. Thực hiện nhận phòng (Check-in).
4. Thực hiện trả phòng (Check-out).
5. Theo dõi tình trạng phòng.
6. Quản lý và kiểm tra hóa đơn.
7. Tiếp nhận, xử lý yêu cầu từ khách hàng.

9.3. Chức năng quản trị viên
1. Quản lý danh sách phòng và loại phòng.
2. Quản lý thông tin khách hàng.
3. Quản lý tài khoản và nhân viên.
4. Quản lý đặt phòng.
5. Theo dõi hóa đơn và thanh toán.
6. Xem thống kê và báo cáo hoạt động kinh doanh.

10. CHỨC NĂNG GỢI Ý PHÒNG
Website sử dụng phương pháp Content-Based Recommendation kết hợp Weighted Scoring nhằm đề xuất các phòng phù hợp với nhu cầu của khách hàng.

Hệ thống đánh giá mức độ phù hợp dựa trên năm tiêu chí và trọng số:
| STT | Tiêu chí | Trọng số |
|---|---|---|
| 1 | Ngân sách | 35% |
| 2 | Sức chứa | 25% |
| 3 | Tiện nghi | 20% |
| 4 | Diện tích | 10% |
| 5 | Đánh giá | 10% |
| | Tổng cộng | 100% |

Điểm phù hợp được tính bằng cách tổng hợp điểm của từng tiêu chí theo trọng số đã thiết lập.
Sau khi tính toán, hệ thống sắp xếp các phòng theo mức độ phù hợp và đề xuất tối đa 5 phòng để khách hàng tham khảo.
Chức năng này giúp khách hàng thu hẹp danh sách lựa chọn và tìm kiếm phòng phù hợp với nhu cầu cá nhân.

11. KIỂM TRA CHƯƠNG TRÌNH SAU KHI CÀI ĐẶT

Sau khi hoàn tất cài đặt và cấu hình, thực hiện kiểm tra các chức năng sau:
| STT | Chức năng | Nội dung kiểm tra |
|---|---|---|
| 1 | Kết nối cơ sở dữ liệu | Backend truy xuất được dữ liệu SQL Server |
| 2 | Trang chủ | Hiển thị giao diện và thông tin khách sạn |
| 3 | Đăng ký, đăng nhập | Tài khoản có thể đăng ký và đăng nhập |
| 4 | Tìm kiếm phòng | Hiển thị danh sách phòng theo điều kiện tìm kiếm |
| 5 | Gợi ý phòng | Hiển thị các phòng được đề xuất theo nhu cầu |
| 6 | Đặt phòng | Khách hàng có thể tạo yêu cầu đặt phòng |
| 7 | Thanh toán | Chuyển đến VNPay Sandbox và nhận kết quả giao dịch |
| 8 | Quản lý đặt phòng | Hiển thị và cập nhật thông tin đặt phòng |
| 9 | Nhận, trả phòng | Nhân viên thực hiện Check-in và Check-out |
| 10 | Quản lý phòng | Quản trị viên quản lý thông tin và tình trạng phòng |
| 11 | Quản lý hóa đơn | Hiển thị và quản lý thông tin hóa đơn |

12. CÁC LỖI THƯỜNG GẶP VÀ CÁCH KHẮC PHỤC
12.1. Không chạy được Backend
Kiểm tra .NET SDK:
dotnet --version

Khôi phục thư viện:
dotnet restore

Biên dịch lại chương trình:
dotnet build

Chạy chương trình:
dotnet run

Nếu xuất hiện lỗi, kiểm tra nội dung thông báo trong Terminal để xác định nguyên nhân.

12.2. Không kết nối được SQL Server
Nguyên nhân có thể do:
- SQL Server chưa được khởi động.
- Tên Server không chính xác.
- Tên cơ sở dữ liệu không đúng.
- Tài khoản kết nối không có quyền truy cập.
- Chuỗi kết nối trong appsettings.json chưa phù hợp.

Cách khắc phục:
1. Mở SQL Server Management Studio.
2. Kiểm tra kết nối đến SQL Server.
3. Kiểm tra tên cơ sở dữ liệu.
4. Cập nhật lại chuỗi kết nối.
5. Khởi động lại Backend.

12.3. Giao diện không hiển thị dữ liệu
Kiểm tra:
1. Backend đang chạy.
2. Địa chỉ API được cấu hình chính xác.
3. SQL Server đang hoạt động.
4. Trình duyệt không xuất hiện lỗi kết nối trong Developer Tools.

Có thể nhấn F12 → Console để xem thông báo lỗi của trình duyệt.

12.4. Lỗi khi thanh toán VNPay
Kiểm tra:
- Thông tin cấu hình VNPay Sandbox.
- Mã TmnCode.
- Khóa HashSecret.
- Địa chỉ ReturnUrl.
- Địa chỉ và cổng website đang chạy.

Nếu thay đổi cổng chạy chương trình, cần cập nhật các địa chỉ liên quan đến thanh toán.

13. LƯU Ý KHI CHẠY CHƯƠNG TRÌNH
- Cần khởi động SQL Server trước khi chạy Backend.
- Cần chạy Backend trước khi sử dụng các chức năng lấy dữ liệu của Frontend.
- Đảm bảo cấu hình kết nối cơ sở dữ liệu chính xác.
- Sử dụng đúng phiên bản .NET tương thích với chương trình.
- Không tự ý thay đổi cấu trúc cơ sở dữ liệu khi chưa kiểm tra các ràng buộc.
- VNPay Sandbox chỉ phục vụ kiểm thử thanh toán.
- Các tài khoản phải được phân quyền phù hợp với từng nhóm người dùng.
- Không đưa mật khẩu, khóa bí mật hoặc thông tin nhạy cảm lên GitHub công khai.

14. KẾT LUẬN

Sau khi thực hiện đầy đủ các bước cài đặt và cấu hình, chương trình có thể được chạy trên môi trường localhost để phục vụ kiểm thử và trình bày đồ án.
Website hỗ trợ các chức năng quản lý khách sạn, tìm kiếm và đặt phòng, thanh toán trực tuyến, quản lý hóa đơn và gợi ý phòng theo nhu cầu khách hàng. Qua đó, chương trình góp phần hỗ trợ hoạt động quản lý và nâng cao sự thuận tiện trong quá trình tìm kiếm, lựa chọn phòng của khách hàng.
