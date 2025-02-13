using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AcentaWebAPI.Models;

public partial class DemoAcentaDbContext : DbContext
{
    public DemoAcentaDbContext()
    {
    }

    public DemoAcentaDbContext(DbContextOptions<DemoAcentaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agency> Agencies { get; set; }

    public virtual DbSet<Claim> Claims { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<Firm> Firms { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Policy> Policies { get; set; }

    public virtual DbSet<Quote> Quotes { get; set; }

    public virtual DbSet<Site> Sites { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-DHR5N5E\\MSSQLSERVER01;Database=DemoAcentaDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agency>(entity =>
        {
            entity.HasKey(e => e.AgencyId).HasName("PK__Agencies__95C546FBEE54557F");

            entity.Property(e => e.AgencyId).HasColumnName("AgencyID");
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.BankAccountNumber).HasMaxLength(100);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CommissionRate).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.ContactEmail).HasMaxLength(255);
            entity.Property(e => e.ContactPerson).HasMaxLength(255);
            entity.Property(e => e.ContactPhone).HasMaxLength(50);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Iban)
                .HasMaxLength(50)
                .HasColumnName("IBAN");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsBranch).HasDefaultValue(false);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.Latitude).HasColumnType("decimal(10, 6)");
            entity.Property(e => e.LicenseNumber).HasMaxLength(100);
            entity.Property(e => e.Longitude).HasColumnType("decimal(10, 6)");
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.TaxNumber).HasMaxLength(50);
            entity.Property(e => e.TotalAvailableDbslimit)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TotalAvailableDBSLimit");
            entity.Property(e => e.TotalDbslimit)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TotalDBSLimit");
            entity.Property(e => e.TradeRegisterNumber).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UseMultipleCurrencies).HasDefaultValue(false);

            entity.HasOne(d => d.ParentAgency).WithMany(p => p.InverseParentAgency)
                .HasForeignKey(d => d.ParentAgencyId)
                .HasConstraintName("FK__Agencies__Parent__66603565");
        });

        modelBuilder.Entity<Claim>(entity =>
        {
            entity.HasKey(e => e.ClaimId).HasName("PK__Claims__EF2E13BBFBAB0B08");

            entity.Property(e => e.ClaimId).HasColumnName("ClaimID");
            entity.Property(e => e.ClaimAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ClaimDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.PolicyId).HasColumnName("PolicyID");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Claims)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Claims__Customer__797309D9");

            entity.HasOne(d => d.Policy).WithMany(p => p.Claims)
                .HasForeignKey(d => d.PolicyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Claims__PolicyID__787EE5A0");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D8AA013A72");

            entity.HasIndex(e => e.Email, "UQ__Customer__A9D1053453DECE7E").IsUnique();

            entity.HasIndex(e => e.NationalId, "UQ__Customer__E9AA321A14E2E199").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DiscountRate).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.District).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.NationalId)
                .HasMaxLength(20)
                .HasColumnName("NationalID");
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.TotalAvailableDbslimit)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TotalAvailableDBSLimit");
            entity.Property(e => e.TotalDbslimit)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TotalDBSLimit");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Currency).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CurrencyId)
                .HasConstraintName("FK__Customers__Curre__440B1D61");
        });

        modelBuilder.Entity<CustomerAddress>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__Customer__091C2A1BCB0F49CB");

            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.AddressLine).HasMaxLength(500);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.PostalCode).HasMaxLength(20);

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerAddresses)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CustomerA__Custo__49C3F6B7");
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.HasKey(e => e.DivisionId).HasName("PK__Division__20EFC6A8C1A2155C");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Firm>(entity =>
        {
            entity.HasKey(e => e.FirmId).HasName("PK__Firms__1F1F209C22869F2B");

            entity.Property(e => e.FirmName).HasMaxLength(255);
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.LanguageId).HasName("PK__Language__B93855ABAE4FB1D9");

            entity.Property(e => e.LanguageCode).HasMaxLength(10);
            entity.Property(e => e.LanguageName).HasMaxLength(100);
        });

        modelBuilder.Entity<Policy>(entity =>
        {
            entity.HasKey(e => e.PolicyId).HasName("PK__Policies__2E1339442B078B36");

            entity.HasIndex(e => e.PolicyNumber, "UQ__Policies__46DA0157F4ED1A81").IsUnique();

            entity.Property(e => e.PolicyId).HasColumnName("PolicyID");
            entity.Property(e => e.AgencyId).HasColumnName("AgencyID");
            entity.Property(e => e.CoverageAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PolicyNumber).HasMaxLength(50);
            entity.Property(e => e.PolicyType).HasMaxLength(50);
            entity.Property(e => e.PremiumAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Agency).WithMany(p => p.Policies)
                .HasForeignKey(d => d.AgencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Policies__Agency__73BA3083");

            entity.HasOne(d => d.Customer).WithMany(p => p.Policies)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Policies__Custom__72C60C4A");
        });

        modelBuilder.Entity<Quote>(entity =>
        {
            entity.HasKey(e => e.QuoteId).HasName("PK__Quotes__AF9688E10228B3D7");

            entity.HasIndex(e => e.QuoteNumber, "UQ__Quotes__8A47966AAFFBF3CD").IsUnique();

            entity.Property(e => e.QuoteId).HasColumnName("QuoteID");
            entity.Property(e => e.AgencyId).HasColumnName("AgencyID");
            entity.Property(e => e.CancellationReason).HasMaxLength(500);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");
            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DiscountRate).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.FinalPremium).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.IsAutoRenewal).HasDefaultValue(false);
            entity.Property(e => e.IsMultiCurrency).HasDefaultValue(false);
            entity.Property(e => e.ModifiedByUserId).HasColumnName("ModifiedByUserID");
            entity.Property(e => e.OfferedPremium).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentTerm).HasMaxLength(50);
            entity.Property(e => e.PolicyType).HasMaxLength(50);
            entity.Property(e => e.QuoteNumber).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Agency).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.AgencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Quotes__AgencyID__123EB7A3");

            entity.HasOne(d => d.Customer).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Quotes__Customer__114A936A");
        });

        modelBuilder.Entity<Site>(entity =>
        {
            entity.HasKey(e => e.SiteId).HasName("PK__Sites__B9DCB9633EFA9A3B");

            entity.Property(e => e.SiteName).HasMaxLength(255);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__55433A4B6410B487");

            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.AgencyId).HasColumnName("AgencyID");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.PolicyId).HasColumnName("PolicyID");
            entity.Property(e => e.TransactionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TransactionType).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Agency).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.AgencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacti__Agenc__7F2BE32F");

            entity.HasOne(d => d.Customer).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacti__Custo__7E37BEF6");

            entity.HasOne(d => d.Policy).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.PolicyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacti__Polic__00200768");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACF0A21C38");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534F7D183A2").IsUnique();

            entity.HasIndex(e => e.Tckn, "UQ__Users__B773400396F60B33")
                .IsUnique()
                .HasFilter("([TCKN] IS NOT NULL)");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.ChangePasswordToken).HasMaxLength(255);
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DemoTenantId).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.IdmuserId)
                .HasMaxLength(100)
                .HasColumnName("IDMUserId");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.LastPasswordChangedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.Tckn)
                .HasMaxLength(11)
                .HasColumnName("TCKN");
            entity.Property(e => e.UserName).HasMaxLength(100);

            entity.HasOne(d => d.CreateUser).WithMany(p => p.InverseCreateUser)
                .HasForeignKey(d => d.CreateUserId)
                .HasConstraintName("FK__Users__CreateUse__5BE2A6F2");

            entity.HasOne(d => d.CustomerAddress).WithMany(p => p.Users)
                .HasForeignKey(d => d.CustomerAddressId)
                .HasConstraintName("FK__Users__CustomerA__5AEE82B9");

            entity.HasOne(d => d.DefaultCustomer).WithMany(p => p.Users)
                .HasForeignKey(d => d.DefaultCustomerId)
                .HasConstraintName("FK__Users__DefaultCu__5629CD9C");

            entity.HasOne(d => d.Firm).WithMany(p => p.Users)
                .HasForeignKey(d => d.FirmId)
                .HasConstraintName("FK__Users__FirmId__534D60F1");

            entity.HasOne(d => d.Language).WithMany(p => p.Users)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK__Users__LanguageI__5535A963");

            entity.HasOne(d => d.ModifyUser).WithMany(p => p.InverseModifyUser)
                .HasForeignKey(d => d.ModifyUserId)
                .HasConstraintName("FK__Users__ModifyUse__5CD6CB2B");

            entity.HasOne(d => d.Site).WithMany(p => p.Users)
                .HasForeignKey(d => d.SiteId)
                .HasConstraintName("FK__Users__SiteId__52593CB8");

            entity.HasOne(d => d.UserType).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__UserTypeI__5165187F");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasKey(e => e.UserTypeId).HasName("PK__UserType__40D2D816D761E7A2");

            entity.Property(e => e.TypeName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
