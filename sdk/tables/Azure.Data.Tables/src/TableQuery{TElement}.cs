// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using Azure.Core;
using Azure.Data.Tables.Queryable;

namespace Azure.Data.Tables
{
    /// <summary>
    /// Represents a query against a Microsoft Azure table.
    /// </summary>
    public class TableQuery<TElement> : IQueryable<TElement> where TElement : TableEntity, new()
    {
        private readonly TableQueryProvider queryProvider;
        private int? takeCount = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableQuery{TElement}"/> class.
        /// </summary>
        public TableQuery()
        {
        }

        // used by client to create the first query
        internal TableQuery(TableClient table)
            : base()
        {
            queryProvider = new TableQueryProvider(table);

            // TODO can base expression be non constant?
            Expression =
                new ResourceSetExpression(typeof(IOrderedQueryable<TElement>), null, Expression.Constant("0"), typeof(TElement), null, CountOption.None, null, null);
        }

        // Used by iqueryable on subsequent expression updates to update expression / provider
        internal TableQuery(Expression queryExpression, TableQueryProvider queryProvider)
        {
            this.queryProvider = queryProvider;
            Expression = queryExpression;
        }

        /// <summary>
        /// Gets or sets the number of entities the query returns specified in the table query.
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
                if (value.HasValue)
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

        /// <summary>
        /// Gets the type of the element(s) that are returned when the expression tree is executed.
        /// </summary>
        /// <returns>A <see cref="Type"/> that represents the type of the element(s) that are returned when the expression tree associated with this object is executed.</returns>
        public Type ElementType
        {
            get { return typeof(TElement); }
        }

        /// <summary>
        /// Gets the expression tree.
        /// </summary>
        /// <returns>The <see cref="System.Linq.Expressions.Expression"/> that is associated with this instance of <see cref="System.Linq.IQueryable"/>.</returns>
        public Expression Expression { get; }

        /// <summary>
        /// Gets the query provider that is associated with this data source.
        /// </summary>
        /// <returns>The <see cref="System.Linq.IQueryProvider"/> that is associated with this data source.</returns>
        public IQueryProvider Provider
        {
            get { return queryProvider; }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="TableQuery{TElement}"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{TElement}"/> for the <see cref="TableQuery{TElement}"/>.</returns>
        public virtual IEnumerator<TElement> GetEnumerator()
        {
            if (Expression == null)
            {
                throw new InvalidOperationException();
            }
            else
            {
                Bind();

                var response = queryProvider.Table.Query<TElement>(string.Join(",", SelectColumns), FilterString, TakeCount);
                return response.GetEnumerator();
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Queries entities in the table.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
        public virtual AsyncPageable<TElement> QueryAsync(CancellationToken cancellationToken = default)
        {
            Bind();
            return queryProvider.Table.QueryAsync<TElement>(string.Join(",", SelectColumns), FilterString, TakeCount, cancellationToken);
        }

        /// <summary>
        /// Queries entities in the table.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>

        public virtual Pageable<TElement> Query(CancellationToken cancellationToken = default)
        {
            Bind();
            return queryProvider.Table.Query<TElement>(string.Join(",", SelectColumns), FilterString, TakeCount, cancellationToken);
        }

        internal void Bind()
        {
            // IQueryable impl
            if (Expression != null)
            {
                Dictionary<Expression, Expression> normalizerRewrites = new Dictionary<Expression, Expression>(ReferenceEqualityComparer<Expression>.Instance);

                // Step 1. Evaluate any local evaluatable expressions ( lambdas etc)
                Expression partialEvaluatedExpression = Evaluator.PartialEval(Expression);

                // Step 2. Normalize expression, replace String Comparisons etc.
                Expression normalizedExpression = ExpressionNormalizer.Normalize(partialEvaluatedExpression, normalizerRewrites);

                // Step 3. Bind Expression, Analyze predicates and create query option expressions. End result is a single ResourceSetExpression
                Expression boundExpression = ResourceBinder.Bind(normalizedExpression);

                // Step 4. Parse the Bound expression into sub components, i.e. take count, filter, select columns, request options, opcontext, etc.
                ExpressionParser parser = queryProvider.Table.GetExpressionParser();
                parser.Translate(boundExpression);

                // Step 5. Store query components & params
                TakeCount = parser.TakeCount;
                FilterString = parser.FilterString;
                SelectColumns = parser.SelectColumns;

                /*
                // Step 6. If projection & no resolver then generate a resolver to perform the projection
                if (parser.Resolver == null)
                {
                    if (parser.Projection != null && parser.Projection.Selector != ProjectionQueryOptionExpression.DefaultLambda)
                    {
                        Type intermediateType = parser.Projection.Selector.Parameters[0].Type;

                        // Convert Expression to take type object as input to allow for direct invocation.
                        ParameterExpression paramExpr = Expression.Parameter(typeof(object));

                        Func<object, TElement> projectorFunc = Expression.Lambda<Func<object, TElement>>(
                            Expression.Invoke(parser.Projection.Selector, Expression.Convert(paramExpr, intermediateType)), paramExpr).Compile();

                        // Generate a resolver to do the projection.
                        retVal.Resolver = (pk, rk, ts, props, etag) =>
                        {
                            // Parse to intermediate type
                            ITableEntity intermediateObject = (TableEntity)EntityUtilities.InstantiateEntityFromType(intermediateType);
                            intermediateObject.PartitionKey = pk;
                            intermediateObject.RowKey = rk;
                            intermediateObject.Timestamp = ts;
                            intermediateObject.ReadEntity(props, parser.OperationContext);
                            intermediateObject.ETag = etag;

                            // Invoke lambda expression
                            return projectorFunc(intermediateObject);
                        };
                    }
                    else
                    {
                        // No op - No resolver or projection specified.
                    }
                }
                else
                {
                    retVal.Resolver = (EntityResolver<TElement>)parser.Resolver.Value;
                }
                */
            }

            //retVal.RequestOptions = TableRequestOptions.ApplyDefaults(retVal.RequestOptions, queryProvider.Table.ServiceClient);
            //retVal.OperationContext = retVal.OperationContext ?? new OperationContext();
        }
    }
}
