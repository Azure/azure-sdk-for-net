// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

[CodeGenType("StructuredOutputsOutputItem")]
public partial class AgentStructuredOutputsResponseItem
{
    /// <summary> Initializes a new instance of <see cref="AgentStructuredOutputsResponseItem"/>. </summary>
    /// <param name="output"> The structured output data. </param>
    public AgentStructuredOutputsResponseItem(BinaryData output)
        : this(id: null, agentReference: null, responseId: null, additionalBinaryDataProperties: null, output: output)
    { }

    /// <summary> Initializes a new instance of <see cref="AgentStructuredOutputsResponseItem"/>. </summary>
    /// <param name="id"></param>
    /// <param name="agentReference"> The agent that created the item. </param>
    /// <param name="responseId"> The response on which the item is created. </param>
    /// <param name="output"> The structured output captured during the response. </param>
    /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
    internal AgentStructuredOutputsResponseItem(string id, AgentReference agentReference, string responseId, BinaryData output, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(ResponseItemKind.StructuredOutputs)
    {
        Output = output;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }

    /// <summary> Initializes a new instance of <see cref="AgentStructuredOutputsResponseItem"/> for deserialization. </summary>
    internal AgentStructuredOutputsResponseItem(): base(ResponseItemKind.StructuredOutputs)
    {
    }

    /// <summary> Initializes a new instance of <see cref="AgentStructuredOutputsResponseItem"/>. </summary>
    /// <param name="type"></param>
    /// <param name="id"></param>
    /// <param name="agentReference"> The agent that created the item. </param>
    /// <param name="responseId"> The response on which the item is created. </param>
    /// <param name="output"> The structured output captured during the response. </param>
    /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
    internal AgentStructuredOutputsResponseItem(ResponseItemKind @type, string id, AgentReference agentReference, string responseId, BinaryData output, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(@type)
    {
        Output = output;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}
