// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Common.Http.ServerSentEvent;

/// <summary>
/// Represents a Server-Sent Event (SSE) frame.
/// </summary>
/// <param name="Id">The event ID.</param>
/// <param name="Name">The event name.</param>
/// <param name="Data">The collection of data objects for the event.</param>
/// <param name="Comments">The collection of comment strings for the event.</param>
public record SseFrame(
    string? Id = null,
    string? Name = null,
    IList<object>? Data = null,
    IList<string>? Comments = null)
{
    /// <summary>
    /// Creates a new SSE frame with the specified properties.
    /// </summary>
    /// <param name="id">The event ID.</param>
    /// <param name="name">The event name.</param>
    /// <param name="data">The data object for the event.</param>
    /// <param name="comment">The comment string for the event.</param>
    /// <returns>A new <see cref="SseFrame"/> instance.</returns>
    public static SseFrame Of(string? id = null, string? name = null, object? data = null, string? comment = null)
    {
        return new SseFrame
        {
            Id = id,
            Name = name,
            Data = data != null ? [data] : null,
            Comments = comment != null ? [comment] : null
        };
    }
}
