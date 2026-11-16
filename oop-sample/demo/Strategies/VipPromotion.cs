using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_sample.demo.Strategies
{

    public class VipPromotion : IPromotionStrategy
    {
        public decimal CalculateFinalPrice(decimal totalAmount) => totalAmount * 0.9m; // Giảm 10%
    }

}
