// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Projects.Agents;

/// <summary> The AzureFunctionDefinitionFunction. </summary>
public partial class AzureFunctionDefinitionFunction
{
    /// <summary> The JSON-encoded parameter schema for the Azure Function. </summary>
    // Customization: retain IDictionary<string, BinaryData> despite Record<unknown> basis
    [CodeGenMember("parameters")]
    public BinaryData Parameters { get; set; }
}
