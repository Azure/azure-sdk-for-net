// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.AI.Extensions.OpenAI;

namespace Azure.AI.Extensions.OpenAI;

[CodeGenType("StructuredInputDefinition")]
public partial class StructuredInputDefinition
{
    [CodeGenMember("Required")]
    public bool? IsRequired { get; set; }
}
