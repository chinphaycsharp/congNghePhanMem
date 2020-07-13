using congNghePhanMem.Models;
using congNghePhanMem.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace congNghePhanMem.Areas.Admin.Controllers
{
    public class codeController : baseController
    {
        // GET: Admin/code
        public ActionResult Index(string Search, int page = 1, int pageSize = 2)
        {
            var dao = new codeDao();
            var model = dao.listAllPaging(Search, page, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //tao user
        public ActionResult Create(departcode acc)
        {
            if (ModelState.IsValid)
            {
                var dao = new codeDao();
                int id = dao.Insert(acc);
                if (id > 0)
                {
                    return RedirectToAction("Index", "code");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm phòng ban không thành công");
                }
            }
            return View();
        }

        //view update
        public ActionResult Edit(int id)
        {
            var code = new codeDao().viewDetail(id);
            return View(code);
        }

        [HttpPost]
        //tao user
        public ActionResult Edit(departcode acc)
        {
            if (ModelState.IsValid)
            {
                var dao = new codeDao();
                var result = dao.update(acc);
                if (result)
                {
                    return RedirectToAction("Index", "code");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhập thành công");
                }
            }
            return View("Index");
        }

        //Xoa ban ghi
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new codeDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}