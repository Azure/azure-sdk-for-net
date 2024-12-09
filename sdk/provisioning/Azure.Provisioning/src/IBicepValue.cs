// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning;

/// <summary>
/// Represents the value of a property that could be a literal .NET value, a
/// Bicep expression, or it could be unset.
/// </summary>
public interface IBicepValue
{
    /// <summary>
    /// Gets the kind of this value (a literal value, an expression, or it's
    /// unset).
    /// </summary>
    public BicepValueKind Kind { get; }

    /// <summary>
    /// Gets the expression for this value if it's not a literal.
    /// </summary>
    /// <returns>The expression for this value if it's not a literal.</returns>
    public BicepExpression? Expression { get; set; }

    /// <summary>
    /// Get the value of this expression, if it's literal.
    /// </summary>
    /// <returns>The value of this expression if it's literal.</returns>
    public object? LiteralValue { get; }

    /// <summary>
    /// Gets information about where this value was defined.
    /// </summary>
    public BicepValueReference? Self { get; set; }

    /// <summary>
    /// Gets information about where this value was assigned from.
    /// </summary>
    public BicepValueReference? Source { get; }

    /// <summary>
    /// Tracks whether this is an output only property.
    /// </summary>
    public bool IsOutput { get; }

    /// <summary>
    /// Tracks whether this property is required.
    /// </summary>
    public bool IsRequired { get; }

    /// <summary>
    /// Tracks whether this contains a secure value.
    /// </summary>
    public bool IsSecure { get; }

    /// <summary>
    /// Gets whether this value is unset or empty.
    /// </summary>
    public bool IsEmpty { get; }

    /// <summary>
    /// Assign a value to this property.
    /// </summary>
    /// <param name="source">Source of the value.</param>
    public void Assign(IBicepValue source);

    /// <summary>
    /// Compile this value to a Bicep expression.
    /// </summary>
    /// <returns>The compiled Bicep expression.</returns>
    public BicepExpression Compile();

    /// <summary>
    /// Make this value readonly.
    /// </summary>
    public void SetReadOnly();
}
