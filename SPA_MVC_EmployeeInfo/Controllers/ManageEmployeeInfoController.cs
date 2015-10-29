using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SPA_MVC_EmployeeInfo.Controllers
{
    public class ManageEmployeeInfoController : Controller
    {
        // GET: ManageEmployeeInfo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddNewEmployee()
        {
            return PartialView("AddEmployee");
        }

        public ActionResult ShowEmployees()
        {
            return PartialView("ShowAllEmployee");
        }

        public ActionResult EditEmployee()
        {
            return PartialView("EditEmployee");
        }

        public ActionResult DeleteEmployee()
        {
            return PartialView("DeleteEmployee");
        }
    }
}