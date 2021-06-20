using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestUngDung.Areas.Admin.Models
{
    public class ProductModel
    {
        private VoVanThanhContext context = null;

        public ProductModel()
        {
            context = new VoVanThanhContext();
        }

        public List<Product> ListAll()
        {
            var list = context.Database.SqlQuery<Product>("ProductListAll").ToList();
            return list;
        }

        public List<Product> ListProduct()
        {
            var list = context.Products.ToList();
            return list;
        }
    }
}