// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable OPENAI001

using System;
using OpenAI;

namespace Azure.AI.Projects.Agents;

[CodeGenType("AzureAISearchTool")]
public partial class AzureAISearchTool
{
    /// <summary> Options applied to the <see cref="AzureAISearchTool"/> instance. </summary>
    [CodeGenMember("AzureAiSearch")]
    public AzureAISearchToolOptions Options { get; set; }

    internal AzureAISearchTool()
    { }
}
