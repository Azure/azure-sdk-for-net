// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// Options for a single task invocation. Maps Python's <c>run</c>/<c>start</c> keyword
/// arguments.
/// </summary>
public sealed class RunOptions
{
    /// <summary>An explicit task id for identity-based convergence; generated when omitted.</summary>
    public string? TaskId { get; init; }

    /// <summary>
    /// An explicit per-turn input id; generated when omitted. When the task-bound stream is used,
    /// the id must not be reused by a different task while that stream is retained.
    /// </summary>
    public string? InputId { get; init; }

    /// <summary>A precondition on the last accepted input id, including inputs still queued (FR-006).</summary>
    /// <remarks>
    /// Requires an explicit <see cref="InputId"/>. A known accepted head must match this value.
    /// If no accepted head has been recorded, the invocation seeds it with <see cref="InputId"/>.
    /// </remarks>
    public string? IfLastInputId { get; init; }
}
