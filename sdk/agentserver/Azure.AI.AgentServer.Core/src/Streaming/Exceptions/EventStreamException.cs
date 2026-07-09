// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.AgentServer.Core.Streaming;

/// <summary>
/// Base type for all event-stream errors. Catch this to handle any streaming
/// failure uniformly. Mirrors Python's <c>EventStreamError</c>.
/// </summary>
public class EventStreamException : Exception
{
    /// <summary>Initializes a new instance of the <see cref="EventStreamException"/> class.</summary>
    public EventStreamException()
    {
    }

    /// <summary>Initializes a new instance of the <see cref="EventStreamException"/> class.</summary>
    /// <param name="message">The error message.</param>
    public EventStreamException(string message)
        : base(message)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="EventStreamException"/> class.</summary>
    /// <param name="message">The error message.</param>
    /// <param name="innerException">The underlying cause.</param>
    public EventStreamException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
