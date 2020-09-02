// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq.Expressions;
using Azure.Core;

namespace Azure.Data.Tables.Queryable
{
    internal class ExpressionParser : LinqExpressionVisitor
    {
        /// <summary>
        /// Gets or sets the filter expression to use in the table query.
        /// </summary>
        /// <value>A string containing the filter expression to use in the query.</value>
        public string FilterString { get; set; }

        internal void Translate(Expression e)
        {
            Visit(e);
        }

        internal override Expression VisitLambda(LambdaExpression lambda)
        {
            FilterString = ExpressionWriter.ExpressionToString(lambda.Body);
            return lambda;
        }
    }
}
