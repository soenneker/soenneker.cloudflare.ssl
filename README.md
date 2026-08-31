[![](https://img.shields.io/nuget/v/soenneker.cloudflare.ssl.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.cloudflare.ssl/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.cloudflare.ssl/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.cloudflare.ssl/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.cloudflare.ssl.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.cloudflare.ssl/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.cloudflare.ssl/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.cloudflare.ssl/actions/workflows/codeql.yml)

# Soenneker.Cloudflare.Ssl

Reads and changes Cloudflare Universal SSL settings for a zone.

## Installation

```bash
dotnet add package Soenneker.Cloudflare.Ssl
```

## Configuration

```json
{
  "Cloudflare": {
    "ApiKey": "your-api-token"
  }
}
```

The token needs permission to read and edit SSL settings for the target zone.

## Registration

```csharp
using Soenneker.Cloudflare.Ssl.Registrars;

services.AddCloudflareSslUtilAsScoped();
```

Singleton registration is available with `AddCloudflareSslUtilAsSingleton()`.

## Usage

```csharp
using Soenneker.Cloudflare.Ssl.Abstract;
using Soenneker.Cloudflare.OpenApiClient.Models;

TlsCertificatesAndHostnamesSslUniversalSettingsResponse? settings =
    await ssl.GetSslSettings(zoneId, cancellationToken);

await ssl.EnableUniversalSsl(zoneId, cancellationToken);
```

`UpdateSslSettings` accepts the generated `TlsCertificatesAndHostnamesUniversal` model for changes that need more than the enable/disable helpers.

Universal SSL controls Cloudflare-managed certificate issuance. It is not the **Always Use HTTPS** redirect setting. Use `Soenneker.Cloudflare.Security` when you need to redirect HTTP requests to HTTPS. The legacy `EnableAlwaysUseHttps` and `DisableAlwaysUseHttps` names remain as obsolete compatibility aliases, but they still control Universal SSL only.

Disabling Universal SSL can remove HTTPS coverage for proxied hostnames. Confirm alternate certificate coverage before doing so. Generated Cloudflare API exceptions are propagated, and response envelopes may be null when the API returns no body.
