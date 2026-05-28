// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Provisioning.Generator.Model;

/// <summary>
/// Base class for all model types.
/// </summary>
public abstract class ModelBase(
    string name,
    string? ns = default,
    Type? armType = default,
    string? description = default)
{
    /// <summary>
    /// Gets or sets the underlying ARM type we're basing this model type on.
    /// </summary>
    public Type? ArmType { get; set; } = armType;

    /// <summary>
    /// Gets or sets the namespace of this type.
    /// </summary>
    public string? Namespace { get; set; } = ns;

    /// <summary>
    /// Gets or sets the name of this type.
    /// </summary>
    public string Name { get; set; } = name;

    /// <summary>
    ///  Gets or sets the description of this type.
    /// </summary>
    public string? Description { get; set; } = description;

    /// <summary>
    /// Gets or sets the specification that contains this type.
    /// </summary>
    public Specification? Spec { get; set; } = null;

    /// <summary>
    /// Gets whether this model type is external and doesn't need to be generated.
    /// </summary>
    public bool IsExternal { get; protected set; } = false;

    /// <summary>
    /// Generate code for this model type.
    /// </summary>
    /// <param name="writer">Code writer.</param>
    public virtual void Generate() { }

    /// <summary>
    /// Generate the name of a type in a way that can be used by C# code.
    /// You can assume the namespace has already been imported.
    /// </summary>
    /// <returns>The C# name.</returns>
    public virtual string GetTypeReference() => Name;

    /// <summary>
    /// Check for common issues.
    /// </summary>
    public virtual void Lint()
    {
        if (IsExternal) { return; }
        if (Name.Contains("ACL")) { Warn($"{GetTypeReference()} contains 'ACL'."); }
        // if (Description is null) { Warn($"Missing a {nameof(Description)}."); }
    }

    /// <summary>
    /// Print warnings.
    /// </summary>
    /// <param name="message">The warning.</param>
    protected void Warn(string message) =>
        Console.WriteLine($"  >> {GetTypeReference()}: {message}");

    public override string ToString() => $"<{GetTypeReference()}>";
}