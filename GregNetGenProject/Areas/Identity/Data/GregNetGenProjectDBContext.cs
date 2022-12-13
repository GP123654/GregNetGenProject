using GregNetGenProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GregNetGenProject.Areas.Identity.Data;

public class GregNetGenProjectDBContext : IdentityDbContext<GregNetGenProjectUser>
{
    public GregNetGenProjectDBContext(DbContextOptions<GregNetGenProjectDBContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new GregNetGenProjectUserEntityConfiguration());
    }
}

public class GregNetGenProjectUserEntityConfiguration : IEntityTypeConfiguration<GregNetGenProjectUser>
{
    public void Configure(EntityTypeBuilder<GregNetGenProjectUser> builder)
    {
        builder.Property(user => user.FirstName).HasMaxLength(100);
        builder.Property(user => user.Surname).HasMaxLength(100);
        builder.Property(user => user.CellularNum).HasMaxLength(12);
        builder.Property(user => user.Age).HasMaxLength(3);
        builder.Property(user => user.Hobbies).HasMaxLength(100);
    }
}