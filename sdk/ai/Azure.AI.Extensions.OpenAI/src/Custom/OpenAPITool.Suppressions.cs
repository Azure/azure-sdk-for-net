// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

[CodeGenSuppress(nameof(OpenAPITool))]
public partial class OpenAPITool
{
    internal OpenAPITool() : base("openapi")
    {
    }
}
