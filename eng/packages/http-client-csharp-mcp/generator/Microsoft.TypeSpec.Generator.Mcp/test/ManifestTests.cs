// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;
using NUnit.Framework;

namespace Microsoft.TypeSpec.Generator.Mcp.Tests;

public sealed class ManifestTests
{
    [Test]
    public void MultipleServicesAndOperationsHaveNoGeneratorSpecificIdentity()
    {
        var manifest = ManifestFixtures.Create();
        manifest.Validate();
        Assert.That(manifest.Operations.Select(t => t.Group[0]), Is.EquivalentTo(new[] { "keyvault", "servicebus" }));
        Assert.That(manifest.Operations.Select(t => t.Types.Binding), Is.Unique);
        Assert.That(manifest.Composites[0].Path, Is.EqualTo("keyvault secret list"));
    }

    [Test]
    public void OperationSelectionIsExactAndIgnoresUnselectedOperations()
    {
        var manifest = ManifestFixtures.Create();
        manifest.ValidateOperationIds(["Services.Secrets.get", "Services.Queues.remove", "Services.Secrets.list"]);
        Assert.Throws<InvalidOperationException>(() => manifest.ValidateOperationIds(["Services.Secrets.get"]));
        Assert.Throws<InvalidOperationException>(() => manifest.ValidateOperationIds(
            ["Services.Secrets.get", "Services.Queues.remove", "Services.Queues.remove"]));
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
        Assert.That(flags.Destructive, Is.EqualTo(destructive));
        Assert.That(flags.Idempotent, Is.EqualTo(idempotent));
        Assert.That(flags.ReadOnly, Is.EqualTo(readOnly));
        Assert.That(flags.OpenWorld, Is.True);
    }

    [Test]
    public void ReviewedSafetyOverridesWinAndMissingOverridesKeepDefaults()
    {
        var defaults = ToolSafety.FromHttpMethod("PUT");
        var flags = new SafetyOverrides(true, false, false, false).Apply(defaults);
        Assert.That(flags, Is.EqualTo(new ToolSafety(true, false, false, false)));
        Assert.That(new SafetyOverrides(null, null, null, null).Apply(defaults), Is.EqualTo(defaults));
        Assert.Throws<InvalidOperationException>(() => ToolSafety.FromHttpMethod("UNKNOWN"));
    }

    [TestCase("operation")]
    [TestCase("id")]
    [TestCase("group")]
    [TestCase("name")]
    [TestCase("binding")]
    [TestCase("option-type")]
    [TestCase("safety")]
    [TestCase("empty")]
    [TestCase("duplicate")]
    [TestCase("duplicate-composite")]
    [TestCase("colliding-composite")]
    [TestCase("duplicate-type")]
    [TestCase("duplicate-type-case")]
    [TestCase("duplicate-option")]
    [TestCase("reference-traversal")]
    [TestCase("invalid-namespace")]
    [TestCase("unknown-target")]
    [TestCase("unknown-argument")]
    [TestCase("ambiguous-argument")]
    [TestCase("nonprimitive-argument")]
    [TestCase("missing-cancellation")]
    [TestCase("invalid-format")]
    public void InvalidManifestIsRejected(string change)
    {
        var manifest = ManifestFixtures.Create();
        var tool = manifest.Operations[0];
        var invalidTool = change switch
        {
            "operation" => tool with { OperationId = "" },
            "id" => tool with { Id = "not-a-guid" },
            "group" => tool with { Group = ["invalid group"] },
            "name" => tool with { Name = "../bad" },
            "binding" => tool with { Binding = null! },
            "option-type" => tool with { Options = [tool.Options[0] with { Type = "unreviewed-reflection" }] },
            "safety" => tool with { Safety = null! },
            "duplicate-type" => tool with { Types = tool.Types with { Catalog = tool.Types.Options } },
            "duplicate-type-case" => tool with { Types = tool.Types with { Catalog = tool.Types.Options.ToLowerInvariant() } },
            "duplicate-option" => tool with { Options = [tool.Options[0], tool.Options[0]] },
            "unknown-target" => tool with { Binding = tool.Binding with { Calls = [tool.Binding.Calls[0] with { Target = "missing" }] } },
            "unknown-argument" => tool with
            {
                Binding = tool.Binding with
                {
                    Calls = [tool.Binding.Calls[0] with { Arguments = [new BindingArgument(Variable: "missing"), .. tool.Binding.Calls[0].Arguments] }]
                }
            },
            "ambiguous-argument" => tool with
            {
                Binding = tool.Binding with
                {
                    Calls = [tool.Binding.Calls[0] with
                {
                    Arguments = [new BindingArgument(Variable: "name", Literal: JsonSerializer.SerializeToElement("value")), .. tool.Binding.Calls[0].Arguments]
                }]
                }
            },
            "nonprimitive-argument" => tool with
            {
                Binding = tool.Binding with
                {
                    Calls = [tool.Binding.Calls[0] with
                {
                    Arguments = [new BindingArgument(Literal: JsonSerializer.SerializeToElement(new[] { 1 })), .. tool.Binding.Calls[0].Arguments]
                }]
                }
            },
            "missing-cancellation" => tool with
            {
                Binding = tool.Binding with
                {
                    Calls = [tool.Binding.Calls[0] with { Arguments = [new BindingArgument(Variable: "name")] }]
                }
            },
            "invalid-format" => tool with { ErrorMessage = "{not-valid" },
            _ => tool
        };
        var invalid = change switch
        {
            "empty" => manifest with { Operations = [] },
            "duplicate" => manifest with { Operations = [tool, tool] },
            "duplicate-composite" => manifest with { Composites = [manifest.Composites[0], manifest.Composites[0]] },
            "colliding-composite" => manifest with { Composites = [new("keyvault secret get", "Collision")] },
            "reference-traversal" => manifest with { MetadataReferences = ["..\\another.dll"] },
            "invalid-namespace" => manifest with { Namespace = "invalid..namespace" },
            _ => manifest with { Operations = [invalidTool] }
        };
        Assert.Throws<InvalidOperationException>(invalid.Validate);
    }

    [TestCase("{}")]
    [TestCase("null")]
    [TestCase("{\"namespace\":\"Example\",\"metadataReferences\":[],\"operations\":null,\"composites\":[]}")]
    public void MalformedJsonDoesNotSilentlyBecomeAnEmptyToolset(string json)
    {
        var path = Path.GetTempFileName();
        try
        {
            File.WriteAllText(path, json);
            Assert.That(() => McpManifest.Load(path),
                Throws.InstanceOf<JsonException>().Or.InstanceOf<InvalidOperationException>());
        }
        finally
        {
            File.Delete(path);
        }
    }

    [TestCase("\"unexpected\":true")]
    [TestCase("\"namespace\":\"Example.Generated\"")]
    public void UnknownAndDuplicatePropertiesInOtherwiseValidTransportAreRejected(string extra)
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

    [Test]
    public void InternalCodeModelPreservesExplicitNullLiterals()
    {
        var path = Path.GetTempFileName();
        try
        {
            var manifest = ManifestFixtures.Create();
            File.WriteAllText(path, JsonSerializer.Serialize(manifest, ManifestFixtures.JsonOptions));
            var loaded = McpManifest.Load(path);
            Assert.That(JsonSerializer.Serialize(loaded), Is.EqualTo(JsonSerializer.Serialize(manifest)));
            Assert.That(loaded.Operations[0].Binding.Calls[0].Arguments[1].Literal.ValueKind, Is.EqualTo(JsonValueKind.Null));
        }
        finally
        {
            File.Delete(path);
        }
    }
}
