using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Qa.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class QaDbContextFactory : IDesignTimeDbContextFactory<QaDbContext>
{
    public QaDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        QaEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<QaDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new QaDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Qa.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
