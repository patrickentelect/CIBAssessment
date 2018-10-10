using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PhonebookApi.Data.Models
{
    public class PhoneBookApiContext : DbContext
    {
        public DbSet<PhoneBook> PhoneBooks { get; set; }
        public DbSet<Entry> Entries { get; set; }

        public PhoneBookApiContext(DbContextOptions<PhoneBookApiContext> options)
        : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)        
        {
            var entry1 = new Entry
            {
                EntryId = 1,
                Name = "Mum",
                PhoneNumber = "071137390"
            };

            var entry2 = new Entry
            {
                EntryId = 2,
                Name = "Dad",
                PhoneNumber = "082499586"
            };

            var entry3 = new Entry
            {
                EntryId = 3,
                Name = "Peter",
                PhoneNumber = "0965222548"
            };

            var phoneBook1 = new PhoneBook
            {
                PhoneBookId = 1,
                Name = "Friends and Family"
            };

            var phoneBook2 = new PhoneBook
            {
                PhoneBookId = 2,
                Name = "Work People"
            };

            modelBuilder.Entity<PhoneBook>()
            .HasData(
                new PhoneBook
                {
                    PhoneBookId = phoneBook1.PhoneBookId,
                    Name = phoneBook1.Name,
                },
                new PhoneBook
                {
                    PhoneBookId = phoneBook2.PhoneBookId,
                    Name = phoneBook2.Name,
                }
            );

            modelBuilder.Entity<Entry>()
            .HasData(
                new
                {
                    EntryId = entry1.EntryId,
                    Name = entry1.Name,
                    PhonebookId = phoneBook1.PhoneBookId,
                    PhoneNumber = entry1.PhoneNumber
                },
                new
                {
                    EntryId = entry2.EntryId,
                    Name = entry2.Name,
                    PhonebookId = phoneBook1.PhoneBookId,
                    PhoneNumber = entry2.PhoneNumber
                },
                new
                {
                    EntryId = entry3.EntryId,
                    Name = entry3.Name,
                    PhonebookId = phoneBook2.PhoneBookId,
                    PhoneNumber = entry3.PhoneNumber
                }                
            );
        }
    }
}