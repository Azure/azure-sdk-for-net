// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

public class TargetScopeStatement(BicepExpression scope) : BicepStatement
{
    public BicepExpression Scope { get; } = scope;
    internal override BicepWriter Write(BicepWriter writer) =>
         writer.Append("targetScope = ").Append(Scope).AppendLine();
}
