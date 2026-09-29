// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core;

/// <summary>
/// Defines callbacks that prepare an agent process for snapshot capture and restore it for a session.
/// </summary>
/// <remarks>
/// Implementations are registered as singletons and must be thread-safe. The library serializes callback
/// execution and handles platform retries, but implementations should keep their completed work idempotent.
/// </remarks>
public interface IAgentSnapshotLifecycle
{
    /// <summary>
    /// Releases process state that must not be inherited by restored sessions.
    /// </summary>
    /// <param name="cancellationToken">A token that is canceled when the host is stopping.</param>
    /// <returns>A task that completes when the process is ready to be captured.</returns>
    Task BeforeSnapshotAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Rebuilds process state for the restored session.
    /// </summary>
    /// <param name="context">The restored session context.</param>
    /// <param name="cancellationToken">A token that is canceled when the host is stopping.</param>
    /// <returns>A task that completes when the process is ready to serve the session.</returns>
    Task AfterRestoreAsync(
        AgentRestoreContext context,
        CancellationToken cancellationToken = default);
}
