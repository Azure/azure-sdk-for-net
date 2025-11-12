// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

#pragma warning disable OPENAI001

namespace Azure.AI.Projects.OpenAI;

[CodeGenType("AzureAISearchToolResource")]
public partial class AzureAISearchToolOptions
{
    /// <summary>
    /// The indices attached to this agent. There can be a maximum of 1 index
    /// resource attached to the agent.
    /// </summary>
    [CodeGenMember("IndexList")]
    public IList<AzureAISearchIndex> Indexes { get; }
}
