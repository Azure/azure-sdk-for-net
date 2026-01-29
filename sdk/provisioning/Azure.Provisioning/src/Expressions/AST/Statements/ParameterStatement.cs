// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Provisioning.Expressions;

public class ParameterStatement(string name, BicepExpression type, BicepExpression? defaultValue) : BicepStatement
{
    public string Name { get; } = name;
    public BicepExpression Type { get; } = type;
    public BicepExpression? DefaultValue { get; } = defaultValue;
    public IList<DecoratorExpression> Decorators { get; } = [];
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.AppendAll(Decorators, (w, d) => w.Append(d).AppendLine())
            .Append("param ").Append(Name).Append(' ').Append(Type)
            .AppendIf(DefaultValue != null, w => w.Append(" = ").Append(DefaultValue!))
            .AppendLine();
    // note: use NullLiteral if you want a null default value
}
