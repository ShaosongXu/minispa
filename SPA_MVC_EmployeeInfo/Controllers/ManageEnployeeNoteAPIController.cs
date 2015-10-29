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
    public class ManageEmployeeNoteAPIController : ApiController
    {
        private EmpManagementEntities db = new EmpManagementEntities();

        // GET: api/ManageEmployeeNoteAPI
        public IQueryable<NoteVM> GetNotes(int empId)
        {
            var notes = from n in db.Note where n.EmployeeID == empId select n;

            List<NoteVM> nvs = new List<NoteVM>();

            foreach (var note in notes)
            {
                NoteVM nv = new NoteVM();
                nv.EmployeeID = note.EmployeeID;
                nv.NoteID = note.NoteID;
                nv.Description = note.Description;
                nvs.Add(nv);
            }

            return nvs.AsQueryable();
        }

        // GET: api/ManageEmployeeNoteAPI/5
        [ResponseType(typeof(Note))]
        public IHttpActionResult GetNote(int empId, int id)
        {
            Note note = db.Note.Find(id);
            if (note == null)
            {
                return NotFound();
            }

            NoteVM nv = new NoteVM();

            nv.EmployeeID = note.EmployeeID;
            nv.NoteID = note.NoteID;
            nv.Description = note.Description;

            return Ok(nv);
        }

        // PUT: api/ManageEmployeeNoteAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNote(int id, Note note)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != note.NoteID)
            {
                return BadRequest();
            }

            db.Entry(note).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteExists(id))
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

        // POST: api/ManageEmployeeNoteAPI
        [ResponseType(typeof(Note))]
        public IHttpActionResult PostNote(Note note)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Note.Add(note);
            db.SaveChanges();

            NoteVM nv = new NoteVM();

            nv.EmployeeID = note.EmployeeID;
            nv.NoteID = note.NoteID;
            nv.Description = note.Description;

            return CreatedAtRoute("DefaultApi", new { id = nv.NoteID }, nv);
        }

        // DELETE: api/ManageEmployeeNoteAPI/5
        [ResponseType(typeof(Note))]
        public IHttpActionResult DeleteNote(int id)
        {
            Note note = db.Note.Find(id);
            if (note == null)
            {
                return NotFound();
            }

            db.Note.Remove(note);
            db.SaveChanges();

            return Ok(note);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NoteExists(int id)
        {
            return db.Note.Count(e => e.NoteID == id) > 0;
        }
    }
}