// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// Thrown when a steerable multi-turn task already has the maximum number of
/// pending steering inputs queued and cannot accept another.
/// </summary>
public sealed class SteeringQueueFullException : TaskException
{
    /// <summary>Initializes a new instance of the <see cref="SteeringQueueFullException"/> class.</summary>
    public SteeringQueueFullException()
        : base("The task steering queue is full.")
    {
    }

    /// <summary>Initializes a new instance of the <see cref="SteeringQueueFullException"/> class with a message.</summary>
    /// <param name="message">A description of the queue-full condition.</param>
    public SteeringQueueFullException(string message)
        : base(message)
    {
    }
}
