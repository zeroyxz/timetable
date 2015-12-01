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
    public class ClassroomsController : ApiController
    {
        private TimeTableAppContext db = new TimeTableAppContext();

        // GET: api/Classrooms
        public IQueryable<Classroom> GetClassrooms()
        {
            return db.Classrooms;
        }

        // GET: api/Classrooms/5
        [ResponseType(typeof(Classroom))]
        public async Task<IHttpActionResult> GetClassroom(int id)
        {
            Classroom classroom = await db.Classrooms.FindAsync(id);
            if (classroom == null)
            {
                return NotFound();
            }

            return Ok(classroom);
        }

        // PUT: api/Classrooms/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClassroom(int id, Classroom classroom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != classroom.Id)
            {
                return BadRequest();
            }

            db.Entry(classroom).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassroomExists(id))
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

        // POST: api/Classrooms
        [ResponseType(typeof(Classroom))]
        public async Task<IHttpActionResult> PostClassroom(Classroom classroom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Classrooms.Add(classroom);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = classroom.Id }, classroom);
        }

        // DELETE: api/Classrooms/5
        [ResponseType(typeof(Classroom))]
        public async Task<IHttpActionResult> DeleteClassroom(int id)
        {
            Classroom classroom = await db.Classrooms.FindAsync(id);
            if (classroom == null)
            {
                return NotFound();
            }

            db.Classrooms.Remove(classroom);
            await db.SaveChangesAsync();

            return Ok(classroom);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClassroomExists(int id)
        {
            return db.Classrooms.Count(e => e.Id == id) > 0;
        }
    }
}