// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Extensions.OpenAI.Internal;

/// <summary>
/// Base class for generated response item extensions that are not yet emitted by
/// the OpenAI .NET SDK.
/// </summary>
public abstract class ResponseItem : global::OpenAI.Responses.ResponseItem
{
    internal ResponseItem()
        : base(default)
    {
    }

    /// <summary> Initializes a new instance of <see cref="ResponseItem"/>. </summary>
    /// <param name="kind"> The response item kind. </param>
    protected ResponseItem(global::OpenAI.Responses.ResponseItemKind kind)
        : base(kind)
    {
    }

    /// <summary> Initializes a new instance of <see cref="ResponseItem"/>. </summary>
    /// <param name="kind"> The response item kind. </param>
    /// <param name="agentReference"> The agent that created the item. </param>
    /// <param name="responseId"> The response on which the item is created. </param>
    internal ResponseItem(global::OpenAI.Responses.ResponseItemKind kind, AgentReference agentReference, string responseId)
        : base(kind)
    {
        AgentReference = agentReference;
        ResponseId = responseId;
    }

    /// <summary> The agent that created the item. </summary>
    public AgentReference AgentReference { get; }

    /// <summary> The response on which the item is created. </summary>
    public string ResponseId { get; }
}
