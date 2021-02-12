using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using Models.DataTransfer;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class Logic
    {
        private readonly Repo _repo;
        private readonly Mapper _mapper;
        private readonly ILogger<Repo> _logger;


        public Logic() { }
        public Logic(Repo repo, Mapper mapper, ILogger<Repo> logger)
        {
            _repo = repo;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get Message by MessageID
        /// </summary>
        /// <param name="id">MessageID</param>
        /// <returns>Message</returns>
        public async Task<Message> GetMessageById(Guid id)
        {
            return await _repo.GetMessageById(id);
        }

        public async Task<IEnumerable<Message>> GetMessagesBySenderById(Guid id)
        {
            return await _repo.GetMessagesBySenderById(id);
        }
        /// <summary>
        /// Get list of Messages
        /// </summary>
        /// <returns>list of Messages</returns>
        public async Task<IEnumerable<Message>> GetMessages()
        {
            return await _repo.GetMessages();
        }
        /// <summary>
        /// Get RecipientList by ID
        /// </summary>
        /// <param name="listId">RecipientListID</param>
        /// <param name="recId">RecipientID</param>
        /// <returns>RecipientList</returns>
        public async Task<RecipientList> GetRecipientListById(Guid listId)
        {
            return await _repo.GetRecipientListById(listId);
        }
        /// <summary>
        /// Get list of RecipientLists
        /// </summary>
        /// <returns>list of RecipientLists</returns>
        public async Task<IEnumerable<RecipientList>> GetRecipientLists()
        {
            return await _repo.GetRecipientLists();
        }
        /// <summary>
        /// Create RecipientList entity with ListID from Message and RecipientID from input
        /// </summary>
        /// <param name="listId">RecipientListID</param>
        /// <param name="recId">RecipientID</param>
        /// <returns>RecipientList</returns>
        public async Task<RecipientList> BuildRecipientList(Guid listId, Guid recId)
        {
            RecipientList rL = new RecipientList()
            {
                RecipientListID = listId,
                RecipientID = recId
            };
            await _repo.RecipientLists.AddAsync(rL);
            await _repo.CommitSave();
            return rL;
        }
        /// <summary>
        /// Create a new Message
        /// </summary>
        /// <param name="newMessageDto">Message from user</param>
        /// <returns>Message</returns>
        public async Task<Message> CreateNewMessage(NewMessageDto newMessageDto)
        {
            Message newMessage = new Message()
            {
                MessageID = Guid.NewGuid(),
                SenderID = newMessageDto.SenderID,
                RecipientListID = Guid.NewGuid(),
                MessageText = newMessageDto.MessageText,
                SentDate = DateTime.Now
            };
            foreach (Guid id in newMessageDto.RecipientList)
            {
                await BuildRecipientList(newMessage.RecipientListID, id);
            }
            //await _repo.messages.AddAsync(newMessage);
            await _repo.CommitSave();
            return newMessage;
        }
        public async Task<IEnumerable<Message>> GetMessagePool(Guid recipientListID)
        {
            List<Message> messagePool = await _repo.Messages.Where(x => x.RecipientListID == recipientListID).ToListAsync();
            return messagePool;
        }
        public async Task<Message> SendCarpool(CarpoolingDto carpoolDto)
        {
            Message message = _mapper.BuildMessage(carpoolDto);
            return await SendMessage(message);
        }
        public async Task<Message> SendReply(ReplyDto replyDto)
        {
            Message message = _mapper.BuildMessage(replyDto);
            return await SendMessage(message);
        }
        /// <summary>
        /// Assign Message to Recipients via RecipientList
        /// </summary>
        /// <param name="message">Message to be assigned</param>
        /// <returns>Boolean success</returns>
        public async Task<Message> SendMessage(Message message)
        {
            var recList = await _repo.RecipientLists.Where(x => x.RecipientListID == message.RecipientListID).ToListAsync();
            List<Guid> listOfRecipients = new List<Guid>();
            foreach (RecipientList r in recList)
            {
                listOfRecipients.Add(r.RecipientID);
            }
            foreach (Guid r in listOfRecipients)
            {
                await CreateUserInbox(r, message.MessageID);
            }
            await _repo.Messages.AddAsync(message);
            await _repo.CommitSave();
            return message;
        }
        /// <summary>
        /// Get a UserInbox entity for given User
        /// </summary>
        /// <param name="userId">UserID</param>
        /// <returns>UserInbox</returns>
        public async Task<IEnumerable<UserInbox>> GetUserInbox(Guid userId)
        {
            return await _repo.GetUserInbox(userId);
        }
        /// <summary>
        /// Create a UserInbox item for assigned Message
        /// </summary>
        /// <param name="userId">UserID</param>
        /// <param name="messageId">MessageID</param>
        /// <returns>UserInbox</returns>
        public async Task<UserInbox> CreateUserInbox(Guid userId, Guid messageId)
        {
            UserInbox uI = new UserInbox()
            {
                UserID = userId,
                MessageID = messageId,
                IsRead = false
            };
            await _repo.UserInboxes.AddAsync(uI);
            await _repo.CommitSave();
            return uI;
        }
        /// <summary>
        /// Delete a Message from given User
        /// </summary>
        /// <param name="userId">UserID</param>
        /// <param name="messageId">MessageID</param>
        /// <returns></returns>
        public async Task DeleteMessageFromInbox(Guid userId, Guid messageId)
        {
            foreach (UserInbox u in _repo.UserInboxes)
            {
                if (u.UserID == userId && u.MessageID == messageId)
                {
                    _repo.UserInboxes.Remove(u);
                }
            }
            await _repo.CommitSave();
        }
    }
}
