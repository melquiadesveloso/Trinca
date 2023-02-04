
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrincaChurrasAPI.Domain.Entities.Request;
using TrincaChurrasAPI.Domain.Entities.Response;

namespace TrincaChurrasAPI.Repository.Context
{
   
    public class CosmoDbContext : DbContext
    {
        public DbSet<ReservaRequest> Reservas { get; set; }

        public CosmoDbContext(DbContextOptions<CosmoDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReservaRequest>()
               .ToContainer("Reservas") // ToContainer
               .HasPartitionKey(da => da.id);

        }
    }
}
