// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Exception thrown when a requested resource (e.g., a response ID) is not found.
/// Maps to HTTP 404 Not Found.
/// </summary>
public class ResourceNotFoundException : Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="ResourceNotFoundException"/> with a message.
    /// </summary>
    /// <param name="message">A description of the missing resource.</param>
    public ResourceNotFoundException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ResourceNotFoundException"/> with a message
    /// and an inner exception.
    /// </summary>
    /// <param name="message">A description of the missing resource.</param>
    /// <param name="innerException">The exception that caused this error.</param>
    public ResourceNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
