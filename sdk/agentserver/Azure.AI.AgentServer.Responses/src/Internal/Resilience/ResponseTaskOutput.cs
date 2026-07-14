// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Internal.Resilience;

/// <summary>
/// The Core resilient-task output (<c>TOutput</c>) for a response invocation. The durable response
/// envelope itself lives in the <see cref="ResponsesProvider"/> (the response projection); this
/// lightweight result only reports how the task turn settled, so a caller awaiting the Core
/// <c>TaskRun</c> can observe the terminal disposition. Serialized by Core via
/// <see cref="System.Text.Json.JsonSerializer"/>, so it is a plain POCO.
/// </summary>
internal sealed class ResponseTaskOutput
{
    /// <summary>Initializes a new instance of the <see cref="ResponseTaskOutput"/> class.</summary>
    public ResponseTaskOutput()
    {
    }

    /// <summary>Gets or sets the response id this task turn settled.</summary>
    public string ResponseId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets whether the recovery re-invocation was dropped because the durable record was
    /// definitively absent (the original connection closed without returning a response id).
    /// </summary>
    public bool WasDropped { get; set; }

    /// <summary>Gets or sets the terminal status of the response, when known.</summary>
    public ResponseStatus? Status { get; set; }

    /// <summary>Creates an output for a normally-settled turn.</summary>
    public static ResponseTaskOutput Completed(string responseId, ResponseStatus? status) =>
        new() { ResponseId = responseId, Status = status };

    /// <summary>Creates an output for a dropped recovery re-invocation.</summary>
    public static ResponseTaskOutput Dropped(string responseId) =>
        new() { ResponseId = responseId, WasDropped = true };
}
