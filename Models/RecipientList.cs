using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class RecipientList
    {
        [DisplayName("Recipient List ID")]
        public Guid RecipientListID { get; set; }
        [DisplayName("Recipient ID")]
        [ForeignKey("UserID")]
        public string RecipientID { get; set; }
    }
}
