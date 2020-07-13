using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using congNghePhanMem.common;
using PagedList;

namespace congNghePhanMem.Models.Dao
{
    public class employeeProjectDao
    {
        dbContext db = null;

        public employeeProjectDao()
        {
            db = new dbContext();
        }

        //lay danh sach
        public IEnumerable<eployeeProject> listAllPaging(string Search, int page, int pageSize)
        {
            var query = from w in db.works
                        join ew in db.employee_account on w.Id equals ew.idDepartcode
                        join us in db.registers on ew.idRegister equals us.Id
                        select new eployeeProject
                        {
                            Name = us.name,
                            Position = us.position,
                            Department = us.department,
                            ProjectName = w.nameProject,
                            StartDate = w.dateWork,
                            EndDate = w.dateFinsinh
                        };

            return query.OrderByDescending(x => x.Name).ToPagedList(page, pageSize);
        }

        //lay ra id
    }
}