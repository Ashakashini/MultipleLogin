using Microsoft.AspNetCore.Identity;

public static class SeedRoles
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

        string[] roleNames = { "Admin", "HR", "Employee" };

        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        // Create default admin
        var adminEmail = "asha.kashini@gmail.com";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        if (adminUser == null)
        {
            var admin = new IdentityUser { UserName = adminEmail, Email = adminEmail };
            var result = await userManager.CreateAsync(admin, "Admin123!");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}

