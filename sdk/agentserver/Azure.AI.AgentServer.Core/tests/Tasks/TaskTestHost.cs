// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Serialization;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

/// <summary>Test harness that wires a <see cref="TaskEngine"/> over a temp-dir <see cref="LocalTaskStore"/>.</summary>
internal sealed class TaskTestHost : IDisposable
{
    private readonly string _tempDir;

    private TaskTestHost(string tempDir, LocalTaskStore store, TaskRegistry registry, string agentName, string sessionId)
    {
        _tempDir = tempDir;
        Store = store;
        Registry = registry;
        Builder = new ResilientTaskBuilder(registry, new TaskServiceProviderAccessor());
        AgentName = agentName;
        SessionId = sessionId;
        Engine = new TaskEngine(store, registry, agentName, sessionId);
    }

    public LocalTaskStore Store { get; }

    public TaskRegistry Registry { get; }

    public ResilientTaskBuilder Builder { get; }

    public TaskEngine Engine { get; }

    public string AgentName { get; }

    public string SessionId { get; }

    public static TaskTestHost Create(string? sharedDir = null, TaskRegistry? sharedRegistry = null,
        string agentName = "agent-a", string sessionId = "sess-1")
    {
        string dir = sharedDir ?? Path.Combine(Path.GetTempPath(), "agentserver-us1-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(dir);
        var store = new LocalTaskStore(dir);
        var registry = sharedRegistry ?? new TaskRegistry();
        return new TaskTestHost(dir, store, registry, agentName, sessionId);
    }

    /// <summary>Creates a second host (simulating a process restart) over the same store + a fresh registry copy.</summary>
    public TaskTestHost Restart(TaskRegistry registry)
        => new(_tempDir, new LocalTaskStore(_tempDir), registry, AgentName, SessionId);

    public ITaskInvoker Invoker => Engine;

    /// <summary>Signals cooperative shutdown on the engine so a handler may call
    /// <c>ExitForRecoveryAsync</c> (which is gated on <c>ctx.Shutdown</c>).</summary>
    public void SignalShutdown() => Engine.SignalShutdown();

    public async Task WaitUntilDeletedAsync(string taskId, TimeSpan timeout)
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();
        while (sw.Elapsed < timeout)
        {
            if (await Store.GetAsync(taskId).ConfigureAwait(false) is null)
            {
                return;
            }

            await Task.Delay(20).ConfigureAwait(false);
        }

        throw new TimeoutException($"Task '{taskId}' was not deleted within {timeout}.");
    }

    /// <summary>Polls the store until the task reaches <paramref name="status"/> (or times out).</summary>
    public async Task<TaskRecord> WaitForStatusAsync(string taskId, string status, TimeSpan timeout)
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();
        while (sw.Elapsed < timeout)
        {
            TaskRecord? record = await Store.GetAsync(taskId).ConfigureAwait(false);
            if (record is not null && string.Equals(record.Status, status, StringComparison.Ordinal))
            {
                return record;
            }

            await Task.Delay(20).ConfigureAwait(false);
        }

        throw new TimeoutException($"Task '{taskId}' did not reach status '{status}' within {timeout}.");
    }

    public void Dispose()
    {
        Engine.Dispose();
        try
        {
            Directory.Delete(_tempDir, recursive: true);
        }
        catch (IOException)
        {
        }
    }
}
