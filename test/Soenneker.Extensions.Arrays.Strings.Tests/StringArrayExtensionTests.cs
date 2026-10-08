using Soenneker.Tests.Unit;
using System.Threading;

namespace Soenneker.Extensions.Arrays.Strings.Tests;

public sealed class StringArrayExtensionTests : UnitTest
{
    [Test]
    public async System.Threading.Tasks.ValueTask ContainsAPart_CanBeCalledAsExtension(CancellationToken cancellationToken)
    {
        string[] values = ["Alpha", null!, "Beta"];

        bool result = values.ContainsAPart("pha", System.StringComparison.Ordinal);

        await Assert.That(result).IsTrue();
    }
}
