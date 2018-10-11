using System;
using System.Linq;
using System.Linq.Expressions;
using PhonebookApi.Data.Models;
 
namespace PhonebookApi.Data.Repositories
{
    public interface IPhoneBookRepository : IRepository<PhoneBook>
    {
    }
}