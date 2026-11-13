// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Base class for all Bicep expression AST nodes.
/// </summary>
public abstract class BicepExpression
{
    internal abstract BicepWriter Write(BicepWriter writer);
    /// <inheritdoc />
    public override string ToString() => new BicepWriter().Append(this).ToString();

    /// <summary>
    /// Implicitly converts a <see cref="string"/> to a <see cref="StringLiteralExpression"/>.
    /// </summary>
    /// <param name="value">The string value.</param>
    public static implicit operator BicepExpression(string value) => new StringLiteralExpression(value);
    /// <summary>
    /// Implicitly converts an <see cref="int"/> to an <see cref="IntLiteralExpression"/>.
    /// </summary>
    /// <param name="value">The integer value.</param>
    public static implicit operator BicepExpression(int value) => new IntLiteralExpression(value);
    /// <summary>
    /// Implicitly converts a <see cref="bool"/> to a <see cref="BoolLiteralExpression"/>.
    /// </summary>
    /// <param name="value">The Boolean value.</param>
    public static implicit operator BicepExpression(bool value) => new BoolLiteralExpression(value);
}
