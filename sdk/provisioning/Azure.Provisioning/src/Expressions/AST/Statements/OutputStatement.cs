// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Provisioning.Expressions;

public class OutputStatement(string name, BicepExpression type, BicepExpression value) : BicepStatement
{
    public string Name { get; } = name;
    public BicepExpression Type { get; } = type;
    public BicepExpression Value { get; } = value;
    public IList<DecoratorExpression> Decorators { get; } = [];
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.AppendAll(Decorators, (w, d) => w.Append(d).AppendLine())
            .Append("output ").Append(Name).Append(' ').Append(Type).Append(" = ").Append(Value).AppendLine();
}
