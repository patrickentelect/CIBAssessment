using System.Collections.Generic;
using System.Linq;
using PhonebookApi.Data.Models;
using PhonebookApi.Data.Repositories;

namespace PhonebookApi.Service.Services
{
    public class EntryService : IEntryService
    {
        IEntryRepository _entryRepository;
        public EntryService(IEntryRepository entryRepository)
        {
            this._entryRepository = entryRepository;
        }

        public void Add(Entry entry)
        {
            this._entryRepository.Insert(entry);
        }

        public Entry Get(int entryId)
        {
            return this._entryRepository.GetById(entryId);
        }

        public List<Entry> Get()
        {
            return this._entryRepository.GetAll().ToList();
        }

        public List<Entry> GetByPhoneBookId(int phoneBookId)
        {
            return this._entryRepository.GetByPhoneBook(phoneBookId).ToList();
        }

        public void Update(Entry entry)
        {
            this._entryRepository.Update(entry);
        }
    }
}