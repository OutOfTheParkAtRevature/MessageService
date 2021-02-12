﻿using Models;
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
        /// <summary>
        /// takes in a CarpoolingDto parameter and creates a Message. returns the new Message
        /// </summary>
        /// <param name="carpoolDto"></param>
        /// <returns></returns>
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
        /// <summary>
        /// takes in a ReplyDto as a parameter and creates and new Message. returns the new message.
        /// </summary>
        /// <param name="replyDto"></param>
        /// <returns></returns>
        public Message BuildMessage(ReplyDto replyDto)
        {
            Message replyMessage = new Message()
            {
                RecipientListID = Guid.Parse(replyDto.RecipientListID),
                SenderID = replyDto.SenderID,
                MessageText = replyDto.MessageText,
                MessageID = Guid.NewGuid(),
                SentDate = DateTime.Now
            };
            return replyMessage;
        }
    }
}
