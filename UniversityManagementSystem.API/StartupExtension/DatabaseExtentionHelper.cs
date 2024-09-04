using Microsoft.EntityFrameworkCore;

using UniversityManagementSystem.DLL.DbContext;

namespace UniversityManagementSystem.API.StartupExtension
{
    public static class DatabaseExtentionHelper
    {
        public static IServiceCollection AddDatabaseExtentionHelper(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
           
            return services;
        }

        public static IApplicationBuilder RunMigration(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                db.Database.Migrate();
            }
            return app;
        }
    }
}
