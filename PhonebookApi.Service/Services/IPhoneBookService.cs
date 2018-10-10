using System.Collections.Generic;
using PhonebookApi.Data.Models;

namespace PhonebookApi.Service.Services
{
    public interface IPhoneBookService
    {
        PhoneBook Get(int phoneBookId);
        List<PhoneBook> Get();
    }
}