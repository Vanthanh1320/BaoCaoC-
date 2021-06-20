using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.Dao
{
    public class ProductDao
    {
        VoVanThanhContext db = null;

        public ProductDao()
        {
            db = new VoVanThanhContext();
        }

        public long Insert(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.IDProduct;
        }

        public Product GetByID(int id)
        {
            return db.Products.Find(id);
        }

        public bool Update(Product entity)
        {
            try
            {
                var pro = db.Products.Find(entity.IDProduct);
                pro.Name = entity.Name;
                pro.UnitCost = entity.UnitCost;
                pro.Quantity = entity.Quantity;
                pro.Image = entity.Image;
                pro.Description = entity.Description;
                pro.Status = entity.Status;
                pro.IDCategory = entity.IDCategory;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
       
        public bool Delete(int idproduct)
        {
            try
            {
                var pro = db.Products.Find(idproduct);
                db.Products.Remove(pro);
                db.SaveChanges();
                return true;
            }
           catch(Exception ex)
            {
                return false;
            }
        }

        public List<Product> ListProduct(int idcate)
        {
            return db.Products.Where(x => x.IDCategory == idcate).ToList();
        }

      
    }
}
