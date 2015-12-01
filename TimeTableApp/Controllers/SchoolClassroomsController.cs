using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TimeTableApp.Models;

namespace TimeTableApp.Controllers
{
    public class SchoolClassroomsController : ApiController
    {
        private TimeTableAppContext db = new TimeTableAppContext();

        // GET: api/SchoolClassrooms
        public IQueryable<SchoolClassroom> GetSchoolClassrooms()
        {
            return db.SchoolClassrooms;
        }

        // GET: api/SchoolClassrooms/5
        [ResponseType(typeof(SchoolClassroom))]
        public async Task<IHttpActionResult> GetSchoolClassroom(int id)
        {
            SchoolClassroom schoolClassroom = await db.SchoolClassrooms.FindAsync(id);
            if (schoolClassroom == null)
            {
                return NotFound();
            }

            return Ok(schoolClassroom);
        }

        // PUT: api/SchoolClassrooms/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSchoolClassroom(int id, SchoolClassroom schoolClassroom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != schoolClassroom.Id)
            {
                return BadRequest();
            }

            db.Entry(schoolClassroom).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolClassroomExists(id))
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

        // POST: api/SchoolClassrooms
        [ResponseType(typeof(SchoolClassroom))]
        public async Task<IHttpActionResult> PostSchoolClassroom(SchoolClassroom schoolClassroom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SchoolClassrooms.Add(schoolClassroom);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = schoolClassroom.Id }, schoolClassroom);
        }

        // DELETE: api/SchoolClassrooms/5
        [ResponseType(typeof(SchoolClassroom))]
        public async Task<IHttpActionResult> DeleteSchoolClassroom(int id)
        {
            SchoolClassroom schoolClassroom = await db.SchoolClassrooms.FindAsync(id);
            if (schoolClassroom == null)
            {
                return NotFound();
            }

            db.SchoolClassrooms.Remove(schoolClassroom);
            await db.SaveChangesAsync();

            return Ok(schoolClassroom);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SchoolClassroomExists(int id)
        {
            return db.SchoolClassrooms.Count(e => e.Id == id) > 0;
        }
    }
}