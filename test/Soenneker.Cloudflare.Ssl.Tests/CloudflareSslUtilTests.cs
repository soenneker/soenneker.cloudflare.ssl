using Soenneker.Cloudflare.Ssl.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Cloudflare.Ssl.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class CloudflareSslUtilTests : HostedUnitTest
{
    private readonly ICloudflareSslUtil _util;

    public CloudflareSslUtilTests(Host host) : base(host)
    {
        _util = Resolve<ICloudflareSslUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
