using congNghePhanMem.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace congNghePhanMem.Models
{
    public class checkDao
    {
        dbContext db = null;

        public checkDao()
        {
            db = new dbContext();
        }

        //lay danh sach
        public IEnumerable<employeeCheck> listAllPaging(string Search,int page, int pageSize)
        {
            var query = from w in db.checks
                        join ew in db.registers on w.idRegister equals ew.Id
                        select new employeeCheck
                        {
                            name = ew.name,
                            userName = ew.userName,
                            dateCheck = w.dateCheck,
                            numCheck = w.numCheck,
                        };
            if (!string.IsNullOrEmpty(Search))
            {
                query = query.Where(x => x.name.Contains(Search) || x.userName.Contains(Search));
            }
            return query.OrderByDescending(x => x.name).ToPagedList(page, pageSize);
        }


        public int Insert(check entity)
        {
            db.checks.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public int check(int idRegister)
        {

            var result = db.checks.Where(x => x.idRegister == idRegister).ToList().Select(x => new { date = x.dateCheck.HasValue ? x.dateCheck.Value.ToString("dd/MM/yyyy") : "" }).ToList();

            if (result.Count() < 1 || !result.Any(x => x.date == DateTime.Now.ToString("dd/MM/yyyy")))
            {
                check c = new check();
                var a = new checkDao();
                c.idRegister = idRegister;
                c.dateCheck = DateTime.Now;
                a.Insert(c);
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}