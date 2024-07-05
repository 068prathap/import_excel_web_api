using ImportExcel.Jobs;
using ImportExcel.Models;
using ImportExcel.Schedular;
using Quartz.Impl;
using Quartz.Spi;
using Quartz;
using ImportExcel.JobFactory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ImportExcel.Data;
using ImportExcel.Repo;

var builder = WebApplication.CreateBuilder(args);

//db connection
builder.Services.AddDbContext<ImportExcelContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ImportExcelContext") ?? throw new InvalidOperationException("Connection string 'ImportExcelContext' not found.")));

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//job scheduler
builder.Services.AddSingleton<IJobFactory, JobFactory>();
builder.Services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

builder.Services.AddSingleton<NotificationJob>();
builder.Services.AddSingleton(new JobMetadata(Guid.NewGuid(), typeof(NotificationJob), "Notify Job", "0 */1 * ? * *"));

builder.Services.AddHostedService<MySchedular>();

// interface
builder.Services.AddScoped<IStudentRepo, StudentRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();