using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.Dao
{
    public class UserDao
    {
        VoVanThanhContext db = null;

        public UserDao()
        {
            db = new VoVanThanhContext();
        }

        public long Insert(UserAccount entity)
        {
            db.UserAccounts.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public UserAccount GetById(string userName)
        {
            return db.UserAccounts.SingleOrDefault(x => x.UserName == userName);
        }
        public int Login(string username, string password)
        {
            var result = db.UserAccounts.SingleOrDefault(x => x.UserName.Contains(username) && x.Password.Contains(password));
            if(result == null)
            {
                return 0;
            }    
            else
            {
                return 1;
            }    
        }

        public IEnumerable<UserAccount> ListAllPaging(int page, int pageSize)
        {
            return db.UserAccounts.OrderByDescending(x => x.ID ).ToPagedList(page,pageSize);
        }

        public bool Delete(int id)
        {
            try
            {
                var ktra = db.UserAccounts.Where(x => x.ID == id && x.Status == "Blocked").FirstOrDefault();
                if (ktra == null)
                {
                    return false;
                }
                else
                {
                    db.UserAccounts.Remove(ktra);
                    db.SaveChanges();
                    return true;
                }    
                     
            }
            catch(Exception)
            {
                return false;
            }
        }

        public List<UserAccount> ListAll()
        {
            return db.UserAccounts.ToList();
        }

        public List<UserAccount>ListSearch(string search)
        {
            if(!string.IsNullOrEmpty(search))
                return db.UserAccounts.Where(x => x.UserName.Contains(search) && x.Status.Contains(search)).ToList();
            return db.UserAccounts.ToList();
        }
    }
}
