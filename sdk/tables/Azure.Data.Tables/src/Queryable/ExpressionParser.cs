// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;
using Azure.Core;

namespace Azure.Data.Tables.Queryable
{
    internal class ExpressionParser : DataServiceLinqExpressionVisitor
    {
        internal ConstantExpression Resolver { get; set; }

        internal ProjectionQueryOptionExpression Projection { get; set; }

        private int? takeCount = null;

        /// <summary>
        /// Gets or sets the number of entities the table query will return.
        /// </summary>
        /// <value>The maximum number of entities for the table query to return.</value>
        public int? TakeCount
        {
            get
            {
                return takeCount;
            }

            set
            {
                if (value.HasValue && value.Value <= 0)
                {
                    Argument.AssertInRange(value.Value, 1, 1000, nameof(TakeCount));
                }

                takeCount = value;
            }
        }

        /// <summary>
        /// Gets or sets the filter expression to use in the table query.
        /// </summary>
        /// <value>A string containing the filter expression to use in the query.</value>
        public string FilterString { get; set; }

        /// <summary>
        /// Gets or sets the property names of the table entity properties to return when the table query is executed.
        /// </summary>
        /// <value>A list of strings containing the property names of the table entity properties to return when the query is executed.</value>
        public IList<string> SelectColumns { get; set; }

        internal ExpressionParser()
        {
            SelectColumns = new List<string>();
        }

        internal void Translate(Expression e)
        {
            Visit(e);
        }

        internal override Expression VisitMethodCall(MethodCallExpression m)
        {
            throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, "The method '{0}' is not supported.", m.Method.Name)); // Error.MethodNotSupported(m);
        }

        internal override Expression VisitUnary(UnaryExpression u)
        {
            throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqUnaryNotSupported, u.NodeType.ToString()));
        }

        internal override Expression VisitBinary(BinaryExpression b)
        {
            throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqBinaryNotSupported, b.NodeType.ToString()));
        }

        internal override Expression VisitConstant(ConstantExpression c)
        {
            throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqConstantNotSupported, c.Value));
        }

        internal override Expression VisitTypeIs(TypeBinaryExpression b)
        {
            throw new NotSupportedException(SR.ALinqTypeBinaryNotSupported);
        }

        internal override Expression VisitConditional(ConditionalExpression c)
        {
            throw new NotSupportedException(SR.ALinqConditionalNotSupported);
        }

        internal override Expression VisitParameter(ParameterExpression p)
        {
            throw new NotSupportedException(SR.ALinqParameterNotSupported);
        }

        internal override Expression VisitMemberAccess(MemberExpression m)
        {
            throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.ALinqMemberAccessNotSupported, m.Member.Name));
        }

        internal override Expression VisitLambda(LambdaExpression lambda)
        {
            throw new NotSupportedException(SR.ALinqLambdaNotSupported);
        }

        internal override NewExpression VisitNew(NewExpression nex)
        {
            throw new NotSupportedException(SR.ALinqNewNotSupported);
        }

        internal override Expression VisitMemberInit(MemberInitExpression init)
        {
            throw new NotSupportedException(SR.ALinqMemberInitNotSupported);
        }

        internal override Expression VisitListInit(ListInitExpression init)
        {
            throw new NotSupportedException(SR.ALinqListInitNotSupported);
        }

        internal override Expression VisitNewArray(NewArrayExpression na)
        {
            throw new NotSupportedException(SR.ALinqNewArrayNotSupported);
        }

        internal override Expression VisitInvocation(InvocationExpression iv)
        {
            throw new NotSupportedException(SR.ALinqInvocationNotSupported);
        }

        internal override Expression VisitNavigationPropertySingletonExpression(NavigationPropertySingletonExpression npse)
        {
            throw new NotSupportedException("Navigation not supported.");
        }

        internal override Expression VisitResourceSetExpression(ResourceSetExpression rse)
        {
            VisitQueryOptions(rse);
            return rse;
        }

        internal void VisitQueryOptions(ResourceExpression re)
        {
            if (re.HasQueryOptions)
            {
                if (re is ResourceSetExpression rse)
                {
                    IEnumerator options = rse.SequenceQueryOptions.GetEnumerator();
                    while (options.MoveNext())
                    {
                        Expression e = (Expression)options.Current;
                        ResourceExpressionType et = (ResourceExpressionType)e.NodeType;
                        switch (et)
                        {
                            case ResourceExpressionType.TakeQueryOption:
                                VisitQueryOptionExpression((TakeQueryOptionExpression)e);
                                break;
                            case ResourceExpressionType.FilterQueryOption:
                                VisitQueryOptionExpression((FilterQueryOptionExpression)e);
                                break;
                            default:
                                //TODO: Determine if support for ResourceExpressionType.Resolver, ResourceExpressionType.OperationContext, or ResourceExpressionType.RequestOptions is needed
                                Debug.Assert(false, "Unexpected expression type " + (int)et);
                                break;
                        }
                    }
                }

                if (re.Projection != null && re.Projection.Paths.Count > 0)
                {
                    Projection = re.Projection;
                    SelectColumns = re.Projection.Paths;
                }

                if (re.CustomQueryOptions.Count > 0)
                {
                    VisitCustomQueryOptions(re.CustomQueryOptions);
                }
            }
        }

        internal virtual void VisitQueryOptionExpression(TakeQueryOptionExpression tqoe)
        {
            TakeCount = (int)tqoe.TakeAmount.Value;
        }

        internal virtual void VisitQueryOptionExpression(FilterQueryOptionExpression fqoe)
        {
            FilterString = ExpressionParser.ExpressionToString(fqoe.Predicate);
        }

        internal static void VisitCustomQueryOptions(Dictionary<ConstantExpression, ConstantExpression> options)
        {
            Argument.AssertNotNull(options, nameof(options));

            throw new NotSupportedException();
        }

        private static string ExpressionToString(Expression expression)
        {
            return ExpressionWriter.ExpressionToString(expression);
        }
    }
}
