// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Azure.Data.Tables.Queryable
{
    [DebuggerDisplay("RequestOptionsQueryOptionExpression {requestOptions}")]
    internal class RequestOptionsQueryOptionExpression : QueryOptionExpression
    {
        internal RequestOptionsQueryOptionExpression(Type type, ConstantExpression requestOptions)
            : base((ExpressionType)ResourceExpressionType.RequestOptions, type)
        {
            RequestOptions = requestOptions;
        }

        internal ConstantExpression RequestOptions { get; }
    }
}
