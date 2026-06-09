// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Optimization;

/// <summary>
/// An optimized tool definition with type, function name, and description.
/// </summary>
public class ToolDefinition
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ToolDefinition"/> class.
    /// </summary>
    /// <param name="type">The tool type (e.g. "function").</param>
    /// <param name="name">The function name.</param>
    /// <param name="description">The optimized description.</param>
    public ToolDefinition(string type, string name, string description)
    {
        Type = type ?? throw new ArgumentNullException(nameof(type));
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Description = description ?? "";
    }

    /// <summary>The tool type (e.g. "function").</summary>
    public string Type { get; }

    /// <summary>The function name.</summary>
    public string Name { get; }

    /// <summary>The optimized description.</summary>
    public string Description { get; }

    /// <inheritdoc/>
    public override string ToString() => $"ToolDefinition(type={Type}, name={Name})";
}
