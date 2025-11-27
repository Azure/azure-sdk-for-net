// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Provisioning.Expressions;

public abstract class BicepStatement
{
    internal abstract BicepWriter Write(BicepWriter writer);
  public override string ToString() => new BicepWriter().Append(this).ToString();
}

public class TargetScopeStatement(BicepExpression scope) : BicepStatement
{
    public BicepExpression Scope { get; } = scope;
 internal override BicepWriter Write(BicepWriter writer) =>
      writer.Append("targetScope = ").Append(Scope).AppendLine();
}

public class VariableStatement(string name, BicepExpression value) : BicepStatement
{
    public string Name { get; } = name;
    public BicepExpression Value { get; } = value;
    public IList<DecoratorExpression> Decorators { get; } = [];
    internal override BicepWriter Write(BicepWriter writer) =>
  writer.AppendAll(Decorators, (w, d) => w.Append(d).AppendLine()).Append("var ").Append(Name).Append(" = ").Append(Value).AppendLine();
}

public class ParameterStatement(string name, BicepExpression type, BicepExpression? defaultValue) : BicepStatement
{
    public string Name { get; } = name;
    public BicepExpression Type { get; } = type;
  public BicepExpression? DefaultValue { get; } = defaultValue;
    public IList<DecoratorExpression> Decorators { get; } = [];
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.AppendAll(Decorators, (w, d) => w.Append(d).AppendLine()).Append("param ").Append(Name).Append(' ').Append(Type)
        .AppendIf(DefaultValue != null, w => w.Append(" = ").Append(DefaultValue!))
            .AppendLine();
    // note: use NullLiteral if you want a null default value
}

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

public class ResourceStatement(string name, BicepExpression type, BicepExpression body) : BicepStatement
{
    public string Name { get; } = name;
    public BicepExpression Type { get; } = type;
    public BicepExpression Body { get; } = body;
    public bool Existing { get; set; }
    public IList<DecoratorExpression> Decorators { get; } = [];
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.AppendAll(Decorators, (w, d) => w.Append(d).AppendLine())
   .Append("resource ").Append(Name).Append(' ').Append(Type).AppendIf(Existing, w => w.Append(" existing")).Append(" = ").Append(Body).AppendLine();
}

public class ModuleStatement(string name, BicepExpression type, BicepExpression body) : BicepStatement
{
public string Name { get; } = name;
    public BicepExpression Type { get; } = type;
    public BicepExpression Body { get; } = body;
    public IList<DecoratorExpression> Decorators { get; } = [];
    internal override BicepWriter Write(BicepWriter writer) =>
writer.AppendAll(Decorators, (w, d) => w.Append(d).AppendLine())
            .Append("module ").Append(Name).Append(' ').Append(Type).Append(" = ").Append(Body).AppendLine();
}

public class CommentStatement(string comment) : BicepStatement
{
    public string Comment { get; } = comment;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append("// ").Append(Comment).AppendLine();
}

public class ExpressionStatement(BicepExpression expression) : BicepStatement
{
    public BicepExpression Expression { get; } = expression;
 internal override BicepWriter Write(BicepWriter writer) =>
     writer.Append(Expression);
}
