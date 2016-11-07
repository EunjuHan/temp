using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;

namespace Assignment7.Controllers
{
    public class RootController : ApiController
    {

        public IHttpActionResult Get()
        {
            // Create a collection of Link objects

            List<Link> links = new List<Link>();
            links.Add(new Link() { Rel = "collection", Href = "/api/smartphones", Method = "GET, POST" });
            links.Add(new Link() { Rel = "Item", Href = "/api/smartphones/{id}", Method = "GET" });

            // Create and configure a dictionary to hold the collection
            // We need to return a simple object, so a Dictionary<TKey, TValue> is ideal

            Dictionary<string, List<Link>> linkList = new Dictionary<string, List<Link>>();
            linkList.Add("Links", links);

            return Ok(linkList);
        }
    }
}