using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using congNghePhanMem.common;
using PagedList; 

namespace congNghePhanMem.Models.Dao
{
    public class userDao
    {
        dbContext db = null;

        public userDao()
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
        public IEnumerable<register> listAllPaging(string Search ,int page ,int pageSize)
        {
            IQueryable<register> model = db.registers;
            if(!string.IsNullOrEmpty(Search))
            {
                model = model.Where(x => x.userName.Contains(Search) || x.name.Contains(Search));
            }
            
            return model.OrderByDescending(x => x.Id).ToPagedList(page, pageSize);
        }

        //Lay ds nv(Id, ten)
        public IEnumerable<register> listAll()
        {
            IQueryable<register> model = db.registers;

            return model;
        }


        public List<int> listAllWithWorkId(int id)
        {
            List<int> model = (from rg in db.registers
                               join ew in db.employee_account on rg.Id equals ew.idRegister
                               where ew.idDepartcode ==id
                               select new
                               {
                                   rg
                               }).Select(x=> x.rg.Id).ToList();

            return model;
        }

        //lay ra id
        public register getById(string userName)
        {
            return db.registers.SingleOrDefault(x => x.userName == userName);
        }

        //
        public register viewDetail(int id)
        {
            return db.registers.Find(id);
        }

        //login he thong
        public int Login(string userName,string passWord)
        {
            var result = db.registers.SingleOrDefault(x => x.userName == userName);
            if(result == null)
            {
                return 0;
            }
            else
            {
                if(result.status == false)
                {
                    return -1;
                }
                else
                {
                    if(result.passWord == passWord)
                    {
                        if(result.permision > 0)    
                        {
                            return 1;
                        }
                        else
                        {
                            return -2;
                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
            }
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
                if(!string.IsNullOrEmpty(ennity.passWord))
                {
                    user.passWord = ennity.passWord;
                }
                user.phone = ennity.phone;
                user.address = ennity.address;
                user.permision = ennity.permision;
                user.status = ennity.status;
                user.position = ennity.position;
                user.department = ennity.department;
                user.numProject = ennity.numProject;
                user.gender = ennity.gender;
                user.birthday = ennity.birthday;
                db.SaveChanges();
                return true;
            }
            catch(Exception)
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
            catch(Exception)
            {
                return false;   
            }
        }
    }
}