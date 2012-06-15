//-----------------------------------------------------------------------
// <copyright file="CloudTableQuery.cs" company="Microsoft">
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
// <summary>
//    Contains code for the CloudTableQuery class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Services.Client;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Net;
    using Tasks;

    using TaskSequence = System.Collections.Generic.IEnumerable<Microsoft.WindowsAzure.StorageClient.Tasks.ITask>;

    /// <summary>
    /// Represents a query against the Windows Azure Table service.
    /// </summary>
    /// <typeparam name="TElement">The type of the query result.</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Microsoft.Naming",
        "CA1710:IdentifiersShouldHaveCorrectSuffix",
        Justification = "The intent is to mirror the name of the DataServiceQuery type.")]
    public class CloudTableQuery<TElement> : IQueryable<TElement>
    {
        /// <summary>
        /// Stores the header prefix for continuation information.
        /// </summary>
        internal const string TableServicePrefixForTableContinuation = "x-ms-continuation-";

        /// <summary>
        /// Stores the header suffix for the next partition key.
        /// </summary>
        internal const string TableServiceNextPartitionKey = "NextPartitionKey";

        /// <summary>
        /// Stores the header suffix for the next row key.
        /// </summary>
        internal const string TableServiceNextRowKey = "NextRowKey";

        /// <summary>
        /// Stores the table suffix for the next table name.
        /// </summary>
        internal const string TableServiceNextTableName = "NextTableName";

        /// <summary>
        /// Stores the maximum results the table service can return.
        /// </summary>
        internal const int TableServiceMaxResults = 1000;

        /// <summary>
        /// Stores the pagination options.
        /// </summary>
        private ResultPagination pagination;

        /// <summary>
        /// Stores the wrapped <see cref="DataServiceQuery&lt;TElement&gt;"/>.
        /// </summary>
        private DataServiceQuery<TElement> query;

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudTableQuery{TElement}"/> class with the specified query.
        /// </summary>
        /// <param name="query">The base query.</param>
        public CloudTableQuery(DataServiceQuery<TElement> query)
            : this(query, RetryPolicies.RetryExponential(3, TimeSpan.FromSeconds(2)))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudTableQuery{TElement}"/> class with the specified query
        /// and retry policy.
        /// </summary>
        /// <param name="query">The base query.</param>
        /// <param name="policy">The retry policy for the query.</param>
        public CloudTableQuery(DataServiceQuery<TElement> query, RetryPolicy policy)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            this.query = query;
            this.RetryPolicy = policy;

            int? queryTakeCount = GetQueryTakeCount(this.query);

            this.pagination = new ResultPagination(queryTakeCount.GetValueOrDefault());
        }

        /// <summary>
        /// Gets or sets the retry policy for the query.
        /// </summary>
        /// <value>The retry policy.</value>
        public RetryPolicy RetryPolicy { get; set; }

        /// <summary>
        /// Gets the type of the element(s) that are returned when the expression tree associated with this 
        /// instance of <see cref="T:System.Linq.IQueryable"/> is executed.
        /// </summary>
        /// <value>
        /// A <see cref="T:System.Type"/> that represents the type of the element(s) that are returned when the expression tree associated with this object is executed.
        /// </value>
        public Type ElementType
        {
            get
            {
                return this.query.ElementType;
            }
        }

        /// <summary>
        /// Gets the expression tree that is associated with the instance of <see cref="T:System.Linq.IQueryable"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:System.Linq.Expressions.Expression"/> that is associated with this instance of <see cref="T:System.Linq.IQueryable"/>.
        /// </value>
        public Expression Expression
        {
            get
            {
                return this.query.Expression;
            }
        }

        /// <summary>
        /// Gets the query provider that is associated with this data source.
        /// </summary>
        /// <value>
        /// The <see cref="T:System.Linq.IQueryProvider"/> that is associated with this data source.
        /// </value>
        public IQueryProvider Provider
        {
            get
            {
                return this.query.Provider;
            }
        }

        /// <summary>
        /// Executes the query with the retry policy specified on the <see cref="CloudTableQuery&lt;TElement&gt;"/> object.
        /// </summary>
        /// <returns>The results of the query, retrieved lazily.</returns>
        public IEnumerable<TElement> Execute()
        {
            return CommonUtils.LazyEnumerateSegmented<TElement>((setResult) => this.ExecuteSegmentedImpl(null, setResult), this.RetryPolicy);
        }

        /// <summary>
        /// Executes the query with the retry policy specified on the <see cref="CloudTableQuery&lt;TElement&gt;"/> object.
        /// </summary>
        /// <param name="continuationToken">A continuation token returned by a previous listing operation.</param> 
        /// <returns>The results of the query, retrieved lazily.</returns>
        public IEnumerable<TElement> Execute(ResultContinuation continuationToken)
        {
            return CommonUtils.LazyEnumerateSegmented<TElement>(
                (setResult) => this.ExecuteSegmentedImpl(continuationToken, setResult),
                this.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to execute a query and return the results as a result segment.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginExecuteSegmented(AsyncCallback callback, object state)
        {
            return this.BeginExecuteSegmented(null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to execute a query and return the results as a result segment.
        /// </summary>
        /// <param name="continuationToken">A continuation token returned by a previous listing operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginExecuteSegmented(ResultContinuation continuationToken, AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImplWithRetry<ResultSegment<TElement>>(
                (setResult) => this.ExecuteSegmentedImpl(continuationToken, setResult),
                this.RetryPolicy,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to execute a query and return the results as a result segment.
        /// </summary>
        /// <param name="asyncResult">The reference to the pending asynchronous request to finish.</param>
        /// <returns>A result segment containing objects of type <typeparamref name="TElement"/>.</returns>
        public ResultSegment<TElement> EndExecuteSegmented(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImplWithRetry<ResultSegment<TElement>>(asyncResult);
        }

        /// <summary>
        /// Expands the specified path.
        /// </summary>
        /// <param name="path">The path to expand.</param>
        /// <returns>A new query with the expanded path.</returns>
        public CloudTableQuery<TElement> Expand(string path)
        {
            return new CloudTableQuery<TElement>(this.query.Expand(path), RetryPolicy);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.</returns>
        public IEnumerator<TElement> GetEnumerator()
        {
            return this.Execute().GetEnumerator();
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString()
        {
            return this.query.ToString();
        }

        /// <summary>
        /// Returns an enumerator that can be used to iterate through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> that can be used to iterate through a collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator() as IEnumerator;
        }

        /// <summary>
        /// Executes the segmented impl.
        /// </summary>
        /// <param name="continuationToken">The continuation token.</param>
        /// <param name="setResult">The set result.</param>
        /// <returns>A <see cref="TaskSequence"/> that executes the query and returns the first segment of results.</returns>
        internal TaskSequence ExecuteSegmentedImpl(ResultContinuation continuationToken, Action<ResultSegment<TElement>> setResult)
        {
            var localQuery = this.query;

            localQuery = RewriteQueryForTakeCount(localQuery, this.pagination);

            localQuery = ApplyContinuationToQuery(continuationToken, localQuery);

            var requestTask = localQuery.ExecuteAsync();

            yield return requestTask;

            try
            {
                var responseResult = requestTask.Result;
                var response = responseResult as QueryOperationResponse;

                ResultContinuation newContinuationToken = this.GetTableContinuationFromResponse(response);

                List<TElement> listResult = new List<TElement>(responseResult.ToList());

                ResultSegment.CreateResultSegment<TElement>(
                    setResult,
                    listResult,
                    newContinuationToken,
                    this.pagination,
                    this.RetryPolicy,
                    (scratch, continuationArg, setResultInnerArg) => this.ExecuteSegmentedImpl(continuationArg, setResultInnerArg));
            }
            catch (InvalidOperationException ex)
            {
                var dsce = CommonUtils.FindInnerDataServiceClientException(ex);

                if (dsce == null)
                {
                    throw;
                }

                if ((HttpStatusCode)dsce.StatusCode == HttpStatusCode.NotFound)
                {
                    setResult(new ResultSegment<TElement>(new List<TElement>(), false, null, null));
                }

                throw;
            }
        }

        /// <summary>
        /// Rewrites the query for take count.
        /// </summary>
        /// <param name="localQuery">The local query.</param>
        /// <param name="pagination">The pagination.</param>
        /// <returns>The rewritten query.</returns>
        private static DataServiceQuery<TElement> RewriteQueryForTakeCount(DataServiceQuery<TElement> localQuery, ResultPagination pagination)
        {
            int? nextRequestPageSize = pagination.GetNextRequestPageSize();

            if (pagination.IsPagingEnabled &&
                ((nextRequestPageSize != pagination.EffectivePageSize) ||
                pagination.EffectivePageSize > TableServiceMaxResults))
            {
                var expression = localQuery.Expression as MethodCallExpression;
                var adjustedTakeExpression = Expression.Call(
                    expression.Object,
                    expression.Method,
                    expression.Arguments[0],
                    Expression.Constant(Math.Min(nextRequestPageSize.Value, TableServiceMaxResults)));

                return localQuery.Provider.CreateQuery<TElement>(adjustedTakeExpression) as DataServiceQuery<TElement>;
            }

            return localQuery;
        }

        /// <summary>
        /// Applies the continuation to query.
        /// </summary>
        /// <param name="continuationToken">The continuation token.</param>
        /// <param name="localQuery">The local query.</param>
        /// <returns>The modified query.</returns>
        private static DataServiceQuery<TElement> ApplyContinuationToQuery(ResultContinuation continuationToken, DataServiceQuery<TElement> localQuery)
        {
            if (continuationToken != null)
            {
                if (continuationToken.NextPartitionKey != null)
                {
                    localQuery = localQuery.AddQueryOption(TableServiceNextPartitionKey, continuationToken.NextPartitionKey);
                }

                if (continuationToken.NextRowKey != null)
                {
                    localQuery = localQuery.AddQueryOption(TableServiceNextRowKey, continuationToken.NextRowKey);
                }

                if (continuationToken.NextTableName != null)
                {
                    localQuery = localQuery.AddQueryOption(TableServiceNextTableName, continuationToken.NextTableName);
                }
            }

            return localQuery;
        }

        /// <summary>
        /// Gets the query take count.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>The take count of the query, if any.</returns>
        private static int? GetQueryTakeCount(DataServiceQuery<TElement> query)
        {
            var expression = query.Expression as MethodCallExpression;

            if (expression != null && expression.Method.Name == "Take")
            {
                var argument = expression.Arguments[1] as ConstantExpression;

                if (argument != null)
                {
                    return (int)argument.Value;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the table continuation from response.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>The continuation.</returns>
        private ResultContinuation GetTableContinuationFromResponse(QueryOperationResponse response)
        {
            string nextPartitionKey;
            string nextRowKey;
            string nextTableName;

            response.Headers.TryGetValue(TableServicePrefixForTableContinuation + TableServiceNextPartitionKey, out nextPartitionKey);
            response.Headers.TryGetValue(TableServicePrefixForTableContinuation + TableServiceNextRowKey, out nextRowKey);
            response.Headers.TryGetValue(TableServicePrefixForTableContinuation + TableServiceNextTableName, out nextTableName);

            ResultContinuation newContinuationToken = new ResultContinuation()
            {
                NextPartitionKey = nextPartitionKey,
                NextRowKey = nextRowKey,
                NextTableName = nextTableName,
                Type = ResultContinuation.ContinuationType.Table
            };

            return newContinuationToken;
        }
    }
}
