using GetJobHelper.API.DBContexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetJobHelpel.API.Integration.Tests
{
    internal class GetJobHelpelWebApplicationTests : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(service =>
            {
                service.RemoveAll(typeof(DbContextOptions<GetJobDBContext>));
                service.AddDbContext<GetJobDBContext>(context =>
                {
                    context.UseInMemoryDatabase("TestRecruitDB");
                });

                var dbContext = CreateDBContext(service);
                dbContext.Database.EnsureDeleted();
            });
        }
        private static GetJobDBContext CreateDBContext(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<GetJobDBContext>();
            return dbContext;
        }
    }
}
