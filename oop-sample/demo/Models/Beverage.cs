using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_sample.demo.Models
{
    public class Beverage
    {
        // Thuộc tính chỉ cho phép đọc từ bên ngoài, chỉ đổi tên khi khởi tạo
        public string Name { get; private set; }

        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set
            {
                // Bảo vệ dữ liệu: Không cho phép giá tiền âm
                if (value < 0)
                {
                    // Quăng lỗi ngay khi dữ liệu không hợp lệ
                    throw new ArgumentException("Giá tiền không được phép âm!");
                }
                
                _price = value;
            }
        }

        public int SugarLevel { get; set; } = 100; // Mặc định 100% đường

        public Beverage(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        // Hàm ảo (virtual) để lớp con có thể ghi đè (sẽ dùng ở Giờ 2)
        public virtual void Prepare()
        {
            Console.WriteLine($"Đang pha chế {Name} với {SugarLevel}% đường.");
        }
    }
}
