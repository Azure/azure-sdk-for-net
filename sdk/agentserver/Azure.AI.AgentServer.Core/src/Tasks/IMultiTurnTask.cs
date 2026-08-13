// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// Lifecycle operations for multi-turn task chains. A multi-turn chain shares one
/// <c>taskId</c> across turns and parks at <c>suspended</c> between turns; ending the
/// chain is explicit.
/// </summary>
public interface IMultiTurnTask
{
    /// <summary>
    /// Ends a multi-turn chain: cancels any in-flight turn, resolves queued callers as
    /// cancelled, and removes the record. Idempotent — a no-op when the chain is absent.
    /// </summary>
    /// <param name="taskId">The chain id.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task that completes when the chain has been removed.</returns>
    Task DeleteAsync(string taskId, CancellationToken cancellationToken = default);
}
