using System;
using System.ComponentModel;

namespace Models.DataTransfer
{
    public class CarpoolingDto
    {
        [DisplayName("Sender ID")]
        public string SenderID { get; set; }
        [DisplayName("Carpool List ID")]
        public Guid CarpoolListID { get; set; }
        [DisplayName("Message Text")]
        public string MessageText { get; set; }
    }
}
