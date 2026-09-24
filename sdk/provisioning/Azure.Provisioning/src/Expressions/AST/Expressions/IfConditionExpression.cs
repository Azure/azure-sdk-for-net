// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions
{
    /// <summary>
    /// Represents a Bicep conditional body expression (<c>if (condition) body</c>).
    /// </summary>
    /// <param name="condition">The condition that controls whether the body is evaluated.</param>
    /// <param name="body">The conditional body expression.</param>
    public partial class IfConditionExpression(BicepExpression condition, BicepExpression body) : BicepExpression
    {
        /// <summary>
        /// Gets the condition expression.
        /// </summary>
        public BicepExpression Condition { get; } = condition;
        /// <summary>
        /// Gets the body expression.
        /// </summary>
        public BicepExpression Body { get; } = body;
        internal override BicepWriter Write(BicepWriter writer)
            => writer.Append("if (").Append(Condition).Append(") ").Append(Body);
    }
}
