// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public sealed class OneShotRecoveryTests
{
    [Test]
    public async Task HandlerRestoresCallIdFromInputAndResetsOuterContext()
    {
        using TaskTestHost host = TaskTestHost.Create();
        var observed = new List<(string? CallId, string? UserId, string? SessionId)>();
        host.Builder.AddTask<CallIdInput, string>("request-context", (ctx, ct) =>
        {
            FoundryAgentRequestContext current = FoundryAgentRequestContext.Current;
            observed.Add((current.CallId, current.UserId, current.SessionId));
            return Task.FromResult(ctx.Input.Prompt);
        });

        FoundryAgentRequestContext? previous = FoundryAgentRequestContext.Exchange(
            new FoundryAgentRequestContext
            {
                CallId = "outer-call",
                UserId = "outer-user",
                SessionId = "outer-session",
            });
        try
        {
            await host.Invoker.RunAsync<CallIdInput, string>(
                "request-context",
                new CallIdInput("persisted-call", "first"));
            await host.Invoker.RunAsync<CallIdInput, string>(
                "request-context",
                new CallIdInput(null, "second"));

            Assert.That(observed, Is.EqualTo(new (string? CallId, string? UserId, string? SessionId)[]
            {
                ("persisted-call", null, null),
                ("outer-call", null, null),
            }));
            Assert.That(FoundryAgentRequestContext.Current.CallId, Is.EqualTo("outer-call"));
            Assert.That(FoundryAgentRequestContext.Current.UserId, Is.EqualTo("outer-user"));
            Assert.That(FoundryAgentRequestContext.Current.SessionId, Is.EqualTo("outer-session"));
        }
        finally
        {
            FoundryAgentRequestContext.Exchange(previous);
        }
    }

    [Test]
    public async Task RecoveredHandlerRestoresPersistedCallId()
    {
        var registry1 = new TaskRegistry();
        using var host1 = TaskTestHost.Create(sharedRegistry: registry1);
        host1.Builder.AddTask<CallIdInput, string>("call-id-recovery", async (ctx, ct) =>
        {
            if (ctx.EntryMode == EntryMode.Fresh)
            {
                await ctx.ExitForRecoveryAsync(ct);
            }

            return ctx.Input.Prompt;
        });

        host1.SignalShutdown();
        TaskRun<string> handle = await host1.Invoker.StartAsync<CallIdInput, string>(
            "call-id-recovery",
            new CallIdInput("persisted-call", "payload"),
            new RunOptions { TaskId = "call-id-recovery-1" });
        await host1.WaitUntilInactiveAsync(handle.TaskId, TimeSpan.FromSeconds(5));

        var observed = new TaskCompletionSource<(string? CallId, string? UserId, string? SessionId)>(
            TaskCreationOptions.RunContinuationsAsynchronously);
        var registry2 = new TaskRegistry();
        using var host2 = host1.Restart(registry2);
        host2.Builder.AddTask<CallIdInput, string>("call-id-recovery", (ctx, ct) =>
        {
            FoundryAgentRequestContext current = FoundryAgentRequestContext.Current;
            observed.TrySetResult((current.CallId, current.UserId, current.SessionId));
            return Task.FromResult(ctx.Input.Prompt);
        });

        int dispatched = await host2.Engine.ScanAndRecoverAsync();
        Assert.That(dispatched, Is.EqualTo(1));
        var expectedContext = (CallId: (string?)"persisted-call", UserId: (string?)null, SessionId: (string?)null);
        Assert.That(
            await observed.Task.WaitAsync(TimeSpan.FromSeconds(5)),
            Is.EqualTo(expectedContext));
        await host2.WaitUntilDeletedAsync(handle.TaskId, TimeSpan.FromSeconds(5));
    }

    [Test]
    public async Task LeaseAbandonedMidRunIsReInvokedAsRecovered()
    {
        var registry1 = new TaskRegistry();
        using var host1 = TaskTestHost.Create(sharedRegistry: registry1);

        // On the first (Fresh) entry, exit for recovery — leaving the record in_progress.
        host1.Builder.AddTask<string, string>("resumable", async (ctx, ct) =>
        {
            if (ctx.EntryMode == EntryMode.Fresh)
            {
                await ctx.ExitForRecoveryAsync(ct);
            }

            return $"done:{ctx.Input}:{ctx.EntryMode}";
        });

        // ExitForRecovery is gated on graceful shutdown — signal it before dispatch so the Fresh
        // turn may bail out for recovery (the documented production pattern; tasks-guide.md §4.11).
        host1.SignalShutdown();
        TaskRun<string> handle = await host1.Invoker.StartAsync<string, string>(
            "resumable", "payload", new RunOptions { TaskId = "rec-1" });

        // The Fresh attempt defers; the handle faults with TaskDeferred and the record stays in_progress.
        // Recovery deferral is an internal lifecycle handoff: it never surfaces on the run handle.
        // Wait for the engine to release the run, then confirm Completion stays pending.
        await host1.WaitUntilInactiveAsync(handle.TaskId, TimeSpan.FromSeconds(5));
        Assert.That(handle.Completion.IsCompleted, Is.False, "deferral must not complete the run handle");
        var midRecord = await host1.Store.GetAsync("rec-1");
        Assert.That(midRecord, Is.Not.Null);
        Assert.That(midRecord!.Status, Is.EqualTo("in_progress"));

        // Simulate a process restart: a new engine over the same store + a fresh registry.
        var registry2 = new TaskRegistry();
        using var host2 = host1.Restart(registry2);
        host2.Builder.AddTask<string, string>("resumable", (ctx, ct) =>
            Task.FromResult($"done:{ctx.Input}:{ctx.EntryMode}"));

        int dispatched = await host2.Engine.ScanAndRecoverAsync();
        Assert.That(dispatched, Is.EqualTo(1));

        // The recovered run completes and the one-shot record is auto-deleted.
        await host2.WaitUntilDeletedAsync("rec-1", TimeSpan.FromSeconds(5));
    }

    [Test]
    public async Task LegacyInProgressTaskWithoutSchemaVersionIsDeletedNotRecovered()
    {
        var registry = new TaskRegistry();
        using var host = TaskTestHost.Create(sharedRegistry: registry);
        bool dispatchedHandler = false;
        host.Builder.AddTask<string, string>("legacy", (ctx, ct) =>
        {
            dispatchedHandler = true;
            return Task.FromResult(ctx.Input);
        });

        // Seed a pre-schema in_progress record (old wire format: no payload.schema_version),
        // owned by this engine and stamped with the framework's reserved source type/name.
        string owner = Azure.AI.AgentServer.Core.Tasks.Engine.LeaseManager.FormatOwner(host.AgentName, host.SessionId);
        await host.Store.CreateAsync(new Azure.AI.AgentServer.Core.Tasks.Providers.TaskCreateRequest
        {
            Id = "legacy-1",
            AgentName = host.AgentName,
            SessionId = host.SessionId,
            Title = "Legacy",
            Status = "in_progress",
            LeaseOwner = owner,
            LeaseInstanceId = "old-worker",
            LeaseDurationSeconds = 60,
            Payload = new System.Text.Json.Nodes.JsonObject
            {
                ["input"] = "stale",
                ["last_input_id"] = "legacy-1",
                // NOTE: deliberately no schema_version — this is the legacy shape.
            },
            Source = new System.Text.Json.Nodes.JsonObject
            {
                ["type"] = "agentserver.task",
                ["name"] = "legacy",
                ["server_version"] = "py/0.0.1",
            },
        });

        int dispatched = await host.Engine.ScanAndRecoverAsync();

        Assert.That(dispatched, Is.EqualTo(0), "legacy task must not be recovered/dispatched");
        Assert.That(dispatchedHandler, Is.False, "handler must not be invoked for a legacy task");
        Assert.That(await host.Store.GetAsync("legacy-1"), Is.Null, "legacy task must be deleted");
    }

    [Test]
    public async Task RecoveredRunObservesIncrementedRecoveryCount()
    {
        var registry1 = new TaskRegistry();
        using var host1 = TaskTestHost.Create(sharedRegistry: registry1);
        host1.Builder.AddTask<string, string>("rc", async (ctx, ct) =>
        {
            if (ctx.EntryMode == EntryMode.Fresh)
            {
                await ctx.ExitForRecoveryAsync(ct);
            }

            return $"rc={ctx.RecoveryCount}";
        });

        host1.SignalShutdown();
        TaskRun<string> handle = await host1.Invoker.StartAsync<string, string>(
            "rc", "x", new RunOptions { TaskId = "rc-1" });
        // Recovery deferral is an internal lifecycle handoff: it never surfaces on the run handle.
        // Wait for the engine to release the run, then confirm Completion stays pending.
        await host1.WaitUntilInactiveAsync(handle.TaskId, TimeSpan.FromSeconds(5));
        Assert.That(handle.Completion.IsCompleted, Is.False, "deferral must not complete the run handle");

        // A fresh run reports recovery count 0.
        var registry2 = new TaskRegistry();
        using var host2 = host1.Restart(registry2);
        int observedRecoveryCount = -1;
        host2.Builder.AddTask<string, string>("rc", (ctx, ct) =>
        {
            observedRecoveryCount = ctx.RecoveryCount;
            return Task.FromResult($"rc={ctx.RecoveryCount}");
        });

        int dispatched = await host2.Engine.ScanAndRecoverAsync();
        Assert.That(dispatched, Is.EqualTo(1));
        await host2.WaitUntilDeletedAsync("rc-1", TimeSpan.FromSeconds(5));

        // The reclaim bumped the lease generation from 0 to 1; recovery_count mirrors it (spec §22).
        Assert.That(observedRecoveryCount, Is.EqualTo(1));
    }

    [Test]
    public async Task RecoveryScanContinuesWhenOneRecordFailsToRehydrate()
    {
        var registry = new TaskRegistry();
        using var host = TaskTestHost.Create(sharedRegistry: registry);
        int goodRecovered = 0;

        host.Builder.AddTask<int, int>("bad", (ctx, ct) => Task.FromResult(ctx.Input));
        host.Builder.AddTask<string, string>("good", (ctx, ct) =>
        {
            if (ctx.EntryMode == EntryMode.Recovered)
            {
                goodRecovered++;
            }

            return Task.FromResult(ctx.Input);
        });

        string owner = LeaseManager.FormatOwner(host.AgentName, host.SessionId);
        await host.Store.CreateAsync(new Azure.AI.AgentServer.Core.Tasks.Providers.TaskCreateRequest
        {
            Id = "bad-1",
            AgentName = host.AgentName,
            SessionId = host.SessionId,
            Title = "bad",
            Status = "in_progress",
            LeaseOwner = owner,
            LeaseInstanceId = "bad-worker",
            LeaseDurationSeconds = 60,
            Payload = new System.Text.Json.Nodes.JsonObject
            {
                [TaskWireKeys.PayloadSchemaVersion] = TaskWireKeys.SchemaVersionValue,
                [TaskWireKeys.PayloadInput] = "not-an-int",
                [TaskWireKeys.PayloadLastInputId] = "bad-1",
            },
            Source = new System.Text.Json.Nodes.JsonObject
            {
                [TaskWireKeys.SourceType] = TaskWireKeys.SourceTypeValue,
                [TaskWireKeys.SourceName] = "bad",
                [TaskWireKeys.SourceServerVersion] = "test",
            },
        });

        await host.Store.CreateAsync(new Azure.AI.AgentServer.Core.Tasks.Providers.TaskCreateRequest
        {
            Id = "good-1",
            AgentName = host.AgentName,
            SessionId = host.SessionId,
            Title = "good",
            Status = "in_progress",
            LeaseOwner = owner,
            LeaseInstanceId = "good-worker",
            LeaseDurationSeconds = 60,
            Payload = new System.Text.Json.Nodes.JsonObject
            {
                [TaskWireKeys.PayloadSchemaVersion] = TaskWireKeys.SchemaVersionValue,
                [TaskWireKeys.PayloadInput] = "payload",
                [TaskWireKeys.PayloadLastInputId] = "good-1",
            },
            Source = new System.Text.Json.Nodes.JsonObject
            {
                [TaskWireKeys.SourceType] = TaskWireKeys.SourceTypeValue,
                [TaskWireKeys.SourceName] = "good",
                [TaskWireKeys.SourceServerVersion] = "test",
            },
        });

        int dispatched = await host.Engine.ScanAndRecoverAsync();

        Assert.That(dispatched, Is.EqualTo(1), "only the valid record should dispatch");
        // Recovery dispatch is asynchronous: ScanAndRecoverAsync returns once the good record is
        // dispatched, but the recovered handler runs on a background task. Wait for that task to
        // complete (record deleted) before asserting the handler observed the recovery — asserting
        // goodRecovered immediately would race the dispatch.
        await host.WaitUntilDeletedAsync("good-1", TimeSpan.FromSeconds(5));
        Assert.That(goodRecovered, Is.EqualTo(1), "scan should continue after one record faults");
        Assert.That(await host.Store.GetAsync("bad-1"), Is.Not.Null, "faulting record remains for later retry/manual handling");
    }

    [Test]
    public async Task RecoveryScanProcessesAllPages()
    {
        var registry = new TaskRegistry();
        using var host = TaskTestHost.Create(sharedRegistry: registry);
        int recovered = 0;
        host.Builder.AddTask<string, string>("paged", (ctx, ct) =>
        {
            if (ctx.EntryMode == EntryMode.Recovered)
            {
                Interlocked.Increment(ref recovered);
            }

            return Task.FromResult(ctx.Input);
        });

        string owner = LeaseManager.FormatOwner(host.AgentName, host.SessionId);
        for (int i = 0; i < 25; i++)
        {
            await host.Store.CreateAsync(new Azure.AI.AgentServer.Core.Tasks.Providers.TaskCreateRequest
            {
                Id = $"paged-{i:D2}",
                AgentName = host.AgentName,
                SessionId = host.SessionId,
                Title = $"paged-{i:D2}",
                Status = "in_progress",
                LeaseOwner = owner,
                LeaseInstanceId = $"worker-{i:D2}",
                LeaseDurationSeconds = 60,
                Payload = new System.Text.Json.Nodes.JsonObject
                {
                    [TaskWireKeys.PayloadSchemaVersion] = TaskWireKeys.SchemaVersionValue,
                    [TaskWireKeys.PayloadInput] = $"payload-{i:D2}",
                    [TaskWireKeys.PayloadLastInputId] = $"paged-{i:D2}",
                },
                Source = new System.Text.Json.Nodes.JsonObject
                {
                    [TaskWireKeys.SourceType] = TaskWireKeys.SourceTypeValue,
                    [TaskWireKeys.SourceName] = "paged",
                    [TaskWireKeys.SourceServerVersion] = "test",
                },
            });
        }

        int dispatched = await host.Engine.ScanAndRecoverAsync();

        Assert.That(dispatched, Is.EqualTo(25), "scan must follow all list pages, not only the first page");
        for (int i = 0; i < 25; i++)
        {
            await host.WaitUntilDeletedAsync($"paged-{i:D2}", TimeSpan.FromSeconds(5));
        }

        Assert.That(recovered, Is.EqualTo(25));
    }

    private sealed record CallIdInput(
        [property: JsonPropertyName("call_id")] string? CallId,
        string Prompt);
}
