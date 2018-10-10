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

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Entry> Get(int id)
        {
            return this._entryService.Get(id);
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
        [HttpPut("{id}")]
        public void Put(Entry entry)
        {
            if (ModelState.IsValid)
            {
                this._entryService.Update(entry);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
