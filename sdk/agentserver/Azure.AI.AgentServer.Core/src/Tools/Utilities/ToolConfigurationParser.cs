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
    /// Gets the list of hosted MCP tools.
    /// </summary>
    public IReadOnlyList<FoundryTool> HostedMcpTools { get; }

    /// <summary>
    /// Gets the list of connected tools (MCP and A2A).
    /// </summary>
    public IReadOnlyList<FoundryTool> ConnectedTools { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ToolConfigurationParser"/> class.
    /// </summary>
    /// <param name="foundryTools">The list of tool definitions to parse.</param>
    public ToolConfigurationParser(IList<FoundryTool> foundryTools)
    {
        var hostedMcp = new List<FoundryTool>();
        var connected = new List<FoundryTool>();

        foreach (var tool in foundryTools)
        {
            var type = tool.Type.ToLowerInvariant();
            if (type == "mcp" || type == "a2a")
            {
                connected.Add(tool);
            }
            else
            {
                hostedMcp.Add(tool);
            }
        }

        HostedMcpTools = hostedMcp;
        ConnectedTools = connected;
    }
}
