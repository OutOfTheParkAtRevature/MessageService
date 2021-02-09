using Microsoft.EntityFrameworkCore;
using Models;

namespace Repository
{
    public class MessageContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<RecipientList> RecipientLists;
        public DbSet<UserInbox> UserInboxes;

        public MessageContext() { }
        public MessageContext(DbContextOptions<MessageContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInbox>()
                .HasKey(c => new { c.UserID, c.MessageID });
            modelBuilder.Entity<RecipientList>()
                .HasKey(c => new { c.RecipientListID, c.RecipientID });
        }
    }
}