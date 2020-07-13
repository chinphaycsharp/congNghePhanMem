using congNghePhanMem.Areas.Admin.Controllers;
using congNghePhanMem.common;
using congNghePhanMem.Models;
using congNghePhanMem.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace congNghePhanMem.Controllers
{
    public class checkController : baseController
    {
        // GET: check
        public ActionResult Index()
        {
            if (Session[commonConst.user_session] == null)
            {
                return RedirectToAction("Login", "loginEmployee");
            }
            userLogin userLogin = Session[commonConst.user_session] as userLogin;
            check check = new check()
            {
                idRegister = userLogin.userID
            };
            ViewBag.IsCheck = null;
            return View(check);
        }
        
        [HttpPost]
        public ActionResult check(checkModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new checkDao();
                var result = dao.check(model.idRegister);
                if (result == 1)
                {
                    return Json(new{
                        status = true,
                        message = "Điểm danh thành công !!!"
                    });
                }
                else
                {
                    return Json(new
                    {
                        status = false,
                        message = "Bạn đã điểm danh ngày hôm nay rồi !!!"
                    });
                }
            }
            return Json(new
            {
                status = false,
                message = "Dữ liệu lỗi, kiểm tra lại !!!"
            });
        }
    }
}