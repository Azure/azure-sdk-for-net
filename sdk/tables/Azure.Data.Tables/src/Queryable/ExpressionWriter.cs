// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Azure.Data.Tables.Queryable
{
    internal class ExpressionWriter : LinqExpressionVisitor
    {
        internal readonly StringBuilder builder;

        private readonly Stack<Expression> expressionStack;

        private bool cantTranslateExpression;

        private Expression parent;

        protected ExpressionWriter()
        {
            builder = new StringBuilder();
            expressionStack = new Stack<Expression>();
            expressionStack.Push(null);
        }

        internal static string ExpressionToString(Expression e)
        {
            ExpressionWriter ew = new ExpressionWriter();
            return ew.ConvertExpressionToString(e);
        }

        internal string ConvertExpressionToString(Expression e)
        {
            string serialized = Translate(e);

            if (cantTranslateExpression)
            {
                throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqCantTranslateExpression, e.ToString()));
            }

            return serialized;
        }

        internal override Expression Visit(Expression exp)
        {
            parent = expressionStack.Peek();
            expressionStack.Push(exp);
            Expression result = base.Visit(exp);
            expressionStack.Pop();
            return result;
        }


        internal override Expression VisitMemberAccess(MemberExpression m)
        {
            if (m.Member is FieldInfo)
            {
                throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqCantReferToPublicField, m.Member.Name));
            }

            Expression e = Visit(m.Expression);
            if (m.Member.Name == "Value" && m.Member.DeclaringType.IsGenericType
                && m.Member.DeclaringType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return m;
            }

            if (!IsInputReference(e) && e.NodeType != ExpressionType.Convert && e.NodeType != ExpressionType.ConvertChecked)
            {
                builder.Append(UriHelper.FORWARDSLASH);
            }

            builder.Append(TranslateMemberName(m.Member.Name));

            return m;
        }

        internal override Expression VisitConstant(ConstantExpression c)
        {
            string result;
            if (c.Value == null)
            {
                builder.Append(UriHelper.NULL);
                return c;
            }
            else if (!ClientConvert.TryKeyPrimitiveToString(c.Value, out result))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, SR.ALinqCouldNotConvert, c.Value));
            }

            Debug.Assert(result != null, "result != null");

            // A Difference from WCF Data Services is that we will escape later when we execute the fully parsed query.
            builder.Append(result);
            return c;
        }

        internal override Expression VisitUnary(UnaryExpression u)
        {
            switch (u.NodeType)
            {
                case ExpressionType.Not:
                    builder.Append(UriHelper.NOT);
                    builder.Append(UriHelper.SPACE);
                    VisitOperand(u.Operand);
                    break;
                case ExpressionType.Negate:
                case ExpressionType.NegateChecked:
                    builder.Append(UriHelper.SPACE);
                    builder.Append(TranslateOperator(u.NodeType));
                    VisitOperand(u.Operand);
                    break;
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                case ExpressionType.UnaryPlus:
                    break;
                default:
                    cantTranslateExpression = true;
                    break;
            }

            return u;
        }

        internal override Expression VisitBinary(BinaryExpression b)
        {
            VisitOperand(b.Left);
            builder.Append(UriHelper.SPACE);
            string operatorString = TranslateOperator(b.NodeType);
            if (string.IsNullOrEmpty(operatorString))
            {
                cantTranslateExpression = true;
            }
            else
            {
                builder.Append(operatorString);
            }

            builder.Append(UriHelper.SPACE);
            VisitOperand(b.Right);
            return b;
        }

        internal override Expression VisitParameter(ParameterExpression p)
        {
            return p;
        }

        private static bool IsInputReference(Expression exp)
        {
            return exp is ParameterExpression;
        }

        private void VisitOperand(Expression e)
        {
            if (e is BinaryExpression || e is UnaryExpression)
            {
                builder.Append(UriHelper.LEFTPAREN);
                Visit(e);
                builder.Append(UriHelper.RIGHTPAREN);
            }
            else
            {
                Visit(e);
            }
        }

        private string Translate(Expression e)
        {
            Visit(e);
            return builder.ToString();
        }

        protected virtual string TranslateMemberName(string memberName)
        {
            return memberName;
        }

        protected virtual string TranslateOperator(ExpressionType type)
        {
            switch (type)
            {
                case ExpressionType.AndAlso:
                case ExpressionType.And:
                    return UriHelper.AND;
                case ExpressionType.OrElse:
                case ExpressionType.Or:
                    return UriHelper.OR;
                case ExpressionType.Equal:
                    return UriHelper.EQ;
                case ExpressionType.NotEqual:
                    return UriHelper.NE;
                case ExpressionType.LessThan:
                    return UriHelper.LT;
                case ExpressionType.LessThanOrEqual:
                    return UriHelper.LE;
                case ExpressionType.GreaterThan:
                    return UriHelper.GT;
                case ExpressionType.GreaterThanOrEqual:
                    return UriHelper.GE;
                case ExpressionType.Add:
                case ExpressionType.AddChecked:
                    return UriHelper.ADD;
                case ExpressionType.Subtract:
                case ExpressionType.SubtractChecked:
                    return UriHelper.SUB;
                case ExpressionType.Multiply:
                case ExpressionType.MultiplyChecked:
                    return UriHelper.MUL;
                case ExpressionType.Divide:
                    return UriHelper.DIV;
                case ExpressionType.Modulo:
                    return UriHelper.MOD;
                case ExpressionType.Negate:
                case ExpressionType.NegateChecked:
                    return UriHelper.NEGATE;
                case ExpressionType.ArrayIndex:
                case ExpressionType.Power:
                case ExpressionType.Coalesce:
                case ExpressionType.ExclusiveOr:
                case ExpressionType.LeftShift:
                case ExpressionType.RightShift:
                default:
                    return null;
            }
        }
    }
}
