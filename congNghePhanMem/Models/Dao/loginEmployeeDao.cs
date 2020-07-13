using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace congNghePhanMem.Models.Dao
{
    public class loginEmployeeDao
    {
        dbContext db = null;

        public loginEmployeeDao()
        {
            db = new dbContext();
        }

        public register getById(string userName)
        {
            return db.registers.SingleOrDefault(x => x.userName == userName);
        }

        public int Login(string userName, string passWord)
        {
            var result = db.registers.SingleOrDefault(x => x.userName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.passWord == passWord)
                    {
                        return 1;
                    }
                    else
                    {
                        return -3;
                    }
                }
            }
        }
    }
}