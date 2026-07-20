// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace System.ClientModel.Primitives.Tests;

public class CredentialSectionOverlayTests
{
    private static IConfigurationSection BuildOriginal()
    {
        var root = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["TestClient:Credential:CredentialSource"] = "Match",
                ["TestClient:Credential:TenantId"] = "tenant-1",
                ["TestClient:Credential:Inner:Foo"] = "bar",
            })
            .Build();
        return root.GetSection("TestClient:Credential");
    }

    private static (IConfigurationSection Original, IConfigurationSection Overlay) BuildPair(
        IDictionary<string, string?> data,
        string sectionPath = "TestClient:Credential")
    {
        var root = new ConfigurationBuilder().AddInMemoryCollection(data).Build();
        IConfigurationSection original = root.GetSection(sectionPath);
        IConfigurationSection overlay = CredentialSectionOverlay.CreateOverlay(original);
        return (original, overlay);
    }

    // ---------- Identity / shape ----------

    [Test]
    public void Overlay_Path_MatchesOriginalSectionPath()
    {
        IConfigurationSection original = BuildOriginal();
        IConfigurationSection overlay = CredentialSectionOverlay.CreateOverlay(original);

        Assert.That(overlay.Path, Is.EqualTo(original.Path));
    }

    [Test]
    public void Overlay_Key_MatchesOriginalSectionKey()
    {
        IConfigurationSection original = BuildOriginal();
        IConfigurationSection overlay = CredentialSectionOverlay.CreateOverlay(original);

        Assert.That(overlay.Key, Is.EqualTo(original.Key));
    }

    [Test]
    public void Overlay_Value_MatchesOriginalSectionValue_WhenLeaf()
    {
        var (original, overlay) = BuildPair(new Dictionary<string, string?>
        {
            ["TestClient:Credential"] = "leaf-value",
        });

        Assert.That(overlay.Value, Is.EqualTo(original.Value));
    }

    [Test]
    public void Overlay_NullOriginal_HasEmptyPath()
    {
        IConfigurationSection overlay = CredentialSectionOverlay.CreateOverlay(null!);

        Assert.That(overlay.Path, Is.EqualTo(string.Empty));
        Assert.That(overlay.Key, Is.EqualTo(string.Empty));
    }

    // ---------- Indexer ----------

    [Test]
    public void Overlay_Indexer_SingleSegment_MatchesOriginal()
    {
        IConfigurationSection original = BuildOriginal();
        IConfigurationSection overlay = CredentialSectionOverlay.CreateOverlay(original);

        Assert.That(overlay["TenantId"], Is.EqualTo(original["TenantId"]));
        Assert.That(overlay["Missing"], Is.EqualTo(original["Missing"]));
    }

    [Test]
    public void Overlay_Indexer_MultiSegmentColonDelimited_MatchesOriginal()
    {
        IConfigurationSection original = BuildOriginal();
        IConfigurationSection overlay = CredentialSectionOverlay.CreateOverlay(original);

        Assert.That(overlay["Inner:Foo"], Is.EqualTo(original["Inner:Foo"]));
    }

    [Test]
    public void Overlay_Indexer_CaseInsensitive_LikeOriginal()
    {
        IConfigurationSection original = BuildOriginal();
        IConfigurationSection overlay = CredentialSectionOverlay.CreateOverlay(original);

        Assert.That(overlay["tenantid"], Is.EqualTo(original["tenantid"]));
        Assert.That(overlay["INNER:foo"], Is.EqualTo(original["INNER:foo"]));
    }

    [Test]
    public void Overlay_Indexer_SetMultiSegment_VisibleViaChain()
    {
        IConfigurationSection original = BuildOriginal();
        IConfigurationSection overlay = CredentialSectionOverlay.CreateOverlay(original);

        overlay["Inner:NewKey"] = "x";

        Assert.That(overlay["Inner:NewKey"], Is.EqualTo("x"));
        Assert.That(overlay.GetSection("Inner").GetSection("NewKey").Value, Is.EqualTo("x"));
    }

    [Test]
    public void Overlay_Indexer_SetNull_RemovesValue()
    {
        IConfigurationSection original = BuildOriginal();
        IConfigurationSection overlay = CredentialSectionOverlay.CreateOverlay(original);

        Assert.That(overlay["TenantId"], Is.Not.Null);
        overlay["TenantId"] = null;
        Assert.That(overlay["TenantId"], Is.Null);
        Assert.That(overlay.GetSection("TenantId").Exists(), Is.False);
    }

    [Test]
    public void Overlay_Indexer_EmptyString_TreatedAsExistingValue()
    {
        IConfigurationSection original = BuildOriginal();
        IConfigurationSection overlay = CredentialSectionOverlay.CreateOverlay(original);

        overlay["EmptyVal"] = string.Empty;

        Assert.That(overlay["EmptyVal"], Is.EqualTo(string.Empty));
        Assert.That(overlay.GetSection("EmptyVal").Exists(), Is.True);
    }

    // ---------- GetChildren ----------

    [Test]
    public void Overlay_GetChildren_PathsKeysValues_MatchOriginal()
    {
        IConfigurationSection original = BuildOriginal();
        IConfigurationSection overlay = CredentialSectionOverlay.CreateOverlay(original);

        var origMap = original.GetChildren()
            .ToDictionary(c => c.Key, c => (c.Path, c.Value), StringComparer.OrdinalIgnoreCase);
        var overlayMap = overlay.GetChildren()
            .ToDictionary(c => c.Key, c => (c.Path, c.Value), StringComparer.OrdinalIgnoreCase);

        Assert.That(overlayMap.Keys, Is.EquivalentTo(origMap.Keys));
        foreach (KeyValuePair<string, (string Path, string? Value)> kvp in origMap)
        {
            Assert.That(overlayMap[kvp.Key].Path, Is.EqualTo(kvp.Value.Path), $"Path for {kvp.Key}");
            Assert.That(overlayMap[kvp.Key].Value, Is.EqualTo(kvp.Value.Value), $"Value for {kvp.Key}");
        }
    }

    [Test]
    public void Overlay_GetChildren_NumericKeys_OrderMatchesOriginal_ForCollectionBind()
    {
        // List/array binding via Bind walks GetChildren in numeric order. The
        // built-in provider sorts numeric segments numerically, so 0,1,2,10
        // not 0,1,10,2. The overlay must mirror that to bind collections
        // identically.
        var (original, overlay) = BuildPair(new Dictionary<string, string?>
        {
            ["TestClient:Credential:Items:0"] = "a",
            ["TestClient:Credential:Items:1"] = "b",
            ["TestClient:Credential:Items:2"] = "c",
            ["TestClient:Credential:Items:10"] = "j",
        });

        string[] origOrder = original.GetSection("Items").GetChildren().Select(c => c.Key).ToArray();
        string[] overlayOrder = overlay.GetSection("Items").GetChildren().Select(c => c.Key).ToArray();

        Assert.That(overlayOrder, Is.EqualTo(origOrder));
    }

    // ---------- GetSection ----------

    [Test]
    public void Overlay_GetSection_PathIsFullyQualified()
    {
        IConfigurationSection original = BuildOriginal();
        IConfigurationSection overlay = CredentialSectionOverlay.CreateOverlay(original);

        IConfigurationSection origChild = original.GetSection("TenantId");
        IConfigurationSection overlayChild = overlay.GetSection("TenantId");

        Assert.That(overlayChild.Path, Is.EqualTo(origChild.Path));
        Assert.That(overlayChild.Key, Is.EqualTo(origChild.Key));
        Assert.That(overlayChild.Value, Is.EqualTo(origChild.Value));
    }

    [Test]
    public void Overlay_GetSection_Nested_PathIsFullyQualified()
    {
        IConfigurationSection original = BuildOriginal();
        IConfigurationSection overlay = CredentialSectionOverlay.CreateOverlay(original);

        IConfigurationSection origNested = original.GetSection("Inner").GetSection("Foo");
        IConfigurationSection overlayNested = overlay.GetSection("Inner").GetSection("Foo");

        Assert.That(overlayNested.Path, Is.EqualTo(origNested.Path));
        Assert.That(overlayNested.Key, Is.EqualTo(origNested.Key));
        Assert.That(overlayNested.Value, Is.EqualTo(origNested.Value));
    }

    [Test]
    public void Overlay_GetSection_MultiSegmentKey_KeyIsLastSegment()
    {
        // ConfigurationSection uses ConfigurationPath.GetSectionKey, which
        // returns the segment after the LAST ':'. So GetSection("Inner:Foo")
        // yields a section whose Key == "Foo" (and Path ends with "Inner:Foo").
        IConfigurationSection original = BuildOriginal();
        IConfigurationSection overlay = CredentialSectionOverlay.CreateOverlay(original);

        IConfigurationSection origMulti = original.GetSection("Inner:Foo");
        IConfigurationSection overlayMulti = overlay.GetSection("Inner:Foo");

        Assert.That(overlayMulti.Path, Is.EqualTo(origMulti.Path));
        Assert.That(overlayMulti.Key, Is.EqualTo(origMulti.Key));
        Assert.That(overlayMulti.Value, Is.EqualTo(origMulti.Value));
    }

    [Test]
    public void Overlay_GetSection_NonExistent_ReturnsSectionWithExistsFalse()
    {
        IConfigurationSection original = BuildOriginal();
        IConfigurationSection overlay = CredentialSectionOverlay.CreateOverlay(original);

        IConfigurationSection origMissing = original.GetSection("DoesNotExist");
        IConfigurationSection overlayMissing = overlay.GetSection("DoesNotExist");

        Assert.That(overlayMissing, Is.Not.Null);
        Assert.That(overlayMissing.Exists(), Is.EqualTo(origMissing.Exists()));
        Assert.That(overlayMissing.Exists(), Is.False);
        Assert.That(overlayMissing.Path, Is.EqualTo(origMissing.Path));
    }

    // ---------- Exists() ----------

    [Test]
    public void Overlay_Exists_ParentWithDescendantsOnly_ReturnsTrue()
    {
        IConfigurationSection original = BuildOriginal();
        IConfigurationSection overlay = CredentialSectionOverlay.CreateOverlay(original);

        // Inner has no Value of its own, only descendants.
        Assert.That(overlay.GetSection("Inner").Exists(), Is.EqualTo(original.GetSection("Inner").Exists()));
        Assert.That(overlay.GetSection("Inner").Exists(), Is.True);
    }

    [Test]
    public void Overlay_Exists_RootWithChildren_True()
    {
        IConfigurationSection original = BuildOriginal();
        IConfigurationSection overlay = CredentialSectionOverlay.CreateOverlay(original);

        Assert.That(overlay.Exists(), Is.True);
        Assert.That(overlay.Exists(), Is.EqualTo(original.Exists()));
    }

    [Test]
    public void Overlay_Exists_AfterDeletingAllChildren_ReturnsFalse()
    {
        IConfigurationSection original = BuildOriginal();
        IConfigurationSection overlay = CredentialSectionOverlay.CreateOverlay(original);

        overlay["CredentialSource"] = null;
        overlay["TenantId"] = null;
        overlay["Inner:Foo"] = null;

        Assert.That(overlay.Exists(), Is.False);
    }

    // ---------- Deletion ----------

    [Test]
    public void Overlay_DeleteParentValue_DoesNotRemoveDescendants()
    {
        // Section can have a Value AND descendants. Setting parent value to null
        // must only clear the value; descendants must remain. Mirrors how a
        // ConfigurationSection's Value lookup is independent of its children.
        var (original, overlay) = BuildPair(new Dictionary<string, string?>
        {
            ["TestClient:Credential:Inner"] = "innerVal",
            ["TestClient:Credential:Inner:Foo"] = "fooVal",
        });

        Assert.That(overlay.GetSection("Inner").Value, Is.EqualTo(original.GetSection("Inner").Value));

        overlay["Inner"] = null;

        Assert.That(overlay.GetSection("Inner").Value, Is.Null);
        Assert.That(overlay.GetSection("Inner").Exists(), Is.True,
            "Parent should still exist because its descendants remain.");
        Assert.That(overlay["Inner:Foo"], Is.EqualTo("fooVal"));
    }

    [Test]
    public void Overlay_DeleteDescendant_LeavesParentExistsBasedOnRemainingChildren()
    {
        IConfigurationSection original = BuildOriginal();
        IConfigurationSection overlay = CredentialSectionOverlay.CreateOverlay(original);

        overlay["Inner:Foo"] = null;

        Assert.That(overlay.GetSection("Inner").Exists(), Is.False);
    }

    // ---------- Live view: cached child observes parent mutations ----------

    [Test]
    public void Overlay_CachedChildSection_ObservesLaterMutations()
    {
        // Real ConfigurationSection objects are live views over the root.
        // A resolver may capture `var inner = section.GetSection("Inner")`
        // and later observe writes the customer makes via the parent.
        IConfigurationSection original = BuildOriginal();
        IConfigurationSection overlay = CredentialSectionOverlay.CreateOverlay(original);

        IConfigurationSection cachedChild = overlay.GetSection("Inner").GetSection("Foo");
        Assert.That(cachedChild.Value, Is.EqualTo("bar"));

        overlay["Inner:Foo"] = "mutated";

        Assert.That(cachedChild.Value, Is.EqualTo("mutated"));
    }

    [Test]
    public void Overlay_CachedChildSection_ObservesNewSiblings()
    {
        IConfigurationSection original = BuildOriginal();
        IConfigurationSection overlay = CredentialSectionOverlay.CreateOverlay(original);

        IConfigurationSection inner = overlay.GetSection("Inner");
        Assert.That(inner.GetChildren().Select(c => c.Key), Is.EquivalentTo(new[] { "Foo" }));

        overlay["Inner:NewSibling"] = "z";

        Assert.That(inner.GetChildren().Select(c => c.Key),
            Is.EquivalentTo(new[] { "Foo", "NewSibling" }));
    }

    // ---------- Bind ----------

    [Test]
    public void Overlay_Bind_FlatPoco_MatchesOriginal()
    {
        IConfigurationSection original = BuildOriginal();
        IConfigurationSection overlay = CredentialSectionOverlay.CreateOverlay(original);

        var fromOriginal = new FlatCredOptions();
        original.Bind(fromOriginal);

        var fromOverlay = new FlatCredOptions();
        overlay.Bind(fromOverlay);

        Assert.That(fromOverlay.CredentialSource, Is.EqualTo(fromOriginal.CredentialSource));
        Assert.That(fromOverlay.TenantId, Is.EqualTo(fromOriginal.TenantId));
    }

    [Test]
    public void Overlay_Bind_NestedPoco_MatchesOriginal()
    {
        IConfigurationSection original = BuildOriginal();
        IConfigurationSection overlay = CredentialSectionOverlay.CreateOverlay(original);

        var fromOriginal = new NestedCredOptions();
        original.Bind(fromOriginal);

        var fromOverlay = new NestedCredOptions();
        overlay.Bind(fromOverlay);

        Assert.That(fromOverlay.Inner?.Foo, Is.EqualTo(fromOriginal.Inner?.Foo));
    }

    [Test]
    public void Overlay_Bind_Collection_MatchesOriginal()
    {
        var (original, overlay) = BuildPair(new Dictionary<string, string?>
        {
            ["TestClient:Credential:Items:0"] = "a",
            ["TestClient:Credential:Items:1"] = "b",
            ["TestClient:Credential:Items:2"] = "c",
            ["TestClient:Credential:Items:10"] = "j",
        });

        var fromOriginal = new ListCredOptions();
        original.Bind(fromOriginal);

        var fromOverlay = new ListCredOptions();
        overlay.Bind(fromOverlay);

        Assert.That(fromOverlay.Items, Is.EqualTo(fromOriginal.Items));
    }

    [Test]
    public void Overlay_Bind_AfterMutation_PicksUpOverrides()
    {
        IConfigurationSection original = BuildOriginal();
        IConfigurationSection overlay = CredentialSectionOverlay.CreateOverlay(original);

        overlay["TenantId"] = "overridden-tenant";

        var bound = new FlatCredOptions();
        overlay.Bind(bound);

        Assert.That(bound.TenantId, Is.EqualTo("overridden-tenant"));
        Assert.That(bound.CredentialSource, Is.EqualTo("Match"));
    }

    // ---------- AsEnumerable ----------

    [Test]
    public void Overlay_AsEnumerable_KeysAndValues_MatchOriginal()
    {
        IConfigurationSection original = BuildOriginal();
        IConfigurationSection overlay = CredentialSectionOverlay.CreateOverlay(original);

        Dictionary<string, string?> origPairs = original.AsEnumerable()
            .Where(p => p.Value is not null)
            .ToDictionary(p => p.Key, p => p.Value, StringComparer.OrdinalIgnoreCase);
        Dictionary<string, string?> overlayPairs = overlay.AsEnumerable()
            .Where(p => p.Value is not null)
            .ToDictionary(p => p.Key, p => p.Value, StringComparer.OrdinalIgnoreCase);

        Assert.That(overlayPairs, Is.EquivalentTo(origPairs));
    }

    // ---------- Helper POCOs ----------

    private sealed class FlatCredOptions
    {
        public string? CredentialSource { get; set; }
        public string? TenantId { get; set; }
    }

    private sealed class NestedCredOptions
    {
        public InnerOptions? Inner { get; set; }
    }

    private sealed class InnerOptions
    {
        public string? Foo { get; set; }
    }

    private sealed class ListCredOptions
    {
        public List<string> Items { get; set; } = new();
    }
}
