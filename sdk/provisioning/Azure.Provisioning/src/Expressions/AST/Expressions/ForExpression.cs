// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions
{
    /// <summary>
    /// A for expression (e.g. <c>[for item in items: { ... }]</c>).
    /// </summary>
    public partial class ForExpression(
        string itemVariable,
        string? indexVariable,
        BicepExpression collection,
        BicepExpression body,
        BicepExpression? condition) : BicepExpression
    {
        /// <summary>The loop variable name bound to each item.</summary>
        public string ItemVariable { get; } = itemVariable;

        /// <summary>Optional index variable name (e.g. <c>(item, i)</c>).</summary>
        public string? IndexVariable { get; } = indexVariable;

        /// <summary>The collection expression being iterated.</summary>
        public BicepExpression Collection { get; } = collection;

        /// <summary>The body expression evaluated for each iteration.</summary>
        public BicepExpression Body { get; } = body;

        /// <summary>Optional filter condition applied to each iteration.</summary>
        public BicepExpression? Condition { get; } = condition;

        /// <summary>
        /// Creates a <see cref="ForExpression"/> without an index variable or condition.
        /// </summary>
        public ForExpression(string itemVariable, BicepExpression collection, BicepExpression body)
            : this(itemVariable, null, collection, body, null)
        {
        }

        internal override BicepWriter Write(BicepWriter writer)
        {
            writer.Append("[for ");
            if (IndexVariable != null)
                writer.Append("(").Append(ItemVariable).Append(", ").Append(IndexVariable).Append(")");
            else
                writer.Append(ItemVariable);
            writer.Append(" in ").Append(Collection).Append(": ");
            if (Condition != null)
                writer.Append("if (").Append(Condition).Append(") ");
            writer.Append(Body).Append("]");
            return writer;
        }
    }
}
