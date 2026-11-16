using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_sample.demo.Strategies
{
    public interface IPromotionStrategy
    {
        decimal CalculateFinalPrice(decimal totalAmount);
    }
}
