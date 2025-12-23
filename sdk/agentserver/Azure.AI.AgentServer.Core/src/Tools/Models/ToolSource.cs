// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Tools.Models;

/// <summary>
/// Represents the source of a tool.
/// </summary>
public enum ToolSource
{
    /// <summary>
    /// Tools from Model Context Protocol (MCP) servers.
    /// </summary>
    McpTools,

    /// <summary>
    /// Tools from remote Azure AI Tools API.
    /// </summary>
    RemoteTools
}
