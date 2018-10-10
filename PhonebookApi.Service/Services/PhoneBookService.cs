using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            return this._context.PhoneBooks.First(x => x.PhoneBookId == phoneBookId);
        }

        public List<PhoneBook> Get()
        {
            return this._context.PhoneBooks.ToList();//.Include(p => p.Entries).ToList();
        }
    }
}