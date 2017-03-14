using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SamsungIssueTestProject.Business.Models
{
    public class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Displayname { get; set; }

        public string UserFromNumber { get; set; }

        public string UserToNumber { get; set; }

        public bool IsEstablished { get; set; }
    }
}
