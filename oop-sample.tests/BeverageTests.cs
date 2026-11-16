using oop_sample.demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_sample.tests
{
    public class BeverageTests
    {
        [Fact]
        public void SetPrice_NegativeValue_ShouldThrowArgumentException()
        {
            // 1. ARRANGE
            // Khởi tạo một ly nước với giá hợp lệ ban đầu
            var coffee = new Coffee("Cà phê Test", 20000, true);

            // 2 & 3. ACT & ASSERT (Gộp chung trong trường hợp test lỗi)
            // Assert.Throws sẽ "bắt" lỗi sinh ra từ đoạn code bên trong nó
            Action act = () =>
            {
                coffee.Price = -5000; // Cố tình gán giá âm
            };

            var exception = Assert.Throws<ArgumentException>(act);

            // (Tuỳ chọn) Kiểm tra xem câu thông báo lỗi có chính xác như lập trình không
            Assert.Equal("Giá tiền không được phép âm!", exception.Message);
        }

        [Fact]
        public void Constructor_NegativePrice_ShouldThrowArgumentException()
        {
            // 1, 2 & 3: Gom gọn lại thành 1 dòng (Cách viết thực tế lập trình viên hay dùng)
            // Test ngay lúc khởi tạo (new) đối tượng
            Assert.Throws<ArgumentException>(() => new Coffee("Cà phê Lỗi", -10000, false));
        }
    }
}
