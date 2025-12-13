// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Tools.Models;

namespace Azure.AI.AgentServer.Core.Tools.Utilities;

/// <summary>
/// Parses tool configurations into categorized lists.
/// </summary>
internal class ToolConfigurationParser
{
    /// <summary>
    /// Gets the list of named MCP tools.
    /// </summary>
    public IReadOnlyList<ToolDefinition> NamedMcpTools { get; }

    /// <summary>
    /// Gets the list of remote tools (MCP and A2A).
    /// </summary>
    public IReadOnlyList<ToolDefinition> RemoteTools { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ToolConfigurationParser"/> class.
    /// </summary>
    /// <param name="toolDefinitions">The list of tool definitions to parse.</param>
    public ToolConfigurationParser(IList<ToolDefinition> toolDefinitions)
    {
        var namedMcp = new List<ToolDefinition>();
        var remote = new List<ToolDefinition>();

        foreach (var toolDef in toolDefinitions)
        {
            var type = toolDef.Type.ToLowerInvariant();
            if (type == "mcp" || type == "a2a")
            {
                remote.Add(toolDef);
            }
            else
            {
                namedMcp.Add(toolDef);
            }
        }

        NamedMcpTools = namedMcp;
        RemoteTools = remote;
    }
}
