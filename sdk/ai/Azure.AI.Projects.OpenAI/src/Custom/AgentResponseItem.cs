// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI;

[CodeGenType("AgentResponseItem")]
public abstract partial class AgentResponseItem
{
    [CodeGenMember("CreatedBy")]
    public AgentItemSource ItemSource { get; }

    public string Id { get; }

    public static AgentResponseItem CreateStructuredOutputsItem(BinaryData output = null)
        => new AgentStructuredOutputsResponseItem(output);

    public static AgentResponseItem CreateWorkflowActionItem(string actionKind, string actionId)
        => new AgentWorkflowActionResponseItem(actionKind, actionKind, status: null);

    public ResponseItem AsResponseResultItem()
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

    public static implicit operator ResponseItem(AgentResponseItem agentResponseItem) => agentResponseItem.AsResponseResultItem();

    public static implicit operator AgentResponseItem(ResponseItem responseItem) => responseItem.AsAgentResponseItem();
}
