// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Singleton service that tracks in-flight and recently-completed response executions.
/// Provides pipeline context (execution tasks, cancellation, completion tracking).
/// State persistence and eviction are delegated to <see cref="ResponsesProvider"/>.
/// Implements <see cref="IHostedService"/> for graceful shutdown.
/// </summary>
internal sealed class ResponseExecutionTracker : IHostedService, IDisposable
{
    private readonly ConcurrentDictionary<(ResponseStorePartition Partition, string ResponseId), ResponseExecution> _executions = new();
    private readonly ILogger<ResponseExecutionTracker> _logger;

    /// <summary>
    /// Initializes a new instance of <see cref="ResponseExecutionTracker"/>.
    /// </summary>
    public ResponseExecutionTracker(ILogger<ResponseExecutionTracker> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Creates a new <see cref="ResponseExecution"/> and registers it for tracking.
    /// </summary>
    public ResponseExecution Create(string responseId, PlatformContext context,
        bool isBackground = false, bool isStreaming = false, bool store = true)
    {
        var partition = ResponseStorePartition.FromContext(context);
        var execution = new ResponseExecution(responseId, partition, isBackground, isStreaming, store);
        if (!_executions.TryAdd((partition, responseId), execution))
        {
            execution.Dispose();
            throw new InvalidOperationException($"Response '{responseId}' is already being tracked.");
        }

        return execution;
    }

    public ResponseExecution Create(string responseId,
        bool isBackground = false, bool isStreaming = false, bool store = true) =>
        Create(responseId, PlatformContext.Empty, isBackground, isStreaming, store);

    /// <summary>
    /// Attempts to look up a tracked execution by response ID.
    /// </summary>
    public bool TryGet(string responseId, PlatformContext context, out ResponseExecution? execution)
    {
        return _executions.TryGetValue((ResponseStorePartition.FromContext(context), responseId), out execution);
    }

    public bool TryGet(string responseId, out ResponseExecution? execution) =>
        TryGet(responseId, PlatformContext.Empty, out execution);

    /// <summary>
    /// Removes a tracked execution by response ID.
    /// </summary>
    /// <returns><c>true</c> if the execution was found and removed; otherwise <c>false</c>.</returns>
    public bool TryRemove(string responseId, PlatformContext context)
    {
        if (_executions.TryRemove((ResponseStorePartition.FromContext(context), responseId), out var execution))
        {
            execution.Dispose();
            return true;
        }

        return false;
    }

    public bool TryRemove(string responseId) => TryRemove(responseId, PlatformContext.Empty);

    /// <summary>
    /// Evicts a completed execution from the tracker so that subsequent API calls
    /// (GET, DELETE, Cancel) fall through to the durable <see cref="ResponsesProvider"/>.
    /// Unlike <see cref="TryRemove(string, PlatformContext)"/>, this does <b>not</b> dispose the execution —
    /// callers such as <see cref="ResponseOrchestrator.CancelAsync"/> may still hold
    /// a reference and read <see cref="ResponseExecution.Response"/> after the
    /// <see cref="ResponseExecution.FinalizedSignal"/> fires.
    /// </summary>
    /// <returns><c>true</c> if the execution was found and evicted; otherwise <c>false</c>.</returns>
    public bool TryEvict(string responseId, PlatformContext context)
    {
        return _executions.TryRemove((ResponseStorePartition.FromContext(context), responseId), out _);
    }

    public bool TryEvict(string responseId) => TryEvict(responseId, PlatformContext.Empty);

    /// <summary>
    /// Evicts a tracked execution using its immutable user partition and response ID.
    /// </summary>
    public bool TryEvict(ResponseExecution execution)
    {
        ArgumentNullException.ThrowIfNull(execution);
        return _executions.TryRemove((execution.Partition, execution.ResponseId), out _);
    }

    /// <inheritdoc/>
    public Task StartAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    /// <inheritdoc/>
    /// <remarks>
    /// Graceful-shutdown grace window (US4 Path A/B): each in-flight execution is first signalled
    /// — the dedicated <see cref="ResponseContext.Shutdown"/> token is triggered and
    /// <c>IsShutdownRequested = true</c> — so a cooperative handler can observe the shutdown and either
    /// wind down to a natural terminal (Path A) or call <see cref="ResponseContext.ExitForRecoveryAsync"/>
    /// to hand off to next-lifetime recovery. The handler's primary cancellation token is then cancelled to
    /// wake handlers parked at a safe boundary, and the framework waits for the background tasks to
    /// drain within the host's <c>HostOptions.ShutdownTimeout</c> — which serves as the grace window.
    /// If that window is exhausted with tasks still running, the process is terminated and any Row 1
    /// work resumes via the next-lifetime recovery scan (Path C fallback, FR-015).
    /// <para>
    /// Remaining divergence from Python (grace-window timing, tracked as CR5-F2-SHUTDOWN-GRACE):
    /// Python exposes a distinct <c>shutdown_grace_period_seconds</c> during which handlers are only
    /// signalled via <c>context.shutdown</c> (the primary cancellation signal is <em>not</em> tripped),
    /// letting a token-honouring handler mid-computation reach a natural terminal before force-cancel.
    /// The dedicated <see cref="ResponseContext.Shutdown"/> token now provides the same observation
    /// surface, but here the primary cancellation token is still cancelled immediately at shutdown
    /// (not only after a pre-cancel grace window). Fully decoupling that timing changes foreground-
    /// streaming and multiple e2e row-path semantics, so it is deferred pending review.
    /// </para>
    /// </remarks>
    public async Task StopAsync(CancellationToken cancellationToken)
    {
        foreach (var execution in _executions.Values)
        {
            // All tracked executions are in-flight (completed ones are eagerly evicted).
            // Signal shutdown BEFORE cancelling so handlers see the dedicated context.Shutdown
            // token fired and IsShutdownRequested == true.
            execution.ShutdownRequested = true;
            if (execution.Context is not null)
            {
                execution.Context.IsShutdownRequested = true;
            }

            try
            {
                await execution.CancellationTokenSource.CancelAsync();
            }
            catch (ObjectDisposedException) { }
        }

        var backgroundTasks = _executions.Values
            .Where(e => e.ExecutionTask is not null)
            .Select(e => e.ExecutionTask!)
            .ToArray();

        if (backgroundTasks.Length > 0)
        {
            // Wait for background tasks to complete, respecting the host's
            // HostOptions.ShutdownTimeout via the provided cancellationToken.
            // No hardcoded timeout — the host controls the deadline.
            try
            {
                await Task.WhenAll(backgroundTasks).WaitAsync(cancellationToken);
            }
            catch (OperationCanceledException)
            {
                _logger.LogWarning(
                    "Shutdown timeout reached with {Count} background task(s) still running",
                    backgroundTasks.Count(t => !t.IsCompleted));
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Error waiting for background tasks during shutdown");
            }
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        foreach (var execution in _executions.Values)
        {
            execution.Dispose();
        }
        _executions.Clear();
    }
}
