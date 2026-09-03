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

    /// <summary>An explicit per-turn input id; generated when omitted.</summary>
    public string? InputId { get; init; }

    /// <summary>A precondition requiring the task's last input id to equal this value (FR-006).</summary>
    public string? IfLastInputId { get; init; }
}
