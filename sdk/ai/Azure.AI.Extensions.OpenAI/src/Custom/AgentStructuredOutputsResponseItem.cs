// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

[CodeGenType("StructuredOutputsOutputItem")]
[CodeGenSuppress("Patch")]
public partial class AgentStructuredOutputsResponseItem
{
    /// <summary> Initializes a new instance of <see cref="AgentStructuredOutputsResponseItem"/>. </summary>
    /// <param name="output"> The structured output data. </param>
    public AgentStructuredOutputsResponseItem(BinaryData output)
        : base(ResponseItemKind.StructuredOutputs)
    {
        Id = null;
        Output = output;
    }

    /// <summary> Initializes a new instance of <see cref="AgentStructuredOutputsResponseItem"/> for deserialization. </summary>
    internal AgentStructuredOutputsResponseItem() : base(ResponseItemKind.StructuredOutputs)
    {
    }

    /// <summary> Initializes a new instance of <see cref="AgentStructuredOutputsResponseItem"/>. </summary>
    /// <param name="type"></param>
    /// <param name="id"></param>
    /// <param name="agentReference"> The agent that created the item. </param>
    /// <param name="responseId"> The response on which the item is created. </param>
    /// <param name="output"> The structured output captured during the response. </param>
    /// <param name="patch"></param>
    internal AgentStructuredOutputsResponseItem(ResponseItemKind @type, string id, AgentReference agentReference, string responseId, BinaryData output, in JsonPatch patch) : base(@type)
    {
        _patch = patch;
        this.ApplyAgentAttribution(agentReference, responseId, null);
        Id = id;
        Output = output;
    }
}
