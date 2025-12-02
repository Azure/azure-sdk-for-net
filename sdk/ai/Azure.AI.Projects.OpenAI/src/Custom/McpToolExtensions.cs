// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI.Responses;

#pragma warning disable SCME0001

namespace Azure.AI.Projects.OpenAI;

public static partial class McpToolExtensions
{
    extension(McpTool mcpTool)
    {
        public string ProjectConnectionId
        {
            get => mcpTool.Patch.GetStringEx("$.project_connection_id"u8);
            set => mcpTool.Patch.SetOrClearEx("$.project_connection_id"u8, "$.project_connection_id"u8, value);
        }
    }
}
