using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_sample.demo.Models
{
    public class Coffee : Beverage
    {
        public bool HasIce { get; set; }

        public Coffee(string name, decimal price, bool hasIce) : base(name, price)
        {
            HasIce = hasIce;
        }

        // Ghi đè cách pha chế riêng của Cà phê
        public override void Prepare()
        {
            string iceStatus = HasIce ? "có đá" : "nóng";
            Console.WriteLine($"Đang pha {Name} {iceStatus}, lượng đường {SugarLevel}%.");
        }
    }
}
