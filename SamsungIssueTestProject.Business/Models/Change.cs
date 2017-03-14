using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SamsungIssueTestProject.Business.Models
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
