// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Azure.Data.Tables.Queryable
{
    [DebuggerDisplay("TakeQueryOptionExpression {TakeAmount}")]
    internal class TakeQueryOptionExpression : QueryOptionExpression
    {
        internal TakeQueryOptionExpression(Type type, ConstantExpression takeAmount)
            : base((ExpressionType)ResourceExpressionType.TakeQueryOption, type)
        {
            TakeAmount = takeAmount;
        }

        internal ConstantExpression TakeAmount { get; }

        internal override QueryOptionExpression ComposeMultipleSpecification(QueryOptionExpression previous)
        {
            Debug.Assert(previous != null, "other != null");
            Debug.Assert(previous.GetType() == GetType(), "other.GetType == GetType() -- otherwise it's not the same specification");
            Debug.Assert(TakeAmount != null, "takeAmount != null");
            Debug.Assert(
                TakeAmount.Type == typeof(int),
                "takeAmount.Type == typeof(int) -- otherwise it wouldn't have matched the Enumerable.Take(source, int count) signature");
            int thisValue = (int)TakeAmount.Value;
            int previousValue = (int)((TakeQueryOptionExpression)previous).TakeAmount.Value;
            return (thisValue < previousValue) ? this : previous;
        }
    }
}
