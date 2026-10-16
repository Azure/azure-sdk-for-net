// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;
using StorageMcp.Generator;
using NUnit.Framework;

namespace StorageMcp.Generator.Tests;

public sealed class ManifestTests
{
    private static StorageManifest Manifest => new(
        [new ToolSelection("StoragePilot.Containers.create", "f5088334-e630-4df0-a5be-ac87787acad0",
            ["storage", "blob", "container"], "create", "Create a container", "blob-container-create-private",
            ["account", "tenant"], true, new SafetyOverrides(true, false, false, false))],
        [
            new CompositeSelection("storage account get", "Handwritten account composite."),
            new CompositeSelection("storage blob container get", "Handwritten container composite."),
            new CompositeSelection("storage blob get", "Handwritten blob composite.")
        ]);

    [Test]
    public void ReviewedManifestPreservesExistingIdentityAndComposites()
    {
        var manifest = Manifest;
        manifest.Validate();
        Assert.That(manifest.Operations, Has.Length.EqualTo(1));
        var tool = manifest.Operations[0];
        Assert.That(tool.Id, Is.EqualTo("f5088334-e630-4df0-a5be-ac87787acad0"));
        Assert.That(tool.OperationId, Is.EqualTo("StoragePilot.Containers.create"));
        Assert.That(tool.Group, Is.EqualTo(new[] { "storage", "blob", "container" }));
        Assert.That(tool.AmbientParameters, Is.EqualTo(new[] { "account", "tenant" }));
        Assert.That(tool.UseDescriptionOverride, Is.True);
        Assert.That(manifest.Composites.Any(c => c.Path == "storage account get"), Is.True);
        Assert.That(manifest.Composites.Any(c => c.Path == "storage blob container get"), Is.True);
        Assert.That(manifest.Composites.Any(c => c.Path == "storage blob get"), Is.True);
    }

    [Test]
    public void OperationSelectionIsExactAndIgnoresUnselectedOperations()
    {
        Manifest.ValidateOperationIds(["StoragePilot.Containers.create", "StoragePilot.Containers.get"]);
        Assert.Throws<InvalidOperationException>(() => Manifest.ValidateOperationIds(["StoragePilot.Containers.get"]));
        Assert.Throws<InvalidOperationException>(() => Manifest.ValidateOperationIds(
            ["StoragePilot.Containers.create", "StoragePilot.Containers.create"]));
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
        var flags = Manifest.Operations[0].Safety.Apply(defaults);
        Assert.That(flags.Destructive, Is.True);
        Assert.That(flags.Idempotent, Is.False);
        Assert.That(flags.ReadOnly, Is.False);
        Assert.That(flags.OpenWorld, Is.False);
        Assert.That(new SafetyOverrides(null, null, null, null).Apply(defaults), Is.EqualTo(defaults));
        Assert.Throws<InvalidOperationException>(() => ToolSafety.FromHttpMethod("UNKNOWN"));
    }

    [TestCase("operation")]
    [TestCase("id")]
    [TestCase("group")]
    [TestCase("name")]
    [TestCase("binding")]
    [TestCase("ambient")]
    [TestCase("safety")]
    [TestCase("empty")]
    [TestCase("multiple")]
    [TestCase("duplicate-composite")]
    [TestCase("colliding-composite")]
    public void InvalidManifestIsRejected(string change)
    {
        var manifest = Manifest;
        var tool = manifest.Operations[0];
        var invalid = change switch
        {
            "operation" => manifest with { Operations = [tool with { OperationId = "" }] },
            "id" => manifest with { Operations = [tool with { Id = "not-a-guid" }] },
            "group" => manifest with { Operations = [tool with { Group = ["storage", "wrong"] }] },
            "name" => manifest with { Operations = [tool with { Name = "delete" }] },
            "binding" => manifest with { Operations = [tool with { Binding = "unreviewed-reflection" }] },
            "ambient" => manifest with { Operations = [tool with { AmbientParameters = ["subscription"] }] },
            "safety" => manifest with { Operations = [tool with { Safety = null! }] },
            "empty" => manifest with { Operations = [] },
            "multiple" => manifest with { Operations = [tool, tool] },
            "duplicate-composite" => manifest with { Composites = [manifest.Composites[0], manifest.Composites[0]] },
            "colliding-composite" => manifest with { Composites = [new("storage blob container create", "Collision")] },
            _ => throw new InvalidOperationException(change)
        };
        Assert.Throws<InvalidOperationException>(invalid.Validate);
    }

    [TestCase("{}")]
    [TestCase("null")]
    [TestCase("{\"operations\":[],\"composites\":[],\"typo\":true}")]
    [TestCase("{\"operations\":[],\"operations\":[],\"composites\":[]}")]
    [TestCase("{\"operations\":null,\"composites\":[]}")]
    public void MalformedJsonDoesNotSilentlyBecomeAnEmptyToolset(string json)
    {
        var path = Path.GetTempFileName();
        try
        {
            File.WriteAllText(path, json);
            Assert.That(() => StorageManifest.Load(path),
                Throws.InstanceOf<JsonException>().Or.InstanceOf<InvalidOperationException>());
        }
        finally
        {
            File.Delete(path);
        }
    }

    [Test]
    public void ValidManifestLoadsFromConsumerJson()
    {
        var path = Path.GetTempFileName();
        try
        {
            var manifest = Manifest;
            File.WriteAllText(path, JsonSerializer.Serialize(manifest,
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }));
            var loaded = StorageManifest.Load(path);
            Assert.That(JsonSerializer.Serialize(loaded.Operations), Is.EqualTo(JsonSerializer.Serialize(manifest.Operations)));
            Assert.That(loaded.Composites, Is.EqualTo(manifest.Composites));
        }
        finally
        {
            File.Delete(path);
        }
    }
}
