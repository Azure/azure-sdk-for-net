// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Provisioning.Expressions;

// TODO: Consider exposing helpers like this to allow for more concise Bicep
// expression declaration.

internal static class BicepSyntax
{
    public static BicepProgram Program(params BicepStatement[] body) => new(body);

    public static IdentifierExpression Var(string name) => new(name);
    public static NullLiteralExpression Null() => new();
    public static BoolLiteralExpression Value(bool value) => new(value);
    public static IntLiteralExpression Value(int value) => new(value);
    public static BicepExpression Value(long value)
    {
        // see if the value falls into the int range
        if (value >= int.MinValue && value <= int.MaxValue)
        {
            return BicepSyntax.Value((int)value);
        }
        // otherwise we use the workaround from https://github.com/Azure/bicep/issues/1386#issuecomment-818077233
        return BicepFunction.ParseJson(BicepSyntax.Value(value.ToString())).Compile();
    }
    public static BicepExpression Value(double value)
    {
        // see if the value is a whole number
        if (value >= int.MinValue && value <= int.MaxValue && value == Math.Floor(value))
        {
            return BicepSyntax.Value((int)value);
        }
        // otherwise we use the workaround from https://github.com/Azure/bicep/issues/1386#issuecomment-818077233
        return BicepFunction.ParseJson(BicepSyntax.Value(value.ToString())).Compile();
    }
    public static StringLiteralExpression Value(string value) => new(value);
    public static ArrayExpression Array(params BicepExpression[] values) => new(values);
    public static ObjectExpression Object(IDictionary<string, BicepExpression> properties) => new(properties.Keys.Select(k => new PropertyExpression(k, properties[k])).ToArray());
    public static ObjectExpression Object(IDictionary<string, BicepValue> properties) => new(properties.Keys.Select(k => new PropertyExpression(k, properties[k].Compile())).ToArray());
    public static ObjectExpression Object<T>(BicepDictionary<T> properties) => new(properties.Keys.Select(k => new PropertyExpression(k, properties[k].Compile())).ToArray());

    public static UnaryExpression Not(BicepExpression value) => new(UnaryBicepOperator.Not, value);
    public static UnaryExpression Negate(BicepExpression value) => new(UnaryBicepOperator.Negate, value);
    public static UnaryExpression SuppressNull(BicepExpression value) => new(UnaryBicepOperator.SuppressNull, value);

    public static BinaryExpression And(BicepExpression left, BicepExpression right) => new(left, BinaryBicepOperator.And, right);
    public static BinaryExpression Or(BicepExpression left, BicepExpression right) => new(left, BinaryBicepOperator.Or, right);
    public static BinaryExpression Coalesce(BicepExpression left, BicepExpression right) => new(left, BinaryBicepOperator.Coalesce, right);
    public static BinaryExpression Equal(BicepExpression left, BicepExpression right) => new(left, BinaryBicepOperator.Equal, right);
    public static BinaryExpression EqualIgnoreCase(BicepExpression left, BicepExpression right) => new(left, BinaryBicepOperator.EqualIgnoreCase, right);
    public static BinaryExpression NotEqual(BicepExpression left, BicepExpression right) => new(left, BinaryBicepOperator.NotEqual, right);
    public static BinaryExpression NotEqualIgnoreCase(BicepExpression left, BicepExpression right) => new(left, BinaryBicepOperator.NotEqualIgnoreCase, right);
    public static BinaryExpression Greater(BicepExpression left, BicepExpression right) => new(left, BinaryBicepOperator.Greater, right);
    public static BinaryExpression GreaterOrEqual(BicepExpression left, BicepExpression right) => new(left, BinaryBicepOperator.GreaterOrEqual, right);
    public static BinaryExpression Less(BicepExpression left, BicepExpression right) => new(left, BinaryBicepOperator.Less, right);
    public static BinaryExpression LessOrEqual(BicepExpression left, BicepExpression right) => new(left, BinaryBicepOperator.LessOrEqual, right);
    public static BinaryExpression Add(BicepExpression left, BicepExpression right) => new(left, BinaryBicepOperator.Add, right);
    public static BinaryExpression Subtract(BicepExpression left, BicepExpression right) => new(left, BinaryBicepOperator.Subtract, right);
    public static BinaryExpression Multiply(BicepExpression left, BicepExpression right) => new(left, BinaryBicepOperator.Multiply, right);
    public static BinaryExpression Divide(BicepExpression left, BicepExpression right) => new(left, BinaryBicepOperator.Divide, right);
    public static BinaryExpression Modulo(BicepExpression left, BicepExpression right) => new(left, BinaryBicepOperator.Modulo, right);

    public static ConditionalExpression Conditional(BicepExpression condition, BicepExpression consequent, BicepExpression alternate) => new(condition, consequent, alternate);

    public static FunctionCallExpression Call(BicepExpression func, params BicepExpression[] args) => new(func, args);
    public static FunctionCallExpression Call(string func, params BicepExpression[] args) => Call(Var(func), args);

    public static InterpolatedStringExpression Interpolate(params BicepExpression[] values) => new(values);

    public static MemberExpression Get(this BicepExpression value, string name) => new(value, name);
    public static IndexExpression Index(this BicepExpression value, BicepExpression index) => new(value, index);

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
        public static ParameterStatement Param<T>(string name, BicepExpression? defaultValue = null) => Param(name, Types.Create<T>(), defaultValue);
        public static ParameterStatement Param(string name, BicepExpression type, BicepExpression? defaultValue = null) => new(name, type, defaultValue);
        public static VariableStatement Var(string name, BicepExpression value) => new(name, value);
        public static OutputStatement Output<T>(string name, BicepExpression value) => Output(name, Types.Create<T>(), value);
        public static OutputStatement Output(string name, BicepExpression type, BicepExpression value) => new(name, type, value);
        public static ResourceStatement Resource(string name, BicepExpression type, BicepExpression body) => new(name, type, body);
        public static ModuleStatement Module(string name, BicepExpression type, BicepExpression body) => new(name, type, body);
    }

    public static CommentStatement Comment(string comment) => new(comment);

    public static DecoratorExpression Decorator(string name, params BicepExpression[] values) => new(Call(Var(name), values));
    public static ParameterStatement Decorate(this ParameterStatement target, string name, params BicepExpression[] values) { target.Decorators.Add(Decorator(name, values)); return target; }
    public static VariableStatement Decorate(this VariableStatement target, string name, params BicepExpression[] values) { target.Decorators.Add(Decorator(name, values)); return target; }
    public static OutputStatement Decorate(this OutputStatement target, string name, params BicepExpression[] values) { target.Decorators.Add(Decorator(name, values)); return target; }
    public static ResourceStatement Decorate(this ResourceStatement target, string name, params BicepExpression[] values) { target.Decorators.Add(Decorator(name, values)); return target; }
    public static ModuleStatement Decorate(this ModuleStatement target, string name, params BicepExpression[] values) { target.Decorators.Add(Decorator(name, values)); return target; }
}
