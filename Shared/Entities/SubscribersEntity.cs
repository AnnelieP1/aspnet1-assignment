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
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Email { get; set; } = null!;
    public DateTime Created { get; set; } = DateTime.Now;
    public bool DailyNewsletter { get; set; }
    public bool AdvertisingUpdates { get; set; }
    public bool WeekinReview { get; set; }
    public bool EventUpdates { get; set; }
    public bool StartupsWeekly { get; set; }
    public bool Podcasts { get; set; }
}
