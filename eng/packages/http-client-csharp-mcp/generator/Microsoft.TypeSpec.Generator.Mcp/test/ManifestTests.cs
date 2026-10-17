// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;
using NUnit.Framework;

namespace Microsoft.TypeSpec.Generator.Mcp.Tests;

public sealed class ManifestTests
{
    [Test]
    public void MultipleOperationsDeriveNamesWithoutGeneratorSpecificIdentity()
    {
        var manifest = ManifestFixtures.Create();
        manifest.Validate();
        Assert.That(manifest.Commands.Select(tool => tool.Path.Split(' ')[0]), Is.EquivalentTo(new[] { "keyvault", "servicebus" }));
        Assert.That(manifest.Commands.Select(tool => tool.CommandType),
            Is.EqualTo(new[] { "Services.SecretGetCommand", "Services.QueueRemoveCommand" }));
    }

    [Test]
    public void OperationSelectionIsExactAndIgnoresUnselectedOperations()
    {
        var manifest = ManifestFixtures.Create();
        manifest.ValidateOperationIds(["Services.Secret.get", "Services.Queue.remove", "Services.Secret.list"]);
        Assert.Throws<InvalidOperationException>(() => manifest.ValidateOperationIds(["Services.Secret.get"]));
        Assert.Throws<InvalidOperationException>(() => manifest.ValidateOperationIds(
            ["Services.Secret.get", "Services.Queue.remove", "Services.Queue.remove"]));
    }

    [TestCase("GET", false, true, true)]
    [TestCase("head", false, true, true)]
    [TestCase("OPTIONS", false, true, true)]
    [TestCase("PUT", true, true, false)]
    [TestCase("DELETE", true, true, false)]
    [TestCase("POST", true, false, false)]
    [TestCase("PATCH", true, false, false)]
    public void SafetyDefaultsAreConservative(string verb, bool destructive, bool idempotent, bool readOnly)
    {
        var flags = ToolSafety.FromHttpMethod(verb);
        Assert.That(flags, Is.EqualTo(new ToolSafety(destructive, idempotent, readOnly, true)));
    }

    [Test]
    public void ReviewedSafetyOverridesWinAndMissingOverridesKeepDefaults()
    {
        var defaults = ToolSafety.FromHttpMethod("PUT");
        Assert.That(new SafetyOverrides(true, false, false, false).Apply(defaults), Is.EqualTo(new ToolSafety(true, false, false, false)));
        Assert.That(new SafetyOverrides().Apply(defaults), Is.EqualTo(defaults));
        Assert.Throws<InvalidOperationException>(() => ToolSafety.FromHttpMethod("UNKNOWN"));
    }

    [TestCase("operation")]
    [TestCase("id")]
    [TestCase("path")]
    [TestCase("title")]
    [TestCase("safety")]
    [TestCase("namespace")]
    [TestCase("outside-service")]
    [TestCase("empty")]
    [TestCase("duplicate")]
    [TestCase("duplicate-id")]
    [TestCase("duplicate-path")]
    [TestCase("duplicate-output")]
    [TestCase("duplicate-output-case")]
    public void InvalidCodeModelIsRejected(string change)
    {
        var manifest = ManifestFixtures.Create();
        var command = manifest.Commands[0];
        var invalid = change switch
        {
            "operation" => command with { OperationId = "not-the-source-operation" },
            "id" => command with { Id = "invalid" },
            "path" => command with { Path = "../bad" },
            "title" => command with { Title = "" },
            "safety" => command with { Safety = null! },
            "namespace" => command with { Namespace = "invalid..namespace" },
            "outside-service" => command with { Namespace = "Other", OperationId = "Other.Secret.get" },
            _ => command
        };
        var model = change switch
        {
            "empty" => manifest with { Commands = [] },
            "duplicate" => manifest with { Commands = [command, command] },
            "duplicate-id" => manifest with { Commands = [command, manifest.Commands[1] with { Id = command.Id }] },
            "duplicate-path" => manifest with { Commands = [command, manifest.Commands[1] with { Path = command.Path }] },
            "duplicate-output" => manifest with { Commands = [command, command with
                { Namespace = "Services.Nested", OperationId = "Services.Nested.Secret.get", Id = manifest.Commands[1].Id, Path = "other get" }] },
            "duplicate-output-case" => manifest with { Commands = [command, command with
                { InterfaceName = "secret", OperationId = "Services.secret.get", Id = manifest.Commands[1].Id, Path = "other get" }] },
            _ => manifest with { Commands = [invalid] }
        };
        Assert.Throws<InvalidOperationException>(model.Validate);
    }

    [TestCase("{}")]
    [TestCase("null")]
    [TestCase("{\"namespace\":\"Example\",\"commands\":null}")]
    public void MalformedJsonDoesNotSilentlyBecomeAnEmptyToolset(string json)
    {
        var path = Path.GetTempFileName();
        try
        {
            File.WriteAllText(path, json);
            Assert.That(() => McpManifest.Load(path), Throws.InstanceOf<JsonException>().Or.InstanceOf<InvalidOperationException>());
        }
        finally
        {
            File.Delete(path);
        }
    }

    [TestCase("\"unexpected\":true")]
    [TestCase("\"namespace\":\"Other\"")]
    [TestCase("\"metadataReferences\":[]")]
    public void UnknownDuplicateAndOldClrConfigurationAreRejected(string extra)
    {
        var path = Path.GetTempFileName();
        try
        {
            var json = JsonSerializer.Serialize(ManifestFixtures.Create(), ManifestFixtures.JsonOptions);
            File.WriteAllText(path, json[..^1] + "," + extra + "}");
            Assert.Throws<JsonException>(() => McpManifest.Load(path));
        }
        finally
        {
            File.Delete(path);
        }
    }
}
