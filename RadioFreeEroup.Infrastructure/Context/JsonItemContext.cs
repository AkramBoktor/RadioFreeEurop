using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RadioFreeEroup.Domain.Entities;
using System;


namespace RadioFreeEroup.Infrastructure.Context
{
    public class JsonItemContext : DbContext
    {
        public JsonItemContext(DbContextOptions<JsonItemContext> options) : base(options)
        {

        }
        //protected readonly IConfiguration Configuration;

        ////public JsonItemContext(IConfiguration configuration)
        ////{
        ////    Configuration = configuration;
        ////}
        ////protected override void OnConfiguring(DbContextOptions options)
        ////{
        ////    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        //}

        public DbSet<JsonItem> JsonItems { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<JsonItem>().HasKey(table => new { table.Id, table.Position });
        }
    }
}