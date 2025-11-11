// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.Projects.OpenAI;

[CodeGenType("StructuredOutputsItemResource")]
public partial class AgentStructuredOutputsResponseItem
{
    public AgentStructuredOutputsResponseItem(BinaryData output)
        : this(AgentResponseItemKind.StructuredOutputs, createdBy: new(),  id: null, additionalBinaryDataProperties: null, output: output)
    { }
}
