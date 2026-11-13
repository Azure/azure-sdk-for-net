// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// A single validation error with a JSON path and human-readable message.
/// </summary>
public sealed class ValidationError
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationError"/> class.
    /// </summary>
    /// <param name="path">The JSON path to the invalid field (e.g., <c>$.model</c>, <c>$.tools[0].type</c>).</param>
    /// <param name="message">A human-readable description of the constraint that was violated.</param>
    public ValidationError(string path, string message)
    {
        Path = path;
        Message = message;
    }

    /// <summary>
    /// Gets the JSON path to the invalid field.
    /// </summary>
    public string Path { get; }

    /// <summary>
    /// Gets a human-readable description of the constraint that was violated.
    /// </summary>
    public string Message { get; }
}
