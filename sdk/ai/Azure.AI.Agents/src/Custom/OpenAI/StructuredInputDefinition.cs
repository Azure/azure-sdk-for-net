// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.AI.Agents;

namespace Azure.AI.Projects.OpenAI;

[CodeGenType("StructuredInputDefinition")]
public partial class StructuredInputDefinition
{
    [CodeGenMember("Required")]
    public bool? IsRequired { get; set; }
}
