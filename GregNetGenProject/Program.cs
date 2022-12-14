using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GregNetGenProject.Areas.Identity.Data;
using GregNetGenProject.Areas.Identity.Pages.Account;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("GregNetGenProjectDBContextConnection") ?? throw new InvalidOperationException("Connection string 'GregNetGenProjectDBContextConnection' not found.");

builder.Services.AddDbContext<GregNetGenProjectDBContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<GregNetGenProjectUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<GregNetGenProjectDBContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

//Trying to add a register audit log
//builder.Services.AddScoped<RegisterModel, RegisterModel>();


//Trying to do roles
//builder.Services.AddDefaultIdentity<IdentityUser>()
//    .AddRoles<IdentityRole>();


AddAuthorizationPolicies(builder.Services);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//Authentication and Authorization
app.UseAuthentication();;
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//For using Razor
app.MapRazorPages();

app.Run();


void AddAuthorizationPolicies(IServiceCollection services)
{
    services.AddAuthorization(options =>
    {
        options.AddPolicy("EmployeeOnly", policy => policy.RequireClaim("EmployeeNumber"));
    });
}