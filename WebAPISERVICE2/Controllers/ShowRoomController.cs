using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPISERVICE2.Repository;
using System.Web.Http.Results;
using DataAccessLayer;

namespace WebAPISERVICE2.Controllers
{
    public class ShowRoomController : ApiController
    {
        [HttpGet]
        public JsonResult<List<Models.Product>> GetAllProduct()
        {
            EntityMapper<DataAccessLayer.Product, Models.Product> mapObject = new EntityMapper<DataAccessLayer.Product, Models.Product>();
            List<DataAccessLayer.Product> productList = DAL.GetAllProducts();
            List<Models.Product> products = new List<Models.Product>();
            foreach(var item in productList)
            {
                products.Add(mapObject.Translate(item));
            }
            return Json<List<Models.Product>>(products);
        }

        [HttpPost]
        public bool InsertProduct(Models.Product product)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapper<Models.Product, DataAccessLayer.Product> mapObject = new EntityMapper<Models.Product,  DataAccessLayer.Product>();
                DataAccessLayer.Product productObject = new DataAccessLayer.Product();
                productObject = mapObject.Translate(product);
                status = DAL.InsertProduct(productObject);
            }
            return status;
        }

        [HttpPut]
        public bool UpdateProduct(Models.Product product)
        {
            EntityMapper<Models.Product, DataAccessLayer.Product> mapper = new EntityMapper<Models.Product, DataAccessLayer.Product>();
            DataAccessLayer.Product productObj = new DataAccessLayer.Product();
            productObj = mapper.Translate(product);
            var status = DAL.UpdateProduct(productObj);
            return status;
        }

        [HttpDelete]
        public bool DeleteProduct(int id)
        {
            var status = DAL.DeleteProduct(id);
            return status;
        }
    }
}
