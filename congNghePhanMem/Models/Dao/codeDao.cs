using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using PagedList;

namespace congNghePhanMem.Models.Dao
{
    public class codeDao
    {
        dbContext db = null;

        public codeDao()
        {
            db = new dbContext();
        }

        //insert
        public int Insert(departcode entity)
        {
            db.departcodes.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        //lay danh sach
        public IEnumerable<departcode> listAllPaging(string Search, int page, int pageSize)
        {
            IQueryable<departcode> model = db.departcodes;
            if (!string.IsNullOrEmpty(Search))
            {
                model = model.Where(x => x.nameEmployee.Contains(Search) || x.phone.Contains(Search));
            }

            return model.OrderByDescending(x => x.Id).ToPagedList(page, pageSize);
        }

        //lay ra id
        public departcode getById(string name)
        {
            return db.departcodes.SingleOrDefault(x => x.nameEmployee == name);
        }

        //
        public departcode viewDetail(int id)
        {
            return db.departcodes.Find(id);
        }

        //update
        public bool update(departcode ennity)
        {
            try
            {
                var user = db.departcodes.Find(ennity.Id);
                user.nameDepartment = ennity.nameDepartment;
                user.nameEmployee = ennity.nameEmployee;
                user.IdInformation = ennity.IdInformation;
                user.phone = ennity.phone;
                user.position = ennity.position;
                user.userName = ennity.userName;
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
                var user = db.departcodes.Find(id);
                db.departcodes.Remove(user);
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