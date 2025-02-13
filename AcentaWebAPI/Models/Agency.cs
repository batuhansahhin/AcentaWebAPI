using System;
using System.Collections.Generic;

namespace AcentaWebAPI.Models;

public partial class Agency
{
    public int AgencyId { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? TaxNumber { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? CurrencyId { get; set; }

    public string? Code { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreateUserId { get; set; }

    public int? ModifyUserId { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? ModifyDate { get; set; }

    public string? TradeRegisterNumber { get; set; }

    public string? LicenseNumber { get; set; }

    public string? ContactPerson { get; set; }

    public string? ContactPhone { get; set; }

    public string? ContactEmail { get; set; }

    public string? BankAccountNumber { get; set; }

    public string? Iban { get; set; }

    public decimal? CommissionRate { get; set; }

    public decimal? TotalDbslimit { get; set; }

    public decimal? TotalAvailableDbslimit { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public bool? IsBranch { get; set; }

    public int? ParentAgencyId { get; set; }

    public bool? UseMultipleCurrencies { get; set; }

    public int? SortNumber { get; set; }

    public virtual ICollection<Agency> InverseParentAgency { get; set; } = new List<Agency>();

    public virtual Agency? ParentAgency { get; set; }

    public virtual ICollection<Policy> Policies { get; set; } = new List<Policy>();

    public virtual ICollection<Quote> Quotes { get; set; } = new List<Quote>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
