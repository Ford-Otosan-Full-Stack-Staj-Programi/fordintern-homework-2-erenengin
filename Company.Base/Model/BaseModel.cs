using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Base;

public class BaseModel
{
    public int Id { get; set; }
    

    public string Email { get; set; }
    public string CreatedBy { get; set; }
    
     public DateTime CreatedAt { get; set; }
}
