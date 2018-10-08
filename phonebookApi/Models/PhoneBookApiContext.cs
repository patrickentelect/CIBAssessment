using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace phonebookApi.Models
{
    public class PhonebookApiContext : DbContext
    {
        public DbSet<PhoneBook> PhoneBooks { get; set; }
        public DbSet<Entry> Entries { get; set; }

        public PhonebookApiContext(DbContextOptions<PhonebookApiContext> options)
        : base(options)
        { }
    }
}