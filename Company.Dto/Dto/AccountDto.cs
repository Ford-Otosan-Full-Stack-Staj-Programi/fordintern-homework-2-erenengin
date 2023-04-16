using Company.Base;
using System.ComponentModel.DataAnnotations;

namespace Company.Dto;

public class AccountDto : BaseDto
{
    [Required]
    [MaxLength(125)]
   
    [Display(Name = "User Name")]
    public string UserName { get; set; }

    [Required]
    
    public string Password { get; set; }

    [Required]
    [MaxLength(500)]
    public string Name { get; set; }



    [Required]
    
    public string Role { get; set; }


    [Display(Name = "Last Activity")]
    public DateTime LastActivity { get; set; }
}
