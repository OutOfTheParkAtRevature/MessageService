using Models;
using Models.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Mapper
    {
        public Message BuildMessage(CarpoolingDto carpoolDto)
        {
            Message carpoolMessage = new Message()
            {
                RecipientListID = carpoolDto.CarpoolListID,
                SenderID = carpoolDto.SenderID,
                MessageText = carpoolDto.MessageText,
                MessageID = Guid.NewGuid(),
                SentDate = DateTime.Now
            };
            return carpoolMessage;
        }
        public Message BuildMessage(ReplyDto replyDto)
        {
            Message replyMessage = new Message()
            {
                RecipientListID = replyDto.RecipientListID,
                SenderID = replyDto.SenderID,
                MessageText = replyDto.MessageText,
                MessageID = Guid.NewGuid(),
                SentDate = DateTime.Now
            };
            return replyMessage;
        }
    }
}
