using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_sample.demo.Models
{
    public class MilkTea : Beverage
    {
        public string Topping { get; set; }

        public MilkTea(string name, decimal price, string topping) : base(name, price)
        {
            Topping = topping;
        }

        // Ghi đè cách pha chế riêng của Trà sữa
        public override void Prepare()
        {
            Console.WriteLine($"Đang pha {Name} với {SugarLevel}% đường, thêm topping {Topping}.");
        }
    }
}
