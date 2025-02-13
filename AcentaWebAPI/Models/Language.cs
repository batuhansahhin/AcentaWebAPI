using System;
using System.Collections.Generic;

namespace AcentaWebAPI.Models;

public partial class Language
{
    public int LanguageId { get; set; }

    public string LanguageCode { get; set; } = null!;

    public string LanguageName { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
