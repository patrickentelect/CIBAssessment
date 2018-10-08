using System.Collections.Generic;

namespace phonebookApi.Models
{
    public class PhoneBook
    {
        public int Id;
        public string Name;
        public List<Entry> Entries;
    }
}