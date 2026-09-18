// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.AgentServer.Core.Tasks.Engine;

/// <summary>
/// Cooperative per-turn timeout watchdog (FR-015/FR-016). The deadline is computed from the
/// <em>persisted</em> turn-start timestamp (<c>_turn_started_at</c>), not the current lifetime's
/// wall clock, so a crash-and-recover cannot reset the budget — a recovered turn reads the same
/// absolute deadline. On expiry it flags the timeout cause <em>before</em> raising the cooperative
/// cancellation signal (strict cause-before-cancel ordering), and never force-stops the handler.
/// </summary>
internal sealed class TimeoutWatchdog : IAsyncDisposable
{
    private readonly CancellationTokenSource _stop = new();
    private readonly Task _loop;

    private TimeoutWatchdog(DateTimeOffset deadline, TimeSpan budget, Action onTimeout, CancellationTokenSource handlerCts)
    {
        _loop = RunAsync(deadline, budget, onTimeout, handlerCts, _stop.Token);
    }

    /// <summary>
    /// Starts a watchdog for the given persisted turn start and timeout, or returns
    /// <see langword="null"/> when no timeout is configured.
    /// </summary>
    public static TimeoutWatchdog? Start(
        DateTimeOffset turnStartedAt, TimeSpan? timeout, Action onTimeout, CancellationTokenSource handlerCts)
    {
        if (timeout is not { } budget || budget < TimeSpan.Zero)
        {
            return null;
        }

        // A zero budget means "time out immediately": the deadline is the turn start, so the
        // watchdog fires on its first tick (Python parity — timeout=0 is a valid immediate timeout).
        return new TimeoutWatchdog(turnStartedAt + budget, budget, onTimeout, handlerCts);
    }

    private static async Task RunAsync(
        DateTimeOffset deadline, TimeSpan budget, Action onTimeout, CancellationTokenSource handlerCts, CancellationToken stop)
    {
        try
        {
            // Clamp to [0, budget] for clock-skew safety (SOT §"timeout watchdog"): a persisted
            // turn-start timestamp ahead of this node's clock must never extend the sleep beyond
            // the configured timeout.
            TimeSpan remaining = deadline - DateTimeOffset.UtcNow;
            if (remaining > budget)
            {
                remaining = budget;
            }

            if (remaining > TimeSpan.Zero)
            {
                await Task.Delay(remaining, stop).ConfigureAwait(false);
            }

            // Cause-before-cancel (FR-016): flag the timeout cause, then signal cancellation.
            onTimeout();
            await handlerCts.CancelAsync().ConfigureAwait(false);
        }
        catch (OperationCanceledException)
        {
            // The handler finished (or the turn ended) before the deadline — stop quietly.
        }
    }

    public async ValueTask DisposeAsync()
    {
        _stop.Cancel();
        try
        {
            await _loop.ConfigureAwait(false);
        }
        catch
        {
            // Teardown is best-effort.
        }

        _stop.Dispose();
    }
}
