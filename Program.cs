#nullable disable
using Microsoft.EntityFrameworkCore;
using TESTASP_DCPR.Models;
using AutoMapper;
using  Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//add service dbcontext
string strcon = builder.Configuration.GetConnectionString("DATABASE_CONNECTION");
builder.Services.AddDbContext<db_context>(options => options.UseSqlServer(strcon));
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddIdentity<Agents, IdentityRole>(options =>
{
    options.Password = new PasswordOptions
    {
        RequireDigit = true,
        RequireUppercase = false,
        RequireLowercase = true,
        RequireNonAlphanumeric = false

    };

}).AddEntityFrameworkStores<db_context>();


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

app.MapRazorPages();

app.Run();
