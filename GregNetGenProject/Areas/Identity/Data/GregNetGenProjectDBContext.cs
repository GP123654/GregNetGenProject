using GregNetGenProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;
using GregNetGenProject.Models;

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

        //User Info
        builder.ApplyConfiguration(new GregNetGenProjectUserEntityConfiguration());

        //Trying to add roles
        /*
        builder.Entity<Role>().HasData(new List<Role>
        {
            new Role {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new Role {
                Id = 2,
                Name = "Staff",
                NormalizedName = "STAFF"
              },
            });*/

    }

    public DbSet<GregNetGenProject.Models.AuditingModel> AuditingModel { get; set; }
}

//--------------------------------------------------------------------------------------//
/// <summary>
/// Extra fields for registration
/// </summary>
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
//-------------------------------ooo000 END OF FILE 000ooo-------------------------------//