// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Configuration options for the Responses API server SDK.
/// </summary>
public class ResponsesServerOptions
{
    /// <summary>
    /// Gets or sets the default model to use when <c>model</c> is omitted from a
    /// <c>CreateResponse</c> request. When <c>null</c> and the request omits <c>model</c>,
    /// an empty string is used. Request-level <c>model</c> always takes precedence.
    /// </summary>
    public string? DefaultModel { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of conversation history items that
    /// <see cref="ResponseContext.GetHistoryAsync"/> fetches. Default: 100.
    /// Can also be configured via the <c>DEFAULT_FETCH_HISTORY_ITEM_COUNT</c>
    /// environment variable (integer value). Programmatic configuration takes precedence.
    /// </summary>
    public int DefaultFetchHistoryCount { get; set; } = DefaultFetchHistoryCountValue;

    /// <summary>
    /// The default value for <see cref="DefaultFetchHistoryCount"/>.
    /// </summary>
    internal const int DefaultFetchHistoryCountValue = 100;

    /// <summary>
    /// Gets or sets whether background responses are resilient to process crashes and
    /// graceful shutdown. When <see langword="true"/>, accepted background responses
    /// (<c>store=true</c>, <c>background=true</c>) are registered with the durable task
    /// subsystem so that a handler interrupted by a crash or shutdown is re-invoked in a
    /// subsequent process lifetime with the original request context restored
    /// (<see cref="ResponseContext.IsRecovery"/> is <see langword="true"/>). When
    /// <see langword="false"/> (the default), an interrupted background response
    /// transitions to a failed terminal state and is not re-invoked.
    /// <para>
    /// Enabling this option requires resilient-capable response, task, and stream
    /// persistence providers to be registered; the server fails loudly at startup when
    /// they are missing rather than silently downgrading to weaker durability.
    /// </para>
    /// </summary>
    public bool ResilientBackground { get; set; }

    /// <summary>
    /// Gets or sets whether in-flight conversations accept steering (mid-turn additional
    /// input) sharing a single resilient task. When <see langword="true"/>, additional
    /// input submitted against an in-progress response for the same conversation is queued
    /// (<c>queued</c>) and drained by the running handler
    /// (<see cref="ResponseContext.IsSteeredTurn"/>, <see cref="ResponseContext.PendingInputCount"/>),
    /// forks are rejected with <c>409 conversation_fork_not_supported</c>, and overlapping
    /// turns are rejected with <c>409 conversation_locked</c>. When <see langword="false"/>
    /// (the default), steering is disabled.
    /// </summary>
    public bool SteerableConversations { get; set; }

    /// <summary>
    /// Gets or sets an optional hook that customizes the <c>queued</c> envelope returned to the
    /// caller when a new turn is queued behind an active steerable conversation (the .NET port of
    /// Python's <c>@app.response_acceptor</c>). The hook receives the incoming
    /// <see cref="Models.CreateResponse"/> request and the turn's <see cref="ResponseContext"/> and
    /// returns the <see cref="Models.ResponseObject"/> surfaced to the HTTP caller. When
    /// <see langword="null"/> (the default) a minimal envelope
    /// (<c>status="queued"</c>, empty output) is returned. If the hook throws, the framework falls
    /// back to the default envelope and logs a warning. The returned object's status is normalized
    /// to <see cref="Models.ResponseStatus.Queued"/> when unset.
    /// </summary>
    public Func<Models.CreateResponse, ResponseContext, Models.ResponseObject>? ResponseAcceptor { get; set; }
}
