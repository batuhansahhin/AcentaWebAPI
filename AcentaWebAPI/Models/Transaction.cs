using System;
using System.Collections.Generic;

namespace AcentaWebAPI.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int CustomerId { get; set; }

    public int AgencyId { get; set; }

    public int PolicyId { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? TransactionDate { get; set; }

    public string? TransactionType { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Agency Agency { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual Policy Policy { get; set; } = null!;
}
