using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace congNghePhanMem.Areas.Admin.Controllers
{
    public class listCheckController : baseController
    {
        // GET: Admin/check
        public ActionResult Index(string search,int page = 1, int pageSize = 2)
        {
            var dao = new congNghePhanMem.Models.checkDao();
            var model = dao.listAllPaging(search,page, pageSize);
            return View(model); 
        }

        //public ActionResult Index(string Search , int page = 1, int pageSize = 2)
        //{
        //    var dao = new congNghePhanMem.Models.checkDao();
        //    var model = dao.listAllPaging(Search, page, pageSize);
        //    ViewBag.Search = Search;
        //    return View(model);
        //}
    }
}