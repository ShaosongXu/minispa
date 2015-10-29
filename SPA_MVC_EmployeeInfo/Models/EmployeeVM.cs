using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPA_MVC_EmployeeInfo.Models
{
    public class EmployeeVM
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public string Email { get; set; }
        public string HiredYear { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}