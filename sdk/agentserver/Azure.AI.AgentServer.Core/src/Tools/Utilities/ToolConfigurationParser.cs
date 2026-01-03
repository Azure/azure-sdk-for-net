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
    public IReadOnlyList<FoundryHostedMcpTool> HostedMcpTools { get; }

    /// <summary>
    /// Gets the list of connected tools (MCP and A2A).
    /// </summary>
    public IReadOnlyList<FoundryConnectedTool> ConnectedTools { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ToolConfigurationParser"/> class.
    /// </summary>
    /// <param name="foundryTools">The list of tool definitions to parse.</param>
    public ToolConfigurationParser(IList<FoundryTool> foundryTools)
    {
        var hostedMcp = new List<FoundryHostedMcpTool>();
        var connected = new List<FoundryConnectedTool>();

        foreach (var tool in foundryTools)
        {
            switch (tool.Source)
            {
                case FoundryToolSource.CONNECTED when tool is FoundryConnectedTool connectedTool:
                    connected.Add(connectedTool);
                    break;
                case FoundryToolSource.HOSTED_MCP when tool is FoundryHostedMcpTool hostedTool:
                    hostedMcp.Add(hostedTool);
                    break;
                default:
                    throw new InvalidOperationException($"Unsupported tool configuration type: {tool.GetType().Name}");
            }
        }

        HostedMcpTools = hostedMcp;
        ConnectedTools = connected;
    }
}
