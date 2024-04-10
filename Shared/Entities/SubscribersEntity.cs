using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities;

public class SubscribersEntity
{
    [Key]
    [Required] 
    public string Email { get; set; } = null!;
}
