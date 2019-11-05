using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class DAL
    {
        static APIDBEntities1 DbContext;

        static DAL()
        {
            DbContext = new APIDBEntities1();
        }

        public static List<Product> GetAllProducts()
        {
            return DbContext.Products.ToList();
        }

        public static Product GetProduct(int productID)
        {
            return DbContext.Products.Where(x => x.ProductId == productID).FirstOrDefault();
        }

        public static bool InsertProduct(Product product)
        {
            bool status;
            try
            {
                DbContext.Products.Add(product);
                DbContext.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public static bool UpdateProduct(Product product)
        {
            bool status = false;
            try
            {
                Product NewProduct = DbContext.Products.Where(x => x.ProductId == product.ProductId).FirstOrDefault();
                if (NewProduct != null)
                {
                    NewProduct.ProductName = product.ProductName;
                    NewProduct.Quantity = product.Quantity;
                    NewProduct.Price = product.Price;
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public static bool DeleteProduct(int id)
        {
            bool status = false;

            try
            {
                Product product = DbContext.Products.Where(x => x.ProductId == id).FirstOrDefault();
                if(product != null)
                {
                    DbContext.Products.Remove(product);
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

    }
}
