// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Provisioning.Expressions;

// This is a partial, simplified version of the Bicep AST that you can
// reference at https://github.com/Azure/bicep/blob/main/docs/grammar.md.  It's
// a non-goal to be able to do EVERYTHING that Bicep allows in C#.  We're just
// trying to glue them together better - if you need something not supported
// here then you can drop down to Bicep directly.

public abstract class BicepExpression
{
    internal abstract BicepWriter Write(BicepWriter writer);
    public override string ToString() => new BicepWriter().Append(this).ToString();

    public static implicit operator BicepExpression(string value) => new StringLiteralExpression(value);
    public static implicit operator BicepExpression(int value) => new IntLiteralExpression(value);
    public static implicit operator BicepExpression(bool value) => new BoolLiteralExpression(value);
}

public class IdentifierExpression(string name) : BicepExpression
{
    public string Name { get; } = name;
    internal override BicepWriter Write(BicepWriter writer) => writer.Append(Name);
}

public abstract class LiteralExpression(object? value = null) : BicepExpression
{
    public object? Value { get; } = value;
}

public class NullLiteralExpression() : LiteralExpression()
{
    internal override BicepWriter Write(BicepWriter writer) => writer.Append("null");
}

public class BoolLiteralExpression(bool value) : LiteralExpression(value)
{
    public new bool Value { get => (bool)base.Value!; }
    internal override BicepWriter Write(BicepWriter writer) => writer.Append(Value ? "true" : "false");
}

public class IntLiteralExpression(int value) : LiteralExpression(value)
{
    public new int Value { get => (int)base.Value!; }
    internal override BicepWriter Write(BicepWriter writer) => writer.Append(Value.ToString());
}

public class StringLiteralExpression(string value) : LiteralExpression(value)
{
    public new string Value { get => (string)base.Value!; }
    internal override BicepWriter Write(BicepWriter writer) =>
        (Value == null) ?
            writer.Append("null") :
            writer.Append('\'').AppendEscaped(Value).Append('\'');
}

public class InterpolatedStringExpression(BicepExpression[] values) : BicepExpression
{
    public BicepExpression[] Values { get; } = values;
    internal override BicepWriter Write(BicepWriter writer)
    {
        writer.Append('\'');
        foreach (BicepExpression value in Values)
        {
            if (value is StringLiteralExpression lit)
            {
                writer = writer.AppendEscaped(lit.Value);
            }
            else
            {
                writer = writer.Append("${").Append(value).Append('}');
            }
        }
        return writer.Append('\'');
    }
}

public class ArrayExpression(params BicepExpression[] values) : BicepExpression
{
    public BicepExpression[] Values { get; } = values;
    internal override BicepWriter Write(BicepWriter writer)
    {
        if (Values.Length == 0)
        {
            return writer.Append("[]");
        }
        else
        {
            return writer.Append('[')
                .Indent(w => w.AppendLine().AppendAll(Values, (w, v) => w.Append(v), w => w./*Append(',').*/AppendLine()))
                .AppendLine().Append(']');
        }
    }
}

public class ObjectExpression(params PropertyExpression[] properties) : BicepExpression
{
    public PropertyExpression[] Properties { get; } = properties;
    private static bool IsIdentifierChar(char c) => char.IsLetterOrDigit(c) || c == '_';
    internal override BicepWriter Write(BicepWriter writer) =>
        Properties.Length == 0 ?
            writer.Append("{ }") :
            writer.Append('{')
                .Indent(w => w.AppendLine().AppendAll(Properties,
                    (w, p) =>
                    {
                        bool quote = p.Name[0] != '\'' && !p.Name.All(IsIdentifierChar);
                        if (quote) { w.Append('\''); }
                        w.Append(p.Name);
                        if (quote) { w.Append('\''); }
                        return w.Append(": ").Append(p.Value);
                    },
                    w => w.AppendLine()))
                .AppendLine().Append('}');
}

public class PropertyExpression(string name, BicepExpression value) : BicepExpression
{
    public string Name { get; } = name;
    public BicepExpression Value { get; } = value;
    internal override BicepWriter Write(BicepWriter writer) => throw new InvalidOperationException("Properties are only valid inside an object");
}

public class TypeExpression(Type type) : BicepExpression
{
    public Type Type { get; } = type;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(
            BicepTypeMapping.GetBicepTypeName(Type) ??
            throw new NotSupportedException($"Failed to automatically map {Type.FullName} into a {nameof(TypeExpression)}.  Please explicitly choose a primitive type like bool, int, string, object, array, etc."));
}

