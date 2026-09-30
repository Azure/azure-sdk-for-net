// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI;

namespace Azure.AI.Projects.Agents
{
    /// <summary> The input definition information for an Azure AI search tool as used to configure an agent. </summary>
    public partial class AzureAISearchTool : ProjectsAgentTool
    {
        /// <summary> Initializes a new instance of <see cref="AzureAISearchTool"/>. </summary>
        /// <param name="type"></param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="options"> The azure ai search index resource. </param>
        internal AzureAISearchTool(ToolType @type, IDictionary<string, BinaryData> additionalBinaryDataProperties, AzureAISearchToolOptions options) : base(@type, additionalBinaryDataProperties)
        {
            Options = options;
        }
    }
}
