using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using congNghePhanMem.common;
using PagedList;

namespace congNghePhanMem.Models.Dao
{
    public class workDao
    {
        dbContext db = null;

        public workDao()
        {
            db = new dbContext();
        }

        //insert
        public int Insert(createProject entity)
        {
            work w = new work();
            w.nameProject = entity.nameProject;
            w.Leader = entity.nameLeader;
            w.dateWork = entity.dateWork;
            w.dateFinsinh = entity.dateEnd;
            w.numJoin = entity.dsNv.Count().ToString();
            db.works.Add(w);
            db.SaveChanges();
            foreach (var item in entity.dsNv)
            {
                employee_account ew = new employee_account();
                ew.idDepartcode = w.Id;
                ew.idRegister = item;
                db.employee_account.Add(ew);
            }
            db.SaveChanges();
            return w.Id;
        }

        //lay danh sach
        public IEnumerable<work> listAllPaging(string Search ,int page, int pageSize)
        {
            IQueryable<work> model = db.works;
            if (!string.IsNullOrEmpty(Search))
            {
                model = model.Where(x => x.Leader.Contains(Search) || x.nameProject.Contains(Search));
            }

            return model.OrderByDescending(x => x.Id).ToPagedList(page, pageSize);
        }

        //lay ra id
        public work getById(int  id)
        {
            return db.works.SingleOrDefault(x => x.Id == id);
        }

        //
        public work viewDetail(int id)
        {
            return db.works.Find(id);
        }

        //update
        public bool update(updateProject entity)
        {
            try
            {
                var user = db.works.Find(entity.Id);
                //user.Id = ennity.Id;
                //user.dateWork = ennity.dateWork;
                //user.dateFinsinh = ennity.dateFinsinh;
                //user.Leader = ennity.Leader;
                //user.numJoin = ennity.numJoin;
                //user.nameProject = ennity.nameProject;
                //db.SaveChanges();
                //work w = new work();
                user.nameProject = entity.nameProject;
                user.Leader = entity.nameLeader;
                user.dateWork = entity.dateWork;
                user.dateFinsinh = entity.dateEnd;
                user.numJoin = entity.dsNv.Count().ToString();
                //db.works.Add(user);
                db.SaveChanges();
                foreach (var item in entity.dsNv)
                {
                    employee_account ew = new employee_account();
                    ew.idDepartcode = user.Id;
                    ew.idRegister = item;
                    db.employee_account.Add(ew);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //delete
        public bool Delete(int id)
        {
            try
            {
                var user = db.works.Find(id);
                db.works.Remove(user);
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