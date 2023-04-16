using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;

namespace Company.Dto
{
    public class TokenRequest
    {
        [Required]
        [MaxLength(125)]
       
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        
        public string Password { get; set; }
    }
}
