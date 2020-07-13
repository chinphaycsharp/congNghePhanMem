using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using congNghePhanMem.common;
using congNghePhanMem.Models;
using congNghePhanMem.Models.Dao;
using PagedList;

namespace congNghePhanMem.Areas.Admin.Controllers
{
    public class workController : baseController
    {
        // GET: Admin/work
        public ActionResult Index(string Search, int page = 1, int pageSize = 2)
        {
            var dao = new workDao();
            var model = dao.listAllPaging(Search, page, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var db = new userDao();
            ViewBag.dsNv = new MultiSelectList(db.listAll(), "ID", "Name");
            return View();
        }

        [HttpPost]
        //tao user
        public ActionResult Create(createProject acc)
        {
            if (ModelState.IsValid)
            {
                var dao = new workDao();
                int id = dao.Insert(acc);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Work");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user thành công");
                }
            }
            if (acc.dsNv == null)
            {
                var db = new userDao();
                ViewBag.dsNv = new MultiSelectList(db.listAll(), "ID", "Name");
            }
            return View();
        }

        //view update

        public ActionResult Edit(int id)
        {
            var w = new workDao().viewDetail(id);
            var updateProject = new updateProject();
            updateProject.Id = w.Id;
            updateProject.nameProject = w.nameProject;
            updateProject.nameLeader = w.Leader;
            updateProject.dateWork = w.dateWork;
            updateProject.dateEnd = w.dateFinsinh;
            updateProject.numjoin = w.numJoin;

            var db = new userDao();
            var a = db.listAllWithWorkId(id);
            ViewBag.dsNv = new MultiSelectList(db.listAll(), "ID", "Name", db.listAllWithWorkId(id));

            return View(updateProject);
        }
        [HttpPost]
        public ActionResult Edit(updateProject acc)
        {
            if (ModelState.IsValid)
            {
                var dao = new workDao();

                var result = dao.update(acc);
                if (result)
                {
                    return RedirectToAction("Index", "Work");
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
            new userDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}