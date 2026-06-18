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
        : this(ResponseItemKind.StructuredOutputs, id: null, agentReference: null, responseId: null, additionalBinaryDataProperties: null, output: output)
    { }
}
