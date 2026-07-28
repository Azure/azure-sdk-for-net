// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.AgentServer.Core.Streaming;

/// <summary>
/// Raised when <see cref="IEventStream.EmitAsync"/> is called after the stream
/// has been closed. This signals a producer bug (the producer should not emit
/// after closing); HTTP layers should treat it as a server error (5xx), not a
/// client error. Mirrors Python's <c>EventStreamClosedError</c>.
/// </summary>
public sealed class EventStreamClosedException : EventStreamException
{
    /// <summary>Initializes a new instance of the <see cref="EventStreamClosedException"/> class.</summary>
    public EventStreamClosedException()
    {
    }

    /// <summary>Initializes a new instance of the <see cref="EventStreamClosedException"/> class.</summary>
    /// <param name="message">The error message.</param>
    public EventStreamClosedException(string message)
        : base(message)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="EventStreamClosedException"/> class.</summary>
    /// <param name="message">The error message.</param>
    /// <param name="innerException">The underlying cause.</param>
    public EventStreamClosedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
