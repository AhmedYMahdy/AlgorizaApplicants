using System.Reflection;
using AlgorizaApplicants.API.Helpers;
using AlgorizaApplicants.DAL.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AlgorizaContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("AlgorizaCS")));
builder.Services.AddScoped(typeof(AlgorizaContext));

var swaggerXmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
var swaggerXmlFilePath = Path.Combine(AppContext.BaseDirectory, swaggerXmlFileName);
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Algoriza",
        Version = "v1",
        Description = "Algoriza.Applicant API Swagger surface"
    });
    options.OperationFilter<AddRequiredHeaderParameter>();
    //options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    //{
    //    In = ParameterLocation.Header,
    //    Type = SecuritySchemeType.Http,
    //    Name = "Authorization",
    //    Scheme = "bearer",
    //    BearerFormat = "JWT",
    //    Description = "Specify the authorization token."
    //});
    //options.AddSecurityRequirement(new OpenApiSecurityRequirement
    //{
    //    {
    //        new OpenApiSecurityScheme
    //        {
    //            Reference = new OpenApiReference
    //            {
    //                Type = ReferenceType.SecurityScheme,
    //                Id = "Bearer"
    //            }
    //        },
    //        new string[] { }
    //    }
    //});
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
