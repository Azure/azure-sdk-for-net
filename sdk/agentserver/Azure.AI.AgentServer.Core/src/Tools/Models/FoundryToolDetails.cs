// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Tools.Models;

/// <summary>
/// Represents parsed tool details.
/// </summary>
public sealed record FoundryToolDetails
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FoundryToolDetails"/> class.
    /// </summary>
    /// <param name="name">The tool name.</param>
    /// <param name="description">The tool description.</param>
    /// <param name="metadata">The raw tool metadata.</param>
    /// <param name="inputSchema">The input schema for the tool.</param>
    public FoundryToolDetails(
        string name,
        string description,
        IReadOnlyDictionary<string, object?> metadata,
        IReadOnlyDictionary<string, object?>? inputSchema = null)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Description = description ?? throw new ArgumentNullException(nameof(description));
        Metadata = metadata ?? throw new ArgumentNullException(nameof(metadata));
        InputSchema = inputSchema;
    }

    /// <summary>
    /// Gets the tool name.
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Gets the tool description.
    /// </summary>
    public string Description { get; init; }

    /// <summary>
    /// Gets the raw tool metadata.
    /// </summary>
    public IReadOnlyDictionary<string, object?> Metadata { get; init; }

    /// <summary>
    /// Gets the tool input schema.
    /// </summary>
    public IReadOnlyDictionary<string, object?>? InputSchema { get; init; }
}
