// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Optimization;

/// <summary>
/// A learned skill discovered during optimization.
/// </summary>
public class OptimizationSkill : IEquatable<OptimizationSkill>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OptimizationSkill"/> class.
    /// </summary>
    /// <param name="name">The skill name.</param>
    /// <param name="description">A short description of the skill.</param>
    /// <param name="body">The skill body text.</param>
    public OptimizationSkill(string name, string description, string body = "")
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Description = description ?? throw new ArgumentNullException(nameof(description));
        Body = body ?? "";
    }

    /// <summary>The skill name.</summary>
    public string Name { get; }

    /// <summary>A short description of the skill.</summary>
    public string Description { get; }

    /// <summary>The skill body text.</summary>
    public string Body { get; }

    /// <inheritdoc/>
    public bool Equals(OptimizationSkill? other)
    {
        if (other is null) return false;
        return Name == other.Name
            && Description == other.Description
            && Body == other.Body;
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj) => Equals(obj as OptimizationSkill);

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(Name, Description, Body);

    /// <inheritdoc/>
    public override string ToString() => $"OptimizationSkill(name={Name}, description={Description})";
}
