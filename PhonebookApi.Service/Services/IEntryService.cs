using System.Collections.Generic;
using PhonebookApi.Data.Models;

namespace PhonebookApi.Service.Services
{
    public interface IEntryService
    {
        Entry Get(int entryId);
        List<Entry> Get();
        void Update(Entry entry);
        void Add(Entry entry);
        List<Entry> GetByPhoneBookId(int phoneBookId);
    }
}