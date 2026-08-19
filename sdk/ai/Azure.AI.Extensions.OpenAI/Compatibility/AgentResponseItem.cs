// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

public abstract partial class AgentResponseItem
{
    private protected AgentResponseItem(ResponseItemKind kind) => Type = kind;

    private protected AgentResponseItem(AgentResponseItemKind kind) : this((ResponseItemKind)kind) { }

    internal AgentResponseItem(ResponseItemKind kind, string id, AgentReference agentReference, string responseId)
    {
        Type = kind;
        Id = id;
        AgentReference = agentReference;
        ResponseId = responseId;
    }

    internal AgentResponseItem() { }

    internal ResponseItemKind Type { get; }

    /// <summary> Gets the response item ID. </summary>
    public string Id { get; }

    /// <summary> Gets or sets the agent that created the item. </summary>
    public AgentReference AgentReference { get; set; }

    /// <summary> Gets or sets the response on which the item was created. </summary>
    public string ResponseId { get; set; }

    /// <summary> Creates a response item that contains structured output data. </summary>
    public static AgentResponseItem CreateStructuredOutputsItem(BinaryData output = null)
        => new AgentStructuredOutputsResponseItem(output);

    /// <summary> Creates a response item that represents a workflow preview action. </summary>
    public static AgentResponseItem CreateWorkflowPreviewActionItem(string actionKind, string actionId)
        => new AgentWorkflowPreviewActionResponseItem(actionKind, actionId, status: null);

    /// <summary> Converts this agent response item into an OpenAI response item. </summary>
    public ResponseItem AsResponseResultItem()
    {
        if (this is UnknownAgentResponseItem unknownItem && unknownItem.InnerItem is not null)
        {
            return unknownItem.InnerItem;
        }

        BinaryData data = ModelReaderWriter.Write(this, ModelReaderWriterOptions.Json, AzureAIExtensionsOpenAIContext.Default);
        return ModelReaderWriter.Read<ResponseItem>(data, ModelReaderWriterOptions.Json, OpenAIContext.Default);
    }

    /// <summary> Converts an agent response item into an OpenAI response item. </summary>
    public static implicit operator ResponseItem(AgentResponseItem agentResponseItem) => agentResponseItem?.AsResponseResultItem();

    /// <summary> Converts an OpenAI response item into an agent response item. </summary>
    public static implicit operator AgentResponseItem(ResponseItem responseItem) => responseItem?.AsAgentResponseItem();
}
