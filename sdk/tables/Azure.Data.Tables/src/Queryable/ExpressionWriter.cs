// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Azure.Data.Tables.Models;
using System.Runtime.Serialization;

namespace Azure.Data.Tables.Queryable
{
    internal class ExpressionWriter : ExpressionVisitor
    {
        internal readonly StringBuilder _builder;
        private readonly Stack<Expression> _expressionStack;
        private bool _cantTranslateExpression;

        protected ExpressionWriter()
        {
            _builder = new StringBuilder();
            _expressionStack = new Stack<Expression>();
            _expressionStack.Push(null);
        }

        internal static string ExpressionToString(Expression e)
        {
            ExpressionWriter ew = new ExpressionWriter();
            return ew.ConvertExpressionToString(e);
        }

        internal string ConvertExpressionToString(Expression e)
        {
            string serialized = Translate(e);

            if (_cantTranslateExpression)
            {
                throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqCantTranslateExpression, e.ToString()));
            }

            return serialized;
        }

        public override Expression Visit(Expression exp)
        {
            _expressionStack.Push(exp);
            Expression result = base.Visit(exp);
            _expressionStack.Pop();
            return result;
        }

        protected override Expression VisitMethodCall(MethodCallExpression m)
        {
            if (ReflectionUtil.s_dictionaryMethodInfosHash.Contains(m.Method) && m.Arguments.Count == 1 && m.Arguments[0] is ConstantExpression ce)
            {
                _builder.Append(ce.Value as string);
            }
            else
            {
                return base.VisitMethodCall(m);
            }

            return m;
        }

        protected override Expression VisitMember(MemberExpression m)
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
                _builder.Append(UriHelper.FORWARDSLASH);
            }

            if (m.Expression.Type == typeof(TableItem) && m.Member.Name == XmlConstants.TableItemClientPropertyName)
            {
                _builder.Append(XmlConstants.TableItemServicePropertyName);
            }
            else
            {
                _builder.Append(TranslateMemberName(m.Member));
            }

            return m;
        }

        protected override Expression VisitConstant(ConstantExpression c)
        {
            string result;
            if (c.Value == null)
            {
                _builder.Append(UriHelper.NULL);
                return c;
            }
            else if (!ClientConvert.TryKeyPrimitiveToString(c.Value, out result))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, SR.ALinqCouldNotConvert, c.Value));
            }

            Debug.Assert(result != null, "result != null");

            // A Difference from WCF Data Services is that we will escape later when we execute the fully parsed query.
            _builder.Append(result);
            return c;
        }

        protected override Expression VisitUnary(UnaryExpression u)
        {
            switch (u.NodeType)
            {
                case ExpressionType.Not:
                    _builder.Append(UriHelper.NOT);
                    _builder.Append(UriHelper.SPACE);
                    VisitOperand(u.Operand);
                    break;
                case ExpressionType.Negate:
                case ExpressionType.NegateChecked:
                    _builder.Append(UriHelper.SPACE);
                    _builder.Append(TranslateOperator(u.NodeType));
                    VisitOperand(u.Operand);
                    break;
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                case ExpressionType.UnaryPlus:
                    break;
                default:
                    _cantTranslateExpression = true;
                    break;
            }

            return u;
        }

        protected override Expression VisitBinary(BinaryExpression b)
        {
            VisitOperand(b.Left);
            _builder.Append(UriHelper.SPACE);
            string operatorString = TranslateOperator(b.NodeType);
            if (string.IsNullOrEmpty(operatorString))
            {
                _cantTranslateExpression = true;
            }
            else
            {
                _builder.Append(operatorString);
            }

            _builder.Append(UriHelper.SPACE);
            VisitOperand(b.Right);
            return b;
        }

        protected override Expression VisitParameter(ParameterExpression p)
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
                if (e is UnaryExpression unary && unary.NodeType == ExpressionType.TypeAs)
                {
                    Visit(unary.Operand);
                }
                else
                {
                    _builder.Append(UriHelper.LEFTPAREN);
                    Visit(e);
                    _builder.Append(UriHelper.RIGHTPAREN);
                }
            }
            else
            {
                Visit(e);
            }
        }

        private string Translate(Expression e)
        {
            Visit(e);
            return _builder.ToString();
        }

        protected virtual string TranslateMemberName(MemberInfo memberInfo)
        {
            if (memberInfo.GetCustomAttribute<DataMemberAttribute>() is DataMemberAttribute dataMemberAttribute)
            {
                return dataMemberAttribute.Name;
            }
            else
            {
                return memberInfo.Name;
            }
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
