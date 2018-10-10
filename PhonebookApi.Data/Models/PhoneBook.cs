using System.Collections.Generic;

namespace PhonebookApi.Data.Models
{
    public class PhoneBook
    {
        public int PhoneBookId;
        public string Name;
        public List<Entry> Entries;
    }
}