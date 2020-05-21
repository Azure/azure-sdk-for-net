// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Azure.Data.Tables.Queryable
{
    internal abstract class QueryOptionExpression : Expression
    {
        public override ExpressionType NodeType { get; }
        public override Type Type { get; }

        internal QueryOptionExpression(ExpressionType nodeType, Type type) : base()
        {
            NodeType = nodeType;
            Type = type;
        }

        internal virtual QueryOptionExpression ComposeMultipleSpecification(QueryOptionExpression previous)
        {
            Debug.Assert(previous != null, "other != null");
            Debug.Assert(previous.GetType() == GetType(), "other.GetType == this.GetType() -- otherwise it's not the same specification");
            return this;
        }
    }
}
