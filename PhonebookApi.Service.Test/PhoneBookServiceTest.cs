using System;
using Xunit;
using Moq;
using PhonebookApi.Service.Services;
using PhonebookApi.Data.Repositories;
using System.Collections.Generic;
using PhonebookApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PhonebookApi.Service.Test
{
    public class PhoneBookServiceTest
    {
        [Fact]
        public void Get_ReturnsAListOfPhoneBooks()
        {
            // Arrange
            var mockRepo = new Mock<IPhoneBookRepository>();
            mockRepo.Setup(service => service.GetAll())
                .Returns(GetFakePhoneBooks());
            var phoneBookService = new PhonebookBookService(mockRepo.Object);

            // Act
            var result = phoneBookService.Get();

            // Assert
            Assert.IsType<List<PhoneBook>>(result);
            Assert.Equal(2, result.Count());
        } 
        
        [Fact]
        public void GetById_ReturnsAPhoneBook()
        {
            // Arrange
            var testId = 1;
            var mockRepo = new Mock<IPhoneBookRepository>();
            mockRepo.Setup(service => service.GetById(testId))
                .Returns(GetFakePhoneBooks().First());
            var phoneBookService = new PhonebookBookService(mockRepo.Object);

            // Act
            var result = phoneBookService.Get(testId);

            // Assert
            Assert.IsType<PhoneBook>(result);
            Assert.Equal(testId, result.PhoneBookId);
        }

        private IQueryable<PhoneBook> GetFakePhoneBooks()
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
                Entries = entries1
            };

            var phoneBook2 = new PhoneBook
            {
                PhoneBookId = 2,
                Name = "Work People",
                Entries = entries2
            };

            return new List<PhoneBook>
            {
                phoneBook1,
                phoneBook2
            }.AsQueryable();
        }
    }
}
