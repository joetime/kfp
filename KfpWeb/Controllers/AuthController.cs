using KfpWeb.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KfpWeb.Controllers
{
    public class AuthController : ApiController
    {
        private KfpWebContext db = new KfpWebContext();

        public object Post([FromBody]JObject creds)
        {
            string username = creds["username"].ToString().ToLower();
            string password = creds["password"].ToString().ToLower();
           
            User user = db.Users.Find(username);

            if (user == null)
                throw new InvalidOperationException("Username not found");
            else if (password != user.password)
                throw new InvalidOperationException("Incorrect Password");

            /// update last access date
            user.lastActive = DateTime.Now;
            db.SaveChanges();

            return creds;
        }
    }
}
