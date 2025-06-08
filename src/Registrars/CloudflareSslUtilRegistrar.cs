using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Cloudflare.Ssl.Abstract;
using Soenneker.Cloudflare.Utils.Client.Registrars;

namespace Soenneker.Cloudflare.Ssl.Registrars;

/// <summary>
/// A utility for managing Cloudflare SSL settings
/// </summary>
public static class CloudflareSslUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="ICloudflareSslUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddCloudflareSslUtilAsSingleton(this IServiceCollection services)
    {
        services.AddCloudflareClientUtilAsSingleton().TryAddSingleton<ICloudflareSslUtil, CloudflareSslUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="ICloudflareSslUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddCloudflareSslUtilAsScoped(this IServiceCollection services)
    {
        services.AddCloudflareClientUtilAsSingleton().TryAddScoped<ICloudflareSslUtil, CloudflareSslUtil>();

        return services;
    }
}
