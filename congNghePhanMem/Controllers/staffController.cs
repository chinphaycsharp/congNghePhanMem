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
    public class staffController : baseEmployeeController
    {
        public ActionResult Index()
        {
            if (Session[commonConst.user_session] != null)
            {
                userLogin a = Session[commonConst.user_session] as userLogin;
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var user = new staffDao().viewDetail(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(updateStaff acc)
        {
            if (ModelState.IsValid)
            {
                var dao = new staffDao();
                //Hàm lấy đối tượng register với id truyền vào
                var user = dao.viewDetail(acc.Id);
                user.name = acc.Name;
                user.passWord = acc.Password;
                user.phone = acc.Phone;
                user.address = acc.Address;
                user.gender = acc.Gender;
                user.birthday = acc.Birthday;
                var result = dao.update(user);
                var userSession = new userLogin();
                //add session
                userSession.userName = user.userName;
                userSession.userID = user.Id;
                userSession.name = user.name;
                userSession.email = user.email;
                userSession.phone = user.phone;
                userSession.address = user.address;
                userSession.department = user.department;
                userSession.positon = user.position;
                userSession.salary = user.salary;
                userSession.numProject = user.numProject;
                userSession.birthday = user.birthday;
                userSession.gender = user.gender;
                Session.Add(commonConst.user_session, userSession);
                if (result)
                {
                    return RedirectToAction("Index", "staff");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhập không thành công");
                }
            }
            return View("Index");
        }
    }
}