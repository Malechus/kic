using KiCData.Services;
using KiCData.Models;
using KiCData.Models.WebModels;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IConfigurationBuilder configBuilder = new ConfigurationBuilder()
	.AddJsonFile("appsettings.json");
if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
{
	configBuilder.AddJsonFile("appsettings.Production.json");
}
else if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
{
	configBuilder.AddJsonFile("appsettings.Development.json");
}
else
{
	configBuilder.AddJsonFile("appsettings.Debug.json");
}
IConfigurationRoot config = configBuilder.Build();

// Add services to the container.
builder.Services.AddSingleton(config);
builder.Services.AddSingleton<IEmailService, EmailService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<ICookieService, CookieService>();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<IKiCLogger, KiCLogger>();
builder.Services.AddDbContext<KiCdbContext>(options => options.UseMySql(config["Database:ConnectionString"], ServerVersion.AutoDetect(config["Database:ConnectionString"])));
builder.Services.AddControllersWithViews();

WebApplication app = builder.Build();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
	ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedFor | Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedProto
});

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

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
