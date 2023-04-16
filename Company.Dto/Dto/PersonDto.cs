
using Company.Base;
using System.ComponentModel.DataAnnotations;

namespace Company.Dto;

public class PersonDto : BaseDto
{
    [Required]
    
    [Display(Name = "Account Id")]
    public int AccountId { get; set; }

    [Required]
    [MaxLength(500)]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(500)]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

  

    [MaxLength(500)]
    public string Description { get; set; }

    [Phone]
    [MaxLength(25)]
    public string Phone { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Date Of Birth")]
    public DateTime DateOfBirth { get; set; }


    public string FullName
    {
        get { return FirstName + " " + LastName; }
    }

}
