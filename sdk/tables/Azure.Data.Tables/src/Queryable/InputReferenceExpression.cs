// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Azure.Data.Tables.Queryable
{
    [DebuggerDisplay("InputReferenceExpression -> {Type}")]
    internal sealed class InputReferenceExpression : Expression
    {

        public override ExpressionType NodeType { get; }
        public override Type Type { get; }

        internal InputReferenceExpression(ResourceExpression target)
            : base()
        {
            Debug.Assert(target != null, "Target resource set cannot be null");
            Target = target;
            NodeType = (ExpressionType)ResourceExpressionType.InputReference;
            Type = target.ResourceType;
        }
        internal ResourceExpression Target { get; private set; }

        internal void OverrideTarget(ResourceSetExpression newTarget)
        {
            Debug.Assert(newTarget != null, "Resource set cannot be null");
            Debug.Assert(newTarget.ResourceType.Equals(this.Type), "Cannot reference a resource set with a different resource type");

            Target = newTarget;
        }
    }
}
