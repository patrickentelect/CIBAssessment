using System;
using System.Linq;
using System.Linq.Expressions;
using PhonebookApi.Data.Models;

namespace PhonebookApi.Data.Repositories
{
    public class EntryRepository : IEntryRepository
    {
        private readonly PhoneBookApiContext _phoneBookApiContext;

        public EntryRepository(PhoneBookApiContext phoneBookApiContext)
        {
            this._phoneBookApiContext = phoneBookApiContext;
        }

        public IQueryable<Entry> GetAll()
        {
            return this._phoneBookApiContext.Entries.AsQueryable();
        }

        public IQueryable<Entry> GetByPhoneBook(int phoneBookId)
        {
            return this._phoneBookApiContext.Entries.Where(x => x.PhonebookId == phoneBookId);
        }

        public Entry GetById(int id)
        {
            return this._phoneBookApiContext.Entries
                            .First(x => x.EntryId == id);
        }

        public void Insert(Entry entity)
        {
            this._phoneBookApiContext.Entries.Add(entity);
            this._phoneBookApiContext.SaveChanges();
        }

        public void Update(Entry entity)
        {
            this._phoneBookApiContext.Entries.Update(entity);
            this._phoneBookApiContext.SaveChanges();
        }
    }
}