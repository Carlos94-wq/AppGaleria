using Fotos.Core.Interfaces;
using Fotos.Infra.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Fotos.Infra.Extensions
{
    public static class ServicesCollection
    {
        public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            string ConnectionStrings = configuration.GetConnectionString("GALERIA");

            services.AddTransient<IDbConnection>(options => new SqlConnection(ConnectionStrings));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IFotoRepository, FotoRepository>();
            return services;
        }
    }
}
