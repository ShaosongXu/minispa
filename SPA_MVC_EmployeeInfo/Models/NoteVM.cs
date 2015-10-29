using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPA_MVC_EmployeeInfo.Models
{
    public class NoteVM
    {
        public int EmployeeID { get; set; }
        public int NoteID { get; set; }
        public string Description { get; set; }
    }
}