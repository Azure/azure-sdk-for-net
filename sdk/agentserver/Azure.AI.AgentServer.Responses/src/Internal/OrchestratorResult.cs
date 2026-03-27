// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Represents the outcome of a <see cref="ResponseOrchestrator.CreateAsync"/> call.
/// Either a synchronous result wrapping a completed <see cref="Models.ResponseObject"/>,
/// or a streaming result wrapping a processed event stream.
/// </summary>
internal sealed class OrchestratorResult
{
    private OrchestratorResult(Models.ResponseObject? response, IAsyncEnumerable<ResponseStreamEvent>? events, bool isStreaming)
    {
        Response = response;
        Events = events;
        IsStreaming = isStreaming;
    }

    /// <summary>Creates a synchronous result wrapping a completed Response.</summary>
    /// <param name="response">The completed Response.</param>
    /// <returns>An <see cref="OrchestratorResult"/> with <see cref="IsStreaming"/> = <c>false</c>.</returns>
    public static OrchestratorResult Completed(Models.ResponseObject response) =>
        new(response ?? throw new ArgumentNullException(nameof(response)), null, false);

    /// <summary>Creates a streaming result wrapping a processed event stream.</summary>
    /// <param name="events">The processed event stream from the orchestrator.</param>
    /// <returns>An <see cref="OrchestratorResult"/> with <see cref="IsStreaming"/> = <c>true</c>.</returns>
    public static OrchestratorResult Streaming(IAsyncEnumerable<ResponseStreamEvent> events) =>
        new(null, events ?? throw new ArgumentNullException(nameof(events)), true);

    /// <summary>Gets whether this is a streaming result.</summary>
    public bool IsStreaming { get; }

    /// <summary>Gets the completed Response. Non-null when <see cref="IsStreaming"/> is <c>false</c>.</summary>
    public Models.ResponseObject? Response { get; }

    /// <summary>Gets the processed event stream. Non-null when <see cref="IsStreaming"/> is <c>true</c>.</summary>
    public IAsyncEnumerable<ResponseStreamEvent>? Events { get; }
}
