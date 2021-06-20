using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.Dao
{
    public class CategoryDao
    {
        VoVanThanhContext db = null;

        public CategoryDao()
        {
            db = new VoVanThanhContext();
        }

        public List<Category> ListAll()
        {
            return db.Categories.ToList();
        }

        public Category GetByID(int id)
        {
            return db.Categories.Find(id);
        }

        public bool Update(Category entity)
        {
            try
            {
                var cat = db.Categories.Find(entity.IDCategory);
                cat.Name = entity.Name;
                cat.Description = entity.Description;
               
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
