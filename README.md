# ☕ Beverage Shop Demo - OOP & Design Patterns in C#

Dự án này là mã nguồn minh họa cho việc ứng dụng **Lập trình Hướng đối tượng (OOP)** và **Design Patterns** cơ bản trong C#/.NET. Mã nguồn được thiết kế tối giản, tập trung vào việc tổ chức cấu trúc dữ liệu khoa học, bám sát các nguyên lý thiết kế linh hoạt (SOLID), và dễ dàng tích hợp kiểm thử tự động (Unit Test).

## Cấu trúc dự án (Solution Structure)

Giải pháp (Solution) được chia thành 2 dự án (Projects) riêng biệt để thể hiện tính chuyên nghiệp và tư duy phân tách trách nhiệm (Separation of Concerns):

1. **`BeverageShopDemo`**: Project chính (Console Application) chứa logic nghiệp vụ cốt lõi.
2. **`BeverageShopDemo.Tests`**: Project kiểm thử (xUnit) chứa các kịch bản kiểm tra tự động, tách biệt hoàn toàn khỏi mã nguồn chính.

## Tổ chức thư mục (Directory Tree)

```text
BeverageShopDemo_Solution/
│
├── BeverageShopDemo/                    # [DỰ ÁN CHÍNH]
│   ├── BeverageShopDemo.csproj
│   ├── Program.cs                       # Điểm neo chạy ứng dụng chính
│   │
│   ├── Models/                          # (Entities) Chứa dữ liệu cốt lõi
│   │   ├── Beverage.cs
│   │   ├── Coffee.cs
│   │   ├── MilkTea.cs
│   │   └── Order.cs
│   │
│   ├── Factories/                       # (Design Pattern) Nơi sản xuất
│   │   └── BeverageFactory.cs
│   │
│   ├── Strategies/                      # (Design Pattern) Xử lý nghiệp vụ
│   │   ├── IPromotionStrategy.cs
│   │   ├── NoPromotion.cs
│   │   ├── VipPromotion.cs
│   │   └── WeekendPromotion.cs
│   │
│   └── Utils/                           # Các tiện ích dùng chung toàn cục
│       └── ShopLogger.cs
│
└── BeverageShopDemo.Tests/              # [DỰ ÁN KIỂM THỬ]
    ├── BeverageShopDemo.Tests.csproj
    ├── BeverageTests.cs                 # Kiểm thử các lỗi ngoại lệ (Exception)
    └── OrderTests.cs                    # Kiểm thử logic tính tiền

```

## Mục đích của từng Thư mục & Class

### 1. Thư mục `Models/` (Thực thể miền)

Đây là "trái tim" của hệ thống, chứa các đối tượng phản ánh thế giới thực.

* **`Beverage.cs`**: Lớp cơ sở (Base Class) định nghĩa cấu trúc chung của một loại đồ uống (Tên, Giá, Lượng đường). Thể hiện tính **Đóng gói (Encapsulation)** thông qua việc kiểm soát giá trị đầu vào (chặn gán giá trị âm).
* **`Coffee.cs` & `MilkTea.cs**`: Các lớp con kế thừa từ `Beverage`. Thể hiện tính **Kế thừa (Inheritance)** và **Đa hình (Polymorphism)** khi mỗi loại đồ uống tự ghi đè (`override`) phương thức `Prepare()` để quá trình pha chế diễn ra theo đặc thù riêng.
* **`Order.cs`**: Đại diện cho một đơn hàng (Context), chứa danh sách các món đồ uống và nhận lệnh tính toán tổng tiền dựa trên chiến lược được cung cấp.

### 2. Thư mục `Factories/` (Factory Method Pattern)

* **`BeverageFactory.cs`**: Đóng vai trò như một "Xưởng pha chế". Giải quyết sự phụ thuộc cứng bằng cách tập trung toàn bộ từ khóa khởi tạo đối tượng (`new`) vào một chỗ. Khi quán cập nhật menu đồ uống mới, hệ thống chỉ cần bảo trì duy nhất file này mà không làm hỏng logic của quy trình gọi món.

### 3. Thư mục `Strategies/` (Strategy Pattern)

Chứa các thuật toán xử lý nghiệp vụ độc lập, giúp loại bỏ hoàn toàn các vòng lặp và câu lệnh rẽ nhánh `if-else` (Cyclomatic Complexity cao) khi tính toán giá trị đơn hàng.

* **`IPromotionStrategy.cs`**: Giao diện chung (Interface) định nghĩa khuôn mẫu bắt buộc cho mọi chương trình khuyến mãi.
* **`NoPromotion.cs`, `VipPromotion.cs`, `WeekendPromotion.cs**`: Các lớp chiến lược cụ thể. Nhờ kiến trúc này, hệ thống có thể dễ dàng "cắm thêm" (plug-in) các chương trình khuyến mãi mới mẻ trong tương lai mà không cần chạm vào file `Order.cs` (Nguyên lý Open/Closed).

### 4. Thư mục `Utils/` (Singleton Pattern)

* **`ShopLogger.cs`**: Tiện ích ghi chú hệ thống. Áp dụng kỹ thuật khởi tạo đối tượng duy nhất (Singleton) nhằm đảm bảo toàn bộ ứng dụng chỉ sử dụng chung một "cuốn sổ" ghi log, giúp tiết kiệm bộ nhớ, tăng tốc độ truy xuất và ngăn ngừa xung đột dữ liệu.

### 5. `Program.cs`

Điểm khởi chạy ứng dụng (Entry Point). Mô phỏng luồng hoạt động thực tế bằng cách điều phối các đối tượng từ `Models`, `Factories` và `Strategies` tương tác với nhau: *Khởi tạo đơn hàng với khuyến mãi -> Yêu cầu Factory sản xuất đồ uống -> Tiến hành pha chế đa hình -> Thanh toán và Ghi log hệ thống.*

### 6. Dự án `BeverageShopDemo.Tests` (Kiểm thử xUnit)

Môi trường kiểm thử tự động, hoạt động hoàn toàn độc lập với ứng dụng chính nhằm xác minh tính chính xác của mã nguồn.

* **`BeverageTests.cs`**: Tập trung vào Kiểm thử trường hợp ngoại lệ (Negative Testing). Xác nhận việc hệ thống có ném ra đúng lỗi `ArgumentException` khi phát hiện dữ liệu nhập vào (giá tiền) bị âm hay không.
* **`OrderTests.cs`**: Xác minh tính đúng đắn của logic tính toán tiền bạc trong thư mục `Strategies` thông qua việc mô phỏng các kịch bản thực tế: áp dụng thẻ VIP, giữ nguyên giá gốc, hoặc áp dụng mã giảm giá cuối tuần.

---

**Hướng dẫn chạy thử trên Terminal/Command Line:**

1. Khôi phục thư viện: `dotnet restore`
2. Chạy ứng dụng chính: `dotnet run --project BeverageShopDemo`
3. Chạy kiểm thử tự động: `dotnet test BeverageShopDemo.Tests`
