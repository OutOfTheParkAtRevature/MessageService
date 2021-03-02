using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.DataTransfer;
using Models;
using Models.DataTransfer;
using Service;

namespace MessageService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessageController : ControllerBase
    {
        private readonly Logic _logic;
        //private readonly ILogger<UsersController> _logger;

        private readonly IEmailSender _emailSender;

        public MessageController(Logic logic,IEmailSender emailSender)
        {
            _logic = logic;
            _emailSender = emailSender;
         
        }
        [HttpGet]
        public async Task<IEnumerable<Message>> GetMessages()
        {
            return await _logic.GetMessages();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetMessage(Guid id)
        {
            return await _logic.GetMessageById(id);
        }

        [HttpGet("Sender/{id}")]
        public async Task<IEnumerable<Message>> GetMessagesBySenderById(string id)
        {
            return await _logic.GetMessagesBySenderById(id);
        }

        [HttpPost("SendNew")]
        public async Task<ActionResult<Message>> SendNewMessage(NewMessageDto newMessageDto)
        {
            Message message = await _logic.CreateNewMessage(newMessageDto);
            Message sent = await _logic.SendMessage(message);
            if (sent == null)
            {
                //_logger.LogInformation("Bad Request");
                return BadRequest("Message was not sent");
            }
            return sent;
        }
        [HttpPost("Send")]
        public async Task<ActionResult<Message>> SendMessage(Message message)
        {
            Message sent = await _logic.SendMessage(message);
            if (sent == null)
            {
               // _logger.LogInformation("Bad Request");
                return BadRequest("Message was not sent");
            }
            return sent;
        }
        [HttpPost("Send/Carpool")]
        public async Task<ActionResult<Message>> SendCarpool(CarpoolingDto carpoolDto)
        {
            Message sent = await _logic.SendCarpool(carpoolDto);
            if (sent == null)
            {
               // _logger.LogInformation("Bad Request");
                return BadRequest("Message was not sent");
            }
            return sent;
        }

        [HttpPost("Send/Reply")]
        public async Task<ActionResult<Message>> SendReply(ReplyDto replyDto)
        {
            Message sent = await _logic.SendReply(replyDto);
            if (sent == null)
            {
               // _logger.LogInformation("Bad Request");
                return BadRequest("Message was not sent");
            }
            return sent;
        }

        [HttpPost("RecipientLists/create")]
        public async Task<ActionResult<RecipientList>> CreateRecipientList([FromBody] CreateCarpoolDto createCarpool)
        {
            return Ok(await _logic.BuildRecipientList(createCarpool.CarpoolID, createCarpool.UserID));
        }


        [HttpGet("RecipientLists")]
        public async Task<IEnumerable<RecipientList>> GetRecipientLists()
        {
            return await _logic.GetRecipientLists();
        }

        [HttpGet("RecipientLists/{id}")]
        public async Task<ActionResult<RecipientList>> GetRecipientList(Guid id)
        {
            return await _logic.GetRecipientListById(id);
        }

        [HttpGet("Inboxes/{id}")]
        public async Task<IEnumerable<UserInbox>> GetUserInboxes(string id)
        {
            return await _logic.GetUserInbox(id);
        }

        [HttpPost]
        [Route("SendEmail")]
        public async Task<ActionResult> SendEmailToUser(EmailMessage message)
        {
            await _emailSender.SendEmailAsync(message);
            return Ok();
        }


        [HttpPost]
        public async Task<ActionResult> SendEmailToUserWithAttachment(EmailMessage eMessage)
        {
            var files = Request.Form.Files.Any() ? Request.Form.Files : new FormFileCollection();

            var message = new EmailMessage(new string[] { eMessage.To.ToString() }, eMessage.Subject, eMessage.Content, files);
            await _emailSender.SendEmailAsync(message);
            return Ok();

        }
    }
}
