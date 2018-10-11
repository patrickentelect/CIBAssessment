using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using PhonebookApi.Data.Models;
using PhonebookApi.Data.Repositories;
using System.Collections.Generic;
using Moq;

namespace PhonebookApi.Data.Test
{
    public class PhoneBookRepositoryTest
    {
        [Fact]
        public void GetAll_ReturnsAListOfPhoneBooks()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<PhoneBookApiContext>()
                .UseInMemoryDatabase(databaseName: "phone_book_get_all")
                .Options;

            using (var context = new PhoneBookApiContext(options))
            {
                context.PhoneBooks.Add(GetFakePhoneBooks()[0]);
                context.PhoneBooks.Add(GetFakePhoneBooks()[1]);
                context.SaveChanges();

                var phoneBookRepository = new PhoneBookRepository(context);

                // Act
                var result = phoneBookRepository.GetAll().ToList();
                Assert.IsType<List<PhoneBook>>(result);
                Assert.Equal(2, result.Count());
            }
        }

        [Fact]
        public void Get_ReturnsAPhoneBook()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<PhoneBookApiContext>()
                .UseInMemoryDatabase(databaseName: "phone_book_get_by_id")
                .Options;
            var testId = 1;

            using (var context = new PhoneBookApiContext(options))
            {
                context.PhoneBooks.Add(GetFakePhoneBooks()[0]);
                context.PhoneBooks.Add(GetFakePhoneBooks()[1]);
                context.SaveChanges();

                var phoneBookRepository = new PhoneBookRepository(context);

                // Act
                var result = phoneBookRepository.GetById(1);

                // Assert
                Assert.IsType<PhoneBook>(result);
                Assert.Equal(testId, result.PhoneBookId);
            }
        }

        private List<PhoneBook> GetFakePhoneBooks()
        {
            var entries1 = new List<Entry>
            {
                new Entry
                {
                    EntryId = 1,
                    Name = "Mum",
                    PhoneNumber = "071137390"
                },
                new Entry
                {
                    EntryId = 2,
                    Name = "Dad",
                    PhoneNumber = "082499586"
                }
            };

            var entries2 = new List<Entry>
            {
                new Entry
                {
                    EntryId = 3,
                    Name = "Peter",
                    PhoneNumber = "0965222548"
                }
            };

            var phoneBook1 = new PhoneBook
            {
                PhoneBookId = 1,
                Name = "Friends and Family",
                //Entries = entries1
            };

            var phoneBook2 = new PhoneBook
            {
                PhoneBookId = 2,
                Name = "Work People",
                //Entries = entries2
            };

            return new List<PhoneBook>
            {
                phoneBook1,
                phoneBook2
            };
        }
    }
}
