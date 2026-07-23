// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.AgentServer.Responses.Models;

/// <summary> Custom tool. </summary>
[CodeGenSuppress(nameof(CustomToolParam))]
public partial class CustomToolParam
{
    /// <summary> Initializes a new instance of <see cref="CustomToolParam"/> for deserialization. </summary>
    internal CustomToolParam()
        : base("custom")
    {
    }
}
