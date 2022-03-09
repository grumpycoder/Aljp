using System.Text.Json.Serialization;
using DateOnlyTimeOnly.AspNet.Converters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace Aljp.Web;

public static class MvcDependencyInjection
{
    public static IServiceCollection AddMvcDependencyInjection(this IServiceCollection services)
    {
        services
            .AddControllersWithViews()
            .AddJsonOptions(
                options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                }
            ).ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; });
        
        services.AddRazorPages();
        services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
        
        return services;
    }
   
}