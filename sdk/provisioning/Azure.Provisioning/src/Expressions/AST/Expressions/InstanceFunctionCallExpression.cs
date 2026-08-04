// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

/// <summary>
/// An instance method call expression (e.g. <c>base.method(arg1, arg2)</c>).
/// </summary>
public partial class InstanceFunctionCallExpression(BicepExpression @base, string name, params BicepExpression[] arguments) : BicepExpression
{
    public BicepExpression Base { get; } = @base;
    public string Name { get; } = name;
    public BicepExpression[] Arguments { get; } = arguments;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Base).Append('.').Append(Name).Append('(')
            .AppendAll(Arguments, (w, a) => w.Append(a), w => w.Append(", ")).Append(')');
}