public enum UnaryBicepOperator { Not, Negate, SuppressNull }
public class UnaryExpression(UnaryBicepOperator op, BicepExpression value) : BicepExpression
{
    public UnaryBicepOperator Operator { get; } = op;
    public BicepExpression Value { get; } = value;
    internal override BicepWriter Write(BicepWriter writer) =>
        Operator switch
        {
            UnaryBicepOperator.Not => writer.Append('!').Append(Value),
            UnaryBicepOperator.Negate => writer.Append('-').Append(Value),
            UnaryBicepOperator.SuppressNull => writer.Append(Value).Append('!'),
            _ => throw new NotImplementedException($"Unknown {nameof(UnaryBicepOperator)} value {Operator}")
        };
}

public enum BinaryBicepOperator { And, Or, Coalesce, Equal, EqualIgnoreCase, NotEqual, NotEqualIgnoreCase, Greater, GreaterOrEqual, Less, LessOrEqual, Add, Subtract, Multiply, Divide, Modulo }
public class BinaryExpression(BicepExpression left, BinaryBicepOperator op, BicepExpression right) : BicepExpression
{
    public BicepExpression Left { get; } = left;
    public BinaryBicepOperator Operator { get; } = op;
    public BicepExpression Right { get; } = right;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append('(').Append(Left).Append(' ')
            .Append(
                Operator switch
                {
                    BinaryBicepOperator.And => "&&",
                    BinaryBicepOperator.Or => "||",
                    BinaryBicepOperator.Coalesce => "??",
                    BinaryBicepOperator.Equal => "==",
                    BinaryBicepOperator.EqualIgnoreCase => "=~",
                    BinaryBicepOperator.NotEqual => "!=",
                    BinaryBicepOperator.NotEqualIgnoreCase => "!~",
                    BinaryBicepOperator.Greater => ">",
                    BinaryBicepOperator.GreaterOrEqual => ">=",
                    BinaryBicepOperator.Less => "<",
                    BinaryBicepOperator.LessOrEqual => "<=",
                    BinaryBicepOperator.Add => "+",
                    BinaryBicepOperator.Subtract => "-",
                    BinaryBicepOperator.Multiply => "*",
                    BinaryBicepOperator.Divide => "/",
                    BinaryBicepOperator.Modulo => "%",
                    _ => throw new NotImplementedException($"Unknown {nameof(BinaryBicepOperator)} value {Operator}"),
                })
            .Append(' ').Append(Right).Append(')');
}

public class ConditionalExpression(BicepExpression condition, BicepExpression consequent, BicepExpression alternate) : BicepExpression
{
    public BicepExpression Condition { get; } = condition;
    public BicepExpression Consequent { get; } = consequent;
    public BicepExpression Alternate { get; } = alternate;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Condition).Append(" ? ").Append(Consequent).Append(" : ").Append(Alternate);
}

public class IndexExpression(BicepExpression value, BicepExpression index) : BicepExpression
{
    public BicepExpression Value { get; } = value;
    public BicepExpression Index { get; } = index;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Value).Append('[').Append(Index).Append(']');
}

public class MemberExpression(BicepExpression value, string member) : BicepExpression
{
    public BicepExpression Value { get; } = value;
    public string Member { get; } = member;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Value).Append('.').Append(Member);
}

public class NestedExpression(BicepExpression value, string nestedMember) : BicepExpression
{
    public BicepExpression Value { get; } = value;
    public string NestedMember { get; } = nestedMember;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Value).Append("::").Append(NestedMember);
}

public class SafeIndexExpression(BicepExpression value, BicepExpression index) : BicepExpression
{
    public BicepExpression Value { get; } = value;
    public BicepExpression Index { get; } = index;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Value).Append("[?").Append(Index).Append(']');
}

public class SafeMemberExpression(BicepExpression value, string member) : BicepExpression
{
    public BicepExpression Value { get; } = value;
    public string Member { get; } = member;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Value).Append(".?").Append(Member);
}

public class DecoratorExpression(BicepExpression value) : BicepExpression
{
    public BicepExpression Value { get; } = value;
    internal override BicepWriter Write(BicepWriter writer) => writer.Append('@').Append(Value);
}

public class FunctionCallExpression(BicepExpression function, params BicepExpression[] arguments) : BicepExpression
{
    public BicepExpression Function { get; } = function;
    public BicepExpression[] Arguments { get; } = arguments;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Function).Append('(').AppendAll(Arguments, (w, a) => w.Append(a), w => w.Append(", ")).Append(')');
}

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

public class BicepProgram(params BicepStatement[] body)
{
    public BicepStatement[] Body { get; } = body;
    public string? ModuleName { get; set; }
    public override string ToString()
    {
        BicepWriter writer = new();
        // if (ModuleName != null) { writer.Append("// module ").Append(ModuleName).AppendLine(); }
        foreach (BicepStatement statement in Body)
        {
            writer = writer.Append(statement).AppendLine();
        }
        return writer.ToString();
    }
}
