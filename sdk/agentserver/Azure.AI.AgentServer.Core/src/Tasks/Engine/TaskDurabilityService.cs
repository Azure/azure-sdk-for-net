// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Azure.AI.AgentServer.Core.Tasks.Engine;

/// <summary>
/// The FR-022 durability background loop. Runs a <b>periodic recovery scan</b> (default cadence
/// <see cref="TaskEngineConstants.RecoveryScanIntervalSeconds"/>) that re-lists this owner's
/// <c>in_progress</c> tasks and re-invokes any whose execution was interrupted by a crash or a
/// lease takeover — without waiting for a cold process restart. The complementary per-active-task
/// lease-renewal loop runs inside the engine's turn execution (one renewal task per active turn),
/// so this service owns only the standing recovery sweep.
/// </summary>
/// <remarks>
/// Selected as the <see cref="IHostedService"/> only when the host opts in to resilient tasks.
/// <see cref="StartAsync"/> runs the cold-start scan (blocking startup per SOT §49) and then spawns
/// the periodic loop; <see cref="StopAsync"/> tears the loop down on graceful shutdown.
/// </remarks>
internal sealed class TaskDurabilityService : IHostedService, IAsyncDisposable
{
    private readonly RecoveryScanner _scanner;
    private readonly TaskEngine _engine;
    private readonly TimeSpan _scanInterval;
    private readonly TimeSpan _shutdownGrace;
    private readonly ILogger _logger;
    private readonly ResilientTaskEnablementState _enablement;
    private readonly SemaphoreSlim _activationGate = new(1, 1);
    private readonly SemaphoreSlim _scanGate = new(1, 1);
    private CancellationTokenSource _stopCts = new();
    private Task? _loop;
    private string? _completedRestoreId;
    private string? _preparedRestoreId;
    private int _disposed;

    internal bool IsStarted => _loop is not null;

    public TaskDurabilityService(
        RecoveryScanner scanner,
        TaskEngine engine,
        TimeSpan? scanInterval = null,
        TimeSpan? shutdownGrace = null,
        ILogger? logger = null,
        ResilientTaskEnablementState? enablement = null)
    {
        _scanner = scanner ?? throw new ArgumentNullException(nameof(scanner));
        _engine = engine ?? throw new ArgumentNullException(nameof(engine));
        _scanInterval = scanInterval
            ?? TimeSpan.FromSeconds(TaskEngineConstants.RecoveryScanIntervalSeconds);
        _shutdownGrace = shutdownGrace ?? TaskEngineConstants.ShutdownGrace;
        _logger = logger ?? NullLogger.Instance;
        _enablement = enablement
            ?? new ResilientTaskEnablementState(enabled: true, ready: true);
    }

    /// <summary>
    /// Runs the cold-start recovery scan to completion, then starts the periodic recovery-scan
    /// loop. The initial scan is awaited before returning so recovered handlers are visible
    /// before any HTTP route goes live (SOT §49: "The cold-start scan blocks startup until done").
    /// Safe to call again after <see cref="StopAsync"/>.
    /// </summary>
    public Task StartAsync(CancellationToken cancellationToken = default)
        => ActivateAsync(
            restoreId: null,
            cancellationToken);

    internal Task ActivateAfterRestoreAsync(
        string restoreId,
        CancellationToken cancellationToken = default)
        => ActivateAsync(
            restoreId,
            cancellationToken);

