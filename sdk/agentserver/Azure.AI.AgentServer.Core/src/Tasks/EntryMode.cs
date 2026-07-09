// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// Describes how a task handler was entered for the current turn. Recovery is
/// observable only through this enum (there is no public recovery counter),
/// matching the Python <c>TaskContext</c> surface.
/// </summary>
public enum EntryMode
{
    /// <summary>The handler is running for the first time for this input.</summary>
    Fresh,

    /// <summary>The handler resumed after a suspension (e.g. awaiting steering input).</summary>
    Resumed,

    /// <summary>The handler was recovered after a process crash or lease takeover.</summary>
    Recovered,
}
