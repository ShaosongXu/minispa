using System;
using System.IO;
using System.Web;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Http.Headers;
using System.Web.Http.Description;
using SPA_MVC_EmployeeInfo.Models;

namespace SPA_MVC_EmployeeInfo.Controllers
{
    public class ManageEmployeeInfoAPIController : ApiController
    {
        private EmpManagementEntities db = new EmpManagementEntities();

        // GET: api/ManageEmployeeInfoAPI
        public IQueryable<EmployeeVM> GetEmployee()
        {
            List<EmployeeVM> employees = new List<EmployeeVM>();

            foreach (var emp in db.Employee)
            {
                EmployeeVM employee = new EmployeeVM();
                employee.EmployeeID = emp.EmployeeID;
                employee.Name = emp.Name;
                employee.ImgUrl = emp.ImgUrl;
                employee.Email = emp.Email;
                employee.HiredYear = emp.HiredYear;
                employee.City = emp.City;
                employee.Country = emp.Country;
                employees.Add(employee);
            }

            return employees.AsQueryable();
        }

        // GET: api/ManageEmployeeInfoAPI/5
        [ResponseType(typeof(EmployeeVM))]
        public IHttpActionResult GetEmployee(int id)
        {
            Employee emp = db.Employee.Find(id);

            if (emp == null)
            {
                return NotFound();
            }

            EmployeeVM employee = new EmployeeVM();
            employee.EmployeeID = emp.EmployeeID;
            employee.Name = emp.Name;
            employee.ImgUrl = emp.ImgUrl;
            employee.Email = emp.Email;
            employee.HiredYear = emp.HiredYear;
            employee.City = emp.City;
            employee.Country = emp.Country;

            return Ok(employee);
        }

        // PUT: api/ManageEmployeeInfoAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee(int id, EmployeeVM emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emp.EmployeeID)
            {
                return BadRequest();
            }

            Employee employee = new Employee();
            employee.EmployeeID = emp.EmployeeID;
            employee.Name = emp.Name;
            employee.ImgUrl = emp.ImgUrl;
            employee.Email = emp.Email;
            employee.HiredYear = emp.HiredYear;
            employee.City = emp.City;
            employee.Country = emp.Country;

            db.Entry(employee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!employeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ManageEmployeeInfoAPI
        [ResponseType(typeof(EmployeeVM))]
        public IHttpActionResult PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employee.Add(employee);

            db.SaveChanges();

            EmployeeVM emp = new EmployeeVM();
            emp.EmployeeID = employee.EmployeeID;
            emp.Name = employee.Name;
            emp.ImgUrl = employee.ImgUrl;
            emp.Email = employee.Email;
            emp.HiredYear = employee.HiredYear;
            emp.City = employee.City;
            emp.Country = employee.Country;

            return CreatedAtRoute("DefaultApi", new { id = emp.EmployeeID }, emp);
        }

        // DELETE: api/ManageEmployeeInfoAPI/5
        [ResponseType(typeof(EmployeeVM))]
        public IHttpActionResult DeleteEmployee(int id)
        {
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.Employee.Remove(employee);
            db.SaveChanges();

            EmployeeVM emp = new EmployeeVM();
            emp.EmployeeID = emp.EmployeeID;
            emp.Name = emp.Name;
            emp.ImgUrl = emp.ImgUrl;
            emp.Email = emp.Email;
            emp.HiredYear = emp.HiredYear;
            emp.City = emp.City;
            emp.Country = emp.Country;

            return Ok(emp);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool employeeExists(int id)
        {
            return db.Employee.Count(e => e.EmployeeID == id) > 0;
        }
    }
}