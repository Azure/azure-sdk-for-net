// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq.Expressions;

namespace Azure.Data.Tables.Queryable
{
    internal sealed class ExpressionPrecedenceComparer : IComparer<Expression>
    {
        //From (2.2.3.6.1.1.2 Operator Precedence) https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-odata/f3380585-3f87-41d9-a2dc-ff46cc38e7a6
        private const byte PrimaryPrecedenceCategory = 8;
        private const byte UnaryPrecedenceCategory = 7;
        private const byte MultiplicativePrecedenceCategory = 6;
        private const byte AdditivePrecedenceCategory = 5;
        private const byte RelationalPrecedenceCategory = 4;
        private const byte EqualityPrecedenceCategory = 3;
        private const byte ConditionalAndPrecedenceCategory = 2;
        private const byte ConditionalOrPrecedenceCategory = 1;

        private static Dictionary<ExpressionType, byte> _operatorPrecedence = new Dictionary<ExpressionType, byte>
        {
            {
                ExpressionType.MemberAccess, PrimaryPrecedenceCategory
            },
            {
                ExpressionType.Call, PrimaryPrecedenceCategory
            },
            {
                ExpressionType.Negate, UnaryPrecedenceCategory
            },
            {
                ExpressionType.Not, UnaryPrecedenceCategory
            },
            {
                ExpressionType.Convert, UnaryPrecedenceCategory
            },
            {
                ExpressionType.Multiply, MultiplicativePrecedenceCategory
            },
            {
                ExpressionType.MultiplyChecked, MultiplicativePrecedenceCategory
            },
            {
                ExpressionType.Divide, MultiplicativePrecedenceCategory
            },
            {
                ExpressionType.Add, AdditivePrecedenceCategory
            },
            {
                ExpressionType.AddChecked, AdditivePrecedenceCategory
            },
            {
                ExpressionType.Subtract, AdditivePrecedenceCategory
            },
            {
                ExpressionType.SubtractChecked, AdditivePrecedenceCategory
            },
            {
                ExpressionType.LessThan, RelationalPrecedenceCategory
            },
            {
                ExpressionType.GreaterThan, RelationalPrecedenceCategory
            },
            {
                ExpressionType.LessThanOrEqual, RelationalPrecedenceCategory
            },
            {
                ExpressionType.GreaterThanOrEqual, RelationalPrecedenceCategory
            },
            {
                ExpressionType.Equal, EqualityPrecedenceCategory
            },
            {
                ExpressionType.NotEqual, EqualityPrecedenceCategory
            },
            {
                ExpressionType.And, ConditionalAndPrecedenceCategory
            },
            {
                ExpressionType.AndAlso, ConditionalAndPrecedenceCategory
            },
            {
                ExpressionType.Or, ConditionalOrPrecedenceCategory
            },
            {
                ExpressionType.OrElse, ConditionalOrPrecedenceCategory
            }
        };

        static ExpressionPrecedenceComparer()
        {
            Instance = new ExpressionPrecedenceComparer();
        }

        public static ExpressionPrecedenceComparer Instance { get; }

        private ExpressionPrecedenceComparer()
        {
        }
        public int Compare(Expression x, Expression y)
        {
            if (_operatorPrecedence.TryGetValue(x.NodeType, out var xPrecedence) && _operatorPrecedence.TryGetValue(y.NodeType, out var yPrecedence))
            {
                return xPrecedence.CompareTo(yPrecedence);
            }
            return 0;
        }
    }
}
