// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Responses.Internal.Resilience;

namespace Azure.AI.AgentServer.Responses.Tests.Unit;

/// <summary>
/// Verifies per-namespace flush isolation for the durable conversation-chain metadata facade
/// (Finding A). Mirrors Python's per-namespace <c>flush()</c>, which flushes only its own backing:
/// flushing namespace A must persist ONLY A's payload and must NOT flush namespace B (or the
/// default root), even though both received writes through the same owner facade.
/// </summary>
public class DurableConversationChainMetadataFlushIsolationTests
{
    [Test]
    public async Task NamespaceFlush_FlushesOnlyThatNamespace()
    {
        var flushed = new List<string>();
        var root = new RecordingTaskMetadata("<root>", flushed);
        var md = new DurableConversationChainMetadata(root);

        // Write to two named namespaces and the default root through the same owner facade.
        md.Set("a", "k", "1");
        md.Set("b", "k", "2");
        md.Set(ConversationChainMetadata.DefaultNamespaceName, "k", "root");

        // Flushing namespace A persists ONLY A.
        await md.ForNamespace("a").FlushAsync();

        Assert.That(flushed, Is.EqualTo(new[] { "a" }));
    }

    [Test]
    public async Task RootFlush_FlushesOnlyDefaultNamespace()
    {
        var flushed = new List<string>();
        var root = new RecordingTaskMetadata("<root>", flushed);
        var md = new DurableConversationChainMetadata(root);

        md.Set("a", "k", "1");
        md.Set(ConversationChainMetadata.DefaultNamespaceName, "k", "root");

        // The root/default facade flushes ONLY the default namespace, not touched siblings.
        await md.FlushAsync();

        Assert.That(flushed, Is.EqualTo(new[] { "<root>" }));
    }

    [Test]
    public async Task IsolatedFlushes_PersistIndependently()
    {
        var flushed = new List<string>();
        var root = new RecordingTaskMetadata("<root>", flushed);
        var md = new DurableConversationChainMetadata(root);

        md.Set("a", "k", "1");
        md.Set("b", "k", "2");

        await md.ForNamespace("a").FlushAsync();
        Assert.That(flushed, Is.EqualTo(new[] { "a" }));

        await md.ForNamespace("b").FlushAsync();
        Assert.That(flushed, Is.EqualTo(new[] { "a", "b" }));
    }

    /// <summary>
    /// A test double for <see cref="TaskMetadata"/> that records the namespace name each time its
    /// per-namespace <see cref="FlushAsync"/> is invoked, and materializes stable sibling namespaces.
    /// </summary>
    private sealed class RecordingTaskMetadata : TaskMetadata
    {
        private readonly string _namespaceName;
        private readonly List<string> _flushed;
        private readonly Dictionary<string, RecordingTaskMetadata> _children = new(StringComparer.Ordinal);

        public RecordingTaskMetadata(string namespaceName, List<string> flushed)
        {
            _namespaceName = namespaceName;
            _flushed = flushed;
        }

        public override TaskMetadata Namespace(string name)
        {
            if (!_children.TryGetValue(name, out var child))
            {
                child = new RecordingTaskMetadata(name, _flushed);
                _children[name] = child;
            }

            return child;
        }

        public override Task FlushAsync(CancellationToken cancellationToken = default)
        {
            _flushed.Add(_namespaceName);
            return Task.CompletedTask;
        }
    }
}
