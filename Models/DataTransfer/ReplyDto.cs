using System;
using System.ComponentModel;

namespace Models.DataTransfer
{
    public class ReplyDto
    {
        [DisplayName("Sender ID")]
        public string SenderID { get; set; }
        [DisplayName("Recipient List ID")]
        public Guid RecipientListID { get; set; }
        [DisplayName("Message Text")]
        public string MessageText { get; set; }
    }
}
