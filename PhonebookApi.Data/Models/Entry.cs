
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhonebookApi.Data.Models
{
    public class Entry
    {
        [Key]
        public int EntryId {get;set;}
        public string Name {get; set;}
        public string PhoneNumber {get;set;}

        [ForeignKey("PhonebookId")]
        public int PhonebookId { get; set; }
        public PhoneBook PhoneBook { get; set; }
    }
}