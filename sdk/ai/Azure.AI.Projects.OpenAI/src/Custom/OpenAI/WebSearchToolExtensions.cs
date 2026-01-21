// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Nodes;
using Azure.AI.Projects.OpenAI;
using OpenAI.Responses;

#pragma warning disable OPENAI001
#pragma warning disable SCME0001

namespace Azure.AI.Projects.OpenAI;

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
