using System;
using System.Collections.Generic;

namespace AcentaWebAPI.Models;

public partial class CustomerAddress
{
    public int AddressId { get; set; }

    public int CustomerId { get; set; }

    public string AddressLine { get; set; } = null!;

    public string? City { get; set; }

    public string? Country { get; set; }

    public string? PostalCode { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
