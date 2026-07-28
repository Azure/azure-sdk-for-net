// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.AgentServer.Core.Streaming;

/// <summary>
/// The process-level registry that maps stream ids to <see cref="IEventStream"/>
/// instances. Mirrors Python's module-global <c>streams</c> registry.
/// </summary>
public interface IEventStreamRegistry
{
    /// <summary>
    /// Returns the live stream registered under <paramref name="id"/>, or raises
    /// <see cref="EventStreamNotFoundException"/> for any id that is not currently
    /// a live stream. Never installs a tombstone.
    /// </summary>
    /// <param name="id">The stream id.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The live stream.</returns>
    ValueTask<IEventStream> GetAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the stream registered under <paramref name="id"/>, creating a fresh
    /// one if necessary. Idempotent — every caller using the same id gets the same
    /// instance; clears any prior tombstone for the id.
    /// </summary>
    /// <param name="id">The stream id.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The registered or newly-created stream.</returns>
    ValueTask<IEventStream> GetOrCreateAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes the stream and any backing resources for <paramref name="id"/> and
    /// installs a tombstone (even for an id that was never registered). Idempotent.
    /// </summary>
    /// <param name="id">The stream id.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that completes when the id has been deleted.</returns>
    ValueTask DeleteAsync(string id, CancellationToken cancellationToken = default);
}
