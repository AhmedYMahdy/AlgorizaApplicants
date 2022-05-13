using System.Reflection;
using AlgorizaApplicants.API.Helpers;
using AlgorizaApplicants.DAL.DbContext;
using AlgorizaApplicants.DAL.DTOs;
using AlgorizaApplicants.DAL.Helpers;
using AlgorizaApplicants.DAL.RepositoryAbstraction;
using AlgorizaApplicants.Services.MapperConfiguration;
using AlgorizaApplicants.Services.RepositoryImplementation;
using AlgorizaApplicants.Services.Service.Abstraction;
using AlgorizaApplicants.Services.Service.Implementation;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().
    AddFluentValidation(fv=>
    fv.RegisterValidatorsFromAssemblyContaining<ApplicantValidator>());

//Register DB and Context
builder.Services.AddDbContext<AlgorizaContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("AlgorizaCS")));
builder.Services.AddScoped(typeof(AlgorizaContext));
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

//Register Repositories
builder.Services.AddScoped<IApplicantsRepository, ApplicantsRepository>();

//Register Services
builder.Services.AddTransient<IApplicantsService, ApplicantsService>();
builder.Services.AddTransient<ICountriesService, CountriesService>();

//Register HttpClient
builder.Services.AddHttpClient();

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

builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MapperConfig)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //    app.UseExceptionHandler("/Home/Error");
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
    pattern: "api/{controller=ApplicantsFV}/{action=Applicants}/{id?}");

app.Run();
