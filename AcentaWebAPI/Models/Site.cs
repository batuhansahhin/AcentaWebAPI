using System;
using System.Collections.Generic;

namespace AcentaWebAPI.Models;

public partial class Site
{
    public int SiteId { get; set; }

    public string SiteName { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
