// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Represents a Bicep function call expression.
/// </summary>
/// <param name="function">The expression identifying the function to call.</param>
/// <param name="arguments">The arguments to pass to the function.</param>
public class FunctionCallExpression(BicepExpression function, params BicepExpression[] arguments) : BicepExpression
{
    /// <summary>
    /// Gets the expression identifying the function to call.
    /// </summary>
    public BicepExpression Function { get; } = function;
    /// <summary>
    /// Gets the function call arguments.
    /// </summary>
    public BicepExpression[] Arguments { get; } = arguments;
    internal override BicepWriter Write(BicepWriter writer) =>
        writer.Append(Function).Append('(')
            .AppendAll(Arguments, (w, a) => w.Append(a), w => w.Append(", ")).Append(')');
}
