using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryDateFunction.Model;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryDateFunction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<ProductList.Deliverdates> GetDeliveryDates()
        {
            try
            {
                ProductList productlist = new ProductList();
                var result = Business.ProductDeliveryDate.GetDeliveryDates(1234, productlist);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
