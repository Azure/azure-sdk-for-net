// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Azure.Data.Tables.Queryable
{
    [DebuggerDisplay("OperationContextQueryOptionExpression {operationContext}")]
    internal class OperationContextQueryOptionExpression : QueryOptionExpression
    {
        internal OperationContextQueryOptionExpression(Type type, ConstantExpression operationContext)
            : base((ExpressionType)ResourceExpressionType.OperationContext, type)
        {
            OperationContext = operationContext;
        }

        internal ConstantExpression OperationContext { get; }
    }
}
