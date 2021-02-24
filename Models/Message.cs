using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Message ID")]
        public Guid MessageID { get; set; }
        [DisplayName("Sender ID")]
        [ForeignKey("UserID")]
        public string SenderID { get; set; }
        [DisplayName("Recipient List ID")]
        [ForeignKey("UserID")]
        public Guid RecipientListID { get; set; }
        [DisplayName("Sent Date")]
        [DataType(DataType.DateTime)]
        public DateTime SentDate { get; set; }
        [DisplayName("Message Text")]
        public string MessageText { get; set; }
    }
}
