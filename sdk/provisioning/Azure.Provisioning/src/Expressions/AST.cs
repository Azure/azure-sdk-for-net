// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Azure.Provisioning.Expressions;

// This is a partial, simplified version of the Bicep AST that you can
// reference at https://github.com/Azure/bicep/blob/main/docs/grammar.md.  It's
// a non-goal to be able to do EVERYTHING that Bicep allows in C#.  We're just
// trying to glue them together better - if you need something not supported
// here then you can drop down to Bicep directly.

public abstract class Expression
{
    internal abstract BicepWriter Write(BicepWriter writer);
    public override string ToString() => new BicepWriter().Append(this).ToString();

    public static implicit operator Expression(string value) => new StringLiteral(value);
    public static implicit operator Expression(int value) => new IntLiteral(value);
    public static implicit operator Expression(bool value) => new BoolLiteral(value);
}

public class IdentifierExpression(string name) : Expression
{
    public string Name { get; } = name;
    internal override BicepWriter Write(BicepWriter writer) => writer.Append(Name);
}

public abstract class Literal(object? literalValue = null) : Expression
{
    public object? LiteralValue { get; } = literalValue;
}

public class NullLiteral() : Literal()
{
    internal override BicepWriter Write(BicepWriter writer) => writer.Append("null");
}

public class BoolLiteral(bool value) : Literal(value)
{
    public bool Value { get; } = value;
    internal override BicepWriter Write(BicepWriter writer) => writer.Append(Value ? "true" : "false");
}

public class IntLiteral(int value) : Literal(value)
{
    public int Value { get; } = value;
    internal override BicepWriter Write(BicepWriter writer) => writer.Append(Value.ToString());
}

public class StringLiteral(string value) : Literal(value)
{
    public string Value { get; } = value;
    internal override BicepWriter Write(BicepWriter writer) =>
        (Value == null) ?
            writer.Append("null") :
            writer.Append('\'').AppendEscaped(Value).Append('\'');
}

public class InterpolatedString(string format, Expression[] values) : Expression
{
    public string Format { get; } = format;
    public Expression[] Values { get; } = values;
    private static readonly Regex s_formatArgument = new("(\\{\\d+\\})", RegexOptions.Compiled);
    internal override BicepWriter Write(BicepWriter writer)
    {
        writer.Append('\'');
        foreach (string segment in s_formatArgument.Split(Format))
        {
            if (string.IsNullOrEmpty(segment)) { continue; }

            if (s_formatArgument.IsMatch(segment))
            {
                Expression value = Values[int.Parse(segment.TrimStart('{').TrimEnd('}'))];
                if (value is StringLiteral lit)
                {
                    writer.AppendEscaped(lit.Value);
                }
                else
                {
                    writer.Append("${").Append(value).Append('}');
                }
            }
            else
            {
                writer.AppendEscaped(segment);
            }
        }
        writer.Append('\'');
        return writer;
    }
}

public class ArrayExpression(params Expression[] values) : Expression
{
    public Expression[] Values { get; } = values;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append('[')
            .Indent(w => w.AppendLine().AppendAll(Values, (w, v) => w.Append(v), w => w./*Append(',').*/AppendLine()))
            .AppendLine().Append(']');
}

public class ObjectExpression(params PropertyExpression[] properties) : Expression
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

public class PropertyExpression(string name, Expression value) : Expression
{
    public string Name { get; } = name;
    public Expression Value { get; } = value;
    internal override BicepWriter Write(BicepWriter writer) => throw new InvalidOperationException("Properties are only valid inside an object");
}

public class TypeExpression(Type type) : Expression
{
    public Type Type { get; } = type;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(
            BicepTypeMapping.GetBicepTypeName(Type) ??
            throw new NotSupportedException($"Failed to automatically map {Type.FullName} into a {nameof(TypeExpression)}.  Please explicitly choose a primitive type like bool, int, string, object, array, etc."));
}

public enum UnaryOperator { Not, Negate, SuppressNull }
public class UnaryExpression(UnaryOperator op, Expression value) : Expression
{
    public UnaryOperator Operator { get; } = op;
    public Expression Value { get; } = value;
    internal override BicepWriter Write(BicepWriter writer) =>
        Operator switch
        {
            UnaryOperator.Not => writer.Append('!').Append(Value),
            UnaryOperator.Negate => writer.Append('-').Append(Value),
            UnaryOperator.SuppressNull => writer.Append(Value).Append('!'),
            _ => throw new NotImplementedException($"Unknown {nameof(UnaryOperator)} value {Operator}")
        };
}

public enum BinaryOperator { And, Or, Coalesce, Equal, EqualIgnoreCase, NotEqual, NotEqualIgnoreCase, Greater, GreaterOrEqual, Less, LessOrEqual, Add, Subtract, Multiply, Divide, Modulo }
public class BinaryExpression(Expression left, BinaryOperator op, Expression right) : Expression
{
    public Expression Left { get; } = left;
    public BinaryOperator Operator { get; } = op;
    public Expression Right { get; } = right;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append('(').Append(Left).Append(' ')
            .Append(
                Operator switch
                {
                    BinaryOperator.And => "&&",
                    BinaryOperator.Or => "||",
                    BinaryOperator.Coalesce => "??",
                    BinaryOperator.Equal => "==",
                    BinaryOperator.EqualIgnoreCase => "=~",
                    BinaryOperator.NotEqual => "!=",
                    BinaryOperator.NotEqualIgnoreCase => "!~",
                    BinaryOperator.Greater => ">",
                    BinaryOperator.GreaterOrEqual => ">=",
                    BinaryOperator.Less => "<",
                    BinaryOperator.LessOrEqual => "<=",
                    BinaryOperator.Add => "+",
                    BinaryOperator.Subtract => "-",
                    BinaryOperator.Multiply => "*",
                    BinaryOperator.Divide => "/",
                    BinaryOperator.Modulo => "%",
                    _ => throw new NotImplementedException($"Unknown {nameof(BinaryOperator)} value {Operator}"),
                })
            .Append(' ').Append(Right).Append(')');
}

