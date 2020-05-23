using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using TodoApi.Models;

namespace TodoApi.Database
{
  public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TodoContext>
  {
    public TodoContext CreateDbContext(string[] args)
    {
      var directory = Directory.GetCurrentDirectory();
      var configuration = new ConfigurationBuilder()
          .SetBasePath(directory)
          .AddJsonFile("appsettings.Development.json")
          .Build();

      var builder = new DbContextOptionsBuilder<TodoContext>();
      var connectionString = configuration.GetConnectionString("DatabaseConnection");

      builder.UseSqlServer(connectionString);
      return new TodoContext(builder.Options);
    }
  }
}
