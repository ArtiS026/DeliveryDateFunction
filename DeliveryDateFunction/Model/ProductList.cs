using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryDateFunction.Model
{
    public class ProductList
    {
        public int productId { get; set; }
        public string productname { get; set; }
        public string productType { get; set; } // (normal, external or temporary)
        public List<Deliverdates> deliveryDays { get; set; }  //(a list of weekdays when the product can be delivered)
        public int daysInAdvance { get; set; }  // (how many days before delivery the products need to be ordered)

        public class Deliverdates
        {
            public int postalcode { get; set; }
            public bool isGreenDelivery { get; set; }
            public DateTime deliveryDate { get; set; } 
        }

        public class Data
        {
            public List<Deliverdates> Deliverydates { get; set; }
        }
    }
}
