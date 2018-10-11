using System;
using System.Linq;
using System.Linq.Expressions;
using PhonebookApi.Data.Models;
 
namespace PhonebookApi.Data.Repositories
{
    public interface IEntryRepository : IRepository<Entry>
    {
        IQueryable<Entry> GetByPhoneBook(int phoneBookId);
    }
}