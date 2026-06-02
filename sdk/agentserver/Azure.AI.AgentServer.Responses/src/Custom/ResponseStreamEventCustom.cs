// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses.Models;

/// <summary>
/// Customizations for <see cref="ResponseStreamEvent"/>.
/// </summary>
public abstract partial class ResponseStreamEvent
{
    /// <summary>
    /// Gets the event type discriminator (e.g. <c>response.created</c>, <c>response.completed</c>).
    /// </summary>
    /// <remarks>
    /// The generated <c>Type</c> property is internal. This public accessor
    /// allows consuming assemblies to inspect the event type.
    /// </remarks>
    public ResponseStreamEventType EventType => Type;
}
