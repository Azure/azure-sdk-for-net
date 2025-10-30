// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;

namespace Azure.AI.Agents;

[CodeGenType("ItemResource")]
public partial class AgentResponseItem
{
    public static AgentResponseItem CreateStructuredOutputsItem(BinaryData output = null)
        => new AgentStructuredOutputsResponseItem(output);

    public static AgentResponseItem CreateWorkflowActionItem(string actionKind, string actionId)
        => new AgentWorkflowActionResponseItem(id: null, actionKind, actionKind, status: null);

    public OpenAI.Responses.ResponseItem AsOpenAIResponseItem()
    {
        BinaryData serializedAgentResponseItem = ModelReaderWriter.Write(
            this,
            ModelReaderWriterOptions.Json,
            AzureAIAgentsContext.Default);
        return ModelReaderWriter.Read<OpenAI.Responses.ResponseItem>(
            serializedAgentResponseItem,
            ModelReaderWriterOptions.Json,
            OpenAI.OpenAIContext.Default);
    }

    public static implicit operator OpenAI.Responses.ResponseItem(AgentResponseItem agentResponseItem) => agentResponseItem.AsOpenAIResponseItem();

    public static implicit operator AgentResponseItem(OpenAI.Responses.ResponseItem responseItem) => responseItem.AsAgentResponseItem();
}
