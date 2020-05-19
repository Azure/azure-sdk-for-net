// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Azure.Data.Tables.Queryable
{
    internal class ProjectionQueryOptionExpression : QueryOptionExpression
    {
        internal static readonly LambdaExpression DefaultLambda = Expression.Lambda(Expression.Constant(0), null);

        internal ProjectionQueryOptionExpression(Type type, LambdaExpression lambda, List<string> paths)
            : base((ExpressionType)ResourceExpressionType.ProjectionQueryOption, type)
        {
            Debug.Assert(type != null, "type != null");
            Debug.Assert(lambda != null, "lambda != null");
            Debug.Assert(paths != null, "paths != null");

            Selector = lambda;
            Paths = paths;
        }

        internal LambdaExpression Selector { get; }

        internal List<string> Paths { get; }

    }
}
