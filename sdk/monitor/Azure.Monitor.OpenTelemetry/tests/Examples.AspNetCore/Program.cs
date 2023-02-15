using Azure.Monitor.OpenTelemetry;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAzureMonitorOpenTelemetry();

// This is another overload to call AddAzureMonitorOpenTelemetry with IConfiguration.
// builder.Services.AddAzureMonitorOpenTelemetry(builder.Configuration.GetSection("AzureMonitorOpenTelemetry"));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
