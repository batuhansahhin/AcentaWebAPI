using System;
using System.Collections.Generic;

namespace AcentaWebAPI.Models;

public partial class Claim
{
    public int ClaimId { get; set; }

    public int PolicyId { get; set; }

    public int CustomerId { get; set; }

    public decimal? ClaimAmount { get; set; }

    public DateTime? ClaimDate { get; set; }

    public string? Status { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Policy Policy { get; set; } = null!;
}
