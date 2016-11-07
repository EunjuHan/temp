using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment7.Controllers
{
    [Authorize]
    public class SmartphonesController : ApiController
    {
        private Manager m = new Manager();

        // GET: api/Smartphones
        /// <summary>
        /// Get all smartphones, order by model.
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            var c = m.SmartphoneGetAll();

            var re = new SmartphonesLinked
                (Mapper.Map<IEnumerable<SmartphoneWithLink>>(c));

            return Ok(re);
        }
        
        // GET: api/Smartphones/5
        /// <summary>
        /// Get one smartphone, identified by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>        
        [Authorize(Roles = "Employee")]   
        [Authorize(Roles = "Sales, ProductManagement")]
        public IHttpActionResult Get(int? id)
        {
            var o = m.SmartphoneGetById(id.GetValueOrDefault());

            if(o == null)
            {
                return NotFound();
            }
            else
            {
                var re = new SmartphoneLinked
                    (Mapper.Map<SmartphoneWithLink>(o));

                return Ok(re);
            }
        }

        // POST: api/Smartphones
        /// <summary>
        /// Add a new smartphone
        /// </summary>
        /// <param name="newItem">SmartphoneAdd object</param>
        /// <returns></returns>
        [Authorize(Roles = "Employee")]
        [AuthorizeClaim(ClaimType = "Activity", ClaimValue = "SmartphoneEditor")]
        public IHttpActionResult Post([FromBody]SmartphoneAdd newItem)
        {
            if(Request.GetRouteData().Values["id"] != null) { return BadRequest("Invalid request URI"); }

            if(newItem == null) { return BadRequest("Must send an entity body with the request"); }

            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            var addedItem = m.SmartphoneAdd(newItem);

            if (addedItem == null) { return BadRequest("Cannot add the object"); }

            var uri = Url.Link("DefaultApi", new { id = addedItem.Id });

            return Created(uri, addedItem);
        }

        //// PUT: api/Smartphones/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Smartphones/5
        //public void Delete(int id)
        //{
        //}
    }
}
