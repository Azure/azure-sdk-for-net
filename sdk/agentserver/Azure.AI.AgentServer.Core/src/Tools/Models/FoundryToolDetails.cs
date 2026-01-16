// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Tools.Models;

/// <summary>
/// Represents parsed tool details with optional foundry configuration data.
/// </summary>
internal sealed record FoundryToolDetails
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FoundryToolDetails"/> class.
    /// </summary>
    /// <param name="name">The tool name.</param>
    /// <param name="description">The tool description.</param>
    /// <param name="metadata">The raw tool metadata.</param>
    /// <param name="inputSchema">The input schema for the tool.</param>
    /// <param name="foundryTool">The associated foundry tool definition.</param>
    /// <param name="projectConnectionId">The project connection ID for connected tools.</param>
    /// <param name="protocol">The protocol for connected tools.</param>
    public FoundryToolDetails(
        string name,
        string description,
        IReadOnlyDictionary<string, object?> metadata,
        IReadOnlyDictionary<string, object?>? inputSchema = null,
        FoundryTool? foundryTool = null,
        string? projectConnectionId = null,
        string? protocol = null)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Description = description ?? throw new ArgumentNullException(nameof(description));
        Metadata = metadata ?? throw new ArgumentNullException(nameof(metadata));
        InputSchema = inputSchema;
        FoundryTool = foundryTool;
        ProjectConnectionId = projectConnectionId;
        Protocol = protocol;
    }

    /// <summary>
    /// Gets the tool name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the tool description.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Gets the raw tool metadata.
    /// </summary>
    public IReadOnlyDictionary<string, object?> Metadata { get; }

    /// <summary>
    /// Gets the tool input schema.
    /// </summary>
    public IReadOnlyDictionary<string, object?>? InputSchema { get; }

    /// <summary>
    /// Gets the associated foundry tool definition.
    /// </summary>
    public FoundryTool? FoundryTool { get; }

    /// <summary>
    /// Gets the project connection ID for connected tools.
    /// </summary>
    public string? ProjectConnectionId { get; }

    /// <summary>
    /// Gets the protocol for connected tools.
    /// </summary>
    public string? Protocol { get; }
}
