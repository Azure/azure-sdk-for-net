// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Provisioning.Expressions;

// TODO: Consider exposing helpers like this to allow for more concise Bicep
// expression declaration.

internal static class BicepSyntax
{
    public static BicepProgram Program(params Statement[] body) => new(body);

    public static IdentifierExpression Var(string name) => new(name);
    public static NullLiteral Null() => new();
    public static BoolLiteral Value(bool value) => new(value);
    public static IntLiteral Value(int value) => new(value);
    public static StringLiteral Value(string value) => new(value);
    public static ArrayExpression Array(params Expression[] values) => new(values);
    public static ObjectExpression Object(IDictionary<string, Expression> properties) => new(properties.Keys.Select(k => new PropertyExpression(k, properties[k])).ToArray());
    public static ObjectExpression Object(IDictionary<string, BicepValue> properties) => new(properties.Keys.Select(k => new PropertyExpression(k, properties[k].Compile())).ToArray());
    public static ObjectExpression Object<T>(BicepDictionary<T> properties) => new(properties.Keys.Select(k => new PropertyExpression(k, properties[k].Compile())).ToArray());

    public static UnaryExpression Not(Expression value) => new(UnaryOperator.Not, value);
    public static UnaryExpression Negate(Expression value) => new(UnaryOperator.Negate, value);
    public static UnaryExpression SuppressNull(Expression value) => new(UnaryOperator.SuppressNull, value);

    public static BinaryExpression And(Expression left, Expression right) => new(left, BinaryOperator.And, right);
    public static BinaryExpression Or(Expression left, Expression right) => new(left, BinaryOperator.Or, right);
    public static BinaryExpression Coalesce(Expression left, Expression right) => new(left, BinaryOperator.Coalesce, right);
    public static BinaryExpression Equal(Expression left, Expression right) => new(left, BinaryOperator.Equal, right);
    public static BinaryExpression EqualIgnoreCase(Expression left, Expression right) => new(left, BinaryOperator.EqualIgnoreCase, right);
    public static BinaryExpression NotEqual(Expression left, Expression right) => new(left, BinaryOperator.NotEqual, right);
    public static BinaryExpression NotEqualIgnoreCase(Expression left, Expression right) => new(left, BinaryOperator.NotEqualIgnoreCase, right);
    public static BinaryExpression Greater(Expression left, Expression right) => new(left, BinaryOperator.Greater, right);
    public static BinaryExpression GreaterOrEqual(Expression left, Expression right) => new(left, BinaryOperator.GreaterOrEqual, right);
    public static BinaryExpression Less(Expression left, Expression right) => new(left, BinaryOperator.Less, right);
    public static BinaryExpression LessOrEqual(Expression left, Expression right) => new(left, BinaryOperator.LessOrEqual, right);
    public static BinaryExpression Add(Expression left, Expression right) => new(left, BinaryOperator.Add, right);
    public static BinaryExpression Subtract(Expression left, Expression right) => new(left, BinaryOperator.Subtract, right);
    public static BinaryExpression Multiply(Expression left, Expression right) => new(left, BinaryOperator.Multiply, right);
    public static BinaryExpression Divide(Expression left, Expression right) => new(left, BinaryOperator.Divide, right);
    public static BinaryExpression Modulo(Expression left, Expression right) => new(left, BinaryOperator.Modulo, right);

    public static ConditionalExpression Conditional(Expression condition, Expression consequent, Expression alternate) => new(condition, consequent, alternate);

    public static FunctionCallExpression Call(Expression func, params Expression[] args) => new(func, args);
    public static FunctionCallExpression Call(string func, params Expression[] args) => Call(Var(func), args);

    public static InterpolatedString Interpolate(string format, params Expression[] values) => new(format, values);

    public static MemberExpression Get(this Expression value, string name) => new(value, name);
    public static IndexExpression Index(this Expression value, Expression index) => new(value, index);

    public static class Types
    {
        public static TypeExpression Create<T>() => new(typeof(T));
        public static TypeExpression Bool { get; } = Create<bool>();
        public static TypeExpression Int { get; } = Create<int>();
        public static TypeExpression String { get; } = Create<string>();
        public static TypeExpression Object { get; } = Create<object>();
        public static TypeExpression Array { get; } = Create<object[]>(); // Any Array type will do
    }

    public static class Declare
    {
        public static ParameterStatement Param<T>(string name, Expression? defaultValue = null) => Param(name, Types.Create<T>(), defaultValue);
        public static ParameterStatement Param(string name, Expression type, Expression? defaultValue = null) => new(name, type, defaultValue);
        public static VariableStatement Var(string name, Expression value) => new(name, value);
        public static OutputStatement Output<T>(string name, Expression value) => Output(name, Types.Create<T>(), value);
        public static OutputStatement Output(string name, Expression type, Expression value) => new(name, type, value);
        public static ResourceStatement Resource(string name, Expression type, Expression body) => new(name, type, body);
        public static ModuleStatement Module(string name, Expression type, Expression body) => new(name, type, body);
    }

    public static CommentStatement Comment(string comment) => new(comment);

    public static DecoratorExpression Decorator(string name, params Expression[] values) => new(Call(Var(name), values));
    public static ParameterStatement Decorate(this ParameterStatement target, string name, params Expression[] values) { target.Decorators.Add(Decorator(name, values)); return target; }
    public static VariableStatement Decorate(this VariableStatement target, string name, params Expression[] values) { target.Decorators.Add(Decorator(name, values)); return target; }
    public static OutputStatement Decorate(this OutputStatement target, string name, params Expression[] values) { target.Decorators.Add(Decorator(name, values)); return target; }
    public static ResourceStatement Decorate(this ResourceStatement target, string name, params Expression[] values) { target.Decorators.Add(Decorator(name, values)); return target; }
    public static ModuleStatement Decorate(this ModuleStatement target, string name, params Expression[] values) { target.Decorators.Add(Decorator(name, values)); return target; }
}
