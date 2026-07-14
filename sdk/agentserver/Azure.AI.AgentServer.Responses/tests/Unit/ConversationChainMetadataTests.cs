// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses.Tests.Unit;

/// <summary>
/// Unit tests for <see cref="ConversationChainMetadata"/> — the durable, explicitly-flushed
/// per-conversation-chain metadata facade. Verifies namespace isolation, reserved-name
/// rejection (<c>_</c> prefix), snapshot semantics, and the base no-op <c>FlushAsync</c>,
/// mirroring the Python <c>ConversationChainMetadataNamespace</c> facade contract.
/// </summary>
public class ConversationChainMetadataTests
{
    [Test]
    public void SetAndTryGet_DefaultRoundTrip()
    {
        var md = new ConversationChainMetadata();
        md.Set("ns", "phase", "analyze");

        Assert.That(md.TryGet("ns", "phase", out var value), Is.True);
        Assert.That(value, Is.EqualTo("analyze"));
    }

    [Test]
    public void TryGet_MissingKey_ReturnsFalse()
    {
        var md = new ConversationChainMetadata();
        Assert.That(md.TryGet("ns", "absent", out var value), Is.False);
        Assert.That(value, Is.Null);
    }

    [Test]
    public void Namespaces_AreIsolated()
    {
        var md = new ConversationChainMetadata();
        md.Set("a", "k", "1");
        md.Set("b", "k", "2");

        Assert.That(md.GetNamespace("a")["k"], Is.EqualTo("1"));
        Assert.That(md.GetNamespace("b")["k"], Is.EqualTo("2"));
    }

    [Test]
    public void GetNamespace_Unknown_ReturnsEmpty()
    {
        var md = new ConversationChainMetadata();
        Assert.That(md.GetNamespace("nope"), Is.Empty);
    }

    [TestCase("_reserved")]
    [TestCase("_")]
    public void Set_ReservedNamespace_Throws(string ns)
    {
        var md = new ConversationChainMetadata();
        Assert.Throws<ArgumentException>(() => md.Set(ns, "k", "v"));
    }

    [TestCase("_reserved")]
    [TestCase("_x")]
    public void Set_ReservedKey_Throws(string key)
    {
        var md = new ConversationChainMetadata();
        Assert.Throws<ArgumentException>(() => md.Set("ns", key, "v"));
    }

    [Test]
    public void Set_NullValue_Throws()
    {
        var md = new ConversationChainMetadata();
        Assert.Throws<ArgumentNullException>(() => md.Set("ns", "k", null!));
    }

    [Test]
    public async Task FlushAsync_BaseIsNoOp()
    {
        var md = new ConversationChainMetadata();
        md.Set("ns", "k", "v");
        await md.FlushAsync();
        // Still readable after no-op flush.
        Assert.That(md.TryGet("ns", "k", out var v), Is.True);
        Assert.That(v, Is.EqualTo("v"));
    }

    [Test]
    public void Snapshot_CapturesAllNamespaces()
    {
        var md = new ConversationChainMetadata();
        md.Set("a", "k1", "v1");
        md.Set("a", "k2", "v2");
        md.Set("b", "k3", "v3");

        var snap = md.Snapshot();

        Assert.Multiple(() =>
        {
            Assert.That(snap.Keys, Is.EquivalentTo(new[] { "a", "b" }));
            Assert.That(snap["a"]["k1"], Is.EqualTo("v1"));
            Assert.That(snap["a"]["k2"], Is.EqualTo("v2"));
            Assert.That(snap["b"]["k3"], Is.EqualTo("v3"));
        });
    }

    [Test]
    public void Snapshot_IsDefensiveCopy()
    {
        var md = new ConversationChainMetadata();
        md.Set("a", "k1", "v1");
        var snap = md.Snapshot();

        md.Set("a", "k2", "later");

        // The earlier snapshot must not observe the later mutation.
        Assert.That(snap["a"].ContainsKey("k2"), Is.False);
    }

    [Test]
    public void Empty_IsShared()
    {
        Assert.That(ConversationChainMetadata.Empty, Is.SameAs(ConversationChainMetadata.Empty));
    }

    [Test]
    public async Task ForNamespace_FacadeWritesAndReads()
    {
        var md = new ConversationChainMetadata();
        var ns = md.ForNamespace("checkpoints");

        ns.Set("last_seq", "42");
        await ns.FlushAsync();

        Assert.Multiple(() =>
        {
            Assert.That(ns.TryGet("last_seq", out var value), Is.True);
            Assert.That(value, Is.EqualTo("42"));
            Assert.That(md.GetNamespace("checkpoints")["last_seq"], Is.EqualTo("42"));
        });
    }

    [Test]
    public void MetadataNamespace_ExtensionUsesDefaultNamespace()
    {
        var context = new ResponseContext("caresp_test");
        var ns = context.MetadataNamespace();

        ns.Set("k", "v");

        Assert.That(context.ConversationChainMetadata.GetNamespace(ConversationChainMetadata.DefaultNamespaceName)["k"], Is.EqualTo("v"));
    }

    [Test]
    public void EachContext_HasIsolatedMetadata_NoCrossContextBleed()
    {
        // Regression: the default ConversationChainMetadata must be a per-instance facade, not a
        // process-wide shared singleton — otherwise metadata written by one conversation's handler
        // would leak into unrelated conversations sharing the process.
        var contextA = new ResponseContext("caresp_a");
        var contextB = new ResponseContext("caresp_b");

        contextA.MetadataNamespace().Set("k", "from-a");

        Assert.Multiple(() =>
        {
            Assert.That(contextA.ConversationChainMetadata, Is.Not.SameAs(contextB.ConversationChainMetadata));
            Assert.That(contextB.MetadataNamespace().TryGet("k", out _), Is.False);
            Assert.That(contextA.MetadataNamespace().TryGet("k", out var v), Is.True);
            Assert.That(v, Is.EqualTo("from-a"));
        });
    }
}
