using System;
using System.Collections.Generic;

namespace AcentaWebAPI.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string PasswordHash { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public int UserTypeId { get; set; }

    public int? SiteId { get; set; }

    public int? FirmId { get; set; }

    public bool IsSystemAdmin { get; set; }

    public string? Code { get; set; }

    public int? LanguageId { get; set; }

    public int? DefaultCustomerId { get; set; }

    public int FailedAttemptCount { get; set; }

    public bool ChangePassword { get; set; }

    public DateTime? LastPasswordChangedDate { get; set; }

    public int? DefaultDivisionId { get; set; }

    public bool EnableTwoFactorAuthentication { get; set; }

    public string? IdmuserId { get; set; }

    public string? DemoTenantId { get; set; }

    public string? Tckn { get; set; }

    public bool UseSharedCart { get; set; }

    public int? CustomerAddressId { get; set; }

    public string? ChangePasswordToken { get; set; }

    public int? CreateUserId { get; set; }

    public int? ModifyUserId { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? ModifyDate { get; set; }

    public virtual User? CreateUser { get; set; }

    public virtual CustomerAddress? CustomerAddress { get; set; }

    public virtual Customer? DefaultCustomer { get; set; }

    public virtual Firm? Firm { get; set; }

    public virtual ICollection<User> InverseCreateUser { get; set; } = new List<User>();

    public virtual ICollection<User> InverseModifyUser { get; set; } = new List<User>();

    public virtual Language? Language { get; set; }

    public virtual User? ModifyUser { get; set; }

    public virtual Site? Site { get; set; }

    public virtual UserType UserType { get; set; } = null!;
}
