using oop_sample.demo.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_sample.demo.Models
{
    // 3. Lắp ráp chiến lược vào Đơn hàng (Context)
    public class Order
    {
        public List<Beverage> Items { get; set; } = new List<Beverage>();
        private IPromotionStrategy _promotionStrategy;

        // Cắm (Inject) chiến lược vào đơn hàng lúc khởi tạo
        public Order(IPromotionStrategy promotionStrategy)
        {
            _promotionStrategy = promotionStrategy;
        }

        public decimal Checkout()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total += item.Price;
            }

            // Gọi interface để tính tiền, Order không cần biết bên trong đang giảm giá kiểu gì
            return _promotionStrategy.CalculateFinalPrice(total);
        }
    }

    // ----------------------------------------------------
    // DEMO TRONG MAIN()
    // ----------------------------------------------------
    /*
    Order vipOrder = new Order(new VipPromotion());
    vipOrder.Items.Add(BeverageFactory.CreateBeverage("boba_milktea"));
    Console.WriteLine($"Khách VIP cần trả: {vipOrder.Checkout()}");

    Order weekendOrder = new Order(new WeekendPromotion());
    weekendOrder.Items.Add(BeverageFactory.CreateBeverage("boba_milktea"));
    Console.WriteLine($"Khách cuối tuần cần trả: {weekendOrder.Checkout()}");
    */
}
