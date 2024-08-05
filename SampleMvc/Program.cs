using System.Configuration;
using Microsoft.Extensions.Options;
using SampleMvc.Extensions;
using SampleMvc.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .WithOrigins(builder.Configuration.GetSection("AllowedOrigins").Get<string[]>() ?? [])
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
var contentSecurityPolicySettings = new ContentSecurityPolicySettings();
builder.Configuration.GetSection("ContentSecurityPolicySettings").Bind(contentSecurityPolicySettings);
builder.Services.AddSingleton(contentSecurityPolicySettings);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseNonDevelopmentSecurityHeaders(contentSecurityPolicySettings);
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    // app.UseHsts();
}
else
{
    app.UseDevelopmentSecurityHeaders(contentSecurityPolicySettings);
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors();
app.UseAuthorization();
app.MapControllers();

app.Run();

public partial class Program {}