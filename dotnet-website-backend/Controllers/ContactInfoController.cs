using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetwebsitebackend.Entity;
using dotnetwebsitebackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnetwebsitebackend.Controllers
{
    [Route("api/[controller]")]
    public class ContactInfoController : Controller
    {
        private readonly DataContext _context;

        protected ContactInfoController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets the singular contact info object
        /// </summary>
        /// <returns>The get.</returns>
        [HttpGet]
        public async Task<ContactInfo> Get()
        {
            return await _context.ContactInfos.FirstOrDefaultAsync();
        }

        /// <summary>
        /// Updates the singular contact info page object
        /// </summary>
        /// <param name="value">Value.</param>
        //[Authorize]
        [HttpPut]
        public async Task<IActionResult> Put([FromForm]ContactInfo value)
        {
            if (await _context.ContactInfos.AnyAsync())
            {
                value.Id = 1;
                _context.Update(value);
            }
            else
            {
                _context.Add(value);
            }
            await _context.SaveChangesAsync();

            return Ok(value);
        }
    }
}
