// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.ServerSentEvents;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.Core;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public sealed class TaskStreamTests
{
    [Test]
    public async Task CompletedLiveTaskStreamIsImmediatelyReclaimed()
    {
        using TaskTestHost host = TaskTestHost.Create(
            configureStreams: options => options.UseInMemoryLive());
        host.Builder.AddTask<string, string>(
            "live-stream",
            async (context, cancellationToken) =>
            {
                await context.Stream.EmitAsync(
                    new SseItem<string>("event", "status"),
                    cancellationToken);
                return "done";
            });

        TaskRun<string> run = await host.Invoker.StartAsync<string, string>(
            "live-stream",
            "input",
            new RunOptions { TaskId = "live-stream-1" });
        Assert.That(await run.Completion, Is.EqualTo("done"));

        Assert.ThrowsAsync<AgentEventStreamNotFoundException>(
            async () => await host.Streams.GetAsync(run.InputId));
    }

    [Test]
    public async Task RunAndContextShareInputStreamAndSuccessClosesIt()
    {
        using TaskTestHost host = TaskTestHost.Create(
            configureStreams: options => options.UseInMemoryReplay());
        string? contextInputId = null;
        host.Builder.AddTask<string, string>(
            "stream",
            async (context, cancellationToken) =>
            {
                contextInputId = context.InputId;
                await context.Stream.EmitAsync(
                    new SseItem<string>("hello", "token") { EventId = "1" },
                    cancellationToken);
                return "done";
            });

        TaskRun<string> run = await host.Invoker.StartAsync<string, string>(
            "stream",
            "input",
            new RunOptions { TaskId = "stream-1" });
        Assert.That(await run.Completion, Is.EqualTo("done"));

        List<SseItem<string>> events = await ReadAllAsync(run.Stream);
        Assert.That(contextInputId, Is.EqualTo(run.InputId));
        Assert.That(events.Select(item => item.Data), Is.EqualTo(new[] { "hello" }));
    }

    [Test]
    public async Task RetryReusesStreamAndDoesNotCloseBetweenAttempts()
    {
        using TaskTestHost host = TaskTestHost.Create(
            configureStreams: options => options.UseInMemoryReplay());
        host.Builder.AddTask<string, string>(
            "retry-stream",
            async (context, cancellationToken) =>
            {
                await context.Stream.EmitAsync(
                    new SseItem<string>(
                        $"attempt-{context.RetryAttempt}",
                        "attempt")
                    {
                        EventId = (context.RetryAttempt + 1).ToString(),
                    },
                    cancellationToken);
                if (context.RetryAttempt == 0)
                {
                    throw new InvalidOperationException("retry");
                }

                return "done";
            },
            configure: options => options.Retry = new TaskRetryPolicy
            {
                MaxAttempts = 2,
                Delay = DelayStrategy.CreateFixedDelayStrategy(TimeSpan.Zero),
            });

        TaskRun<string> run = await host.Invoker.StartAsync<string, string>(
            "retry-stream",
            "input",
            new RunOptions { TaskId = "retry-stream-1" });
        Assert.That(await run.Completion, Is.EqualTo("done"));

        List<SseItem<string>> events = await ReadAllAsync(run.Stream);
        Assert.That(
            events.Select(item => item.Data),
            Is.EqualTo(new[] { "attempt-0", "attempt-1" }));
    }

    [Test]
    public async Task ExplicitCancellationClosesStream()
    {
        using TaskTestHost host = TaskTestHost.Create(
            configureStreams: options => options.UseInMemoryReplay());
        var started = new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);
        var never = new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);
        host.Builder.AddTask<string, string>(
            "cancel-stream",
            async (context, cancellationToken) =>
            {
                await context.Stream.EmitAsync(
                    new SseItem<string>("started", "status") { EventId = "1" },
                    cancellationToken);
                started.TrySetResult();
                await never.Task.WaitAsync(cancellationToken);
                return "unreachable";
            });

        TaskRun<string> run = await host.Invoker.StartAsync<string, string>(
            "cancel-stream",
            "input",
            new RunOptions { TaskId = "cancel-stream-1" });
        await started.Task.WaitAsync(TimeSpan.FromSeconds(5));
        await run.RequestCancellationAsync();

        Assert.ThrowsAsync<OperationCanceledException>(
            async () => await run.Completion);
        List<SseItem<string>> events = await ReadAllAsync(run.Stream);
        Assert.That(events.Select(item => item.Data), Is.EqualTo(new[] { "started" }));
    }

    [Test]
    public async Task MultiTurnUsesDistinctStreamForEachInput()
    {
        using TaskTestHost host = TaskTestHost.Create(
            configureStreams: options => options.UseInMemoryReplay());
        host.Builder.AddMultiTurnTask<string, string>(
            "multi-stream",
            async (context, cancellationToken) =>
            {
                await context.Stream.EmitAsync(
                    new SseItem<string>(context.Input, "turn") { EventId = "1" },
                    cancellationToken);
                return context.Input;
            });

        TaskRun<string> first = await host.Invoker.StartAsync<string, string>(
            "multi-stream",
            "first",
            new RunOptions { TaskId = "chain-1", InputId = "turn-1" });
        Assert.That(await first.Completion, Is.EqualTo("first"));

        TaskRun<string> second = await host.Invoker.StartAsync<string, string>(
            "multi-stream",
            "second",
            new RunOptions { TaskId = "chain-1", InputId = "turn-2" });
        Assert.That(await second.Completion, Is.EqualTo("second"));

        Assert.That(
            (await ReadAllAsync(first.Stream)).Select(item => item.Data),
            Is.EqualTo(new[] { "first" }));
        Assert.That(
            (await ReadAllAsync(second.Stream)).Select(item => item.Data),
            Is.EqualTo(new[] { "second" }));
    }

    [Test]
    public async Task RecoveryContinuesSameOpenStream()
    {
        string streamDir =
            Path.Combine(Path.GetTempPath(), "agentserver-task-stream-" + Guid.NewGuid().ToString("N"));
        var registry1 = new TaskRegistry();
        using TaskTestHost host1 = TaskTestHost.Create(
            sharedRegistry: registry1,
            configureStreams: options => options.UseFileBackedReplay(streamDir));
        host1.Builder.AddTask<string, string>(
            "recover-stream",
            async (context, cancellationToken) =>
            {
                await context.Stream.EmitAsync(
                    new SseItem<string>("before", "status") { EventId = "1" },
                    cancellationToken);
                await context.ExitForRecoveryAsync(cancellationToken);
                return "deferred";
            });

        host1.SignalShutdown();
        TaskRun<string> run = await host1.Invoker.StartAsync<string, string>(
            "recover-stream",
            "input",
            new RunOptions { TaskId = "recover-stream-1" });
        await host1.WaitUntilInactiveAsync(run.TaskId, TimeSpan.FromSeconds(5));
        Assert.That(run.Completion.IsCompleted, Is.False);

        AgentEventStream processOneStream =
            await host1.Streams.GetAsync(run.InputId);
        (processOneStream as IDisposable)?.Dispose();

        var registry2 = new TaskRegistry();
        using TaskTestHost host2 = host1.Restart(registry2);
        var recovered = new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);
        host2.Builder.AddTask<string, string>(
            "recover-stream",
            async (context, cancellationToken) =>
            {
                await context.Stream.EmitAsync(
                    new SseItem<string>("after", "status") { EventId = "2" },
                    cancellationToken);
                recovered.TrySetResult();
                return "done";
            });

        Assert.That(await host2.Engine.ScanAndRecoverAsync(), Is.EqualTo(1));
        await recovered.Task.WaitAsync(TimeSpan.FromSeconds(5));
        await host2.WaitUntilInactiveAsync(run.TaskId, TimeSpan.FromSeconds(5));

        AgentEventStream recoveredStream =
            await host2.Streams.GetAsync(run.InputId);
        var events = new List<SseItem<string>>();
        await foreach (SseItem<string> item in recoveredStream.Subscribe())
        {
            events.Add(item);
        }

        Assert.That(
            events.Select(item => item.Data),
            Is.EqualTo(new[] { "before", "after" }));
    }

    [Test]
    public async Task UnusedTaskStreamDoesNotCreateFileBacking()
    {
        string streamDir =
            Path.Combine(Path.GetTempPath(), "agentserver-unused-stream-" + Guid.NewGuid().ToString("N"));
        try
        {
            using TaskTestHost host = TaskTestHost.Create(
                configureStreams: options => options.UseFileBackedReplay(streamDir));
            host.Builder.AddTask<string, string>(
                "no-stream",
                (context, cancellationToken) => Task.FromResult(context.Input));

            Assert.That(
                await host.Invoker.RunAsync<string, string>(
                    "no-stream",
                    "done",
                    new RunOptions { TaskId = "no-stream-1" }),
                Is.EqualTo("done"));
            Assert.That(Directory.Exists(streamDir), Is.False);
        }
        finally
        {
            try
            {
                Directory.Delete(streamDir, recursive: true);
            }
            catch (DirectoryNotFoundException)
            {
            }
        }
    }

    [Test]
    public async Task SubscribeAfterUnusedStreamCompletesWithNoEvents()
    {
        using TaskTestHost host = TaskTestHost.Create(
            configureStreams: options => options.UseInMemoryReplay());
        host.Builder.AddTask<string, string>(
            "empty-stream",
            (context, cancellationToken) => Task.FromResult("done"));

        TaskRun<string> run = await host.Invoker.StartAsync<string, string>(
            "empty-stream",
            "input",
            new RunOptions { TaskId = "empty-stream-1" });
        Assert.That(await run.Completion, Is.EqualTo("done"));

        List<SseItem<string>> events = await ReadAllAsync(run.Stream)
            .WaitAsync(TimeSpan.FromSeconds(5));
        Assert.That(events, Is.Empty);
    }

    [Test]
    public async Task DeletingMultiTurnChainDoesNotDeleteTurnStream()
    {
        using TaskTestHost host = TaskTestHost.Create(
            configureStreams: options => options.UseInMemoryReplay());
        TaskDefinition<string, string> definition =
            host.Builder.AddMultiTurnTask<string, string>(
                "delete-chain",
                async (context, cancellationToken) =>
                {
                    await context.Stream.EmitAsync(
                        new SseItem<string>("retained", "turn") { EventId = "1" },
                        cancellationToken);
                    return "done";
                });

        TaskRun<string> run = await definition.StartAsync(
            "input",
            new RunOptions { TaskId = "delete-chain-1", InputId = "delete-turn-1" });
        Assert.That(await run.Completion, Is.EqualTo("done"));

        await definition.DeleteAsync(run.TaskId);

        AgentEventStream retained = await host.Streams.GetAsync(run.InputId);
        var events = new List<SseItem<string>>();
        await foreach (SseItem<string> item in retained.Subscribe())
        {
            events.Add(item);
        }

        Assert.That(events.Select(item => item.Data), Is.EqualTo(new[] { "retained" }));
    }

    [Test]
    public async Task DeleteAfterRecoveryDeferralClosesPersistedTurnStream()
    {
        string streamDir =
            Path.Combine(Path.GetTempPath(), "agentserver-delete-recovery-stream-" + Guid.NewGuid().ToString("N"));
        var registry1 = new TaskRegistry();
        try
        {
            using (TaskTestHost host1 = TaskTestHost.Create(
                sharedRegistry: registry1,
                configureStreams: options => options.UseFileBackedReplay(streamDir)))
            {
                TaskDefinition<string, string> original =
                    host1.Builder.AddMultiTurnTask<string, string>(
                        "delete-recovery",
                        async (context, cancellationToken) =>
                        {
                            await context.Stream.EmitAsync(
                                new SseItem<string>("before", "status") { EventId = "1" },
                                cancellationToken);
                            await context.ExitForRecoveryAsync(cancellationToken);
                            return "deferred";
                        });

                host1.SignalShutdown();
                TaskRun<string> run = await original.StartAsync(
                    "input",
                    new RunOptions
                    {
                        TaskId = "delete-recovery-task",
                        InputId = "delete-recovery-input",
                    });
                await host1.WaitUntilInactiveAsync(run.TaskId, TimeSpan.FromSeconds(5));
                (await host1.Streams.GetAsync(run.InputId) as IDisposable)?.Dispose();

                var registry2 = new TaskRegistry();
                using (TaskTestHost host2 = host1.Restart(registry2))
                {
                    TaskDefinition<string, string> recovered =
                        host2.Builder.AddMultiTurnTask<string, string>(
                            "delete-recovery",
                            (context, cancellationToken) => Task.FromResult(context.Input));

                    await recovered.DeleteAsync(run.TaskId);

                    (await host2.Streams.GetAsync(run.InputId) as IDisposable)?.Dispose();
                    string contents = await File.ReadAllTextAsync(
                        Path.Combine(streamDir, run.InputId + ".jsonl"));
                    Assert.That(contents, Does.Contain("\"__terminal__\":true"));
                }
            }
        }
        finally
        {
            try
            {
                Directory.Delete(streamDir, recursive: true);
            }
            catch (DirectoryNotFoundException)
            {
            }
        }
    }

    [Test]
    public async Task DeletingTaskWithoutMaterializedStreamDoesNotCreateBacking()
    {
        string streamDir =
            Path.Combine(Path.GetTempPath(), "agentserver-delete-unused-stream-" + Guid.NewGuid().ToString("N"));
        try
        {
            using TaskTestHost host = TaskTestHost.Create(
                configureStreams: options => options.UseFileBackedReplay(streamDir));
            TaskDefinition<string, string> definition =
                host.Builder.AddMultiTurnTask<string, string>(
                    "delete-unused",
                    (context, cancellationToken) => Task.FromResult(context.Input));

            TaskRun<string> run = await definition.StartAsync(
                "input",
                new RunOptions
                {
                    TaskId = "delete-unused-task",
                    InputId = "delete-unused-input",
                });
            Assert.That(await run.Completion, Is.EqualTo("input"));

            await definition.DeleteAsync(run.TaskId);

            Assert.That(Directory.Exists(streamDir), Is.False);
        }
        finally
        {
            try
            {
                Directory.Delete(streamDir, recursive: true);
            }
            catch (DirectoryNotFoundException)
            {
            }
        }
    }

    [Test]
    public async Task OneShotHotReclaimUsesPersistedInputIdForStream()
    {
        string streamDir =
            Path.Combine(Path.GetTempPath(), "agentserver-hot-stream-" + Guid.NewGuid().ToString("N"));
        var registry1 = new TaskRegistry();
        using TaskTestHost host1 = TaskTestHost.Create(
            sharedRegistry: registry1,
            configureStreams: options => options.UseFileBackedReplay(streamDir));
        host1.Builder.AddTask<string, string>(
            "hot-stream",
            async (context, cancellationToken) =>
            {
                await context.Stream.EmitAsync(
                    new SseItem<string>("before", "status") { EventId = "1" },
                    cancellationToken);
                await context.ExitForRecoveryAsync(cancellationToken);
                return "deferred";
            });

        host1.SignalShutdown();
        TaskRun<string> original = await host1.Invoker.StartAsync<string, string>(
            "hot-stream",
            "input",
            new RunOptions
            {
                TaskId = "hot-stream-1",
                InputId = "persisted-input",
            });
        await host1.WaitUntilInactiveAsync(original.TaskId, TimeSpan.FromSeconds(5));
        AgentEventStream processOneStream =
            await host1.Streams.GetAsync(original.InputId);
        (processOneStream as IDisposable)?.Dispose();

        var registry2 = new TaskRegistry();
        using TaskTestHost host2 = host1.Restart(registry2);
        host2.Builder.AddTask<string, string>(
            "hot-stream",
            async (context, cancellationToken) =>
            {
                await context.Stream.EmitAsync(
                    new SseItem<string>("after", "status") { EventId = "2" },
                    cancellationToken);
                return "done";
            });

        TaskRun<string> reclaimed = await host2.Invoker.StartAsync<string, string>(
            "hot-stream",
            "ignored",
            new RunOptions { TaskId = original.TaskId });
        Assert.That(reclaimed.InputId, Is.EqualTo("persisted-input"));
        Assert.That(await reclaimed.Completion, Is.EqualTo("done"));

        List<SseItem<string>> events = await ReadAllAsync(reclaimed.Stream);
        Assert.That(
            events.Select(item => item.Data),
            Is.EqualTo(new[] { "before", "after" }));
    }

    [Test]
    public async Task QueuedCancellationClosesQueuedInputStream()
    {
        using TaskTestHost host = TaskTestHost.Create(
            configureStreams: options => options.UseInMemoryReplay());
        var started = new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);
        var never = new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);
        host.Builder.AddMultiTurnTask<string, string>(
            "queued-stream",
            async (context, cancellationToken) =>
            {
                if (context.Input == "first")
                {
                    started.TrySetResult();
                    // Keep the first turn active while cancelling the queued input. The task is
                    // released explicitly below so this test does not race steering promotion.
                    await never.Task;
                }

                return context.Input;
            },
            steerable: true);

        TaskRun<string> first = await host.Invoker.StartAsync<string, string>(
            "queued-stream",
            "first",
            new RunOptions { TaskId = "queued-stream-1", InputId = "first-input" });
        await started.Task.WaitAsync(TimeSpan.FromSeconds(5));

        TaskRun<string> queued = await host.Invoker.StartAsync<string, string>(
            "queued-stream",
            "second",
            new RunOptions { TaskId = "queued-stream-1", InputId = "queued-input" });
        Assert.That(queued.IsQueued, Is.True);
        Assert.That(await queued.Stream.GetLastEventIdAsync(), Is.Null);

        await queued.RequestCancellationAsync();
        Assert.ThrowsAsync<OperationCanceledException>(
            async () => await queued.Completion);
        Assert.That(
            await ReadAllAsync(queued.Stream).WaitAsync(TimeSpan.FromSeconds(5)),
            Is.Empty);

        never.TrySetResult();
        Assert.That(await first.Completion, Is.EqualTo("first"));
    }

    [Test]
    public async Task UnrelatedTasksCannotReuseExplicitInputId()
    {
        using TaskTestHost host = TaskTestHost.Create(
            configureStreams: options => options.UseInMemoryReplay());
        host.Builder.AddTask<string, string>(
            "owner-a",
            async (context, cancellationToken) =>
            {
                await context.Stream.EmitAsync(
                    new SseItem<string>("owner-a", "owner") { EventId = "1" },
                    cancellationToken);
                return "done";
            });
        host.Builder.AddTask<string, string>(
            "owner-b",
            async (context, cancellationToken) =>
            {
                await context.Stream.EmitAsync(
                    new SseItem<string>("owner-b", "owner") { EventId = "1" },
                    cancellationToken);
                return "done";
            });

        TaskRun<string> first = await host.Invoker.StartAsync<string, string>(
            "owner-a",
            "input",
            new RunOptions { TaskId = "owner-a-task", InputId = "shared-input" });
        Assert.That(await first.Completion, Is.EqualTo("done"));

        TaskRun<string> second = await host.Invoker.StartAsync<string, string>(
            "owner-b",
            "input",
            new RunOptions { TaskId = "owner-b-task", InputId = "shared-input" });
        ResilientTaskException exception = Assert.ThrowsAsync<ResilientTaskException>(
            async () => await second.Completion);
        Assert.That(exception.ErrorCode, Is.EqualTo(ResilientTaskErrorCode.HandlerError));

        Assert.That(
            (await ReadAllAsync(first.Stream)).Select(item => item.Data),
            Is.EqualTo(new[] { "owner-a" }));
    }

    [Test]
    public async Task FileBackedOwnershipSurvivesRestart()
    {
        string streamDir =
            Path.Combine(Path.GetTempPath(), "agentserver-owned-stream-" + Guid.NewGuid().ToString("N"));
        try
        {
            using (TaskTestHost host1 = TaskTestHost.Create(
                configureStreams: options => options.UseFileBackedReplay(streamDir)))
            {
                host1.Builder.AddTask<string, string>(
                    "owner-a",
                    async (context, cancellationToken) =>
                    {
                        await context.Stream.EmitAsync(
                            new SseItem<string>("owner-a", "owner") { EventId = "1" },
                            cancellationToken);
                        return "done";
                    });

                TaskRun<string> first = await host1.Invoker.StartAsync<string, string>(
                    "owner-a",
                    "input",
                    new RunOptions { TaskId = "owner-a-task", InputId = "persistent-input" });
                Assert.That(await first.Completion, Is.EqualTo("done"));
                AgentEventStream stream = await host1.Streams.GetAsync(first.InputId);
                (stream as IDisposable)?.Dispose();
            }

            using TaskTestHost host2 = TaskTestHost.Create(
                configureStreams: options => options.UseFileBackedReplay(streamDir));
            host2.Builder.AddTask<string, string>(
                "owner-b",
                async (context, cancellationToken) =>
                {
                    await context.Stream.EmitAsync(
                        new SseItem<string>("owner-b", "owner") { EventId = "1" },
                        cancellationToken);
                    return "done";
                });

            TaskRun<string> second = await host2.Invoker.StartAsync<string, string>(
                "owner-b",
                "input",
                new RunOptions { TaskId = "owner-b-task", InputId = "persistent-input" });
            ResilientTaskException exception = Assert.ThrowsAsync<ResilientTaskException>(
                async () => await second.Completion);
            Assert.That(exception.ErrorCode, Is.EqualTo(ResilientTaskErrorCode.HandlerError));
        }
        finally
        {
            try
            {
                Directory.Delete(streamDir, recursive: true);
            }
            catch (DirectoryNotFoundException)
            {
            }
        }
    }

    [Test]
    public async Task FileBackedOwnershipIsReleasedWhenStreamIsDeleted()
    {
        string streamDir =
            Path.Combine(Path.GetTempPath(), "agentserver-reused-stream-" + Guid.NewGuid().ToString("N"));
        try
        {
            using TaskTestHost host = TaskTestHost.Create(
                configureStreams: options => options.UseFileBackedReplay(streamDir));
            host.Builder.AddTask<string, string>(
                "owner-a",
                async (context, cancellationToken) =>
                {
                    await context.Stream.EmitAsync(
                        new SseItem<string>("owner-a", "owner") { EventId = "1" },
                        cancellationToken);
                    return "done";
                });
            host.Builder.AddTask<string, string>(
                "owner-b",
                async (context, cancellationToken) =>
                {
                    await context.Stream.EmitAsync(
                        new SseItem<string>("owner-b", "owner") { EventId = "1" },
                        cancellationToken);
                    return "done";
                });

            TaskRun<string> first = await host.Invoker.StartAsync<string, string>(
                "owner-a",
                "input",
                new RunOptions { TaskId = "owner-a-task", InputId = "reused-input" });
            Assert.That(await first.Completion, Is.EqualTo("done"));
            await host.Streams.DeleteAsync(first.InputId);

            TaskRun<string> second = await host.Invoker.StartAsync<string, string>(
                "owner-b",
                "input",
                new RunOptions { TaskId = "owner-b-task", InputId = "reused-input" });
            Assert.That(await second.Completion, Is.EqualTo("done"));
            Assert.That(
                (await ReadAllAsync(second.Stream)).Select(item => item.Data),
                Is.EqualTo(new[] { "owner-b" }));
            await host.Streams.DeleteAsync(second.InputId);
        }
        finally
        {
            try
            {
                Directory.Delete(streamDir, recursive: true);
            }
            catch (DirectoryNotFoundException)
            {
            }
        }
    }

    private static async Task<List<SseItem<string>>> ReadAllAsync(TaskStream stream)
    {
        var events = new List<SseItem<string>>();
        await foreach (SseItem<string> item in stream.Subscribe())
        {
            events.Add(item);
        }

        return events;
    }
}
