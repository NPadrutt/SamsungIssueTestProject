using FriendsAppDate.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace FriendsAppDate.DataAccess
{
    public class FadContext : DbContext
    {
        public static string DataBasePath { get; set; }

        internal DbSet<User> Users { get; set; }
        internal DbSet<Contact> Contacts { get; set; }
        internal DbSet<ContactAddress> ContactAddresss { get; set; }
        internal DbSet<ContactEvent> ContactEvents { get; set; }
        internal DbSet<ContactInfo> ContactInfos { get; set; }
        internal DbSet<Request> Requests { get; set; }
        internal DbSet<Change> Changes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DataBasePath}");
        }
    }
}
