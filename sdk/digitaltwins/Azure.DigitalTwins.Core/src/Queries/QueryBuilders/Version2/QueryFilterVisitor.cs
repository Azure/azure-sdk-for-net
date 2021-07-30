// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Diagnostics;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    internal class QueryFilterVisitor : LinqExpressionVisitor
    {
        private StringBuilder _filter = new StringBuilder();

        private QueryFilterVisitor() { }

        public static string Translate(Expression e)
        {
            var visitor = new QueryFilterVisitor();
            visitor.Visit(e);

            return visitor._filter.ToString();
        }

        private static Exception NotSupported(Expression e)
        {
            return new InvalidOperationException($"Expression {e} is not supported.");
        }

        internal override Expression VisitConstant(ConstantExpression c)
        {
            _filter.Append(DigitalTwinsFunctions.Convert(c.Value, CultureInfo.InvariantCulture));
            return c;
        }

        internal override Expression VisitMemberAccess(MemberExpression m)
        {
            if (m.Expression is ParameterExpression)
            {
                _filter.Append(m.Member.Name);
                return m;
            }

            throw NotSupported(m);
        }

        internal override Expression VisitBinary(BinaryExpression b)
        {
            string op = b.NodeType switch
            {
                ExpressionType.Equal => "=",
                ExpressionType.NotEqual => "!=",
                ExpressionType.GreaterThan => ">",
                ExpressionType.LessThan => "<",
                ExpressionType.GreaterThanOrEqual => ">=",
                ExpressionType.LessThanOrEqual => "<=",
                ExpressionType.AndAlso => "AND",
                ExpressionType.OrElse => "OR",
                _ => throw NotSupported(b)
            };

            // left side
            bool parens = GetPrecedence(b) >= GetPrecedence(b.Left);
            // isOccupied == (empty || free)
            //             9        4
            /*
                      BinExp (==)
                       /       \
                    Const         BinExp(||)
                                  empty    free
            */

            if (parens)
            {
                _filter.Append('(');
            }

            Visit(b.Left);

            if (parens)
            {
                _filter.Append(')');
            }

            // operator
            _filter.Append(' ').Append(op).Append(' ');

            // right side
            parens = GetPrecedence(b) >= GetPrecedence(b.Right);

            if (parens)
            {
                _filter.Append('(');
            }

            Visit(b.Right);

            if (parens)
            {
                _filter.Append(')');
            }

            return b;
        }

        // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/
        private static int GetPrecedence(Expression e) =>
            e.NodeType switch
            {
                // Unused ExpressionType values:
                ExpressionType.Block => 20,
                ExpressionType.Constant => 20,
                ExpressionType.DebugInfo => 20,
                ExpressionType.Dynamic => 20,
                ExpressionType.Extension => 20,
                ExpressionType.Goto => 20,
                ExpressionType.Label => 20,
                ExpressionType.Loop => 20,
                ExpressionType.Parameter => 20,
                ExpressionType.Quote => 20,
                ExpressionType.RuntimeVariables => 20,
                ExpressionType.Throw => 20,
                ExpressionType.Try => 20,
                ExpressionType.Unbox => 20,

                // Primary: x.y, f(x), a[i], x?.y, x?[y], x++, x--, x!, new,
                // typeof, checked, unchecked, default, nameof, delegate,
                // sizeof, stackalloc, x->y
                ExpressionType.MemberAccess => 19,
                ExpressionType.ArrayLength => 19,
                ExpressionType.Call => 19,
                ExpressionType.Invoke => 19,
                ExpressionType.Index => 19,
                ExpressionType.ArrayIndex => 19,
                ExpressionType.PostIncrementAssign => 19,
                ExpressionType.PostDecrementAssign => 19,
                ExpressionType.New => 19,
                ExpressionType.NewArrayBounds => 19,
                ExpressionType.NewArrayInit => 19,
                ExpressionType.MemberInit => 19,
                ExpressionType.ListInit => 19,
                ExpressionType.Default => 19,

                // Unary: +x, -x, !x, ~x, ++x, --x, ^x, (T)x, await, &x, *x, true and false
                ExpressionType.UnaryPlus => 18,
                ExpressionType.Negate => 18,
                ExpressionType.NegateChecked => 18,
                ExpressionType.OnesComplement => 18,
                ExpressionType.Not => 18,
                ExpressionType.Increment => 18,
                ExpressionType.PreIncrementAssign => 18,
                ExpressionType.Decrement => 18,
                ExpressionType.PreDecrementAssign => 18,
                ExpressionType.Convert => 18,
                ExpressionType.ConvertChecked => 18,
                ExpressionType.IsTrue => 18,
                ExpressionType.IsFalse => 18,

                // Range: x..y
                // (not represented in LINQ)

                // switch expression
                ExpressionType.Switch => 16,

                // with expression
                // (not represented in LINQ)

                // Power: a ^ b
                ExpressionType.Power => 14,

                // Multiplicative: x * y, x / y, x % y
                ExpressionType.Multiply => 13,
                ExpressionType.MultiplyChecked => 13,
                ExpressionType.Divide => 13,
                ExpressionType.Modulo => 13,

                // Additive: x + y, x – y
                ExpressionType.Add => 12,
                ExpressionType.AddChecked => 12,
                ExpressionType.Subtract => 12,
                ExpressionType.SubtractChecked => 12,

                // Shift: x << y, x >> y
                ExpressionType.LeftShift => 11,
                ExpressionType.RightShift => 11,

                // Relational and type-testing: x < y, x > y, x <= y, x >= y, is, as
                ExpressionType.LessThan => 10,
                ExpressionType.GreaterThan => 10,
                ExpressionType.LessThanOrEqual => 10,
                ExpressionType.GreaterThanOrEqual => 10,
                ExpressionType.TypeIs => 10,
                ExpressionType.TypeAs => 10,
                ExpressionType.TypeEqual => 10,

                // Equality: x == y, x != y
                ExpressionType.Equal => 9,
                ExpressionType.NotEqual => 9,

                // Boolean logical AND or bitwise logical AND: x & y
                ExpressionType.And => 8,

                // Boolean logical XOR or bitwise logical XOR: x ^ y
                ExpressionType.ExclusiveOr => 7,

                // Boolean logical OR or bitwise logical OR: x | y
                ExpressionType.Or => 6,

                // Conditional AND: x && y
                ExpressionType.AndAlso => 5,

                // Conditional OR: x || y
                ExpressionType.OrElse => 4,

                // Null-coalescing operator: x ?? y
                ExpressionType.Coalesce => 3,

                // Conditional operator: c ? t : f
                ExpressionType.Conditional => 2,

                // Assignment and lambda declaration:
                // x = y, x += y, x -= y, x *= y, x /= y, x %= y, x &= y,
                // x |= y, x ^= y, x <<= y, x >>= y, x ??= y, =>
                ExpressionType.Assign => 1,
                ExpressionType.AddAssign => 1,
                ExpressionType.AddAssignChecked => 1,
                ExpressionType.SubtractAssign => 1,
                ExpressionType.SubtractAssignChecked => 1,
                ExpressionType.MultiplyAssign => 1,
                ExpressionType.MultiplyAssignChecked => 1,
                ExpressionType.DivideAssign => 1,
                ExpressionType.ModuloAssign => 1,
                ExpressionType.PowerAssign => 1,
                ExpressionType.AndAssign => 1,
                ExpressionType.OrAssign => 1,
                ExpressionType.ExclusiveOrAssign => 1,
                ExpressionType.LeftShiftAssign => 1,
                ExpressionType.RightShiftAssign => 1,
                ExpressionType.Lambda => 1,

                // Unknown
                _ => 0
            };

        internal override Expression VisitInvocation(InvocationExpression iv)
        {
            throw NotSupported(iv);
        }

        internal override Expression VisitLambda(LambdaExpression lambda)
        {
            throw NotSupported(lambda);
        }

        internal override Expression VisitMethodCall(MethodCallExpression m)
        {
            if (m.Method.DeclaringType == typeof(DigitalTwinsFunctions))
            {
                string name = m.Method.Name switch
                {
                    nameof(DigitalTwinsFunctions.IsDefined) => QueryConstants.IsDefined,
                    nameof(DigitalTwinsFunctions.IsNumber) => QueryConstants.IsNumber,
                    nameof(DigitalTwinsFunctions.IsPrimitive) => QueryConstants.IsPrimitive,
                    nameof(DigitalTwinsFunctions.IsBool) => QueryConstants.IsBool,
                    nameof(DigitalTwinsFunctions.IsString) => QueryConstants.IsString,
                    nameof(DigitalTwinsFunctions.IsObject) => QueryConstants.IsObject,
                    nameof(DigitalTwinsFunctions.IsNull) => QueryConstants.IsNull,
                    nameof(DigitalTwinsFunctions.StartsWith) => QueryConstants.StartsWith,
                    nameof(DigitalTwinsFunctions.EndsWith) => QueryConstants.EndsWith,
                    nameof(DigitalTwinsFunctions.IsOfModel) => QueryConstants.IsOfModel,
                    _ => throw NotSupported(m)
                };

                if (m.Method.Name == nameof(DigitalTwinsFunctions.StartsWith) || m.Method.Name == nameof(DigitalTwinsFunctions.EndsWith))
                {
                    Debug.Assert(m.Arguments.Count == 2);

                    if (m.Arguments[0] is ConstantExpression c && c.Value == null)
                    {
                        throw new InvalidOperationException($"{nameof(DigitalTwinsFunctions)}.{nameof(DigitalTwinsFunctions.StartsWith)} requires non-null values");
                    }

                    if (m.Arguments[1] is ConstantExpression c2 && c2.Value == null)
                    {
                        throw new InvalidOperationException($"{nameof(DigitalTwinsFunctions)}.{nameof(DigitalTwinsFunctions.StartsWith)} requires non-null values");
                    }
                }

                _filter.Append(name).Append('(');

                if (m.Method.Name == nameof(DigitalTwinsFunctions.IsOfModel))
                {
                    Debug.Assert(m.Arguments.Count >= 1);

                    if (m.Arguments[0] is ConstantExpression expr && expr.Value == null)
                    {
                        throw new InvalidOperationException($"{nameof(DigitalTwinsFunctions)}.{nameof(DigitalTwinsFunctions.IsOfModel)} requires a non-null Model ID.");
                    }

                    Visit(m.Arguments[0]);

                    if (m.Arguments.Count == 2)
                    {
                        ConstantExpression c = m.Arguments[1] as ConstantExpression;
                        Debug.Assert(c != null);
                        Debug.Assert(c.Value is bool);

                        bool isExact = (bool)c.Value;

                        if (isExact)
                        {
                            _filter.Append(", exact");
                        }
                    }
                }

                else if (m.Arguments.Count > 0)
                {
                    bool first = true;

                    foreach (Expression arg in m.Arguments)
                    {
                        if (arg is ConstantExpression expr && expr.Value == null)
                        {
                            throw new InvalidOperationException($"Cannot pass null into a Digital Twins function.");
                        }

                        if (!first)
                        {
                            _filter.Append(", ");
                        }

                        Visit(arg);
                        first = false;
                    }
                }

                _filter.Append(')');

                return m;
            }

            throw NotSupported(m);
        }

        internal override Expression VisitParameter(ParameterExpression p)
        {
            throw NotSupported(p);
        }

        internal override Expression VisitUnary(UnaryExpression u)
        {
            if (u.NodeType == ExpressionType.Convert)
            {
                return Visit(u.Operand);
            }

            throw NotSupported(u);
        }

        internal override Expression Visit(Expression exp)
        {
            return base.Visit(exp);
        }

        internal override ReadOnlyCollection<Expression> VisitExpressionList(ReadOnlyCollection<Expression> original)
        {
            return base.VisitExpressionList(original);
        }
    }
}
