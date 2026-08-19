// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

public static partial class ExtensionsOpenAIModelFactory
{
    /// <summary> Creates a project conversation for mocking. </summary>
    public static ProjectConversation ProjectConversation(
        string id = default,
        IDictionary<string, string> metadata = default,
        DateTimeOffset createdAt = default)
        => new(id, "conversation", metadata, createdAt, additionalBinaryDataProperties: null);

    /// <summary> Creates an agent response item for mocking. </summary>
    public static AgentResponseItem AgentResponseItem(
        string type = default,
        string id = default,
        AgentReference agentReference = default,
        string responseId = default)
        => new UnknownAgentResponseItem(type, id, agentReference, responseId);
}
