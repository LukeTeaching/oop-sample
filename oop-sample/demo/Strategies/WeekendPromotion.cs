using oop_sample.demo.Models;
using oop_sample.demo.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_sample.demo.Strategies
{

    public class WeekendPromotion : IPromotionStrategy
    {
        public decimal CalculateFinalPrice(decimal totalAmount) => totalAmount - 15000; // Giảm trực tiếp 15k
    }

   
}
