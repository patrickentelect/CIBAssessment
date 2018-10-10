using System.Collections.Generic;
using System.Linq;
using PhonebookApi.Data.Models;

namespace PhonebookApi.Service.Services
{
    public class EntryService : IEntryService
    {
        private PhoneBookApiContext _context;

        public EntryService(PhoneBookApiContext context)
        {
            this._context = context;
        }

        public void Add(Entry entry)
        {
            this._context.Entries.Add(entry);
            this._context.SaveChanges();
        }

        public Entry Get(int entryId)
        {
            return this._context.Entries.First(x => x.EntryId == entryId);
        }

        public List<Entry> Get()
        {
            return this._context.Entries.ToList();
        }

        public List<Entry> GetByPhoneBookId(int phoneBookId)
        {
            return this._context.Entries.Where(x => x.PhonebookId == phoneBookId)
                                        .ToList();
        }

        public void Update(Entry entry)
        {
            this._context.Entries.Update(entry);
            this._context.SaveChanges();
        }
    }
}