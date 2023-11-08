using Microsoft.EntityFrameworkCore;
using webapp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Razor Pages is enabled
builder.Services.AddRazorPages();

builder.Services.AddDbContext<CustomerDbContext>(options =>
    options.UseInMemoryDatabase("name"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
// Razor Pages is enabled
app.MapRazorPages();

app.Run();
