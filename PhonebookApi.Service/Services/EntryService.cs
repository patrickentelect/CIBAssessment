using System.Collections.Generic;
using PhonebookApi.Data.Models;

namespace PhonebookApi.Service.Services
{
    public class EntryService : IEntryService
    {
        public EntryService(PhoneBookApiContext context)
        {
        }

        public Entry Get(int entryId)
        {
            throw new System.NotImplementedException();
        }

        public List<Entry> Get()
        {
            throw new System.NotImplementedException();
        }
    }
}