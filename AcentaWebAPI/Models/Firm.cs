using System;
using System.Collections.Generic;

namespace AcentaWebAPI.Models;

public partial class Firm
{
    public int FirmId { get; set; }

    public string FirmName { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
