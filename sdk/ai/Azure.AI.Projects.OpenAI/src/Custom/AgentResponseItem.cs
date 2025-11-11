// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI;

[CodeGenType("ItemResource")]
public partial class AgentResponseItem
{
    public static AgentResponseItem CreateStructuredOutputsItem(BinaryData output = null)
        => new AgentStructuredOutputsResponseItem(output);

    public static AgentResponseItem CreateWorkflowActionItem(string actionKind, string actionId)
        => new AgentWorkflowActionResponseItem(id: null, actionKind, actionKind, status: null);

    public ResponseItem AsOpenAIResponseItem()
    {
        BinaryData serializedAgentResponseItem = ModelReaderWriter.Write(
            this,
            ModelReaderWriterOptions.Json,
            AzureAIProjectsOpenAIContext.Default);
        return ModelReaderWriter.Read<ResponseItem>(
            serializedAgentResponseItem,
            ModelReaderWriterOptions.Json,
            OpenAIContext.Default);
    }

    public static implicit operator ResponseItem(AgentResponseItem agentResponseItem) => agentResponseItem.AsOpenAIResponseItem();

    public static implicit operator AgentResponseItem(ResponseItem responseItem) => responseItem.AsAgentResponseItem();
}
