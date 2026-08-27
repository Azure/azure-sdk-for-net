// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.AgentServer.Core.Tasks.Engine;

/// <summary>
/// Performs the cold-start recovery scan before route binding: lists this owner's
/// <c>in_progress</c> tasks (filtered to the framework's reserved <c>sourceType</c>),
/// reclaims their leases, and re-invokes their handlers with
/// <see cref="EntryMode.Recovered"/> so work interrupted by a crash or lease takeover
/// resumes automatically (FR-022).
/// </summary>
internal sealed class RecoveryScanner
{
    private readonly TaskEngine _engine;

    public RecoveryScanner(TaskEngine engine) => _engine = engine;

    /// <summary>Runs the recovery scan once.</summary>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The number of tasks dispatched for recovery.</returns>
    public Task<int> ScanAsync(CancellationToken cancellationToken = default)
        => _engine.ScanAndRecoverAsync(cancellationToken);
}
