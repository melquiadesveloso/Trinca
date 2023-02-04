using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrincaChurrasAPI.Business.Interfaces;
using TrincaChurrasAPI.Business.Services;
using TrincaChurrasAPI.Business.Settings;
using TrincaChurrasAPI.Domain.Entities;
using TrincaChurrasAPI.Repository;
using TrincaChurrasAPI.Repository.Base;
using TrincaChurrasAPI.Repository.Context;
using TrincaChurrasAPI.Repository.Interfaces;

namespace TrincaChurrasAPI.Business.Configuration
{
    public static class RegisterTypes
    {
        public static void AddRegister(this IServiceCollection services, IConfiguration configuration)
        {

            //database
            var mongoDb = configuration.GetSection("MogonDBSetting").Get<MongoDBSetting>();
              
            services.AddDbContext<CosmoDbContext>(options => options.UseCosmos(mongoDb.ServiceEndpoint, mongoDb.AuthKey, mongoDb.DatabaseName)
                .LogTo(message => Console.WriteLine(message))
            );
         
            services.AddTransient<CosmoDbContext>();

            //repositorys
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));


            //Services
            services.AddScoped<IReservaServices, ReservaServices>();


        }
    }
}
