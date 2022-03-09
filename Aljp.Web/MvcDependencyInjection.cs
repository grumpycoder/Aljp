using System.Text.Json.Serialization;
using DateOnlyTimeOnly.AspNet.Converters;

namespace Aljp.Web;

public static class MvcDependencyInjection
{
    public static IServiceCollection AddMvcDependencyInjection(this IServiceCollection services)
    {
        services
            // .AddControllersWithViews(options =>
            //     // options.Filters.Add<ApiExceptionFilterAttribute>()
            // )
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
    
    // public static IServiceCollection AddMvcDependencyInjection(this IServiceCollection services)
    // {
    //     services
    //         .AddControllersWithViews(options =>
    //             // options.Filters.Add<ApiExceptionFilterAttribute>()
    //         )
    //         .AddJsonOptions(
    //             options =>
    //             {
    //                 options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
    //                 options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    //             }
    //         ).ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; });
    //
    //     services.AddRazorPages();
    //
    //     services.AddApiVersioning(options =>
    //     {
    //         options.ReportApiVersions = true;
    //         options.UseApiBehavior = true;
    //         options.AssumeDefaultVersionWhenUnspecified = true;
    //         options.DefaultApiVersion = new ApiVersion(1, 0);
    //         options.ApiVersionReader = ApiVersionReader.Combine(
    //             new QueryStringApiVersionReader(), //defaults to "api-version"
    //             new QueryStringApiVersionReader("v"),
    //             new HeaderApiVersionReader("api-version"),
    //             new HeaderApiVersionReader("v"),
    //             new MediaTypeApiVersionReader(), //defaults to "v"
    //             new MediaTypeApiVersionReader("api-version"));
    //     });
    //
    //     services.AddVersionedApiExplorer(
    //         options =>
    //         {
    //             // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
    //             // NOTE: the specified format code will format the version as "'v'major[.minor][-status]"
    //             options.GroupNameFormat = "'v'VVV";
    //             // NOTE: this option is only necessary when versioning by url segment. the SubstitutionFormat
    //             // can also be used to control the format of the API version in route templates
    //             options.SubstituteApiVersionInUrl = true;
    //         });
    //
    //     services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
    //
    //     return services;
    // }
}