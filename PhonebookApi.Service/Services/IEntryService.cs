using System.Collections.Generic;
using PhonebookApi.Data.Models;

namespace PhonebookApi.Service.Services
{
    public interface IEntryService
    {
        Entry Get(int entryId);
        List<Entry> Get();
    }
}