using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Todo.DAL
{
    public static class Bootstrapper
    {
        public static void UseTodoInMemoryDataAccess(this IServiceCollection services, DbConfig config)
        {
            if (services == null || string.IsNullOrWhiteSpace(config?.ConnectionString))
            {
                throw new Exception("Both services and a valid database configuration is required");
            }

            services.AddScoped(provider => config);
            services.AddScoped<ITodoRepository, InMemoryTodoRepository>();
        }
    }
}
