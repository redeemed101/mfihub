using MFIHub.Infra.IoC;
using MFIHub.Server.Background;
using MFIHub.Server.Hubs;
using MFIHub.Server.Services;
using MFIHub.Shared.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSignalR();
builder.Services.AddHostedService<TopicChecker>();
builder.Services.AddTransient<ITopicService, TopicService>();
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IMFIHubSettings, MFIHubSettings>();
DependencyInjection.RegisterServices(builder.Services, builder.Configuration);
//builder.Services.AddControllers().AddNewtonsoftJson();
var MyAllowSpecificOrigins = "corsOrigin";


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin();
                          policy.AllowAnyMethod();
                          policy.AllowAnyHeader();
                      });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");
app.MapHub<TopicHub>("/topics");

app.Run();
