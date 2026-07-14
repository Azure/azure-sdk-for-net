// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Internal control signal yielded by <see cref="ResponseEventStream.Checkpoint"/>. It carries the
/// live response snapshot to the orchestrator, which persists it (gated to resilient background
/// responses) and then resumes the handler. It is NEVER forwarded to the SSE wire — the orchestrator
/// intercepts it by CLR type before any wire coercion.
/// <para>
/// Mirrors Python's <c>ResponseCheckpointEvent</c> (streaming/_checkpoint.py). The base
/// <see cref="ResponseStreamEvent"/> discriminator is a reserved sentinel that never reaches
/// serialization; the interception is purely type-based.
/// </para>
/// </summary>
internal sealed class ResponseCheckpointEvent : ResponseStreamEvent
{
    /// <summary>The reserved, never-serialized discriminator for the checkpoint control signal.</summary>
    internal const string CheckpointEventType = "__internal.checkpoint";

    /// <summary>
    /// Initializes a new instance of the <see cref="ResponseCheckpointEvent"/> class carrying the
    /// live response snapshot to be persisted.
    /// </summary>
    /// <param name="response">The live mutable response envelope to checkpoint.</param>
    public ResponseCheckpointEvent(ResponseObject response)
        : base(new ResponseStreamEventType(CheckpointEventType), sequenceNumber: 0)
    {
        Response = response;
    }

    /// <summary>Gets the live response snapshot to persist at this checkpoint.</summary>
    public ResponseObject Response { get; }
}
