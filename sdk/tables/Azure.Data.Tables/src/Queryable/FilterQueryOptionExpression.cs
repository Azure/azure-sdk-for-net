// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq.Expressions;

namespace Azure.Data.Tables.Queryable
{
    internal class FilterQueryOptionExpression : QueryOptionExpression
    {
        internal FilterQueryOptionExpression(Type type, Expression predicate)
            : base((ExpressionType)ResourceExpressionType.FilterQueryOption, type)
        {
            Predicate = predicate;
        }

        internal Expression Predicate { get; }
    }
}
