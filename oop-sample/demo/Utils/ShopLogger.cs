using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_sample.demo.Utils
{
    public class ShopLogger
    {
        // 1. Biến static lưu trữ phiên bản DUY NHẤT của class
        // (Sẽ được khởi tạo ngay khi chương trình gọi đến nó lần đầu tiên)
        private static readonly ShopLogger _instance = new ShopLogger();

        // 2. CHỐT CHẶN QUAN TRỌNG: Constructor phải là private
        // Ngăn chặn việc sử dụng từ khóa 'new ShopLogger()' từ bên ngoài
        private ShopLogger()
        {
            Console.WriteLine("=> [Hệ thống] Cuốn sổ Log đã được mở (Chỉ chạy 1 lần duy nhất).");
        }

        // 3. Cổng giao tiếp toàn cục (Global Access Point) để lấy cuốn sổ này
        public static ShopLogger Instance
        {
            get { return _instance; }
        }

        // --- Các phương thức nghiệp vụ của cuốn sổ ---
        public void Log(string message)
        {
            // Trong thực tế, đoạn này sẽ ghi vào file .txt hoặc Database. Ở đây ta in ra màn hình.
            Console.WriteLine($"[LOG {DateTime.Now:HH:mm:ss}] {message}");
        }
    }
}
