using Microsoft.EntityFrameworkCore;

namespace skh.Data
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options)
            : base(options)
        {
        }

        public DbSet<skh.Models.ContactModel> Contacts { get; set; }
    }
}