    internal async Task PrepareAfterRestoreAsync(
        string restoreId,
        CancellationToken cancellationToken = default)
    {
        await _activationGate.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            if (_completedRestoreId is not null
                && !string.Equals(
                    _completedRestoreId,
                    restoreId,
                    StringComparison.Ordinal)
                && !string.Equals(
                    _preparedRestoreId,
                    restoreId,
                    StringComparison.Ordinal))
            {
                await _scanGate.WaitAsync(cancellationToken).ConfigureAwait(false);
                try
                {
                    _engine.RotateLeaseInstanceIfIdle();
                }
                finally
                {
                    _scanGate.Release();
                }
            }

            _preparedRestoreId = restoreId;
        }
        finally
        {
            _activationGate.Release();
        }
    }

    private async Task ActivateAsync(
        string? restoreId,
        CancellationToken cancellationToken)
    {
        await _activationGate.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            if (_loop is not null
                && (restoreId is null
                    || string.Equals(
                        _completedRestoreId,
                        restoreId,
                        StringComparison.Ordinal)))
            {
                return;
            }

            if (_stopCts.IsCancellationRequested)
            {
                _stopCts.Dispose();
                _stopCts = new CancellationTokenSource();
            }

            _logger.TaskManagerStarting(
                _engine.Owner,
                _engine.InstanceId,
                Azure.AI.AgentServer.Core.FoundryEnvironment.IsHosted);

            using CancellationTokenSource startupCts =
                CancellationTokenSource.CreateLinkedTokenSource(
                    cancellationToken,
                    _stopCts.Token);
            try
            {
                await ScanOnceAsync(startupCts.Token).ConfigureAwait(false);
            }
            catch (OperationCanceledException) when (startupCts.IsCancellationRequested)
            {
                _enablement.MarkStopped();
                return;
            }
            catch (Exception ex)
            {
                _enablement.MarkStopped();
                _logger.RecoveryScanFailed(ex.GetType().Name);
                throw;
            }

            _loop ??= Task.Run(
                () => RunLoopAsync(_stopCts.Token),
                CancellationToken.None);
            _completedRestoreId = restoreId;
            _preparedRestoreId = restoreId;
            _enablement.MarkReady();
        }
        finally
        {
            _activationGate.Release();
        }
    }

    /// <summary>
    /// Stops the recovery loop deterministically, then gracefully shuts the engine down: in-flight
    /// turns get up to <see cref="TaskEngineConstants.ShutdownGrace"/> to checkpoint before their
    /// leases are force-expired, so a restarted process reclaims the still-<c>in_progress</c> work
    /// immediately instead of waiting the lease TTL (FR-017, Python <c>TaskManager.shutdown()</c>).
    /// </summary>
    public async Task StopAsync(CancellationToken cancellationToken = default)
    {
        SignalStop();
        if (_loop is not null)
        {
            _stopCts.Cancel();
            try
            {
                await _loop.ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                // Expected on stop.
            }
            finally
            {
                _loop = null;
            }
        }

        // Force-expire in-flight leases after the grace window so recovery is immediate on restart.
        await _engine.ShutdownAsync(_shutdownGrace, cancellationToken).ConfigureAwait(false);
    }

    internal async Task RollbackAsync()
    {
        SignalStop();
        if (_loop is not null)
        {
            try
            {
                await _loop.ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
            }
            finally
            {
                _loop = null;
            }
        }

        await _engine.ShutdownForRollbackAsync().ConfigureAwait(false);
    }

    internal void SignalStop()
    {
        if (Volatile.Read(ref _disposed) != 0)
        {
            return;
        }

        _enablement.MarkStopped();
        _ = _engine.BeginShutdown();
        _stopCts.Cancel();
    }

    internal void SignalRollbackStop()
    {
        if (Volatile.Read(ref _disposed) != 0)
        {
            return;
        }

        _enablement.MarkStopped();
        _ = _engine.BeginRollbackShutdown();
        _stopCts.Cancel();
    }

    internal void DisposeAfterShutdown()
    {
        if (Interlocked.Exchange(ref _disposed, 1) == 0)
        {
            _stopCts.Dispose();
        }
    }

    /// <summary>
    /// Runs a single recovery sweep on demand. Exposed for deterministic testing and reused by the
    /// loop so both paths share identical reclaim semantics.
    /// </summary>
    internal async Task<int> ScanOnceAsync(
        CancellationToken cancellationToken = default)
    {
        await _scanGate.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            return await _scanner.ScanAsync(cancellationToken).ConfigureAwait(false);
        }
        finally
        {
            _scanGate.Release();
        }
    }

    private async Task RunLoopAsync(CancellationToken stopToken)
    {
        // The cold-start scan already ran (blocking) in StartAsync; the loop now sweeps every
        // interval to reclaim tasks orphaned by a crash or lease takeover during steady-state.
        while (!stopToken.IsCancellationRequested)
        {
            try
            {
                await Task.Delay(_scanInterval, stopToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                return;
            }

            try
            {
                await ScanOnceAsync(stopToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                return;
            }
            catch (Exception ex)
            {
                // A failed sweep must never tear down the loop; the next interval retries.
                _logger.RecoveryScanFailed(ex.GetType().Name);
            }
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (Volatile.Read(ref _disposed) != 0)
        {
            return;
        }

        await StopAsync().ConfigureAwait(false);
        DisposeAfterShutdown();
    }
}
