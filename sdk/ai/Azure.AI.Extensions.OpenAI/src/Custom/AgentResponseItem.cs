// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;
#pragma warning disable AAIP001

[CodeGenType("AgentResponseItem")]
public abstract partial class AgentResponseItem
{
    /// <summary> Gets the response item ID. </summary>
    public string Id { get; }

    /// <summary> Creates a response item that contains structured output data. </summary>
    /// <param name="output"> The structured output data. </param>
    /// <returns> The response item containing the structured output data. </returns>
    public static AgentResponseItem CreateStructuredOutputsItem(BinaryData output = null)
        => new AgentStructuredOutputsResponseItem(output);
    /// <summary> Creates a response item that represents a workflow preview action. </summary>
    /// <param name="actionKind"> The kind of workflow action. </param>
    /// <param name="actionId"> The ID of the workflow action. </param>
    /// <returns> The response item representing the workflow preview action. </returns>
    public static AgentResponseItem CreateWorkflowPreviewActionItem(string actionKind, string actionId)
        => new AgentWorkflowPreviewActionResponseItem(actionKind, actionId, status: null);

    /// <summary> Converts this agent response item into an OpenAI response item. </summary>
    /// <returns> The OpenAI response item representation. </returns>
    [Experimental("OPENAI001")]
    public ResponseItem AsResponseResultItem()
    {
        BinaryData serializedAgentResponseItem = ModelReaderWriter.Write(
            this,
            ModelReaderWriterOptions.Json,
            AzureAIExtensionsOpenAIContext.Default);
        return ModelReaderWriter.Read<ResponseItem>(
            serializedAgentResponseItem,
            ModelReaderWriterOptions.Json,
            OpenAIContext.Default);
    }

    /// <summary> Converts an <see cref="AgentResponseItem"/> into an OpenAI <see cref="ResponseItem"/>. </summary>
    /// <param name="agentResponseItem"> The agent response item to convert. </param>
    /// <returns> The OpenAI response item representation. </returns>
    public static implicit operator ResponseItem(AgentResponseItem agentResponseItem) => agentResponseItem.AsResponseResultItem();

    /// <summary> Converts an OpenAI <see cref="ResponseItem"/> into an <see cref="AgentResponseItem"/>. </summary>
    /// <param name="responseItem"> The OpenAI response item to convert. </param>
    /// <returns> The agent response item representation. </returns>
    public static implicit operator AgentResponseItem(ResponseItem responseItem) => responseItem.AsAgentResponseItem();
}
