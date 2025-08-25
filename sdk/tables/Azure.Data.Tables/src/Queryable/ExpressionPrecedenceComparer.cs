// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq.Expressions;

namespace Azure.Data.Tables.Queryable
{
    internal sealed class ExpressionPrecedenceComparer : IComparer<Expression>
    {
        //From (2.2.3.6.1.1.2 Operator Precedence) https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-odata/f3380585-3f87-41d9-a2dc-ff46cc38e7a6
        //and https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/#operator-precedence

        private const byte UnknownPrecedenceCategory = byte.MaxValue;
        private const byte PrimaryPrecedenceCategory = 8;
        private const byte UnaryPrecedenceCategory = 7;
        private const byte MultiplicativePrecedenceCategory = 6;
        private const byte AdditivePrecedenceCategory = 5;
        private const byte RelationalPrecedenceCategory = 4;
        private const byte EqualityPrecedenceCategory = 3;
        private const byte ConditionalAndPrecedenceCategory = 2;
        private const byte ConditionalOrPrecedenceCategory = 1;

        static ExpressionPrecedenceComparer()
        {
            Instance = new ExpressionPrecedenceComparer();
        }

        public static ExpressionPrecedenceComparer Instance { get; }

        private ExpressionPrecedenceComparer()
        {
        }
        public int Compare(Expression x, Expression y) => GetCategoryLevel(x).CompareTo(GetCategoryLevel(y));

        private static byte GetCategoryLevel(Expression x)
        {
            switch (x.NodeType)
            {
                case ExpressionType.Constant:
                case ExpressionType.MemberAccess:
                case ExpressionType.Call:
                    return PrimaryPrecedenceCategory;
                case ExpressionType.Negate:
                case ExpressionType.NegateChecked:
                case ExpressionType.Not:
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                case ExpressionType.UnaryPlus:
                    return UnaryPrecedenceCategory;
                case ExpressionType.Multiply:
                case ExpressionType.MultiplyChecked:
                case ExpressionType.Divide:
                case ExpressionType.Modulo:
                    return MultiplicativePrecedenceCategory;
                case ExpressionType.Add:
                case ExpressionType.AddChecked:
                case ExpressionType.Subtract:
                case ExpressionType.SubtractChecked:
                    return AdditivePrecedenceCategory;
                case ExpressionType.LessThan:
                case ExpressionType.GreaterThan:
                case ExpressionType.LessThanOrEqual:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.TypeAs:
                    return RelationalPrecedenceCategory;
                case ExpressionType.Equal:
                case ExpressionType.NotEqual:
                    return EqualityPrecedenceCategory;
                case ExpressionType.And:
                case ExpressionType.AndAlso:
                    return ConditionalAndPrecedenceCategory;
                case ExpressionType.Or:
                case ExpressionType.OrElse:
                    return ConditionalOrPrecedenceCategory;
                default:
                    return UnknownPrecedenceCategory;
            };
        }
    }
}
