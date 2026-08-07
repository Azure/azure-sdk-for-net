// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.AgentServer.Core.Streaming;

/// <summary>
/// Raised by any operation against an id that is not currently a live stream
/// (never registered, deleted, or close-clock elapsed). HTTP layers should
/// treat it as a 404. Mirrors Python's <c>EventStreamNotFoundError</c>.
/// </summary>
public sealed class EventStreamNotFoundException : EventStreamException
{
    /// <summary>Initializes a new instance of the <see cref="EventStreamNotFoundException"/> class.</summary>
    public EventStreamNotFoundException()
    {
    }

    /// <summary>Initializes a new instance of the <see cref="EventStreamNotFoundException"/> class.</summary>
    /// <param name="message">The error message.</param>
    public EventStreamNotFoundException(string message)
        : base(message)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="EventStreamNotFoundException"/> class.</summary>
    /// <param name="message">The error message.</param>
    /// <param name="innerException">The underlying cause.</param>
    public EventStreamNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
