// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Options for configuring the built-in in-memory <see cref="ResponsesProvider"/> implementation.
/// </summary>
/// <remarks>
/// <para>
/// These options only affect the built-in <c>InMemoryResponsesProvider</c>.
/// Custom <see cref="ResponsesProvider"/> implementations manage their own
/// storage and eviction policies independently.
/// </para>
/// <para>
/// Response data (envelopes, input items, output items, history, and conversation
/// membership) is retained indefinitely. Only event stream replay buffers are
/// evicted after <see cref="EventStreamTtl"/>.
/// </para>
/// </remarks>
public class InMemoryProviderOptions
{
    /// <summary>
    /// Gets or sets the time-to-live for event stream replay buffers.
    /// After this duration, SSE replay is no longer available for completed responses.
    /// Default: 10 minutes.
    /// </summary>
    public TimeSpan EventStreamTtl { get; set; } = TimeSpan.FromMinutes(10);
}
