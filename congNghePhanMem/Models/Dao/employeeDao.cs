using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace congNghePhanMem.Models.Dao
{
    public class employeeDao
    {
        dbContext db = null;

        public employeeDao()
        {
            db = new dbContext();
        }

        //insert
        public int Insert(register entity)
        {
            db.registers.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        //lay danh sach
        public IEnumerable<register> listAllPaging(string Search, int page, int pageSize)
        {
            IQueryable<register> model = db.registers;
            if (!string.IsNullOrEmpty(Search))
            {
                model = model.Where(x => x.name.Contains(Search) || x.address.Contains(Search));
            }

            return model.OrderByDescending(x => x.Id).ToPagedList(page, pageSize);
        }

        //lay ra id
        public register getById(string name)
        {
            return db.registers.SingleOrDefault(x => x.name == name);
        }

        //
        public register viewDetail(int id)
        {
            return db.registers.Find(id);
        }

        //update
        public bool update(register ennity)
        {
            try
            {
                var user = db.registers.Find(ennity.Id);
                user.name = ennity.name;
                user.userName = ennity.userName;
                user.email = ennity.email;
                user.passWord = ennity.passWord;
                user.phone = ennity.phone;
                user.address = ennity.address;
                user.position = ennity.position;
                user.department = ennity.department;
                user.salary = ennity.salary;
                user.numProject = ennity.numProject;
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

        //delete
        public bool Delete(int id)
        {
            try
            {
                var user = db.registers.Find(id);
                db.registers.Remove(user);
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