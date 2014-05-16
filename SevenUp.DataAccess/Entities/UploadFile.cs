using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenUp.DataAccess.Entities
{
    [Table("UploadFile")]
    public class UploadFile
    {
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
        [Required]
        public string filePath { get; set; }
        [Required]
        public DateTime fileTime { get; set; }
        
    }
}
