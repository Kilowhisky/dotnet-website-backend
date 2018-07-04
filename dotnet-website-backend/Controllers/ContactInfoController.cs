using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetwebsitebackend.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnetwebsitebackend.Controllers
{
    [Route("api/[controller]")]
    public class ContactInfoController : Controller
    {
        static string _content = "My details";

        // GET: api/values
        [HttpGet]
        public ContactInfo Get()
        {
            return new ContactInfo
            {
                content = _content
            };
        }

        // PUT api/values/5
        [HttpPut]
        public void Put([FromForm]ContactInfo value)
        {
            _content = value.content;
        }
    }
}
