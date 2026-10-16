// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using NUnit.Framework;

namespace StorageMcp.Generator.Tests;

public sealed class OptionsSyntaxAdapterTests
{
    private const string Source = """
        #nullable disable
        public partial class Options
        {
            public string Account { get; set; }
            public string Container { get; set; }
            public string Tenant { get; set; }
        }
        """;

    [Test]
    public void RequirednessAndNullableContextArePreserved()
    {
        var result = OptionsSyntaxAdapter.RewriteSource(Source);
        Assert.That(result, Does.Contain("#nullable enable"));
        Assert.That(result, Does.Contain("public required string Account"));
        Assert.That(result, Does.Contain("public required string Container"));
        Assert.That(result, Does.Contain("public string? Tenant"));
        Assert.That(OptionsSyntaxAdapter.RewriteSource(result), Is.EqualTo(result));
    }

    [Test]
    public void UnexpectedOrInvalidSyntaxFailsClosed()
    {
        Assert.Throws<InvalidOperationException>(() => OptionsSyntaxAdapter.RewriteSource(Source.Replace("Tenant", "Subscription", StringComparison.Ordinal)));
        Assert.Throws<InvalidOperationException>(() => OptionsSyntaxAdapter.RewriteSource("class {"));
    }

    [Test]
    public void DirectiveTextInsideDescriptionsIsNotRewritten()
    {
        var source = Source.Replace("public string Tenant", """
            [System.ComponentModel.Description("#nullable disable")]
            public string Tenant
            """, StringComparison.Ordinal);
        var result = OptionsSyntaxAdapter.RewriteSource(source);
        Assert.That(result, Does.Contain("#nullable enable"));
        Assert.That(result, Does.Contain("""Description("#nullable disable")"""));
    }
}
