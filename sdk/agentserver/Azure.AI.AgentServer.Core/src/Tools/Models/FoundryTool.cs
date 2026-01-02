// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.AgentServer.Core.Tools.Models;

/// <summary>
/// Supported tool protocols.
/// </summary>
public enum FoundryToolProtocol
{
    /// <summary>
    /// Model Context Protocol tools.
    /// </summary>
    MCP,

    /// <summary>
    /// Agent-to-agent tools.
    /// </summary>
    A2A
}

/// <summary>
/// Represents a tool configuration definition.
/// </summary>
public record FoundryTool
{
    /// <summary>
    /// Creates a typed tool definition.
    /// </summary>
    /// <param name="protocol">The tool protocol.</param>
    /// <param name="projectConnectionId">The project connection ID for the tool.</param>
    /// <param name="additionalProperties">Optional additional properties for the tool configuration.</param>
    [SetsRequiredMembers]
    public FoundryTool(
        FoundryToolProtocol protocol,
        string projectConnectionId,
        IReadOnlyDictionary<string, object?>? additionalProperties = null)
    {
        Type = protocol switch
        {
            FoundryToolProtocol.MCP => "mcp",
            FoundryToolProtocol.A2A => "a2a",
            _ => throw new ArgumentOutOfRangeException(nameof(protocol))
        };
        ProjectConnectionId = projectConnectionId ?? throw new ArgumentNullException(nameof(projectConnectionId));
        AdditionalProperties = additionalProperties;
    }

    /// <summary>
    /// Creates an MCP tool definition.
    /// </summary>
    public static FoundryTool Mcp(
        string projectConnectionId,
        IReadOnlyDictionary<string, object?>? additionalProperties = null)
        => new(FoundryToolProtocol.MCP, projectConnectionId, additionalProperties);

    /// <summary>
    /// Creates an A2A tool definition.
    /// </summary>
    public static FoundryTool A2a(
        string projectConnectionId,
        IReadOnlyDictionary<string, object?>? additionalProperties = null)
        => new(FoundryToolProtocol.A2A, projectConnectionId, additionalProperties);

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
