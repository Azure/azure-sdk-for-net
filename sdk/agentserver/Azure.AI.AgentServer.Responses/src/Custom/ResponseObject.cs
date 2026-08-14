// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.AgentServer.Responses.Models;

/// <summary>
/// Layer 3 convenience extensions for <see cref="ResponseObject"/>.
/// </summary>
public partial class ResponseObject
{
    /// <summary>
    /// Creates a new <see cref="ResponseObject"/> with minimal required fields.
    /// </summary>
    /// <param name="id">The unique response identifier (e.g. "resp_abc123").</param>
    /// <param name="model">The model that generated this response (e.g. "gpt-4o").</param>
    /// <remarks>
    /// Defaults: <c>CreatedAt</c> = <see cref="DateTimeOffset.UtcNow"/>,
    /// empty <c>Output</c>, <c>ParallelToolCalls</c> = false, nullable fields = null.
    /// Use property setters to customize after construction.
    /// </remarks>
    public ResponseObject(string id, string model)
        : this(
            id: id,
            createdAt: DateTimeOffset.UtcNow,
            error: null!,
            incompleteDetails: null!,
            output: Array.Empty<OutputItem>(),
            instructions: null!,
            parallelToolCalls: false,
            agentReference: null!)
    {
        Model = model;
    }
}
