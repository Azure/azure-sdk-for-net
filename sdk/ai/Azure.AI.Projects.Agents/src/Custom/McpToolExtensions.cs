// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI.Responses;

#pragma warning disable SCME0001

namespace Azure.AI.Projects.Agents;

/// <summary>
/// Extension methods on <see cref="McpTool"/> that expose Foundry-project-specific
/// configuration (such as the project connection identifier).
/// </summary>
public static partial class McpToolExtensions
{
    extension(McpTool mcpTool)
    {
        /// <summary>
        /// Gets or sets the Foundry project connection identifier associated with this MCP tool.
        /// The value is stored as a JSON patch on the underlying tool definition.
        /// </summary>
        public string ProjectConnectionId
        {
            get => mcpTool.Patch.GetStringEx("$.project_connection_id"u8);
            set => mcpTool.Patch.SetOrClearEx("$.project_connection_id"u8, "$.project_connection_id"u8, value);
        }
    }
}
