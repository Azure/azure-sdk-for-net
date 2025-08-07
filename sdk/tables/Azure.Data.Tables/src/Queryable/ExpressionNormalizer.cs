// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace Azure.Data.Tables.Queryable
{
    internal class ExpressionNormalizer : ExpressionVisitor
    {
        private const bool LiftToNull = false;

        private readonly Dictionary<Expression, Pattern> _patterns = new Dictionary<Expression, Pattern>(ReferenceEqualityComparer<Expression>.Instance);

        private bool _underEqualityOperation;

        private ExpressionNormalizer(Dictionary<Expression, Expression> normalizerRewrites)
        {
            Debug.Assert(normalizerRewrites != null, "normalizerRewrites != null");
            NormalizerRewrites = normalizerRewrites;
        }

        internal Dictionary<Expression, Expression> NormalizerRewrites { get; }

        internal static Expression Normalize(Expression expression, Dictionary<Expression, Expression> rewrites)
        {
            Debug.Assert(expression != null, "expression != null");
            Debug.Assert(rewrites != null, "rewrites != null");

            ExpressionNormalizer normalizer = new ExpressionNormalizer(rewrites);
            Expression result = normalizer.Visit(expression);
            return result;
        }

        protected override Expression VisitBinary(BinaryExpression b)
        {
            _underEqualityOperation = b.NodeType == ExpressionType.Equal || b.NodeType == ExpressionType.NotEqual;

            BinaryExpression visited = (BinaryExpression)base.VisitBinary(b);

            switch (visited.NodeType)
            {
                case ExpressionType.Equal:
                case ExpressionType.NotEqual:
                case ExpressionType.LessThan:
                case ExpressionType.LessThanOrEqual:
                case ExpressionType.GreaterThan:
                case ExpressionType.GreaterThanOrEqual:

                    Expression normalizedLeft = UnwrapObjectConvert(visited.Left);
                    Expression normalizedRight = UnwrapObjectConvert(visited.Right);
                    if (normalizedLeft != visited.Left || normalizedRight != visited.Right)
                    {
                        visited = CreateRelationalOperator(visited.NodeType, normalizedLeft, normalizedRight);
                    }
                    break;
            }

            if (_patterns.TryGetValue(visited.Left, out Pattern pattern) && pattern.Kind == PatternKind.Compare && IsConstantZero(visited.Right))
            {
                ComparePattern comparePattern = (ComparePattern)pattern;
                if (TryCreateRelationalOperator(visited.NodeType, comparePattern.Left, comparePattern.Right, out BinaryExpression relationalExpression))
                {
                    visited = relationalExpression;
                }
            }

            _underEqualityOperation = false;

            RecordRewrite(b, visited);

            return visited;
        }
        protected override Expression VisitMember(MemberExpression m)
        {
            Expression visited;
            if (IsImplicitBooleanComparison(m))
            {
                visited = CreateExplicitBooleanComparison(m);
            }
            else
            {
                visited = base.VisitMember(m);
            }

            RecordRewrite(m, visited);

            return visited;
        }

        protected override Expression VisitUnary(UnaryExpression u)
        {
            Expression result;
            if (u.NodeType == ExpressionType.Convert && IsImplicitBooleanComparison(u))
            {
                BinaryExpression expandedBooleanComparison = CreateExplicitBooleanComparison(u);
                result = VisitBinary(expandedBooleanComparison);
            }
            else
            {
                result = base.VisitUnary(u);

                RecordRewrite(u, result);
            }

            return result;
        }

        private bool IsImplicitBooleanComparison(Expression expression)
        {
            return !_underEqualityOperation && typeof(bool?).IsAssignableFrom(expression.Type);
        }

        private static BinaryExpression CreateExplicitBooleanComparison(Expression expression)
        {
            var isNullable = expression.Type == typeof(bool?);
            ConstantExpression constant = isNullable ? Expression.Constant(true, typeof(bool?)) : Expression.Constant(true, typeof(bool));

            return CreateRelationalOperator(ExpressionType.Equal, expression, constant);
        }

        private static Expression UnwrapObjectConvert(Expression input)
        {
            if (input.NodeType == ExpressionType.Constant && input.Type == typeof(object))
            {
                ConstantExpression constant = (ConstantExpression)input;

                if (constant.Value != null &&
                    constant.Value.GetType() != typeof(object))
                {
                    return Expression.Constant(constant.Value, constant.Value.GetType());
                }
            }

            while (ExpressionType.Convert == input.NodeType)
            {
                input = ((UnaryExpression)input).Operand;
            }

            return input;
        }

        private static bool IsConstantZero(Expression expression)
        {
            return expression.NodeType == ExpressionType.Constant &&
                ((ConstantExpression)expression).Value.Equals(0);
        }

        protected override Expression VisitMethodCall(MethodCallExpression call)
        {
            Expression visited = VisitMethodCallNoRewrite(call);
            RecordRewrite(call, visited);
            return visited;
        }

        internal Expression VisitMethodCallNoRewrite(MethodCallExpression call)
        {
            MethodCallExpression visited = (MethodCallExpression)base.VisitMethodCall(call);

            if (visited.Method.IsStatic && visited.Method.Name == "Equals" && visited.Arguments.Count > 1)
            {
                if (visited.Arguments.Count > 2 && !TablesCompatSwitches.DisableThrowOnStringComparisonFilter)
                {
                    throw new NotSupportedException("string.Equals method with more than two arguments is not supported.");
                }
                return Expression.Equal(visited.Arguments[0], visited.Arguments[1], false, visited.Method);
            }

            if (!visited.Method.IsStatic && visited.Method.Name == "Equals" && visited.Arguments.Count > 0)
            {
                if (visited.Arguments.Count > 1 && !TablesCompatSwitches.DisableThrowOnStringComparisonFilter)
                {
                    throw new NotSupportedException("Equals method with more than two arguments is not supported.");
                }
                return CreateRelationalOperator(ExpressionType.Equal, visited.Object, visited.Arguments[0]);
            }

            if (visited.Method.IsStatic && visited.Method.Name == "CompareString" && visited.Method.DeclaringType.FullName == "Microsoft.VisualBasic.CompilerServices.Operators")
            {
                return CreateCompareExpression(visited.Arguments[0], visited.Arguments[1]);
            }

            if (!visited.Method.IsStatic && visited.Method.Name == "CompareTo" && visited.Arguments.Count == 1 && visited.Method.ReturnType == typeof(int))
            {
                return CreateCompareExpression(visited.Object, visited.Arguments[0]);
            }

            if (visited.Method.IsStatic && visited.Method.Name == "Compare" && visited.Arguments.Count > 1 && visited.Method.ReturnType == typeof(int))
            {
                if (visited.Arguments.Count > 2 && !TablesCompatSwitches.DisableThrowOnStringComparisonFilter)
                {
                    throw new NotSupportedException("string.Compare method with more than two arguments is not supported.");
                }
                return CreateCompareExpression(visited.Arguments[0], visited.Arguments[1]);
            }

            if (ReflectionUtil.s_dictionaryMethodInfosHash.Contains(visited.Method) && visited.Arguments.Count == 1 && visited.Arguments[0] is ConstantExpression)
            {
                return visited;
            }

            throw new NotSupportedException($"Method {visited.Method.Name} not supported.");
        }

        private static readonly MethodInfo StaticRelationalOperatorPlaceholderMethod = typeof(ExpressionNormalizer).GetMethod("RelationalOperatorPlaceholder", BindingFlags.Static | BindingFlags.NonPublic);

        private static bool RelationalOperatorPlaceholder<TLeft, TRight>(TLeft left, TRight right)
        {
            Debug.Assert(false, "This method should never be called. It exists merely to support creation of relational LINQ expressions.");
            return object.ReferenceEquals(left, right);
        }

        private static BinaryExpression CreateRelationalOperator(ExpressionType op, Expression left, Expression right)
        {
            if (!TryCreateRelationalOperator(op, left, right, out BinaryExpression result))
            {
                Debug.Assert(false, "CreateRelationalOperator has unknown op " + op);
            }

            return result;
        }

        private static bool TryCreateRelationalOperator(ExpressionType op, Expression left, Expression right, out BinaryExpression result)
        {
            MethodInfo relationalOperatorPlaceholderMethod = StaticRelationalOperatorPlaceholderMethod.MakeGenericMethod(left.Type, right.Type);

            switch (op)
            {
                case ExpressionType.Equal:
                    result = Expression.Equal(left, right, LiftToNull, relationalOperatorPlaceholderMethod);
                    return true;

                case ExpressionType.NotEqual:
                    result = Expression.NotEqual(left, right, LiftToNull, relationalOperatorPlaceholderMethod);
                    return true;

                case ExpressionType.LessThan:
                    result = Expression.LessThan(left, right, LiftToNull, relationalOperatorPlaceholderMethod);
                    return true;

                case ExpressionType.LessThanOrEqual:
                    result = Expression.LessThanOrEqual(left, right, LiftToNull, relationalOperatorPlaceholderMethod);
                    return true;

                case ExpressionType.GreaterThan:
                    result = Expression.GreaterThan(left, right, LiftToNull, relationalOperatorPlaceholderMethod);
                    return true;

                case ExpressionType.GreaterThanOrEqual:
                    result = Expression.GreaterThanOrEqual(left, right, LiftToNull, relationalOperatorPlaceholderMethod);
                    return true;

                default:
                    result = null;
                    return false;
            }
        }

        private Expression CreateCompareExpression(Expression left, Expression right)
        {
            Expression result = Expression.Condition(
                CreateRelationalOperator(ExpressionType.Equal, left, right),
                Expression.Constant(0),
                Expression.Condition(
                    CreateRelationalOperator(ExpressionType.GreaterThan, left, right),
                    Expression.Constant(1),
                    Expression.Constant(-1)));

            _patterns[result] = new ComparePattern(left, right);

            return result;
        }

        private void RecordRewrite(Expression source, Expression rewritten)
        {
            Debug.Assert(source != null, "source != null");
            Debug.Assert(rewritten != null, "rewritten != null");
            Debug.Assert(NormalizerRewrites != null, "this.NormalizerRewrites != null");

            if (source != rewritten)
            {
                NormalizerRewrites.Add(rewritten, source);
            }
        }

        private abstract class Pattern
        {
            internal abstract PatternKind Kind { get; }
        }

        private enum PatternKind
        {
            Compare,
        }

        private sealed class ComparePattern : Pattern
        {
            internal ComparePattern(Expression left, Expression right)
            {
                Left = left;
                Right = right;
            }

            internal readonly Expression Left;

            internal readonly Expression Right;

            internal override PatternKind Kind
            {
                get { return PatternKind.Compare; }
            }
        }
    }
}
