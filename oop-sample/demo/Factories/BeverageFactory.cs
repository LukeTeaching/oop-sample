using oop_sample.demo.Models;
using oop_sample.demo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_sample.demo.Factories
{
    public class BeverageFactory
    {
        // Đầu vào chỉ là một chuỗi string (VD: người dùng bấm nút trên màn hình)
        public static Beverage CreateBeverage(string orderType)
        {
            ShopLogger.Instance.Log($"Đang xử lý yêu cầu tạo món: {orderType}");
            switch (orderType.ToLower())
            {
                case "black_coffee":
                    return new Coffee("Cà phê đen", 20000, true) { SugarLevel = 50 };

                case "boba_milktea":
                    return new MilkTea("Trà sữa truyền thống", 35000, "Trân châu đen");

                case "hot_latte":
                    return new Coffee("Latte", 45000, false);

                default:
                    throw new ArgumentException("Món này hiện không có trong menu!");
            }
        }
    }

    // Demo trong Main():
    // Beverage myDrink = BeverageFactory.CreateBeverage("boba_milktea");
    // myDrink.Prepare();

}
