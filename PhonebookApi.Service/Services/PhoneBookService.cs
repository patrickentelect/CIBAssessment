using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PhonebookApi.Data.Models;
using PhonebookApi.Data.Repositories;

namespace PhonebookApi.Service.Services
{
    public class PhonebookBookService : IPhoneBookService
    {
        IPhoneBookRepository _phoneBookRepository;
        public PhonebookBookService(IPhoneBookRepository phoneBookRepository)
        {
            this._phoneBookRepository = phoneBookRepository;
        }

        public PhoneBook Get(int phoneBookId)
        {
            return this._phoneBookRepository.GetById(phoneBookId);
        }

        public List<PhoneBook> Get()
        {
            return this._phoneBookRepository.GetAll().ToList();
        }
    }
}