using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenUp.DataAccess.Entities
{
    [Table("AuthCode")]
   public class AuthCode
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid id { get; set; }
        [Required]
        public string phone { get; set; }
        public string authCode { get; set; }
        public DateTime deadline { get; set; }


    }
}