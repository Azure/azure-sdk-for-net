// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Azure.Data.Tables.Queryable
{
    [DebuggerDisplay("EntityResolverQueryOptionExpression {requestOptions}")]
    internal class EntityResolverQueryOptionExpression : QueryOptionExpression
    {
        internal EntityResolverQueryOptionExpression(Type type, ConstantExpression resolver)
            : base((ExpressionType)ResourceExpressionType.Resolver, type)
        {
            Resolver = resolver;
        }

        internal ConstantExpression Resolver { get; }
    }
}
