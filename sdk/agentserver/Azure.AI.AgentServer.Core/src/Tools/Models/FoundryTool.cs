// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
public abstract record FoundryTool
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FoundryTool"/> class.
    /// </summary>
    /// <param name="additionalProperties">Optional additional properties for the tool configuration.</param>
    protected FoundryTool(IReadOnlyDictionary<string, object?>? additionalProperties = null)
    {
        AdditionalProperties = additionalProperties;
    }

    /// <summary>
    /// Gets the source of the tool.
    /// </summary>
    public abstract FoundryToolSource Source { get; }

    /// <summary>
    /// Gets the unique identifier for the tool.
    /// </summary>
    public abstract string Id { get; }

    /// <summary>
    /// Gets or initializes additional properties for the tool configuration.
    /// </summary>
    public IReadOnlyDictionary<string, object?>? AdditionalProperties { get; init; }
}
