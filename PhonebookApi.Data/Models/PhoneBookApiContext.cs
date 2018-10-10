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
            var entry = new Entry
            {
                EntryId = 1,
                Name = "Mum",
                PhoneNumber = "071137390"
            };

            var phoneBook = new PhoneBook
            {
                PhoneBookId = 1,
                Name = "Friends and Family"
            };

            modelBuilder.Entity<PhoneBook>()
            .HasData(
                new PhoneBook
                {
                    PhoneBookId = phoneBook.PhoneBookId,
                    Name = phoneBook.Name,
                }
            );

            modelBuilder.Entity<Entry>()
            .HasData(
                new
                {
                    EntryId = entry.EntryId,
                    Name = entry.Name,
                    PhonebookId = phoneBook.PhoneBookId,
                    //PhoneBook = phoneBook
                }
            );
        }
    }
}