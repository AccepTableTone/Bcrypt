using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BCrypt.Controllers
{
    [EnableCors("CorsPolicy")]
    public class BCryptController : ControllerBase
    {
        [HttpGet]
        [Route("api/knock")]
        public string Knock()
        {
            return "i got it";
        }

        [HttpGet]
        [Route("api/hashpassword/{pwd}")]
        public ClientResponse HashPassword(string pwd)
        {
            return new ClientResponse()
            {
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(pwd),
                Password = pwd
            };
        }

        [HttpGet]
        [Route("api/validatehash/{pwd}/{hash}")]
        public ClientResponse validateHash(string pwd, string hash)
        {
            return new ClientResponse()
            {
                PasswordHash = hash,
                Password = pwd,
                IsValid = BCrypt.Net.BCrypt.Verify(pwd, hash)
            };
        }


    }

    public class ClientResponse
    {
        public string PasswordHash { get; set; }
        public string Password { get; set; }
        public bool IsValid { get; set; }

    }
}