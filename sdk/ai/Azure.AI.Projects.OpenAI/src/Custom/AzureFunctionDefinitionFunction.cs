// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Projects.OpenAI;

/// <summary> The AzureFunctionDefinitionFunction. </summary>
public partial class AzureFunctionDefinitionFunction
{
    // Customization: retain IDictionary<string, BinaryData> despite Record<unknown> basis
    [CodeGenMember("parameters")]
    public BinaryData Parameters { get; set; }
}
