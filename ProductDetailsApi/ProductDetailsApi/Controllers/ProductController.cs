using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductDetailsApi.Models;

namespace ProductDetailsApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IActionResult GetProducts()
        {
            var _dbContext = new MithilaProductsContext();
            return new JsonResult(_dbContext.Products.ToList());
        }

        public IActionResult GetProductById(string id)
        {
            var _dbContext = new MithilaProductsContext();
            return new JsonResult(_dbContext.Products.ToList().Where(m => m.ProductId.Equals(id)));
        }

        public IActionResult GetProductsInGroup(int index, int numberOfRecord)
        {
            var _dbContext = new MithilaProductsContext();
            var records = _dbContext.Products.Skip(index * numberOfRecord).Take(numberOfRecord);
            return new JsonResult(records);
        }
    }
}