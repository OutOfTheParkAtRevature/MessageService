using Microsoft.EntityFrameworkCore;
using Models;

namespace Repository
{
    public class MessageContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<RecipientList> RecipientLists { get; set; }
        public DbSet<UserInbox> UserInboxes { get; set; }

        public MessageContext() { }
        public MessageContext(DbContextOptions<MessageContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=LocalHost\\SQLEXPRESS01;Database=MessageService;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInbox>()
                .HasKey(c => new { c.UserID, c.MessageID });
            modelBuilder.Entity<RecipientList>()
                .HasKey(c => new { c.RecipientListID, c.RecipientID });
        }
    }
}