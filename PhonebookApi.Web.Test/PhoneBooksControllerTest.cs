using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using PhonebookApi.Controllers;
using PhonebookApi.Data.Models;
using PhonebookApi.Service.Services;
using PhonebookApi.Web;
using System.Collections.Generic;
using Moq;

namespace PhonebookApi.Web.Test
{
    public class PhoneBooksControllerTest
    {
        [Fact]
        public void Get_ReturnsAListOfPhoneBooks()
        {
            // Arrange
            var mockService = new Mock<IPhoneBookService>();
            mockService.Setup(service => service.Get())
                .Returns(GetFakePhoneBooks());
            var controller = new PhoneBooksController(mockService.Object);

            // Act
            var okResult  = controller.Get().Result as OkObjectResult;

            // Assert
            var result = Assert.IsType<List<PhoneBook>>(okResult.Value);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void Get_WithId_ReturnsAPhoneBook()
        {
            // Arrange
            var testPhoneBookId = 1;
            var mockService = new Mock<IPhoneBookService>();
            mockService.Setup(service => service.Get(testPhoneBookId))
                .Returns(GetFakePhoneBooks().First());
            var controller = new PhoneBooksController(mockService.Object);

            // Act
            var okResult  = controller.Get(1).Result as OkObjectResult;

            // Assert
            var result = Assert.IsType<PhoneBook>(okResult.Value);
            Assert.Equal(testPhoneBookId,result.PhoneBookId);
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
            };
        }
    }
}