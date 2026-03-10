// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using OpenAI.Responses;

#nullable disable
#pragma warning disable OPENAI001
#pragma warning disable SCME0001

namespace Azure.AI.Projects.Agents;

public static partial class WebSearchToolExtensions
{
    extension(WebSearchTool webSearchTool)
    {
        public ProjectWebSearchConfiguration CustomSearchConfiguration
        {
            get => webSearchTool.Patch.GetJsonModelEx<ProjectWebSearchConfiguration>("$.custom_search_configuration"u8);
            set => webSearchTool.Patch.SetOrClearEx("$.custom_search_configuration"u8, "$.custom_search_configuration"u8, value);
        }
    }
}
