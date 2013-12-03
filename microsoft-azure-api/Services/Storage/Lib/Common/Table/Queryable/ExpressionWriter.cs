// -----------------------------------------------------------------------------------------
// <copyright file="ExpressionWriter.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Table.Queryable
{
    #region Namespaces.

    using Microsoft.WindowsAzure.Storage.Core;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text;

    #endregion Namespaces.

    internal class ExpressionWriter : DataServiceALinqExpressionVisitor
    {
        #region Private fields.

        private readonly StringBuilder builder;

        private readonly Stack<Expression> expressionStack;

        private bool cantTranslateExpression;

        private Expression parent;

        #endregion Private fields.

        private ExpressionWriter()
        {
            this.builder = new StringBuilder();
            this.expressionStack = new Stack<Expression>();
            this.expressionStack.Push(null);
        }

        internal static string ExpressionToString(Expression e)
        {
            ExpressionWriter ew = new ExpressionWriter();

            string serialized = null;
            serialized = ew.Translate(e);

            if (ew.cantTranslateExpression)
            {
                throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqCantTranslateExpression, e.ToString()));
            }

            return serialized;
        }

        internal override Expression Visit(Expression exp)
        {
            this.parent = this.expressionStack.Peek();
            this.expressionStack.Push(exp);
            Expression result = base.Visit(exp);
            this.expressionStack.Pop();
            return result;
        }

        internal override Expression VisitConditional(ConditionalExpression c)
        {
            this.cantTranslateExpression = true;
            return c;
        }

        internal override Expression VisitLambda(LambdaExpression lambda)
        {
            this.cantTranslateExpression = true;
            return lambda;
        }

        internal override NewExpression VisitNew(NewExpression nex)
        {
            this.cantTranslateExpression = true;
            return nex;
        }

        internal override Expression VisitMemberInit(MemberInitExpression init)
        {
            this.cantTranslateExpression = true;
            return init;
        }

        internal override Expression VisitListInit(ListInitExpression init)
        {
            this.cantTranslateExpression = true;
            return init;
        }

        internal override Expression VisitNewArray(NewArrayExpression na)
        {
            this.cantTranslateExpression = true;
            return na;
        }

        internal override Expression VisitInvocation(InvocationExpression iv)
        {
            this.cantTranslateExpression = true;
            return iv;
        }

        internal override Expression VisitInputReferenceExpression(InputReferenceExpression ire)
        {
            Debug.Assert(ire != null, "ire != null");
            if (this.parent == null || this.parent.NodeType != ExpressionType.MemberAccess)
            {
                string expressionText = (this.parent != null) ? this.parent.ToString() : ire.ToString();
                throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqCantTranslateExpression, expressionText));
            }

            return ire;
        }

        internal override Expression VisitMethodCall(MethodCallExpression m)
        {
            string methodName;
            if (TypeSystem.TryGetQueryOptionMethod(m.Method, out methodName))
            {
                this.builder.Append(methodName);
                this.builder.Append(UriHelper.LEFTPAREN);

                if (methodName == "substringof")
                {
                    Debug.Assert(m.Method.Name == "Contains", "m.Method.Name == 'Contains'");
                    Debug.Assert(m.Object != null, "m.Object != null");
                    Debug.Assert(m.Arguments.Count == 1, "m.Arguments.Count == 1");
                    this.Visit(m.Arguments[0]);
                    this.builder.Append(UriHelper.COMMA);
                    this.Visit(m.Object);
                }
                else
                {
                    if (m.Object != null)
                    {
                        this.Visit(m.Object);
                    }

                    if (m.Arguments.Count > 0)
                    {
                        if (m.Object != null)
                        {
                            this.builder.Append(UriHelper.COMMA);
                        }

                        for (int ii = 0; ii < m.Arguments.Count; ii++)
                        {
                            this.Visit(m.Arguments[ii]);
                            if (ii < m.Arguments.Count - 1)
                            {
                                this.builder.Append(UriHelper.COMMA);
                            }
                        }
                    }
                }

                this.builder.Append(UriHelper.RIGHTPAREN);
            }
            else
            {
                this.cantTranslateExpression = true;
            }

            return m;
        }

        internal override Expression VisitMemberAccess(MemberExpression m)
        {
            if (m.Member is FieldInfo)
            {
                throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqCantReferToPublicField, m.Member.Name));
            }

            if (m.Member.DeclaringType == typeof(EntityProperty))
            {
                MethodCallExpression mce = m.Expression as MethodCallExpression;
                if (mce != null && mce.Arguments.Count == 1 && mce.Method == ReflectionUtil.DictionaryGetItemMethodInfo)
                {
                    MemberExpression me = mce.Object as MemberExpression;
                    if (me != null && me.Member.DeclaringType == typeof(DynamicTableEntity) && me.Member.Name == "Properties")
                    {
                        // Append Property name arg to string
                        ConstantExpression ce = mce.Arguments[0] as ConstantExpression;
                        if (ce == null || !(ce.Value is string))
                        {
                            throw new NotSupportedException(SR.TableQueryDynamicPropertyAccess);
                        }

                        this.builder.Append((string)ce.Value);
                        return ce;
                    }
                }

                throw new NotSupportedException(SR.TableQueryEntityPropertyInQueryNotSupported);
            }

            Expression e = this.Visit(m.Expression);

            if (m.Member.Name == "Value" && m.Member.DeclaringType.IsGenericType
                && m.Member.DeclaringType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return m;
            }

            if (!IsInputReference(e) && e.NodeType != ExpressionType.Convert && e.NodeType != ExpressionType.ConvertChecked)
            {
                this.builder.Append(UriHelper.FORWARDSLASH);
            }

            this.builder.Append(m.Member.Name);

            return m;
        }

        internal override Expression VisitConstant(ConstantExpression c)
        {
            string result = null;
            if (c.Value == null)
            {
                this.builder.Append(UriHelper.NULL);
                return c;
            }
            else if (!ClientConvert.TryKeyPrimitiveToString(c.Value, out result))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, SR.ALinqCouldNotConvert, c.Value));
            }

            Debug.Assert(result != null, "result != null");

            // A Difference from WCF Data Services is that we will escape later when we execute the fully parsed query. 
            this.builder.Append(result);
            return c;
        }

        internal override Expression VisitUnary(UnaryExpression u)
        {
            switch (u.NodeType)
            {
                case ExpressionType.Not:
                    this.builder.Append(UriHelper.NOT);
                    this.builder.Append(UriHelper.SPACE);
                    this.VisitOperand(u.Operand);
                    break;
                case ExpressionType.Negate:
                case ExpressionType.NegateChecked:
                    this.builder.Append(UriHelper.SPACE);
                    this.builder.Append(UriHelper.NEGATE);
                    this.VisitOperand(u.Operand);
                    break;
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                case ExpressionType.UnaryPlus:
                    break;
                default:
                    this.cantTranslateExpression = true;
                    break;
            }

            return u;
        }

        internal override Expression VisitBinary(BinaryExpression b)
        {
            this.VisitOperand(b.Left);
            this.builder.Append(UriHelper.SPACE);
            switch (b.NodeType)
            {
                case ExpressionType.AndAlso:
                case ExpressionType.And:
                    this.builder.Append(UriHelper.AND);
                    break;
                case ExpressionType.OrElse:
                case ExpressionType.Or:
                    this.builder.Append(UriHelper.OR);
                    break;
                case ExpressionType.Equal:
                    this.builder.Append(UriHelper.EQ);
                    break;
                case ExpressionType.NotEqual:
                    this.builder.Append(UriHelper.NE);
                    break;
                case ExpressionType.LessThan:
                    this.builder.Append(UriHelper.LT);
                    break;
                case ExpressionType.LessThanOrEqual:
                    this.builder.Append(UriHelper.LE);
                    break;
                case ExpressionType.GreaterThan:
                    this.builder.Append(UriHelper.GT);
                    break;
                case ExpressionType.GreaterThanOrEqual:
                    this.builder.Append(UriHelper.GE);
                    break;
                case ExpressionType.Add:
                case ExpressionType.AddChecked:
                    this.builder.Append(UriHelper.ADD);
                    break;
                case ExpressionType.Subtract:
                case ExpressionType.SubtractChecked:
                    this.builder.Append(UriHelper.SUB);
                    break;
                case ExpressionType.Multiply:
                case ExpressionType.MultiplyChecked:
                    this.builder.Append(UriHelper.MUL);
                    break;
                case ExpressionType.Divide:
                    this.builder.Append(UriHelper.DIV);
                    break;
                case ExpressionType.Modulo:
                    this.builder.Append(UriHelper.MOD);
                    break;
                case ExpressionType.ArrayIndex:
                case ExpressionType.Power:
                case ExpressionType.Coalesce:
                case ExpressionType.ExclusiveOr:
                case ExpressionType.LeftShift:
                case ExpressionType.RightShift:
                default:
                    this.cantTranslateExpression = true;
                    break;
            }

            this.builder.Append(UriHelper.SPACE);
            this.VisitOperand(b.Right);
            return b;
        }

        internal override Expression VisitTypeIs(TypeBinaryExpression b)
        {
            this.builder.Append(UriHelper.ISOF);
            this.builder.Append(UriHelper.LEFTPAREN);

            if (!IsInputReference(b.Expression))
            {
                this.Visit(b.Expression);
                this.builder.Append(UriHelper.COMMA);
                this.builder.Append(UriHelper.SPACE);
            }

            this.builder.Append(UriHelper.QUOTE);
            this.builder.Append(this.TypeNameForUri(b.TypeOperand));
            this.builder.Append(UriHelper.QUOTE);
            this.builder.Append(UriHelper.RIGHTPAREN);

            return b;
        }

        internal override Expression VisitParameter(ParameterExpression p)
        {
            return p;
        }

        private static bool IsInputReference(Expression exp)
        {
            return exp is InputReferenceExpression || exp is ParameterExpression;
        }

        private string TypeNameForUri(Type type)
        {
            Debug.Assert(type != null, "type != null");
            type = Nullable.GetUnderlyingType(type) ?? type;

            if (ClientConvert.IsKnownType(type))
            {
                if (ClientConvert.IsSupportedPrimitiveTypeForUri(type))
                {
                    return ClientConvert.ToTypeName(type);
                }

                throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqCantCastToUnsupportedPrimitive, type.Name));
            }
            else
            {
                return null;

                // return this.context.ResolveNameFromType(type) ?? type.FullName;
            }
        }

        private void VisitOperand(Expression e)
        {
            if (e is BinaryExpression || e is UnaryExpression)
            {
                this.builder.Append(UriHelper.LEFTPAREN);
                this.Visit(e);
                this.builder.Append(UriHelper.RIGHTPAREN);
            }
            else
            {
                this.Visit(e);
            }
        }

        private string Translate(Expression e)
        {
            this.Visit(e);
            return this.builder.ToString();
        }
    }
}
