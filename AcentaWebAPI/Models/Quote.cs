using System;
using System.Collections.Generic;

namespace AcentaWebAPI.Models;

public partial class Quote
{
    public int QuoteId { get; set; }

    public int CustomerId { get; set; }

    public int AgencyId { get; set; }

    public string? PolicyType { get; set; }

    public decimal? OfferedPremium { get; set; }

    public DateOnly? ValidUntil { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? QuoteNumber { get; set; }

    public int? CreatedByUserId { get; set; }

    public int? ModifiedByUserId { get; set; }

    public int? CurrencyId { get; set; }

    public decimal? DiscountRate { get; set; }

    public decimal? FinalPremium { get; set; }

    public string? PaymentTerm { get; set; }

    public string? CoverageDetails { get; set; }

    public DateOnly? ExpirationDate { get; set; }

    public string? CancellationReason { get; set; }

    public bool? IsMultiCurrency { get; set; }

    public bool? IsAutoRenewal { get; set; }

    public int? SortNumber { get; set; }

    public virtual Agency Agency { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
