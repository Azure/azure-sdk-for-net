// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.Projects.OpenAI;

[CodeGenType("StructuredOutputsOutputItem")]
public partial class AgentStructuredOutputsResponseItem
{
    public AgentStructuredOutputsResponseItem(BinaryData output)
        : this(AgentResponseItemKind.StructuredOutputs, id: null, agentReference: null, responseId: null, additionalBinaryDataProperties: null, output: output)
    { }
}
