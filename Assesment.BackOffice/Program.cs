using Assesment.BackOffice.Components;
using Microsoft.EntityFrameworkCore;
using Assesments.Data;
using Assesments.Services;

var builder = WebApplication.CreateBuilder(args);

//adding AppDbContext to start porject 
builder.Services.AddDbContext<ApplicationDbContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAssesmentRepository, AssesmentRepository>();
builder.Services.AddScoped<AssesmentServices, AssesmentServices>();
builder.Services.AddScoped<UserServices, UserServices>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
