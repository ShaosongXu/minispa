using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SPA_MVC_EmployeeInfo.Controllers
{
    public class ManageEmployeeNoteController : Controller
    {
        // GET: ManageEmployeeNote
        public ActionResult Index(int id)
        {
            ViewData["EmpId"] = id;
            return View(ViewData);
        }

        public ActionResult AddNewNote()
        {
            return PartialView("AddNote");
        }

        public ActionResult ShowNotes()
        {
            return PartialView("ShowAllNote");
        }

        public ActionResult EditNote()
        {
            return PartialView("EditNote");
        }

        public ActionResult DeleteNote()
        {
            return PartialView("DeleteNote");
        }
    }
}