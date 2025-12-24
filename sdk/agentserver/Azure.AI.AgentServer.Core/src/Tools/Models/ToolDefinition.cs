// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.AgentServer.Core.Tools.Models;

/// <summary>
/// Supported tool protocols.
/// </summary>
public enum ToolProtocol
{
    /// <summary>
    /// Model Context Protocol tools.
    /// </summary>
    Mcp,

    /// <summary>
    /// Agent-to-agent tools.
    /// </summary>
    A2a
}

/// <summary>
/// Represents a tool configuration definition.
/// </summary>
#pragma warning disable AZC0031
public record ToolDefinition
{
    /// <summary>
    /// Creates a typed tool definition.
    /// </summary>
    /// <param name="protocol">The tool protocol.</param>
    /// <param name="projectConnectionId">The project connection ID for the tool.</param>
    /// <param name="additionalProperties">Optional additional properties for the tool configuration.</param>
    [SetsRequiredMembers]
    public ToolDefinition(
        ToolProtocol protocol,
        string projectConnectionId,
        IReadOnlyDictionary<string, object?>? additionalProperties = null)
    {
        Type = protocol switch
        {
            ToolProtocol.Mcp => "mcp",
            ToolProtocol.A2a => "a2a",
            _ => throw new ArgumentOutOfRangeException(nameof(protocol))
        };
        ProjectConnectionId = projectConnectionId ?? throw new ArgumentNullException(nameof(projectConnectionId));
        AdditionalProperties = additionalProperties;
    }

    /// <summary>
    /// Creates an MCP tool definition.
    /// </summary>
    public static ToolDefinition Mcp(
        string projectConnectionId,
        IReadOnlyDictionary<string, object?>? additionalProperties = null)
        => new(ToolProtocol.Mcp, projectConnectionId, additionalProperties);

    /// <summary>
    /// Creates an A2A tool definition.
    /// </summary>
    public static ToolDefinition A2a(
        string projectConnectionId,
        IReadOnlyDictionary<string, object?>? additionalProperties = null)
        => new(ToolProtocol.A2a, projectConnectionId, additionalProperties);

    /// <summary>
    /// Gets or initializes the type of the tool (e.g., "mcp", "a2a").
    /// </summary>
    required public string Type { get; init; }

    /// <summary>
    /// Gets or initializes the project connection ID for the tool.
    /// </summary>
    required public string ProjectConnectionId { get; init; }

    /// <summary>
    /// Gets or initializes additional properties for the tool configuration.
    /// </summary>
    public IReadOnlyDictionary<string, object?>? AdditionalProperties { get; init; }
}
