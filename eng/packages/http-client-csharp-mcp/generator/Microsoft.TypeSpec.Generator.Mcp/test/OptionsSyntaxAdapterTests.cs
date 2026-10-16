// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Microsoft.TypeSpec.Generator.Mcp.Tests;

public sealed class OptionsSyntaxAdapterTests
{
    private static readonly OptionMapping[] Options =
    [
        new("Account", "string", true, Description: "Account"),
        new("Container", "string", true, Description: "Container"),
        new("Tenant", "string", false, Description: "Tenant")
    ];
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
        var result = OptionsSyntaxAdapter.RewriteSource(Source, Options);
        Assert.That(result, Does.Contain("#nullable enable"));
        Assert.That(result, Does.Contain("public required string Account"));
        Assert.That(result, Does.Contain("public required string Container"));
        Assert.That(result, Does.Contain("public string? Tenant"));
        Assert.That(OptionsSyntaxAdapter.RewriteSource(result, Options), Is.EqualTo(result));
    }

    [Test]
    public void UnexpectedOrInvalidSyntaxFailsClosed()
    {
        Assert.Throws<InvalidOperationException>(() => OptionsSyntaxAdapter.RewriteSource(Source.Replace("Tenant", "Subscription", StringComparison.Ordinal), Options));
        Assert.Throws<InvalidOperationException>(() => OptionsSyntaxAdapter.RewriteSource("class {", Options));
    }

    [Test]
    public void DirectiveTextInsideDescriptionsIsNotRewritten()
    {
        var source = Source.Replace("public string Tenant", """
            [System.ComponentModel.Description("#nullable disable")]
            public string Tenant
            """, StringComparison.Ordinal);
        var result = OptionsSyntaxAdapter.RewriteSource(source, Options);
        Assert.That(result, Does.Contain("#nullable enable"));
        Assert.That(result, Does.Contain("""Description("#nullable disable")"""));
    }

    [Test]
    public void ArbitraryOptionNamesAndValueTypesAreSupported()
    {
        const string source = "#nullable disable\npublic class Options { public string Vault { get; set; } public int Count { get; set; } }";
        OptionMapping[] options = [new("Vault", "string", true), new("Count", "int", false)];
        var result = OptionsSyntaxAdapter.RewriteSource(source, options);
        Assert.That(result, Does.Contain("required string Vault"));
        Assert.That(result, Does.Contain("int? Count"));
        Assert.That(OptionsSyntaxAdapter.RewriteSource(result, options), Is.EqualTo(result));
    }
}
