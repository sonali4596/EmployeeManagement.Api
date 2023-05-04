
using EmployeeManagementInterface;
using EmployeeManagementInterface.Model;
using EmployeeManagementInterface.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient<IMasterEmployeeService, EmployeeService>(client => { client.BaseAddress = new Uri(ConfigurationFile.baseUrl); });
builder.Services.AddSignalR();

builder.Services.AddHttpClient<IDepartmentService, DepartmentService>(client =>
{
    client.BaseAddress = new Uri(ConfigurationFile.baseUrl);
});
builder.Services.AddAutoMapper(typeof(EmployeeProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
