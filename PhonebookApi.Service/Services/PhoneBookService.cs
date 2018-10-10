using System.Collections.Generic;
using PhonebookApi.Data.Models;

namespace PhonebookApi.Service.Services
{
    public class PhonebookBookService : IPhoneBookService
    {
        private PhoneBookApiContext _context;
        public PhonebookBookService(PhoneBookApiContext context)
        {
            this._context = context;
        }

        public PhoneBook Get(int phoneBookId)
        {
            throw new System.NotImplementedException();
        }

        public List<PhoneBook> Get()
        {
            throw new System.NotImplementedException();
        }
    }
}