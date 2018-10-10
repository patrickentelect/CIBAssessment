
namespace PhonebookApi.Data.Models
{
    public class Entry
    {
        public int EntryId {get;set;}
        public string Name {get; set;}
        public string PhoneNumber {get;set;}

        public int PhonebookId { get; set; }
        public PhoneBook PhoneBook { get; set; }
    }
}