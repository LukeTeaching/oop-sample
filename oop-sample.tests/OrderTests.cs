using oop_sample.demo.Models;
using oop_sample.demo.Strategies;

namespace oop_sample.tests
{
    public class OrderTests
    {
        [Fact]
        public void VipPromotion_ShouldReducePriceBy10Percent()
        {
            // 1. ARRANGE (Chuẩn bị dữ liệu)
            // Khởi tạo 1 ly nước giá 50.000đ và áp dụng thẻ VIP
            var testBeverage = new Coffee("Cà phê Test", 50000, false);
            var vipStrategy = new VipPromotion();
            var order = new Order(vipStrategy);

            order.Items.Add(testBeverage);

            // 2. ACT (Thực thi hành động cần test)
            decimal finalPrice = order.Checkout();

            // 3. ASSERT (Xác nhận kết quả)
            // 50.000 giảm 10% phải bằng 45.000
            Assert.Equal(45000m, finalPrice);
        }

        [Fact]
        public void WeekendPromotion_ShouldReducePriceBy15K()
        {
            // 1. ARRANGE
            var testBeverage1 = new MilkTea("Trà sữa Test 1", 30000, "Trân châu");
            var testBeverage2 = new Coffee("Cà phê Test 2", 25000, true);

            var weekendStrategy = new WeekendPromotion();
            var order = new Order(weekendStrategy);

            order.Items.Add(testBeverage1);
            order.Items.Add(testBeverage2);
            // Tổng gốc: 55.000đ

            // 2. ACT
            decimal finalPrice = order.Checkout();

            // 3. ASSERT
            // 55.000 giảm trực tiếp 15.000 phải bằng 40.000
            Assert.Equal(40000m, finalPrice);
        }

        [Fact]
        public void NoPromotion_ShouldKeepOriginalPrice()
        {
            // 1. ARRANGE
            var testBeverage = new MilkTea("Trà sữa gốc", 40000, "Pudding");
            var normalStrategy = new NoPromotion();
            var order = new Order(normalStrategy);

            order.Items.Add(testBeverage);

            // 2. ACT
            decimal finalPrice = order.Checkout();

            // 3. ASSERT
            // Giá phải giữ nguyên 40.000
            Assert.Equal(40000m, finalPrice);
        }
    }
}
