// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

/// <summary>
/// Parity coverage for the schema-version stamp (spec §20/§38) and the immutable
/// <c>source.hosting_environment</c> creation provenance (spec §21): both are stamped at
/// create and required for cross-language recovery compatibility with the Python store.
/// </summary>
[TestFixture]
public sealed class SchemaVersionAndSourceTests
{
    [Test]
    public async Task OneShotCreateStampsSchemaVersion()
    {
        using var host = TaskTestHost.Create();
        TaskRecord? observed = null;
        host.Builder.AddTask<string, string>("echo", async (ctx, ct) =>
        {
            observed = await host.Store.GetAsync("sv-1");
            return ctx.Input;
        });

        await host.Invoker.RunAsync<string, string>("echo", "hi", new RunOptions { TaskId = "sv-1" });

        Assert.That(observed, Is.Not.Null);
        Assert.That((string?)observed!.Payload[TaskWireKeys.PayloadSchemaVersion], Is.EqualTo("1"));
    }

    [Test]
    public async Task MultiTurnCreateStampsSchemaVersion()
    {
        using var host = TaskTestHost.Create();
        host.Builder.AddMultiTurnTask<string, string>("chat", (ctx, ct) => Task.FromResult(ctx.Input));

        TaskRun<string> handle = await host.Invoker.StartAsync<string, string>(
            "chat", "hi", new RunOptions { TaskId = "sv-2", InputId = "turn-1" });
        await handle;

        // The multi-turn chain parks at suspended, so its record survives for inspection.
        TaskRecord record = await host.WaitForStatusAsync("sv-2", "suspended", TimeSpan.FromSeconds(5));
        Assert.That((string?)record.Payload[TaskWireKeys.PayloadSchemaVersion], Is.EqualTo("1"));
    }

    [Test]
    public async Task CreateStampsHostingEnvironmentFromEnvironmentVariable()
    {
        string? previous = Environment.GetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT");
        Environment.SetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT", "prod-eastus");
        try
        {
            using var host = TaskTestHost.Create();
            TaskRecord? observed = null;
            host.Builder.AddTask<string, string>("echo", async (ctx, ct) =>
            {
                observed = await host.Store.GetAsync("he-1");
                return ctx.Input;
            });

            await host.Invoker.RunAsync<string, string>("echo", "hi", new RunOptions { TaskId = "he-1" });

            Assert.That(observed, Is.Not.Null);
            Assert.That((string?)observed!.Source!.ToJson()[TaskWireKeys.SourceHostingEnvironment], Is.EqualTo("prod-eastus"));
        }
        finally
        {
            Environment.SetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT", previous);
        }
    }

    [Test]
    public async Task CreateStampsEmptyHostingEnvironmentWhenUnset()
    {
        string? previous = Environment.GetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT");
        Environment.SetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT", null);
        try
        {
            using var host = TaskTestHost.Create();
            TaskRecord? observed = null;
            host.Builder.AddTask<string, string>("echo", async (ctx, ct) =>
            {
                observed = await host.Store.GetAsync("he-2");
                return ctx.Input;
            });

            await host.Invoker.RunAsync<string, string>("echo", "hi", new RunOptions { TaskId = "he-2" });

            Assert.That(observed, Is.Not.Null);
            Assert.That((string?)observed!.Source!.ToJson()[TaskWireKeys.SourceHostingEnvironment], Is.EqualTo(string.Empty));
        }
        finally
        {
            Environment.SetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT", previous);
        }
    }

    [Test]
    public void SourcePreservesUnknownExtensionFieldsRoundTrip()
    {
        var json = new JsonObject
        {
            [TaskWireKeys.SourceType] = TaskWireKeys.SourceTypeValue,
            [TaskWireKeys.SourceName] = "research",
            [TaskWireKeys.SourceServerVersion] = "py/1.2.3",
            [TaskWireKeys.SourceHostingEnvironment] = "prod",
            ["future_field"] = "keep-me",
            ["nested_ext"] = new JsonObject { ["a"] = 1 },
        };

        Source source = Source.FromJson(json) ?? throw new InvalidOperationException("null source");
        JsonObject roundTrip = source.ToJson();

        Assert.That((string?)roundTrip["future_field"], Is.EqualTo("keep-me"));
        Assert.That((int?)((JsonObject)roundTrip["nested_ext"]!)["a"], Is.EqualTo(1));
        Assert.That((string?)roundTrip[TaskWireKeys.SourceHostingEnvironment], Is.EqualTo("prod"));
    }
}
