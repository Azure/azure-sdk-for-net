// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

/// <summary>
/// An instance method call expression (e.g. <c>base.method(arg1, arg2)</c>).
/// </summary>
/// <param name="base">The expression on which the function is invoked.</param>
/// <param name="name">The function name.</param>
/// <param name="arguments">The function arguments.</param>
public partial class InstanceFunctionCallExpression(BicepExpression @base, string name, params BicepExpression[] arguments) : BicepExpression
{
    /// <summary>
    /// Gets the expression on which the function is invoked.
    /// </summary>
    public BicepExpression Base { get; } = @base;
    /// <summary>
    /// Gets the function name.
    /// </summary>
    public string Name { get; } = name;
    /// <summary>
    /// Gets the function arguments.
    /// </summary>
    public BicepExpression[] Arguments { get; } = arguments;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Base).Append('.').Append(Name).Append('(')
            .AppendAll(Arguments, (w, a) => w.Append(a), w => w.Append(", ")).Append(')');
}
