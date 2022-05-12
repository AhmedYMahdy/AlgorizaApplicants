using System.Reflection;
using AlgorizaApplicants.API.Helpers;
using AlgorizaApplicants.DAL.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DB
builder.Services.AddDbContext<AlgorizaContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("AlgorizaCS")));
builder.Services.AddScoped(typeof(AlgorizaContext));

//Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Algoriza",
        Version = "v1",
        Description = "Algoriza.Applicant API Swagger surface"
    });
    options.OperationFilter<AddRequiredHeaderParameter>();
});


var app = builder.Build();

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

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Algoriza APIs");
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
