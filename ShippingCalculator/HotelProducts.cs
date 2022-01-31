using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace ShippingCalculator
{
    public class HotelProducts
    {
        public string Hotel { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public float WeightPerBox { get; set; }
        public float Length { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float WeightPerItem { get; set; }
        public int QuantityInBox { get; set; }
        public int BoxesPerSkid { get; set; }
        public int BoxesPerRow { get; set; }

    }
}
