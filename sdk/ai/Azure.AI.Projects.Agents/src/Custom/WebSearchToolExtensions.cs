// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.ComponentModel;
using Azure.AI.Extensions.OpenAI;
using OpenAI.Responses;

#nullable disable
#pragma warning disable OPENAI001
#pragma warning disable SCME0001

namespace Azure.AI.Projects.Agents;

/// <summary>
/// Extension methods that expose Microsoft Foundry-specific configuration on
/// <see cref="WebSearchTool"/> instances.
/// </summary>
public static partial class WebSearchToolExtensions
{
    extension(WebSearchTool webSearchTool)
    {
        /// <summary>
        /// Gets or sets the Foundry-specific custom search configuration applied to this web
        /// search tool. The value is stored as a JSON patch on the underlying tool definition.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ProjectWebSearchConfiguration CustomSearchConfiguration
        {
            get => webSearchTool.Patch.GetJsonModelEx<ProjectWebSearchConfiguration>("$.custom_search_configuration"u8);
            set => webSearchTool.Patch.SetOrClearEx("$.custom_search_configuration"u8, "$.custom_search_configuration"u8, value);
        }

        /// <summary> Gets or sets the custom search configuration using the shared OpenAI extensions model. </summary>
        public WebSearchConfiguration SearchConfiguration
        {
            get => webSearchTool.Patch.GetJsonModelEx<WebSearchConfiguration>("$.custom_search_configuration"u8);
            set => webSearchTool.Patch.SetOrClearEx("$.custom_search_configuration"u8, "$.custom_search_configuration"u8, value);
        }
    }
}
