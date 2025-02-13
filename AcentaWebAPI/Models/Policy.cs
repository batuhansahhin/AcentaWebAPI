using System;
using System.Collections.Generic;

namespace AcentaWebAPI.Models;

public partial class Policy
{
    public int PolicyId { get; set; }

    public string PolicyNumber { get; set; } = null!;

    public int CustomerId { get; set; }

    public int AgencyId { get; set; }

    public string? PolicyType { get; set; }

    public decimal? PremiumAmount { get; set; }

    public decimal? CoverageAmount { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Agency Agency { get; set; } = null!;

    public virtual ICollection<Claim> Claims { get; set; } = new List<Claim>();

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
