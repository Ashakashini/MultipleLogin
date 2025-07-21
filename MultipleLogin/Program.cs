
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MultipleLogin.DAL;  // Ensure correct namespace for your DbContext

var builder = WebApplication.CreateBuilder(args);

// Add EF Core & Identity
builder.Services.AddDbContext<MultipleLogin.DAL.EntityMultipleLoginDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LoginConnect")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireUppercase = true;
    options.SignIn.RequireConfirmedEmail = false;
})
.AddEntityFrameworkStores<MultipleLogin.DAL.EntityMultipleLoginDbContext>()
.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Seed roles & admin user
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await SeedRoles.InitializeAsync(services);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();