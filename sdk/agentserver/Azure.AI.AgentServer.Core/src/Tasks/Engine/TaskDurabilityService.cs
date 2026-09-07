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
/// Registered as an <see cref="IHostedService"/> by <c>AddResilientTasks</c> so the host lifespan
/// drives it: <see cref="StartAsync"/> runs the cold-start scan (blocking startup per SOT §49) and
/// then spawns the periodic loop; <see cref="StopAsync"/> tears the loop down on graceful shutdown.
/// </remarks>
internal sealed class TaskDurabilityService : IHostedService, IAsyncDisposable
{
    private readonly RecoveryScanner _scanner;
    private readonly TaskEngine _engine;
    private readonly TimeSpan _scanInterval;
    private readonly TimeSpan _shutdownGrace;
    private readonly ILogger _logger;
    private CancellationTokenSource _stopCts = new();
    private Task? _loop;

    public TaskDurabilityService(
        RecoveryScanner scanner,
        TaskEngine engine,
        TimeSpan? scanInterval = null,
        TimeSpan? shutdownGrace = null,
        ILogger? logger = null)
    {
        _scanner = scanner ?? throw new ArgumentNullException(nameof(scanner));
        _engine = engine ?? throw new ArgumentNullException(nameof(engine));
        _scanInterval = scanInterval
            ?? TimeSpan.FromSeconds(TaskEngineConstants.RecoveryScanIntervalSeconds);
        _shutdownGrace = shutdownGrace ?? TaskEngineConstants.ShutdownGrace;
        _logger = logger ?? NullLogger.Instance;
    }

    /// <summary>
    /// Runs the cold-start recovery scan to completion, then starts the periodic recovery-scan
    /// loop. The initial scan is awaited before returning so recovered handlers are visible
    /// before any HTTP route goes live (SOT §49: "The cold-start scan blocks startup until done").
    /// Safe to call again after <see cref="StopAsync"/>.
    /// </summary>
    public async Task StartAsync(CancellationToken cancellationToken = default)
    {
        if (_loop is not null)
        {
            return;
        }

        if (_stopCts.IsCancellationRequested)
        {
            _stopCts.Dispose();
            _stopCts = new CancellationTokenSource();
        }

        // Emit the operator-facing startup marker once per process boot, carrying the stable lease
        // instance id (worker-<pid>-<hex>-<epoch>). A cross-process restart therefore surfaces as a
        // NEW instance in the logs — parity with Python's "TaskManager starting (owner, instance,
        // hosted)" line and the signal the hosted crash-recovery verifier greps to prove a restart.
        _logger.TaskManagerStarting(_engine.Owner, _engine.InstanceId, Azure.AI.AgentServer.Core.FoundryEnvironment.IsHosted);

        // Cold-start scan blocks startup (SOT §49). A transient failure is logged rather than
        // faulting startup; the periodic loop then retries on its cadence.
        try
        {
            await ScanOnceAsync(cancellationToken).ConfigureAwait(false);
        }
        catch (OperationCanceledException)
        {
            return;
        }
        catch (Exception ex)
        {
            _logger.RecoveryScanFailed(ex.GetType().Name);
        }

        _loop = Task.Run(() => RunLoopAsync(_stopCts.Token), CancellationToken.None);
    }

    /// <summary>
    /// Stops the recovery loop deterministically, then gracefully shuts the engine down: in-flight
    /// turns get up to <see cref="TaskEngineConstants.ShutdownGrace"/> to checkpoint before their
    /// leases are force-expired, so a restarted process reclaims the still-<c>in_progress</c> work
    /// immediately instead of waiting the lease TTL (FR-017, Python <c>TaskManager.shutdown()</c>).
    /// </summary>
    public async Task StopAsync(CancellationToken cancellationToken = default)
    {
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

    /// <summary>
    /// Runs a single recovery sweep on demand. Exposed for deterministic testing and reused by the
    /// loop so both paths share identical reclaim semantics.
    /// </summary>
    internal Task<int> ScanOnceAsync(CancellationToken cancellationToken = default)
        => _scanner.ScanAsync(cancellationToken);

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
        await StopAsync().ConfigureAwait(false);
        _stopCts.Dispose();
    }
}
