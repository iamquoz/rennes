using course.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var config = new ConfigurationBuilder()
	.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
	.AddJsonFile("appsettings.json")
	.Build();

Console.WriteLine(config.GetConnectionString("DefaultConnection"));

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<TypesService>();
builder.Services.AddScoped<OrdersService>();
builder.Services.AddScoped<ClientsService>();
builder.Services.AddDbContext<coursedb.Data.db.CoursedbContext>
	(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

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


app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
