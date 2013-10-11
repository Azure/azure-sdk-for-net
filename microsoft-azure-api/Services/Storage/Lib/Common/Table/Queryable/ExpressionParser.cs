// -----------------------------------------------------------------------------------------
// <copyright file="ExpressionParser.cs" company="Microsoft">
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
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq.Expressions;

    #endregion Namespaces.

    internal class ExpressionParser : DataServiceALinqExpressionVisitor
    {
        #region Properties
        internal TableRequestOptions RequestOptions { get; set; }

        internal OperationContext OperationContext { get; set; }

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
                return this.takeCount;
            }

            set
            {
                if (value.HasValue && value.Value <= 0)
                {
                    throw new ArgumentException(SR.TakeCountNotPositive);
                }

                this.takeCount = value;
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
        #endregion

        internal ExpressionParser()          
        {
            this.SelectColumns = new List<string>();
        }

        internal void Translate(Expression e)
        {
            this.Visit(e);
        }

        #region Not Supported Call Expressions
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
        #endregion

        internal override Expression VisitNavigationPropertySingletonExpression(NavigationPropertySingletonExpression npse)
        {
            throw new NotSupportedException("Navigation not supported.");
        }

        internal override Expression VisitResourceSetExpression(ResourceSetExpression rse)
        {
            /* if ((ResourceExpressionType)rse.NodeType == ResourceExpressionType.ResourceNavigationProperty)
             {
                this.Visit(rse.Source);
                this.uriBuilder.Append(UriHelper.FORWARDSLASH).Append(this.ExpressionToString(rse.MemberExpression));
             }
             else
             {
                this.uriBuilder.Append(UriHelper.FORWARDSLASH).Append((string)((ConstantExpression)rse.MemberExpression).Value);
             }

             TODO optimize for point query 
             if (rse.KeyPredicate != null)
             {
                this.uriBuilder.Append(UriHelper.LEFTPAREN);
                if (rse.KeyPredicate.Count == 1)
                {
                    this.uriBuilder.Append(this.ExpressionToString(rse.KeyPredicate.Values.First()));
                }
                else
                {
                    bool addComma = false;
                    foreach (var kvp in rse.KeyPredicate)
                    {
                        if (addComma)
                        {
                            this.uriBuilder.Append(UriHelper.COMMA);
                        }

                        this.uriBuilder.Append(kvp.Key.Name);
                        this.uriBuilder.Append(UriHelper.EQUALSSIGN);
                        this.uriBuilder.Append(this.ExpressionToString(kvp.Value));
                        addComma = true;
                    }
                }

                this.uriBuilder.Append(UriHelper.RIGHTPAREN);
             }
             else if (rse == this.leafResourceSet)
             {
                this.uriBuilder.Append(UriHelper.LEFTPAREN);
                this.uriBuilder.Append(UriHelper.RIGHTPAREN);
             }

             if (rse.CountOption == CountOption.ValueOnly)
             {
                this.uriBuilder.Append(UriHelper.FORWARDSLASH).Append(UriHelper.DOLLARSIGN).Append(UriHelper.COUNT);
                this.EnsureMinimumVersion(2, 0);
             }
            */
            this.VisitQueryOptions(rse);
            return rse;
        }

        internal void VisitQueryOptions(ResourceExpression re)
        {
            if (re.HasQueryOptions)
            {
                ResourceSetExpression rse = re as ResourceSetExpression;
                if (rse != null)
                {
                    IEnumerator options = rse.SequenceQueryOptions.GetEnumerator();
                    while (options.MoveNext())
                    {
                        Expression e = (Expression)options.Current;
                        ResourceExpressionType et = (ResourceExpressionType)e.NodeType;
                        switch (et)
                        {
                            case ResourceExpressionType.RequestOptions:
                                this.VisitQueryOptionExpression((RequestOptionsQueryOptionExpression)e);
                                break;
                            case ResourceExpressionType.OperationContext:
                                this.VisitQueryOptionExpression((OperationContextQueryOptionExpression)e);
                                break;
                            case ResourceExpressionType.Resolver:
                                this.VisitQueryOptionExpression((EntityResolverQueryOptionExpression)e);
                                break;
                            case ResourceExpressionType.TakeQueryOption:
                                this.VisitQueryOptionExpression((TakeQueryOptionExpression)e);
                                break;
                            case ResourceExpressionType.FilterQueryOption:
                                this.VisitQueryOptionExpression((FilterQueryOptionExpression)e);
                                break;
                            default:
                                Debug.Assert(false, "Unexpected expression type " + (int)et);
                                break;
                        }
                    }
                }           

                if (re.Projection != null && re.Projection.Paths.Count > 0)
                {
                    this.Projection = re.Projection;
                    this.SelectColumns = re.Projection.Paths;
                }
                
                if (re.CustomQueryOptions.Count > 0)
                {
                    this.VisitCustomQueryOptions(re.CustomQueryOptions);
                }
            }
        }

        internal void VisitQueryOptionExpression(RequestOptionsQueryOptionExpression roqoe)
        {
            this.RequestOptions = (TableRequestOptions)roqoe.RequestOptions.Value;
        }

        internal void VisitQueryOptionExpression(OperationContextQueryOptionExpression ocqoe)
        {
            this.OperationContext = (OperationContext)ocqoe.OperationContext.Value;
        }

        internal void VisitQueryOptionExpression(EntityResolverQueryOptionExpression erqoe)
        {
            this.Resolver = erqoe.Resolver;
        }

        internal void VisitQueryOptionExpression(TakeQueryOptionExpression tqoe)
        {
            this.TakeCount = (int)tqoe.TakeAmount.Value;
        }

        internal void VisitQueryOptionExpression(FilterQueryOptionExpression fqoe)
        {
            this.FilterString = ExpressionParser.ExpressionToString(fqoe.Predicate);
        }        
   
        /* 
        internal void VisitCountOptions()
        {
            throw new NotSupportedException("Count not supported.");
        }
        */

        internal void VisitCustomQueryOptions(Dictionary<ConstantExpression, ConstantExpression> options)
        {
            throw new NotSupportedException();
        }

        private static string ExpressionToString(Expression expression)
        {
            return ExpressionWriter.ExpressionToString(expression);
        }
    }
}
