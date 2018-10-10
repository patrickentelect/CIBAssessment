using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhonebookApi.Data.Models;
using PhonebookApi.Service.Services;

namespace PhonebookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBooksController : ControllerBase
    {
        private IPhoneBookService _phoneBookService;

        public PhoneBooksController(IPhoneBookService phoneBookService)
        {
            this._phoneBookService = phoneBookService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<PhoneBook>> Get()
        {
            return this._phoneBookService.Get();//new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<PhoneBook> Get(int id)
        {
            return this._phoneBookService.Get(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
