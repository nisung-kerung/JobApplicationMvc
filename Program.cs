using JobApplicationMVC.Data; // ✅ your DbContext namespace
using Microsoft.EntityFrameworkCore; // ✅ required for UseSqlServer

var builder = WebApplication.CreateBuilder(args);

// ✅ Add EF Core with SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // ✅ required for CSS, JS, etc.
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=JobApplications}/{action=Index}/{id?}"
);

app.Run();
