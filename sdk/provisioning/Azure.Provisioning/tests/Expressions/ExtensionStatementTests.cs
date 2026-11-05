// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Expressions;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.Expressions;

public class ExtensionStatementTests
{
    [Test]
    public void WritesNamedReferenceWithoutOptionalClauses()
    {
        ExtensionStatement statement = new(new IdentifierExpression("kubernetes"));
        Assert.That(statement.ToString().Trim(), Is.EqualTo("extension kubernetes"));
    }

    [TestCase(null)]
    [TestCase("graph")]
    public void WritesArtifactReferenceAndOptionalAlias(string? alias)
    {
        ExtensionStatement statement = new(new StringLiteralExpression("./it's-local.tgz"), alias: alias);
        string expected = "extension './it\\'s-local.tgz'" + (alias is null ? "" : $" as {alias}");
        Assert.That(statement.ToString().Trim(), Is.EqualTo(expected));
    }

    [Test]
    public void WritesConfigurationBeforeAlias()
    {
        ExtensionStatement statement = new(
            new IdentifierExpression("kubernetes"),
            new ObjectExpression(new PropertyExpression("namespace", new StringLiteralExpression("default"))),
            "k8s");

        Assert.That(statement.ToString().Trim().NormalizeLineEndings(), Is.EqualTo(
            """
            extension kubernetes with {
              namespace: 'default'
            } as k8s
            """.NormalizeLineEndings()));
    }

    [Test]
    public void PreservesExplicitEmptyConfiguration()
    {
        ExtensionStatement statement = new(new IdentifierExpression("custom"), new ObjectExpression());
        Assert.That(statement.ToString().Trim(), Is.EqualTo("extension custom with { }"));
    }
}
