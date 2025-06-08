using Soenneker.Cloudflare.Ssl.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Cloudflare.Ssl.Tests;

[Collection("Collection")]
public sealed class CloudflareSslUtilTests : FixturedUnitTest
{
    private readonly ICloudflareSslUtil _util;

    public CloudflareSslUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<ICloudflareSslUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
