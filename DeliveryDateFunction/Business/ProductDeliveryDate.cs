
using DeliveryDateFunction.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace DeliveryDateFunction.Business
{
    public class ProductDeliveryDate
    {
        public static ProductList GetProduct()
        {
            var myJsonString = File.ReadAllText("ProductList.Json");
            dynamic jToken = JToken.Parse(myJsonString).ToString();
            return jToken;
        }
        public static ProductList.Deliverdates GetDeliveryDates(int postalcode, ProductList productlist)
        {
            try
            {
                ProductList.Deliverdates _deliverydates = new ProductList.Deliverdates();
                productlist = GetProduct();

                DateTime startdate = DateTime.Now;
                TimeSpan fortnight = TimeSpan.FromDays(14); 
                DateTime enddate = startdate.Add(fortnight);

                var defaultdeliverydates = new List<DateTime>();

                for (var dt = startdate; dt <= enddate; dt = dt.AddDays(1))
                {
                    defaultdeliverydates.Add(dt);
                }

                foreach (var date in defaultdeliverydates)
                {
                    //logic to get available delivery date
                    var availabledate = defaultdeliverydates.Where(d => d.DayOfWeek != DayOfWeek.Sunday || d.DayOfWeek == DayOfWeek.Saturday);
                    //add to deliverylist
                }

                //deliverdate validity
                // if(ProductList.productype=="temporary")
                if (productlist.daysInAdvance <= 5 && productlist.productType == "temporary")
                {
                    _deliverydates.postalcode = postalcode;
                    _deliverydates.isGreenDelivery = true;
                    //_productlist.deliveryDays = defaultdeliverydates.DefaultIfEmpty
                }
                //if(productlist.daysInAdvance  >=12 && productlist.productType=="external" )
                //if(productlist.daysInAdvance >=10 && productlist.productType=="normal" )



                return _deliverydates;

            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }

        }

    }
}
