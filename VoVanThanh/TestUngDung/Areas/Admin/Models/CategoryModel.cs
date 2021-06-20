using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TestUngDung.Areas.Admin.Models
{
    
    public class CategoryModel
    {
        private VoVanThanhContext context = null;

        public CategoryModel()
        {
            context = new VoVanThanhContext();
        }

        public List<Category> ListAll()
        {
            var list = context.Database.SqlQuery<Category>("CategoryListAll").ToList();
            return list;
        }

        public int Create(string name, string des)
        {
            object[] parameters =
            {
                new SqlParameter("@Name",name),
                new SqlParameter("@Des",des)
            };
            int res = context.Database.ExecuteSqlCommand("InsertCate @Name, @Des", parameters);
            return res;
        }
    }
}