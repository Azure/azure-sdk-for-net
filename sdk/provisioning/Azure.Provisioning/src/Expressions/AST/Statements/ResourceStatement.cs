// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Provisioning.Expressions;

public class ResourceStatement(string name, BicepExpression type, BicepExpression body) : BicepStatement
{
    public string Name { get; } = name;
    public BicepExpression Type { get; } = type;
    public BicepExpression Body { get; } = body;
    public bool Existing { get; set; }
    public IList<DecoratorExpression> Decorators { get; } = [];
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.AppendAll(Decorators, (w, d) => w.Append(d).AppendLine())
            .Append("resource ").Append(Name).Append(' ').Append(Type)
            .AppendIf(Existing, w => w.Append(" existing")).Append(" = ")
            .Append(Body).AppendLine();
}
