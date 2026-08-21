// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591
#pragma warning disable AAIP001

using System;

namespace Azure.AI.Extensions.OpenAI;

public static partial class ExtensionsOpenAIModelFactory
{
    public static SharepointGroundingToolCall SharepointGroundingToolCall(
        string id = default,
        AgentReference agentReference = default,
        string responseId = default,
        string callId = default,
        string arguments = default,
        ToolCallStatus status = ToolCallStatus.InProgress)
        => new(id, agentReference, responseId, callId, arguments, status);

    public static SharepointGroundingToolCallOutput SharepointGroundingToolCallOutput(
        string id = default,
        AgentReference agentReference = default,
        string responseId = default,
        string callId = default,
        BinaryData output = default,
        ToolCallStatus status = ToolCallStatus.InProgress)
        => new(id, agentReference, responseId, callId, output, status);
}
