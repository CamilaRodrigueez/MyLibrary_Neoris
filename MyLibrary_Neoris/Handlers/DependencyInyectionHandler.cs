using Common.Utils.RestServices;
using Common.Utils.RestServices.Interface;
using Microsoft.Extensions.DependencyInjection;
using MiLibrary.Domain.Services;
using MiLibrary.Domain.Services.Interface;
using MyLibrary.Domain.Services;
using MyLibrary.Domain.Services.Interface;

namespace MyLibrary_Neoris.Handlers
{
    public static class DependencyInyectionHandler
    {
        public static void DependencyInyectionConfig(IServiceCollection services)
        {


            // Domain
            services.AddTransient<IUserServices, UserServices>();
            services.AddTransient<IBooksServices, BooksServices>();
            services.AddTransient<IEditorialServices, EditorialServices>();
            services.AddTransient<IAuthorsServices, AuthorsServices>();



            //rest service
            services.AddTransient<IRestService, RestService>();

        }
    }
}
