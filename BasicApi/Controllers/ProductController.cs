using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using BasicApi.Models;
using System.Net.Http.Headers;

namespace BasicApi.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        private UserContext db = new UserContext();


        [HttpGet]
        [Route("findall")]
        public HttpResponseMessage findAll()
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(db.Users.ToList()));
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }


        [HttpGet]
        [Route("find/{id}")]
        public HttpResponseMessage find(int id)
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(db.Users.Single(p => p.Id == id)));
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }


        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage delete(int id)
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                db.Users.Remove(db.Users.Single(p => p.Id == id));
                db.SaveChanges();
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }


        [HttpPost]
        public HttpResponseMessage create(User user)
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                db.Users.Add(user);
                db.SaveChanges();
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }


        [HttpPut]
        public HttpResponseMessage update(User user)
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                var newUser=db.Users.Single(p => p.Id == user.Id);
                newUser.FirstName = user.FirstName;
                newUser.LastName = user.LastName;
                newUser.Email = user.Email;
                newUser.Password = user.Password;
                newUser.CreatedDate = user.CreatedDate;
                newUser.BirthDay = user.BirthDay;
                db.SaveChanges();
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

    }
}
