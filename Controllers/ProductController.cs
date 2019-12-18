using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using macheerballApi.Models;

namespace macheerballApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static List<Product> DataProduct = new List<Product>
        {
            new Product { ProductId = "101001" , ProductName = "Noodle" , ProductAmount = 100},
             new Product { ProductId = "101002" , ProductName = "Noodle02" , ProductAmount = 200},
              new Product { ProductId = "101003" , ProductName = "Noodle03" , ProductAmount = 300}
        };
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Product>> ProductGetAllData()
        {
            return DataProduct.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Product> ProductGetByid(string id)
        {
            return DataProduct.FirstOrDefault(it => it.ProductId == id.ToString());
        }

        // POST api/values
        [HttpPost]
        public Product AddProduct([FromBody] Product data)
        {
            var id = Guid.NewGuid().ToString();
            var item = new Product
            {
                ProductId = id.ToString(),
                ProductName = data.ProductName,
                ProductAmount = data.ProductAmount
            };
            DataProduct.Add(item);
            return item;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Product EditUser(string id, [FromBody] Product data)
        {
             var _id = DataProduct.FirstOrDefault(it => it.ProductId == id.ToString());
              var item = new Product
            {
                ProductId = id.ToString(),
                ProductName = data.ProductName,
                ProductAmount = data.ProductAmount
            };
            DataProduct.Remove(_id);
            DataProduct.Add(item);
            return item;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void DeleteUser(string id)
        {
            var delete = DataProduct.FirstOrDefault(it => it.ProductId == id.ToString());
            DataProduct.Remove(delete);
        }
    }
}
