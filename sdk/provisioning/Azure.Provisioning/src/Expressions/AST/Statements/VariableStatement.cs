// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Provisioning.Expressions;

public class VariableStatement(string name, BicepExpression value) : BicepStatement
{
    public string Name { get; } = name;
    public BicepExpression Value { get; } = value;
    public IList<DecoratorExpression> Decorators { get; } = [];
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.AppendAll(Decorators, (w, d) => w.Append(d).AppendLine())
            .Append("var ").Append(Name).Append(" = ").Append(Value).AppendLine();
}
