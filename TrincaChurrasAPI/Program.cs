using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using MongoDB.Driver.Linq;
using Swashbuckle.AspNetCore.Swagger;
using System;
using TrincaChurrasAPI.Business.Configuration;
using TrincaChurrasAPI.Business.Interfaces;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
                                //.AddJsonOptions(opt =>
                                //{
                                //    opt.JsonSerializerOptions.Converters.Add(new TrincaChurrasAPI.Domain.Util.DataConvert.DateTimeConverter());
                                //});

builder.Services.AddAutoMapper(typeof(Program));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
                            {
                                c.SwaggerDoc("v1",
                                        new OpenApiInfo
                                        {
                                            Title = "Trinca Churras API",
                                            Version = "v1",
                                            Description = "Churrasco da Equipe Trinca",
                                            Contact = new OpenApiContact
                                            {
                                                Name = "Melquíades de Souza Veloso - Projeto",
                                                Url = new Uri("https://github.com/melquiadesveloso/Trinca")
                                            }
                                        });

                                c.MapType<DateTime>(() => new OpenApiSchema
                                {
                                    Type = "string",
                                    //Format = "date",
                                    Example = new OpenApiString("dd/MM/yyyy")
                                });

                                c.MapType<TimeSpan>(() => new OpenApiSchema
                                {
                                    
                                    Type = "string",
                                  //  Format = "date",
                                    Example = new OpenApiString("hh:mm")
                                });

                            });


builder.Services.AddRegister(builder.Configuration);
builder.Services.AddRegisterLogger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
