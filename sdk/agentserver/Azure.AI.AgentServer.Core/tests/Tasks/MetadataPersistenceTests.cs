// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public sealed class MetadataPersistenceTests
{
    [Test]
    public async Task NamedNamespaceValueWrittenTurn1IsVisibleTurn2()
    {
        using var host = TaskTestHost.Create();
        string? observedTurn2 = null;
        host.Builder.AddMultiTurnTask<string, string>("memo", (ctx, ct) =>
        {
            if (ctx.EntryMode == EntryMode.Fresh)
            {
                ctx.Metadata["greeting"] = BinaryData.FromString("\"hi\"");
            }
            else
            {
                BinaryData? value = ctx.Metadata["greeting"];
                observedTurn2 = value?.ToString();
            }

            return Task.FromResult(ctx.Input);
        });

        await host.Invoker.StartAsync<string, string>("memo", "a", new RunOptions { TaskId = "m-1" });
        await host.WaitForStatusAsync("m-1", "suspended", TimeSpan.FromSeconds(5));

        await host.Invoker.StartAsync<string, string>("memo", "b", new RunOptions { TaskId = "m-1" });
        await host.WaitForStatusAsync("m-1", "suspended", TimeSpan.FromSeconds(5));

        Assert.That(observedTurn2, Is.EqualTo("\"hi\""));
    }

    [Test]
    public async Task UnderscorePrefixedKeyIsAllowedAtPrimitiveLayer()
    {
        // SOT §17: the leading-underscore reservation is a CONVENTION at the primitive's API surface
        // — the core primitive does NOT enforce it (Python _metadata.__setitem__ only rejects
        // non-string keys). A `_`-prefixed metadata key writes and persists like any other; it lives
        // under payload["metadata"] and cannot collide with the framework's top-level payload keys.
        using var host = TaskTestHost.Create();
        Exception? captured = null;
        BinaryData? readBack = null;
        host.Builder.AddMultiTurnTask<string, string>("guard", (ctx, ct) =>
        {
            try
            {
                ctx.Metadata["_reserved"] = BinaryData.FromString("\"x\"");
                readBack = ctx.Metadata["_reserved"];
            }
            catch (Exception ex)
            {
                captured = ex;
            }

            return Task.FromResult(ctx.Input);
        });

        await host.Invoker.RunAsync<string, string>("guard", "a", new RunOptions { TaskId = "g-1" });

        Assert.That(captured, Is.Null, "the core primitive must not reject `_`-prefixed metadata keys");
        Assert.That(readBack?.ToString(), Is.EqualTo("\"x\""));
    }

    [Test]
    public async Task TouchedMetadataIsAutoFlushedAtTerminalOfTurn()
    {
        using var host = TaskTestHost.Create();
        host.Builder.AddMultiTurnTask<string, string>("counter", (ctx, ct) =>
        {
            ctx.Metadata.Increment("turns");
            return Task.FromResult(ctx.Input);
        });

        await host.Invoker.StartAsync<string, string>("counter", "a", new RunOptions { TaskId = "c-1" });
        var record = await host.WaitForStatusAsync("c-1", "suspended", TimeSpan.FromSeconds(5));

        // The metadata namespace is persisted into payload.metadata without an explicit flush.
        var metadataNode = record.Payload["metadata"];
        Assert.That(metadataNode, Is.Not.Null);
        Assert.That(metadataNode!["turns"], Is.Not.Null);
    }

    [Test]
    public async Task NamedNamespacesAreIsolatedFromEachOtherAndFromDefault()
    {
        using var host = TaskTestHost.Create();
        string? defaultReadBack = null;
        string? billingReadBack = null;
        bool defaultSawBillingKey = false;
        bool billingSawDefaultKey = false;

        host.Builder.AddMultiTurnTask<string, string>("iso", (ctx, ct) =>
        {
            if (ctx.EntryMode == EntryMode.Fresh)
            {
                // Same key name in two different namespaces must not collide.
                ctx.Metadata["shared"] = BinaryData.FromString("\"from-default\"");
                ctx.Metadata.Namespace("billing")["shared"] = BinaryData.FromString("\"from-billing\"");
            }
            else
            {
                defaultReadBack = ctx.Metadata["shared"]?.ToString();
                billingReadBack = ctx.Metadata.Namespace("billing")["shared"]?.ToString();

                // Cross-namespace leakage checks: neither namespace should see the other's private key.
                ctx.Metadata.Namespace("billing")["only-billing"] = BinaryData.FromString("\"x\"");
                defaultSawBillingKey = ctx.Metadata["only-billing"] is not null;
                ctx.Metadata["only-default"] = BinaryData.FromString("\"y\"");
                billingSawDefaultKey = ctx.Metadata.Namespace("billing")["only-default"] is not null;
            }

            return Task.FromResult(ctx.Input);
        });

        await host.Invoker.StartAsync<string, string>("iso", "a", new RunOptions { TaskId = "iso-1" });
        await host.WaitForStatusAsync("iso-1", "suspended", TimeSpan.FromSeconds(5));

        await host.Invoker.StartAsync<string, string>("iso", "b", new RunOptions { TaskId = "iso-1" });
        await host.WaitForStatusAsync("iso-1", "suspended", TimeSpan.FromSeconds(5));

        Assert.Multiple(() =>
        {
            Assert.That(defaultReadBack, Is.EqualTo("\"from-default\""), "default namespace must retain its own value across turns");
            Assert.That(billingReadBack, Is.EqualTo("\"from-billing\""), "the 'billing' namespace must retain its own value across turns");
            Assert.That(defaultSawBillingKey, Is.False, "the default namespace must not observe a key written to 'billing'");
            Assert.That(billingSawDefaultKey, Is.False, "the 'billing' namespace must not observe a key written to the default namespace");
        });
    }
}
