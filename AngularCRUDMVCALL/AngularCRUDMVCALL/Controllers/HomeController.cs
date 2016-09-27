using AngularCRUDMVCALL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularCRUDMVCALL.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private MVCFirstDBEntities _db = new MVCFirstDBEntities();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllUsers()
        {
            var users = _db.tbl_User.ToList();

            return Json(users, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddUser(tbl_User _tbl)
        {
            _db.tbl_User.Add(_tbl);
            _db.SaveChanges();
            List<tbl_User> tlu = _db.tbl_User.ToList();
            return Json(tlu, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByID(int id)
        {
            tbl_User tbl = _db.tbl_User.Single(u => u.UserId == id);

            return Json(tbl, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateUser(tbl_User _tbl)
        {
            _db.Entry(_tbl).State = EntityState.Modified;

            _db.SaveChanges();
            List<tbl_User> ttt = _db.tbl_User.ToList();

            return Json(ttt, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteUser(int id)
        {
            tbl_User _oemployee = _db.tbl_User.Find(id);
            _db.Entry(_oemployee).State = EntityState.Deleted;
            _db.SaveChanges();
            List<tbl_User> lstemp = _db.tbl_User.ToList();
            return Json(lstemp, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost] alternative
        //public JsonResult UpdateEmployee(Employee _emp)
        //{
        //    _db.Entry(_emp).State = EntityState.Modified;
        //    _db.SaveChanges();

        //    List<Employee> lstemp = _db.Employees.ToList();
        //    return Json(lstemp, JsonRequestBehavior.AllowGet);
        //}
    }
}