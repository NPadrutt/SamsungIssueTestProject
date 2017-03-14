using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SamsungIssueTestProject.Business.Models
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long IdService { get; set; }

        public long IdAddressbook { get; set; }

        public byte[] Image { get; set; }

        public string Prename { get; set; }

        public string MiddleName { get; set; }

        public string Name { get; set; }

        public bool IsMe{ get; set; }

        public bool IsAllowedToReceiveMyInfos { get; set; }

        public bool HasUnsavedChanges { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }

        public List<ContactInfo> Infos { get; set; }

        public List<ContactAddress> Addresses { get; set; }

        public List<ContactEvent> Events { get; set; }
    }
}
