using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenUp.DataAccess.Entities
{
    [Table("Account")]
    public class Account
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid id { get; set; }
        [Required]
        public string phone { get; set; }
    }
}
