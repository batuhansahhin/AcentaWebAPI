using System;
using System.Collections.Generic;

namespace AcentaWebAPI.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? Address { get; set; }

    public string? NationalId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Code { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public decimal? TotalDbslimit { get; set; }

    public decimal? TotalAvailableDbslimit { get; set; }

    public int? CurrencyId { get; set; }

    public decimal? DiscountRate { get; set; }

    public bool IsBranch { get; set; }

    public bool IsRetailCustomer { get; set; }

    public bool IsExemptFromVat { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public string? District { get; set; }

    public virtual ICollection<Claim> Claims { get; set; } = new List<Claim>();

    public virtual Language? Currency { get; set; }

    public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();

    public virtual ICollection<Policy> Policies { get; set; } = new List<Policy>();

    public virtual ICollection<Quote> Quotes { get; set; } = new List<Quote>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
