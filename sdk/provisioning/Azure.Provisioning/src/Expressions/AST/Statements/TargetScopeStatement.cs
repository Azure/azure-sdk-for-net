// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Represents a Bicep <c>targetScope</c> statement.
/// </summary>
/// <param name="scope">The target scope expression.</param>
public partial class TargetScopeStatement(BicepExpression scope) : BicepStatement
{
    /// <summary>
    /// Gets the target scope expression.
    /// </summary>
    public BicepExpression Scope { get; } = scope;
    internal override BicepWriter Write(BicepWriter writer) =>
         writer.Append("targetScope = ").Append(Scope).AppendLine();
}
