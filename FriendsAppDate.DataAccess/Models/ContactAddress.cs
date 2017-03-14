using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FriendsAppDate.DataAccess.Models
{
    public class ContactAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long IdService { get; set; }

        public long IdAddressbook { get; set; }

        public long ContactId { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Postcode { get; set; }

        public int InfoType { get; set; }

        public bool HasUnsavedChanges { get; set; }

        public Contact Contact { get; set; }
    }
}