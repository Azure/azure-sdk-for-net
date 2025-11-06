// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses.Invocation;

/// <summary>
/// Exception thrown when an agent invocation fails.
/// </summary>
/// <param name="error">The response error details.</param>
public class AgentInvocationException(Contracts.Generated.OpenAI.ResponseError error) : Exception
{
    /// <summary>
    /// Gets the response error details.
    /// </summary>
    public Contracts.Generated.OpenAI.ResponseError Error { get; } = error;
}
