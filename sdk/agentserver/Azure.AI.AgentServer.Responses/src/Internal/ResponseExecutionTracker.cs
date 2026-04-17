// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
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
    private readonly ConcurrentDictionary<string, ResponseExecution> _executions = new();
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
    public ResponseExecution Create(string responseId,
        bool isBackground = false, bool isStreaming = false, bool store = true)
    {
        var execution = new ResponseExecution(responseId, isBackground, isStreaming, store);
        if (!_executions.TryAdd(responseId, execution))
        {
            execution.Dispose();
            throw new InvalidOperationException($"Response '{responseId}' is already being tracked.");
        }

        return execution;
    }

    /// <summary>
    /// Attempts to look up a tracked execution by response ID.
    /// </summary>
    public bool TryGet(string responseId, out ResponseExecution? execution)
    {
        return _executions.TryGetValue(responseId, out execution);
    }

    /// <summary>
    /// Removes a tracked execution by response ID.
    /// </summary>
    /// <returns><c>true</c> if the execution was found and removed; otherwise <c>false</c>.</returns>
    public bool TryRemove(string responseId)
    {
        if (_executions.TryRemove(responseId, out var execution))
        {
            execution.Dispose();
            return true;
        }

        return false;
    }

    /// <summary>
    /// Evicts a completed execution from the tracker so that subsequent API calls
    /// (GET, DELETE, Cancel) fall through to the durable <see cref="ResponsesProvider"/>.
    /// Unlike <see cref="TryRemove"/>, this does <b>not</b> dispose the execution —
    /// callers such as <see cref="ResponseOrchestrator.CancelAsync"/> may still hold
    /// a reference and read <see cref="ResponseExecution.Response"/> after the
    /// <see cref="ResponseExecution.FinalizedSignal"/> fires.
    /// </summary>
    /// <returns><c>true</c> if the execution was found and evicted; otherwise <c>false</c>.</returns>
    public bool TryEvict(string responseId)
    {
        return _executions.TryRemove(responseId, out _);
    }

    /// <inheritdoc/>
    public Task StartAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    /// <inheritdoc/>
    public async Task StopAsync(CancellationToken cancellationToken)
    {
        foreach (var execution in _executions.Values)
        {
            // All tracked executions are in-flight (completed ones are eagerly evicted).
            // Signal shutdown BEFORE cancelling so handlers see IsShutdownRequested == true
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
