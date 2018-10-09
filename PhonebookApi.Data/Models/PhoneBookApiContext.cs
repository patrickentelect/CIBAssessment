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
    }
}