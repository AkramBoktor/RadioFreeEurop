using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioFreeEroup.Infrastructure.Context
{
    public class JsonItemContextFactory : IDesignTimeDbContextFactory<JsonItemContext>
    {
        public JsonItemContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<JsonItemContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            dbContextOptionsBuilder.UseSqlServer(connectionString);
            return new JsonItemContext(dbContextOptionsBuilder.Options);

        }
    }
}
