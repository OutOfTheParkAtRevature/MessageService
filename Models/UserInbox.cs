using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class UserInbox
    {
        [DisplayName("User ID")]
        [ForeignKey("UserID")]
        public string UserID { get; set; }
        [DisplayName("Message ID")]
        [ForeignKey("MessageID")]
        public Guid MessageID { get; set; }
        public bool IsRead { get; set; }
    }
}
