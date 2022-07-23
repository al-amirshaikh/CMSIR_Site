using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using CMSIR.IService;
using CMSIR.Admin;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IFileUpload, FileUpload>();
builder.Services.AddTransient<IDBOperation, DBOperation>();
builder.Services.AddTransient<IResumeModel, ResumeModel>();
builder.Services.AddTransient<IDisplayModel, DisplayModel>();



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
