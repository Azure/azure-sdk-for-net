// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable OPENAI001

using System;
using OpenAI;

namespace Azure.AI.Projects.OpenAI;

[CodeGenType("AzureAISearchTool")]
public partial class AzureAISearchTool
{
    /// <summary> Options applied to the <see cref="AzureAISearchTool"/> instance. </summary>
    [CodeGenMember("AzureAiSearch")]
    public AzureAISearchToolOptions Options { get; set; }

    /// <param name="options"> The azure ai search index resource. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
    public AzureAISearchTool(AzureAISearchToolOptions options) : base(ToolType.AzureAiSearch)
    {
        Argument.AssertNotNull(options, nameof(options));

        Options = options;
    }

    internal AzureAISearchTool()
    { }
}
