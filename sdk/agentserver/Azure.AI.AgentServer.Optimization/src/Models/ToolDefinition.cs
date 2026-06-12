// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Optimization;

/// <summary>
/// An optimized tool definition with type, function name, and description.
/// </summary>
/// <remarks>
/// Mutable class so the configuration binder can populate instances when binding
/// from <c>Microsoft.Extensions.Configuration</c>.
/// </remarks>
public class ToolDefinition
{
    /// <summary>Initializes a new instance with default values (<see cref="Type"/> = "function").</summary>
    public ToolDefinition()
    {
        Type = "function";
        Description = string.Empty;
    }

    /// <summary>Initializes a new instance with the supplied values.</summary>
    /// <param name="type">The tool type (e.g. "function"). Required.</param>
    /// <param name="name">The function name. Required.</param>
    /// <param name="description">The optimized description. Optional.</param>
    public ToolDefinition(string type, string name, string description)
    {
        Type = type ?? throw new ArgumentNullException(nameof(type));
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Description = description ?? "";
    }

    /// <summary>The tool type (e.g. "function").</summary>
    public string Type { get; set; }

    /// <summary>The function name.</summary>
    public string Name { get; set; }

    /// <summary>The optimized description.</summary>
    public string Description { get; set; }

    /// <inheritdoc/>
    public override string ToString() => $"ToolDefinition(type={Type}, name={Name})";
}
