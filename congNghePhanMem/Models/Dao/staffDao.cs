using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace congNghePhanMem.Models.Dao
{
    public class staffDao
    {
        dbContext db = null;

        public staffDao()
        {
            db = new dbContext();
        }

        public register viewDetail(int id)
        {
            return db.registers.Find(id);
        }

        public bool update(register ennity)
        {
            try
            {
                var user = db.registers.Find(ennity.Id);
                user.name = ennity.name;
                user.userName = ennity.userName;
                user.email = ennity.email;
                if (!string.IsNullOrEmpty(ennity.passWord))
                {
                    user.passWord = ennity.passWord;
                }
                user.phone = ennity.phone;
                user.address = ennity.address;
                user.gender = ennity.gender;
                user.birthday = ennity.birthday;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}