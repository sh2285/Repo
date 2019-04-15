using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CURDUSERMGMT.Models;

namespace CURDUSERMGMT.Controllers
{
    public class t_user_profileController : ApiController
    {
        private TESTEntities db = new TESTEntities();
        
        // GET: api/t_user_profile
        public IQueryable<t_user_profile> Gett_user_profile()
        {
            return db.t_user_profile;
        }

        // GET: api/t_user_profile/5
        [ResponseType(typeof(t_user_profile))]
        public IHttpActionResult Gett_user_profile(string id)
        {
            t_user_profile t_user_profile = db.t_user_profile.Find(id);
            if (t_user_profile == null)
            {
                return NotFound();
            }

            return Ok(t_user_profile);
        }
    //  [Route("api/t_user_profile/UpdateUser")]
        // PUT: api/t_user_profile/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putt_user_profile(string id, t_user_profile t_user_profile)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != t_user_profile.t_user_Id)
            {
                return BadRequest();
            }
            t_user_profile.t_user_UpdateDt = DateTime.Now;
            db.Entry(t_user_profile).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_user_profileExists(id))
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

        // POST: api/t_user_profile
        [ResponseType(typeof(t_user_profile))]
        public IHttpActionResult Postt_user_profile(t_user_profile t_user_profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
          
            t_user_profile.t_user_UpdateDt = DateTime.Now;
            db.t_user_profile.Add(t_user_profile);
          
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (t_user_profileExists(t_user_profile.t_user_Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = t_user_profile.t_user_Id }, t_user_profile);
        }

        // DELETE: api/t_user_profile/5
        [ResponseType(typeof(t_user_profile))]
        public IHttpActionResult Deletet_user_profile(string id)
        {
            t_user_profile t_user_profile = db.t_user_profile.Find(id);
            if (t_user_profile == null)
            {
                return NotFound();
            }

            db.t_user_profile.Remove(t_user_profile);
            db.SaveChanges();

            return Ok(t_user_profile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool t_user_profileExists(string id)
        {
            return db.t_user_profile.Count(e => e.t_user_Id == id) > 0;
        }
    }
}