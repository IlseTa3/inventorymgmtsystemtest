using Microsoft.EntityFrameworkCore;
using TestInventoryMgmtSystem.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure MySQL connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 36))));

// Register Identity services with ApplicationUser and roles
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
// Use ApplicationDbContext for identity

// Authorization policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdministratorRole", policy => policy.RequireRole("Administrator"));
    options.AddPolicy("RequireStockmanagerRole", policy => policy.RequireRole("Stockmanager"));
    options.AddPolicy("RequireStockemployeeRole", policy => policy.RequireRole("Stockemployee"));
    options.AddPolicy("StockemployeeReadUpdate", policy =>
        policy.RequireAssertion(context =>
            context.User.IsInRole("Stockemployee") &&
            (context.Resource.ToString().Contains("Read") || context.Resource.ToString().Contains("Update"))
        ));
    options.AddPolicy("StockmanagerOrAdmin", policy =>
        policy.RequireAssertion(context =>
            context.User.IsInRole("Stockmanager") || context.User.IsInRole("Administrator")
        ));
});

builder.Services.AddRazorPages();

var app = builder.Build();

// Create a scope for service provider
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    // RoleManager and UserManager
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    // Uncomment these lines if you need to create roles or assign roles to users
    // Creating roles (already done, can be commented out)
    /*
    await roleManager.CreateAsync(new IdentityRole("Stockemployee"));
    await roleManager.CreateAsync(new IdentityRole("Stockmanager"));
    await roleManager.CreateAsync(new IdentityRole("Administrator"));
    */

    // Assigning roles to users (already done, can be commented out)
    /*
    var adminUser = await userManager.FindByEmailAsync("ilset@retroconstruct.be");
    if (adminUser != null)
    {
        await userManager.AddToRoleAsync(adminUser, "Administrator");
    }

    var stockEmloyeeUser = await userManager.FindByEmailAsync("mikec@retroconstruct.be");
    if (stockEmloyeeUser != null)
    {
        await userManager.AddToRoleAsync(stockEmloyeeUser, "Stockemployee");
    }

    var stockManagerUser = await userManager.FindByEmailAsync("johannesdb@retroconstruct.be");
    if (stockManagerUser != null)
    {
        await userManager.AddToRoleAsync(stockManagerUser, "Stockmanager");
    }
    */
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Authentication
app.UseAuthorization();  // Authorization

app.MapRazorPages(); // Map Razor pages

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
