using oop_sample.demo.Factories;
using oop_sample.demo.Models;
using oop_sample.demo.Strategies;
using oop_sample.demo.Utils;
using System.Text;

namespace oop_sample
{


    
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //demo Singleton: Ghi log hệ thống
            ShopLogger.Instance.Log("Hệ thống phần mềm quán bắt đầu hoạt động.");
            // 1. Tạo đơn hàng với Chiến lược khuyến mãi VIP
            Order myOrder = new Order(new VipPromotion());

            // 2. Dùng Factory để tạo đồ uống, thêm vào đơn hàng
            myOrder.Items.Add(BeverageFactory.CreateBeverage("black_coffee"));
            myOrder.Items.Add(BeverageFactory.CreateBeverage("boba_milktea"));
            
            ShopLogger.Instance.Log("Khách vừa gọi xong đồ uống.");
            // 3. Tiến hành pha chế (Demo Đa hình)
            Console.WriteLine("--- QUÁ TRÌNH PHA CHẾ ---");
            foreach (var item in myOrder.Items)
            {
                item.Prepare();
            }

            // 4. Thanh toán (Demo Strategy)
            Console.WriteLine("\n--- THANH TOÁN ---");
            Console.WriteLine($"Tổng tiền khách VIP cần trả: {myOrder.Checkout()} VNĐ");
        }
    }
}
