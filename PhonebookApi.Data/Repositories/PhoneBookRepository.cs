using System;
using System.Linq;
using System.Linq.Expressions;
using PhonebookApi.Data.Models;

namespace PhonebookApi.Data.Repositories
{
    public class PhoneBookRepository : IPhoneBookRepository
    {
        private readonly PhoneBookApiContext _phoneBookApiContext;

        public PhoneBookRepository(PhoneBookApiContext phoneBookApiContext)
        {
            this._phoneBookApiContext = phoneBookApiContext;
        }

        public IQueryable<PhoneBook> GetAll()
        {
            return this._phoneBookApiContext.PhoneBooks.AsQueryable();
        }

        public PhoneBook GetById(int id)
        {
            return this._phoneBookApiContext.PhoneBooks
                            .First(x => x.PhoneBookId == id);
        }

        public void Insert(PhoneBook entity)
        {
            this._phoneBookApiContext.PhoneBooks.Add(entity);
            this._phoneBookApiContext.SaveChanges();
        }

        public void Update(PhoneBook entity)
        {
            this._phoneBookApiContext.PhoneBooks.Remove(entity);
            this._phoneBookApiContext.SaveChanges();
        }
    }
}