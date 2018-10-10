using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhonebookApi.Data.Models
{
    public class PhoneBook
    {
        //[Key]
        public int PhoneBookId { get; set; }
        public string Name { get; set; }
        public List<Entry> Entries { get; set; }
    }
}