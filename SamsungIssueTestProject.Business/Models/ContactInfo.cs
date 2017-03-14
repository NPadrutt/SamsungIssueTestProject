using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SamsungIssueTestProject.Business.Models
{
    public class ContactInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long IdService { get; set; }

        public long IdAddressbook { get; set; }

        public long ContactId { get; set; }

        public int InfoType { get; set; }

        public string Info { get; set; }

        public bool HasUnsavedChanges { get; set; }

        public Contact Contact { get; set; }

    }
}
