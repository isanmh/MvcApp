using Microsoft.EntityFrameworkCore;
using MvcApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ini koneksi database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SSConnection"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Custom Routeing
app.MapGet("/hello", () => "Hello World!");
app.MapGet("/hai", () => "Hai dunia!");

// ...:5000/welcome/welcome?name=YourName&job=YourJob
app.MapGet("/welcome", async context =>
{
    var name = context.Request.Query["name"];
    var job = context.Request.Query["job"];
    var res = $"Welcome {name}, your job is {job}";
    await context.Response.WriteAsJsonAsync(res);
});


app.Run();
