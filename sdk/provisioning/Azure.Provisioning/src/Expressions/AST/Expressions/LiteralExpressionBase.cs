// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Base class for Bicep literal expressions that hold a constant value.
/// </summary>
/// <param name="value">The literal value.</param>
public abstract class LiteralExpression(object? value = null) : BicepExpression
{
    /// <summary>
    /// Gets the literal value.
    /// </summary>
    public object? Value { get; } = value;
}
