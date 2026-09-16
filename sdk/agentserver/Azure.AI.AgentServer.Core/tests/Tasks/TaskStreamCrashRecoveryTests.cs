// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.ServerSentEvents;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public class TaskStreamCrashRecoveryTests
{
    private const string RootVariable = "AGENTSERVER_CRASH_TEST_ROOT";
    private const string ModeVariable = "AGENTSERVER_CRASH_TEST_MODE";
    private static readonly TimeSpan Timeout = TimeSpan.FromSeconds(15);

    [TestCase("suspend")]
    [TestCase("complete")]
    [TestCase("delete")]
    [TestCase("promotion")]
    [TestCase("queued-cancel")]
    [TestCase("before-suspend")]
    public async Task RestartRepairsOnlyStreamsWhoseWorkEnded(string mode)
    {
        string root = Path.Combine(Path.GetTempPath(), "agentserver-crash-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        try
        {
            await CrashAtCheckpoint(root, mode);
            string streamsDirectory = Path.Combine(root, "streams");
            using var host = TaskTestHost.Create(
                sharedDir: Path.Combine(root, "tasks"),
                configureStreams: options => options.UseFileBackedReplay(streamsDirectory, TimeSpan.FromMinutes(10)));
            var entered = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);
            var release = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
            int executions = 0;
            async Task<string> Recovered(TaskContext<string> context, CancellationToken token)
            {
                Interlocked.Increment(ref executions);
                try
                {
                    await context.Stream.EmitAsync(new SseItem<string>("resumed") { EventId = "2" }, CancellationToken.None);
                    entered.TrySetResult(context.InputId);
                    await release.Task;
                    return context.Input;
                }
                catch (Exception exception)
                {
                    entered.TrySetException(exception);
                    throw;
                }
            }
            if (mode == "complete")
            {
                host.Builder.AddTask<string, string>("crash", Recovered);
            }
            else
            {
                host.Builder.AddMultiTurnTask<string, string>("crash", Recovered, steerable: true);
            }

            using var stop = new CancellationTokenSource(Timeout);
            var readers = new List<Task<List<string>>>();
            try
            {
                bool hasLiveWork = mode is "promotion" or "queued-cancel" or "before-suspend";
                int recovered = await host.Engine.ScanAndRecoverAsync(stop.Token);
                Assert.That(recovered, Is.EqualTo(hasLiveWork ? 1 : 0));
                if (hasLiveWork)
                {
                    string liveId = mode == "promotion" ? "b" : "a";
                    Assert.That(await entered.Task.WaitAsync(Timeout), Is.EqualTo(liveId));
                    AgentEventStream live = await host.Streams.GetAsync(liveId, stop.Token);
                    Assert.That(await live.GetLastEventIdAsync(stop.Token), Is.EqualTo("2"),
                        "Recovered work must retain an open writer for its own input.");
                }
                else
                {
                    Assert.That(Volatile.Read(ref executions), Is.Zero,
                        "Repairing EOF must not rerun already-finished work.");
                }

                if (mode != "before-suspend")
                {
                    string endedId = mode == "queued-cancel" ? "b" : "a";
                    AgentEventStream? ended = await ((ITaskEventStreamRegistry)host.Streams)
                        .GetTaskStreamAsync("crash-task", endedId, stop.Token);
                    Assert.That(ended, Is.Not.Null, "Repair must preserve the existing replay backing.");
                    Task<List<string>> replay = ReadAll(ended!, stop.Token);
                    readers.Add(replay);
                    List<string> events = await replay.WaitAsync(Timeout);
                    Assert.That(events, Is.EqualTo(mode == "queued-cancel" ? Array.Empty<string>() : new[] { "first" }));
                }

                release.TrySetResult();
                if (hasLiveWork)
                {
                    await host.WaitUntilInactiveAsync("crash-task", Timeout);
                    string liveId = mode == "promotion" ? "b" : "a";
                    Task<List<string>> replay = ReadAll(await host.Streams.GetAsync(liveId), stop.Token);
                    readers.Add(replay);
                    Assert.That(await replay.WaitAsync(Timeout), Does.Contain("resumed"));
                }
                Assert.That(await host.Engine.ScanAndRecoverAsync(stop.Token), Is.Zero, "Repeated repair is idempotent.");
            }
            finally
            {
                release.TrySetResult();
                await host.WaitUntilInactiveAsync("crash-task", Timeout);
                stop.Cancel();
                foreach (Task reader in readers)
                {
                    try
                    { await reader; }
                    catch (OperationCanceledException) when (stop.IsCancellationRequested)
                    {
                        TestContext.WriteLine("Stopped an open replay reader during crash-test cleanup.");
                    }
                }
            }
        }
        finally
        {
            if (Directory.Exists(root))
            { Directory.Delete(root, recursive: true); }
        }
    }

    [Test]
    [Explicit("Launched only by the parent crash/restart harness.")]
    public async Task CrashWorker()
    {
        string root = Environment.GetEnvironmentVariable(RootVariable)
            ?? throw new InvalidOperationException("Crash worker root was not supplied.");
        string mode = Environment.GetEnvironmentVariable(ModeVariable)
            ?? throw new InvalidOperationException("Crash worker mode was not supplied.");
        using var host = TaskTestHost.Create(
            sharedDir: Path.Combine(root, "tasks"),
            configureStreams: options => options.UseFileBackedReplay(Path.Combine(root, "streams"), TimeSpan.FromMinutes(10)));
        var started = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var release = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        async Task<string> Producer(TaskContext<string> context, CancellationToken token)
        {
            await context.Stream.EmitAsync(new SseItem<string>("first") { EventId = "1" });
            if (context.Input == "a")
            {
                started.TrySetResult();
                await release.Task;
            }
            return context.Input;
        }
        if (mode == "complete")
        { host.Builder.AddTask<string, string>("crash", Producer); }
        else
        { host.Builder.AddMultiTurnTask<string, string>("crash", Producer, steerable: true); }
        using var engine = new TaskEngine(new CheckpointStore(host.Store, root, mode),
            host.Registry, host.AgentName, host.SessionId, host.Streams);
        TaskRun<string> a = await engine.StartAsync<string, string>("crash", "a",
            new RunOptions { TaskId = "crash-task", InputId = "a" });
        await started.Task.WaitAsync(Timeout);
        Task operation;
        if (mode == "delete")
        {
            operation = engine.DeleteAsync("crash", "crash-task");
        }
        else if (mode is "promotion" or "queued-cancel")
        {
            TaskRun<string> b = await engine.StartAsync<string, string>("crash", "b",
                new RunOptions { TaskId = "crash-task", InputId = "b" });
            _ = await b.Stream.GetLastEventIdAsync();
            if (mode == "queued-cancel")
            { operation = b.RequestCancellationAsync(); }
            else
            {
                release.TrySetResult();
                operation = a.Completion;
            }
        }
        else
        {
            release.TrySetResult();
            operation = a.Completion;
        }
        await operation;
        Assert.Fail("Worker unexpectedly passed its crash checkpoint.");
    }

    private static async Task CrashAtCheckpoint(string root, string mode)
    {
        var start = new ProcessStartInfo("dotnet")
        {
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true,
        };
        start.ArgumentList.Add("vstest");
        start.ArgumentList.Add(Assembly.GetExecutingAssembly().Location);
        start.ArgumentList.Add("--Tests:Azure.AI.AgentServer.Core.Tests.Tasks.TaskStreamCrashRecoveryTests.CrashWorker");
        start.ArgumentList.Add("--logger:console;verbosity=minimal");
        start.Environment[RootVariable] = root;
        start.Environment[ModeVariable] = mode;
        using Process process = Process.Start(start) ?? throw new InvalidOperationException("Could not start crash worker.");
        Task<string> output = process.StandardOutput.ReadToEndAsync();
        Task<string> error = process.StandardError.ReadToEndAsync();
        try
        {
            using var deadline = new CancellationTokenSource(TimeSpan.FromMinutes(1));
            string checkpoint = Path.Combine(root, "checkpoint");
            while (!File.Exists(checkpoint))
            {
                if (process.HasExited)
                {
                    Assert.Fail($"Crash worker exited before checkpoint ({process.ExitCode}).\n{await output}\n{await error}");
                }
                await Task.Delay(20, deadline.Token);
            }
            process.Kill(entireProcessTree: true);
            await process.WaitForExitAsync().WaitAsync(Timeout);
        }
        finally
        {
            if (!process.HasExited)
            {
                process.Kill(entireProcessTree: true);
                await process.WaitForExitAsync().WaitAsync(Timeout);
            }
            _ = await output;
            _ = await error;
        }
    }

    private static async Task<List<string>> ReadAll(AgentEventStream stream, CancellationToken cancellationToken)
    {
        var events = new List<string>();
        await foreach (SseItem<string> item in stream.Subscribe(cancellationToken: cancellationToken))
        {
            events.Add(item.Data);
        }
        return events;
    }

    private sealed class CheckpointStore(ITaskStore inner, string root, string mode) : ITaskStore
    {
        public Task<TaskRecord> CreateAsync(TaskCreateRequest request, CancellationToken cancellationToken = default)
            => inner.CreateAsync(request, cancellationToken);
        public Task<TaskRecord?> GetAsync(string taskId, CancellationToken cancellationToken = default)
            => inner.GetAsync(taskId, cancellationToken);
        public Task<TaskListResult> ListAsync(TaskListQuery query, CancellationToken cancellationToken = default)
            => inner.ListAsync(query, cancellationToken);
        public async Task DeleteAsync(string taskId, string? ifMatch = null, bool force = false, bool cascade = false, CancellationToken cancellationToken = default)
        {
            await inner.DeleteAsync(taskId, ifMatch, force, cascade, cancellationToken);
            if (mode == "delete")
            { await Pause(); }
        }
        public async Task<TaskRecord> PatchAsync(string taskId, TaskPatchRequest patch, string? ifMatch, CancellationToken cancellationToken = default)
        {
            bool target = mode switch
            {
                "suspend" or "before-suspend" => patch.Status == TaskWireKeys.StatusSuspended,
                "complete" => patch.Status == TaskWireKeys.StatusCompleted,
                "promotion" => patch.Status == TaskWireKeys.StatusInProgress
                    && (string?)patch.Payload?[TaskWireKeys.PayloadActiveInputId] == "b",
                "queued-cancel" => patch.Status is null
                    && patch.Payload?[TaskWireKeys.PayloadSteering]?[TaskWireKeys.SteeringPendingInputIds] is System.Text.Json.Nodes.JsonArray pending
                    && pending.Count == 0,
                _ => false,
            };
            if (target && mode == "before-suspend")
            { await Pause(); }
            TaskRecord updated = await inner.PatchAsync(taskId, patch, ifMatch, cancellationToken);
            if (target)
            { await Pause(); }
            return updated;
        }
        private async Task Pause()
        {
            using (var checkpoint = new FileStream(Path.Combine(root, "checkpoint"), FileMode.CreateNew, FileAccess.Write, FileShare.Read))
            {
                checkpoint.WriteByte(1);
                checkpoint.Flush(flushToDisk: true);
            }
            await Task.Delay(System.Threading.Timeout.InfiniteTimeSpan);
        }
    }
}
