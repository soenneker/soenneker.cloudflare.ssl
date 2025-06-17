using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Cloudflare.OpenApiClient;
using Soenneker.Cloudflare.Ssl.Abstract;
using Soenneker.Cloudflare.OpenApiClient.Models;
using Soenneker.Cloudflare.Utils.Client.Abstract;
using Soenneker.Extensions.Task;
using Soenneker.Extensions.ValueTask;

namespace Soenneker.Cloudflare.Ssl;

///<inheritdoc cref="ICloudflareSslUtil"/>
public sealed class CloudflareSslUtil : ICloudflareSslUtil
{
    private readonly ICloudflareClientUtil _client;
    private readonly ILogger<CloudflareSslUtil> _logger;

    public CloudflareSslUtil(ICloudflareClientUtil client, ILogger<CloudflareSslUtil> logger)
    {
        _client = client;
        _logger = logger;
    }

    public async ValueTask<TlsCertificatesAndHostnames_ssl_universal_settings_response> GetSslSettings(string zoneId,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Getting SSL settings for zone {ZoneId}", zoneId);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            return await client.Zones[zoneId].Ssl.Universal.Settings.GetAsync(cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting SSL settings for zone {ZoneId}", zoneId);
            throw;
        }
    }

    public async ValueTask<TlsCertificatesAndHostnames_ssl_universal_settings_response> UpdateSslSettings(string zoneId,
        TlsCertificatesAndHostnames_universal settings, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Updating SSL settings for zone {ZoneId}", zoneId);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            return await client.Zones[zoneId].Ssl.Universal.Settings.PatchAsync(settings, cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating SSL settings for zone {ZoneId}", zoneId);
            throw;
        }
    }

    public async ValueTask<TlsCertificatesAndHostnames_ssl_universal_settings_response> EnableAlwaysUseHttps(string zoneId,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Enabling always use HTTPS for zone {ZoneId}", zoneId);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var settings = new TlsCertificatesAndHostnames_universal
            {
                Enabled = true
            };

            return await client.Zones[zoneId].Ssl.Universal.Settings.PatchAsync(settings, cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error enabling always use HTTPS for zone {ZoneId}", zoneId);
            throw;
        }
    }

    public async ValueTask<TlsCertificatesAndHostnames_ssl_universal_settings_response> DisableAlwaysUseHttps(string zoneId,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Disabling always use HTTPS for zone {ZoneId}", zoneId);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var settings = new TlsCertificatesAndHostnames_universal
            {
                Enabled = false
            };

            return await client.Zones[zoneId].Ssl.Universal.Settings.PatchAsync(settings, cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error disabling always use HTTPS for zone {ZoneId}", zoneId);
            throw;
        }
    }
}