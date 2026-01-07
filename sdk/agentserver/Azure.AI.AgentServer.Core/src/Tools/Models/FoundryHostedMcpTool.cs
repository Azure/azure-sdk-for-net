// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Tools.Models;

/// <summary>
/// Represents a hosted MCP tool configuration definition.
/// </summary>
public sealed record FoundryHostedMcpTool : FoundryTool
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FoundryHostedMcpTool"/> class.
    /// </summary>
    /// <param name="name">The name of the hosted MCP tool.</param>
    /// <param name="additionalProperties">Optional additional properties for the tool configuration.</param>
    public FoundryHostedMcpTool(
        string name,
        IReadOnlyDictionary<string, object?>? additionalProperties = null)
        : base(additionalProperties)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    /// <summary>
    /// Creates an MCP tool definition.
    /// </summary>
    public static FoundryHostedMcpTool Create(
        string name,
        IReadOnlyDictionary<string, object?>? additionalProperties = null)
        => new(name, additionalProperties);

    /// <summary>
    /// Gets the source of the tool.
    /// </summary>
    public override FoundryToolSource Source => FoundryToolSource.HOSTED_MCP;

    /// <summary>
    /// Gets or initializes the name of the hosted MCP tool.
    /// </summary>
    public string Name { get; init; }
}
