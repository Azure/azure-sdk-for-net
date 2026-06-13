// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Optimization;

/// <summary>
/// A learned skill discovered during optimization.
/// </summary>
/// <remarks>
/// Mutable class so the configuration binder can populate instances when binding
/// from <c>Microsoft.Extensions.Configuration</c>.
/// </remarks>
public class OptimizationSkill
{
    /// <summary>Initializes a new instance with all fields unset.</summary>
    public OptimizationSkill()
    {
    }

    /// <summary>Initializes a new instance with the supplied values.</summary>
    /// <param name="name">The skill name. Required.</param>
    /// <param name="description">A short description of the skill. Required.</param>
    /// <param name="body">The skill body text. Optional.</param>
    public OptimizationSkill(string name, string description, string body = "")
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Description = description ?? throw new ArgumentNullException(nameof(description));
        Body = body ?? string.Empty;
    }

    /// <summary>The skill name.</summary>
    public string Name { get; set; }

    /// <summary>A short description of the skill.</summary>
    public string Description { get; set; }

    /// <summary>The skill body text.</summary>
    public string Body { get; set; }

    /// <inheritdoc/>
    public override string ToString() => $"OptimizationSkill(name={Name}, description={Description})";
}
