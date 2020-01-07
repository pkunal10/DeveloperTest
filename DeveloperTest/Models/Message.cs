using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DeveloperTest.Models
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; set; }
        public string SenderEmailId { get; set; }
        public string RecevierEmailId { get; set; }
        public string Subject { get; set; }
        public string MessageData { get; set; }
        public DateTime SentTime { get; set; }
        public bool IsArchive { get; set; }
        [NotMapped]
        public string SentTimeDisplay { get; set; }
    }
}