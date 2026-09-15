// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Represents a Bicep index access expression (<c>value[index]</c>).
/// </summary>
/// <param name="value">The expression being indexed.</param>
/// <param name="index">The index expression.</param>
public class IndexExpression(BicepExpression value, BicepExpression index) : BicepExpression
{
    /// <summary>
    /// Gets the expression being indexed.
    /// </summary>
    public BicepExpression Value { get; } = value;
    /// <summary>
    /// Gets the index expression.
    /// </summary>
    public BicepExpression Index { get; } = index;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Value).Append('[').Append(Index).Append(']');
}

/// <summary>
/// Represents a Bicep safe index access expression (<c>value[?index]</c>) that returns null when the key is missing.
/// </summary>
/// <param name="value">The expression being indexed.</param>
/// <param name="index">The index expression.</param>
public class SafeIndexExpression(BicepExpression value, BicepExpression index) : BicepExpression
{
    /// <summary>
    /// Gets the expression being indexed.
    /// </summary>
    public BicepExpression Value { get; } = value;
    /// <summary>
    /// Gets the index expression.
    /// </summary>
    public BicepExpression Index { get; } = index;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Value).Append("[?").Append(Index).Append(']');
}
