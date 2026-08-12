// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Invocations.Internal;

/// <summary>Stable identity marker for an Invocations-owned WebSocket endpoint.</summary>
internal sealed class InvocationsEndpointOwnerMetadata
{
    private InvocationsEndpointOwnerMetadata()
    {
    }

    internal static InvocationsEndpointOwnerMetadata Instance { get; } = new();
}
