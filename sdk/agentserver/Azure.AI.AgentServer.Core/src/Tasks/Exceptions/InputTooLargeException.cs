// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// Thrown when a task input (or steering input) exceeds the maximum size the
/// task store accepts after attachment promotion. Raised before any network
/// call when detected client-side.
/// </summary>
public sealed class InputTooLargeException : TaskException
{
    /// <summary>Initializes a new instance of the <see cref="InputTooLargeException"/> class.</summary>
    public InputTooLargeException()
        : base("The task input is too large.")
    {
    }

    /// <summary>Initializes a new instance of the <see cref="InputTooLargeException"/> class with a message.</summary>
    /// <param name="message">A description of the size violation.</param>
    public InputTooLargeException(string message)
        : base(message)
    {
    }
}
