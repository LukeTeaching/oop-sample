using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_sample.demo.Strategies
{
   
    // 2. Các chiến lược cụ thể
    public class NoPromotion : IPromotionStrategy
    {
        public decimal CalculateFinalPrice(decimal totalAmount) => totalAmount;
    }
}
