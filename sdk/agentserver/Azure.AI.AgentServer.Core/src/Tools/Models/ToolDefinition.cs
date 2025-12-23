// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Tools.Models;

/// <summary>
/// Represents a tool configuration definition.
/// </summary>
#pragma warning disable AZC0031
public record ToolDefinition
{
    /// <summary>
    /// Gets or initializes the type of the tool (e.g., "mcp", "a2a").
    /// </summary>
    required public string Type { get; init; }

    /// <summary>
    /// Gets or initializes the project connection ID for the tool.
    /// </summary>
    public string? ProjectConnectionId { get; init; }

    /// <summary>
    /// Gets or initializes additional properties for the tool configuration.
    /// </summary>
    public IReadOnlyDictionary<string, object?>? AdditionalProperties { get; init; }
}
