using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SamsungIssueTestProject.DataAccess.Models
{
    public class Change
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ContactName { get; set; }

        public string ChangeText { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
