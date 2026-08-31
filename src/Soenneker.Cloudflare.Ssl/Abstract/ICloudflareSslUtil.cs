using System;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Cloudflare.OpenApiClient.Models;

namespace Soenneker.Cloudflare.Ssl.Abstract;

/// <summary>
/// A utility for managing Cloudflare Universal SSL settings for zones.
/// This interface provides methods to get, update, enable, and disable Universal SSL.
/// </summary>
public interface ICloudflareSslUtil
{
    /// <summary>
    /// Retrieves the current Universal SSL settings for a specified zone.
    /// </summary>
    /// <param name="zoneId">The unique identifier of the zone to get SSL settings for.</param>
    /// <param name="cancellationToken">Optional token to cancel the operation.</param>
    /// <returns>A response containing the current Universal SSL settings for the zone.</returns>
    ValueTask<TlsCertificatesAndHostnamesSslUniversalSettingsResponse?> GetSslSettings(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the Universal SSL settings for a specified zone.
    /// </summary>
    /// <param name="zoneId">The unique identifier of the zone to update SSL settings for.</param>
    /// <param name="settings">The new SSL settings to apply to the zone.</param>
    /// <param name="cancellationToken">Optional token to cancel the operation.</param>
    /// <returns>A response containing the updated Universal SSL settings for the zone.</returns>
    ValueTask<TlsCertificatesAndHostnamesSslUniversalSettingsResponse?> UpdateSslSettings(string zoneId, TlsCertificatesAndHostnamesUniversal settings,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Enables Universal SSL certificate issuance for a zone.
    /// </summary>
    /// <param name="zoneId">The unique identifier of the zone.</param>
    /// <param name="cancellationToken">Optional token to cancel the operation.</param>
    /// <returns>A response containing the updated Universal SSL settings for the zone.</returns>
    ValueTask<TlsCertificatesAndHostnamesSslUniversalSettingsResponse?> EnableUniversalSsl(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Disables Universal SSL certificate issuance for a zone.
    /// </summary>
    /// <param name="zoneId">The unique identifier of the zone.</param>
    /// <param name="cancellationToken">Optional token to cancel the operation.</param>
    /// <returns>A response containing the updated Universal SSL settings for the zone.</returns>
    ValueTask<TlsCertificatesAndHostnamesSslUniversalSettingsResponse?> DisableUniversalSsl(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Enables Universal SSL. This legacy name does not enable HTTP-to-HTTPS redirects.
    /// </summary>
    [Obsolete("This method controls Universal SSL, not Always Use HTTPS. Use EnableUniversalSsl instead.")]
    ValueTask<TlsCertificatesAndHostnamesSslUniversalSettingsResponse?> EnableAlwaysUseHttps(string zoneId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Disables Universal SSL. This legacy name does not disable HTTP-to-HTTPS redirects.
    /// </summary>
    [Obsolete("This method controls Universal SSL, not Always Use HTTPS. Use DisableUniversalSsl instead.")]
    ValueTask<TlsCertificatesAndHostnamesSslUniversalSettingsResponse?> DisableAlwaysUseHttps(string zoneId,
        CancellationToken cancellationToken = default);
}
