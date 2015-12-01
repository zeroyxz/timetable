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
    public class TimeTableEntriesController : ApiController
    {
        private TimeTableAppContext db = new TimeTableAppContext();

        // GET: api/TimeTableEntries
        public IQueryable<TimeTableEntry> GetTimeTableEntries()
        {
            return db.TimeTableEntries;
        }

        // GET: api/TimeTableEntries/5
        [ResponseType(typeof(TimeTableEntry))]
        public async Task<IHttpActionResult> GetTimeTableEntry(int id)
        {
            TimeTableEntry timeTableEntry = await db.TimeTableEntries.FindAsync(id);
            if (timeTableEntry == null)
            {
                return NotFound();
            }

            return Ok(timeTableEntry);
        }

        // PUT: api/TimeTableEntries/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTimeTableEntry(int id, TimeTableEntry timeTableEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != timeTableEntry.Id)
            {
                return BadRequest();
            }

            db.Entry(timeTableEntry).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeTableEntryExists(id))
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

        // POST: api/TimeTableEntries
        [ResponseType(typeof(TimeTableEntry))]
        public async Task<IHttpActionResult> PostTimeTableEntry(TimeTableEntry timeTableEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TimeTableEntries.Add(timeTableEntry);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = timeTableEntry.Id }, timeTableEntry);
        }

        // DELETE: api/TimeTableEntries/5
        [ResponseType(typeof(TimeTableEntry))]
        public async Task<IHttpActionResult> DeleteTimeTableEntry(int id)
        {
            TimeTableEntry timeTableEntry = await db.TimeTableEntries.FindAsync(id);
            if (timeTableEntry == null)
            {
                return NotFound();
            }

            db.TimeTableEntries.Remove(timeTableEntry);
            await db.SaveChangesAsync();

            return Ok(timeTableEntry);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TimeTableEntryExists(int id)
        {
            return db.TimeTableEntries.Count(e => e.Id == id) > 0;
        }
    }
}