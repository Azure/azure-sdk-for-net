// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Tracks the lifecycle state of a response builder instance.
/// Used to enforce correct ordering of <c>EmitAdded</c>, intermediate operations, and <c>EmitDone</c>.
/// </summary>
internal enum BuilderLifecycleState
{
    /// <summary>Builder created but <c>EmitAdded</c> not yet called.</summary>
    NotStarted,

    /// <summary><c>EmitAdded</c> called; intermediate operations (deltas) are allowed.</summary>
    Added,

    /// <summary><c>EmitDone</c> called; no further operations are allowed.</summary>
    Done,
}
