using System.Threading;
using System.Threading.Tasks;
using Soenneker.Cloudflare.OpenApiClient.Models;

namespace Soenneker.Cloudflare.Ssl.Abstract;

/// <summary>
/// A utility for managing Cloudflare Universal SSL settings for zones.
/// This interface provides methods to get, update, enable, and disable SSL settings,
/// particularly focusing on the "Always Use HTTPS" feature.
/// </summary>
public interface ICloudflareSslUtil
{
    /// <summary>
    /// Retrieves the current Universal SSL settings for a specified zone.
    /// </summary>
    /// <param name="zoneId">The unique identifier of the zone to get SSL settings for.</param>
    /// <param name="cancellationToken">Optional token to cancel the operation.</param>
    /// <returns>A response containing the current Universal SSL settings for the zone.</returns>
    ValueTask<Tls_certificates_and_hostnames_ssl_universal_settings_response?> GetSslSettings(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the Universal SSL settings for a specified zone.
    /// </summary>
    /// <param name="zoneId">The unique identifier of the zone to update SSL settings for.</param>
    /// <param name="settings">The new SSL settings to apply to the zone.</param>
    /// <param name="cancellationToken">Optional token to cancel the operation.</param>
    /// <returns>A response containing the updated Universal SSL settings for the zone.</returns>
    ValueTask<Tls_certificates_and_hostnames_ssl_universal_settings_response?> UpdateSslSettings(string zoneId, Tls_certificates_and_hostnames_universal settings,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Enables the "Always Use HTTPS" feature for a specified zone.
    /// This will automatically redirect all HTTP traffic to HTTPS.
    /// </summary>
    /// <param name="zoneId">The unique identifier of the zone to enable Always Use HTTPS for.</param>
    /// <param name="cancellationToken">Optional token to cancel the operation.</param>
    /// <returns>A response containing the updated Universal SSL settings for the zone.</returns>
    ValueTask<Tls_certificates_and_hostnames_ssl_universal_settings_response?> EnableAlwaysUseHttps(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Disables the "Always Use HTTPS" feature for a specified zone.
    /// This will allow both HTTP and HTTPS traffic without automatic redirection.
    /// </summary>
    /// <param name="zoneId">The unique identifier of the zone to disable Always Use HTTPS for.</param>
    /// <param name="cancellationToken">Optional token to cancel the operation.</param>
    /// <returns>A response containing the updated Universal SSL settings for the zone.</returns>
    ValueTask<Tls_certificates_and_hostnames_ssl_universal_settings_response?> DisableAlwaysUseHttps(string zoneId, CancellationToken cancellationToken = default);
}