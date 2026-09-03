// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Streaming.Backings;

/// <summary>An event-stream backing the registry can forcibly destroy and clean up.</summary>
internal interface IDestroyableStream
{
    /// <summary>Transitions the stream to destroyed, completing subscribers and freeing backing resources.</summary>
    void Destroy();

    /// <summary>
    /// Opportunistically runs the close-clock check: if the stream is closed and its TTL deadline
    /// has elapsed, transitions it to destroyed (freeing resources and notifying the registry) and
    /// returns <see langword="true"/>. Side-effect-free otherwise. Lets a plain lookup observe the
    /// auto-tombstone without an emit/subscribe (mirrors Python's get-time close-clock check).
    /// </summary>
    /// <returns><see langword="true"/> if this call destroyed the stream.</returns>
    bool TryAutoDestroyIfElapsed();
}
