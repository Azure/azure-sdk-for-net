// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

/// <summary>Test harness that wires a <see cref="TaskEngine"/> over a temp-dir <see cref="LocalTaskStore"/>.</summary>
internal sealed class TaskTestHost : IDisposable
{
    private readonly string _tempDir;
    private readonly AgentEventStreamOptions _streamOptions;

    private TaskTestHost(
        string tempDir,
        LocalTaskStore store,
        TaskRegistry registry,
        string agentName,
        string sessionId,
        ILogger? logger,
        AgentEventStreamOptions streamOptions)
    {
        _tempDir = tempDir;
        _streamOptions = streamOptions;
        Store = store;
        Registry = registry;
        Streams = new InMemoryEventStreamRegistry(streamOptions);
        var engineAccessor = new TaskEngineAccessor();
        Builder = new DefaultResilientTaskBuilder(registry, engineAccessor);
        AgentName = agentName;
        SessionId = sessionId;
        Engine = new TaskEngine(store, registry, agentName, sessionId, Streams, logger);
        engineAccessor.Bind(Engine);
    }

    public LocalTaskStore Store { get; }

    public TaskRegistry Registry { get; }

    public AgentEventStreamRegistry Streams { get; }

    public DefaultResilientTaskBuilder Builder { get; }

    public TaskEngine Engine { get; }

    public string AgentName { get; }

    public string SessionId { get; }

    public static TaskTestHost Create(string? sharedDir = null, TaskRegistry? sharedRegistry = null,
        string agentName = "agent-a", string sessionId = "sess-1", ILogger? logger = null,
        Action<AgentEventStreamOptions>? configureStreams = null)
    {
        string dir = sharedDir ?? Path.Combine(Path.GetTempPath(), "agentserver-us1-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(dir);
        var store = new LocalTaskStore(dir);
        var registry = sharedRegistry ?? new TaskRegistry();
        var streamOptions = new AgentEventStreamOptions();
        configureStreams?.Invoke(streamOptions);
        return new TaskTestHost(
            dir,
            store,
            registry,
            agentName,
            sessionId,
            logger,
            streamOptions);
    }

    /// <summary>Creates a second host (simulating a process restart) over the same store + a fresh registry copy.</summary>
    public TaskTestHost Restart(TaskRegistry registry, ILogger? logger = null)
        => new(
            _tempDir,
            new LocalTaskStore(_tempDir),
            registry,
            AgentName,
            SessionId,
            logger,
            _streamOptions);

    /// <summary>
    /// The task engine, exposed for tests to start/run/look-up tasks by name (the same operations
    /// the typed <see cref="TaskDefinition{TInput, TOutput}"/> forwards to). Named <c>Invoker</c> for
    /// readability at call sites.
    /// </summary>
    public TaskEngine Invoker => Engine;

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

    /// <summary>
    /// Polls until the engine no longer holds an in-memory active run for <paramref name="taskId"/>.
    /// After a recovery deferral this becomes true once the lease has been released and the run
    /// removed — a deterministic barrier replacing the old "await the handle until it faults" pattern
    /// (deferral no longer surfaces on the run handle).
    /// </summary>
    public async Task WaitUntilInactiveAsync(string taskId, TimeSpan timeout)
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();
        while (sw.Elapsed < timeout)
        {
            if (!Engine.IsActive(taskId))
            {
                return;
            }

            await Task.Delay(20).ConfigureAwait(false);
        }

        throw new TimeoutException($"Task '{taskId}' was still active after {timeout}.");
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