public class ConditionalExpression(Expression condition, Expression consequent, Expression alternate) : Expression
{
    public Expression Condition { get; } = condition;
    public Expression Consequent { get; } = consequent;
    public Expression Alternate { get; } = alternate;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Condition).Append(" ? ").Append(Consequent).Append(" : ").Append(Alternate);
}

public class IndexExpression(Expression value, Expression index) : Expression
{
    public Expression Value { get; } = value;
    public Expression Index { get; } = index;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Value).Append('[').Append(Index).Append(']');
}

public class MemberExpression(Expression value, string member) : Expression
{
    public Expression Value { get; } = value;
    public string Member { get; } = member;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Value).Append('.').Append(Member);
}

public class NestedExpression(Expression value, string nestedMember) : Expression
{
    public Expression Value { get; } = value;
    public string NestedMember { get; } = nestedMember;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Value).Append("::").Append(NestedMember);
}

public class SafeIndexExpression(Expression value, Expression index) : Expression
{
    public Expression Value { get; } = value;
    public Expression Index { get; } = index;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Value).Append("[?").Append(Index).Append(']');
}

public class SafeMemberExpression(Expression value, string member) : Expression
{
    public Expression Value { get; } = value;
    public string Member { get; } = member;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Value).Append(".?").Append(Member);
}

public class DecoratorExpression(Expression expr) : Expression
{
    public Expression Expr { get; } = expr;
    internal override BicepWriter Write(BicepWriter writer) => writer.Append('@').Append(Expr);
}

public class FunctionCallExpression(Expression function, params Expression[] arguments) : Expression
{
    public Expression Function { get; } = function;
    public Expression[] Arguments { get; } = arguments;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Function).Append('(').AppendAll(Arguments, (w, a) => w.Append(a), w => w.Append(", ")).Append(')');
}

public abstract class Statement
{
    internal abstract BicepWriter Write(BicepWriter writer);
    public override string ToString() => new BicepWriter().Append(this).ToString();
}

public class TargetScopeStatement(Expression scope) : Statement
{
    public Expression Scope { get; } = scope;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append("targetScope = ").Append(Scope).AppendLine();
}

public class VariableStatement(string name, Expression value) : Statement
{
    public string Name { get; } = name;
    public Expression Value { get; } = value;
    public IList<DecoratorExpression> Decorators { get; } = [];
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.AppendAll(Decorators, (w, d) => w.Append(d).AppendLine()).Append("var ").Append(Name).Append(" = ").Append(Value).AppendLine();
}

public class ParameterStatement(string name, Expression type, Expression? defaultValue) : Statement
{
    public string Name { get; } = name;
    public Expression Type { get; } = type;
    public Expression? DefaultValue { get; } = defaultValue;
    public IList<DecoratorExpression> Decorators { get; } = [];
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.AppendAll(Decorators, (w, d) => w.Append(d).AppendLine()).Append("param ").Append(Name).Append(' ').Append(Type)
            .AppendIf(DefaultValue != null, w => w.Append(" = ").Append(DefaultValue!))
            .AppendLine();
            // note: use NullLiteral if you want a null default value
}

public class OutputStatement(string name, Expression type, Expression value) : Statement
{
    public string Name { get; } = name;
    public Expression Type { get; } = type;
    public Expression Value { get; } = value;
    public IList<DecoratorExpression> Decorators { get; } = [];
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.AppendAll(Decorators, (w, d) => w.Append(d).AppendLine())
            .Append("output ").Append(Name).Append(' ').Append(Type).Append(" = ").Append(Value).AppendLine();
}

public class ResourceStatement(string name, Expression type, Expression body) : Statement
{
    public string Name { get; } = name;
    public Expression Type { get; } = type;
    public Expression Body { get; } = body;
    public bool Existing { get; set; }
    public IList<DecoratorExpression> Decorators { get; } = [];
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.AppendAll(Decorators, (w, d) => w.Append(d).AppendLine())
            .Append("resource ").Append(Name).Append(' ').Append(Type).AppendIf(Existing, w => w.Append(" existing")).Append(" = ").Append(Body).AppendLine();
}

public class ModuleStatement(string name, Expression type, Expression body) : Statement
{
    public string Name { get; } = name;
    public Expression Type { get; } = type;
    public Expression Body { get; } = body;
    public IList<DecoratorExpression> Decorators { get; } = [];
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.AppendAll(Decorators, (w, d) => w.Append(d).AppendLine())
            .Append("module ").Append(Name).Append(' ').Append(Type).Append(" = ").Append(Body).AppendLine();
}

public class CommentStatement(string comment) : Statement
{
    public string Comment { get; } = comment;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append("// ").Append(Comment).AppendLine();
}

public class ExprStatement(Expression expr) : Statement
{
    public Expression Expression { get; } = expr;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Expression);
}

public class BicepProgram(params Statement[] body)
{
    public Statement[] Body { get; } = body;
    public string? ModuleName { get; set; }
    public override string ToString()
    {
        BicepWriter writer = new();
        // if (ModuleName != null) { writer.Append("// module ").Append(ModuleName).AppendLine(); }
        foreach (Statement stmt in Body)
        {
            writer = writer.Append(stmt).AppendLine();
        }
        return writer.ToString();
    }
}
