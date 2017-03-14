using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SamsungIssueTestProject.Business.Models
{
    public class ContactEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long IdService { get; set; }

        public long IdAddressbook { get; set; }

        public long ContactId { get; set; }

        public string Name { get; set; }

        public DateTime Start { get; set; }

        public int Periodicity { get; set; }

        public int InfoType { get; set; }

        public bool HasUnsavedChanges { get; set; }

        public Contact Contact { get; set; }
    }
}
