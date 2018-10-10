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
    public class EntriesController : ControllerBase
    {
        private IEntryService _entryService;

        public EntriesController(IEntryService entryService)
        {
            this._entryService = entryService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Entry>> Get()
        {
            return this._entryService.Get();
        }

        [HttpGet("{entryId}")]
        public ActionResult<Entry> Get(int entryId)
        {
            return this._entryService.Get(entryId);
        }

        // GET api/values/5
        [HttpGet("EntriesByPhoneBookId/{phoneBookId}")]
        public ActionResult<IEnumerable<Entry>> EntriesByPhoneBookId(int phoneBookId)
        {
            return this._entryService.GetByPhoneBookId(phoneBookId);
        }

        // POST api/values
        [HttpPost]
        public void Post(Entry entry)
        {
            if (ModelState.IsValid)
            {
                this._entryService.Add(entry);
            }
        }

        // PUT api/values/5
        [HttpPut]
        public void Put(Entry entry)
        {
            if (ModelState.IsValid)
            {
                this._entryService.Update(entry);
            }
        }


                // PUT api/values/5
        [HttpPut("{entryId}")]
        public void Put(int entryId, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
