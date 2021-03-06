global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.ComponentModel.DataAnnotations;
global using Microsoft.EntityFrameworkCore;
global using MicroServicesWebApi.Models;
global using MicroServicesWebApi.DataAccess;
global using AutoMapper;
global using MicroServicesWebApi.DTOs;
global using Microsoft.AspNetCore.Mvc;
global using System.Text.Json;
global using System.Text;
global using Microsoft.Extensions.Configuration;
global using MicroServicesWebApi.SyncDataServices.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Dbcontext will be moved to sqlserwer later
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMem"));
builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();
builder.Services.AddHttpClient<ICommandDataClient,HttpCommandDataClient>();
builder.Services.AddControllers();
//builder.Services.AddControllersWithViews(options => { options.SuppressAsyncSuffixInActionNames = false; });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

System.Console.WriteLine($"--> CommandService Endpoint {builder.Configuration["CommandService"]}");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();
//app.UseRouting();

app.UseAuthorization();

app.MapControllers();

PrepDb.PrepPopulation(app);

app.Run();

