// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Tools.Models;

/// <summary>
/// Represents the source of a tool.
/// </summary>
public enum FoundryToolSource
{
    /// <summary>
    /// Tools from Model Context Protocol (MCP) servers.
    /// </summary>
    HOSTED_MCP,

    /// <summary>
    /// Tools from remote Azure AI Tools API.
    /// </summary>
    CONNECTED
}
