using congNghePhanMem.common;
using congNghePhanMem.Models;
using congNghePhanMem.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace congNghePhanMem.Areas.Admin.Controllers
{
    public class userController : baseController
    {
        // GET: Admin/user
        public ActionResult Index(string Search, int page = 1, int pageSize = 2)// thử chia làm 3 trang mà n k thấy gì 
        {
            var dao = new userDao();
            var model = dao.listAllPaging(Search,page,pageSize);
            ViewBag.Search = Search;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //tao user
        public ActionResult Create(register acc)
        {
            if(ModelState.IsValid)
            {
                var dao = new userDao();
                var encrypPass = encryptor.MD5Hash(acc.passWord);
                acc.passWord = encrypPass;
                int id = dao.Insert(acc);
                if (id > 0)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user thành công");
                }
            }
            return View();
        }

        //view update
        public ActionResult Edit(int id)
        {
            var user = new userDao().viewDetail(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(register acc)
        {
            if (ModelState.IsValid)
            {
                var dao = new userDao();
                if(!string.IsNullOrEmpty(acc.passWord))
                {
                    var encrypPass = encryptor.MD5Hash(acc.passWord);
                    acc.passWord = encrypPass;
                }
                
                var result = dao.update(acc);
                if (result)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhập không thành công");
                }
            }
            return View("Index");
        }

        //Xoa ban ghi
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new userDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}