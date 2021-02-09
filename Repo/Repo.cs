using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;

namespace Repository
{
    public class Repo
    {
        private readonly MessageContext _messageContext;
        private readonly ILogger _logger;
        public DbSet<Message> Messages;
        public DbSet<RecipientList> RecipientLists;
        public DbSet<UserInbox> UserInboxes;

        public Repo(MessageContext messageContext, ILogger<Repo> logger)
        {
            _messageContext = messageContext;
            _logger = logger;
            this.Messages = _messageContext.Messages;
            this.RecipientLists = _messageContext.RecipientLists;
            this.UserInboxes = _messageContext.UserInboxes;
        }

        // Access SaveChanges from Logic class
        public async Task CommitSave()
        {
            await _messageContext.SaveChangesAsync();
        }

        public async Task<Message> GetMessageById(Guid id)
        {
            return await Messages.FindAsync(id);
        }
        public async Task<IEnumerable<Message>> GetMessages()
        {
            return await Messages.ToListAsync();
        }
        public async Task<IEnumerable<UserInbox>> GetUserInbox(Guid id)
        {
            return await UserInboxes.Where(x => x.UserID == id).ToListAsync();
        }
        public async Task<IEnumerable<Message>> GetMessagesBySenderById(Guid id)
        {
            return await Messages.Where(x => x.SenderID == id).ToListAsync();
        }
        public async Task<RecipientList> GetRecipientListById(Guid listId)
        {
            return await RecipientLists.SingleOrDefaultAsync(x => x.RecipientListID == listId);
        }
        public async Task<IEnumerable<RecipientList>> GetRecipientLists()
        {
            return await RecipientLists.ToListAsync();
        }
    }
}