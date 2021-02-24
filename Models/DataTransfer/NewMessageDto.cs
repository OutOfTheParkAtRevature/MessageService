using System.Collections.Generic;
using System.ComponentModel;

namespace Models.DataTransfer
{
    public class NewMessageDto
    {
        [DisplayName("Sender ID")]
        public string SenderID { get; set; }
        [DisplayName("Recipient List ID")]
        public List<string> RecipientList { get; set; }
        [DisplayName("Message Text")]
        public string MessageText { get; set; }
    }
}
