// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Streaming.Backings;

/// <summary>The lifecycle state of an event-stream backing.</summary>
internal enum StreamState
{
    /// <summary>Open to emits and subscribable.</summary>
    Active,

    /// <summary>Closed: emits raise, existing subscribers drain, new subscribers may still attach.</summary>
    Closed,

    /// <summary>Destroyed: every operation raises <see cref="EventStreamNotFoundException"/>.</summary>
    Destroyed,
}
