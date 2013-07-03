//-----------------------------------------------------------------------
// <copyright file="TableServiceQuery.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Table.DataServices
{
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Table.Protocol;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Services.Client;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// A class for constructing a query against the Table service.
    /// </summary>
    /// <typeparam name="TElement">The type of the element.</typeparam>    
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "Reviewed")]
    public class TableServiceQuery<TElement> : IQueryable<TElement>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TableServiceQuery{TElement}"/> class.
        /// </summary>
        /// <param name="query">An object that implements <see cref="IQueryable"/>.</param>
        /// <param name="context">A <see cref="TableServiceContext"/> object.</param>
        public TableServiceQuery(IQueryable<TElement> query, TableServiceContext context)
        {
            this.Query = query as DataServiceQuery<TElement>;
            this.Context = context;
            this.IgnoreResourceNotFoundException = false;
        }

        /// <summary>
        /// Gets the table service context.
        /// </summary>
        /// <value>
        /// An object of type <see cref="TableServiceContext"/>.
        /// </value>
        public TableServiceContext Context { get; private set; }

        /// <summary>
        /// Stores the wrapped <see cref="DataServiceQuery&lt;TElement&gt;"/>.
        /// </summary>
        internal DataServiceQuery<TElement> Query { get; set; }

        internal bool IgnoreResourceNotFoundException { get; set; }

        /// <summary>
        /// Gets the type of the element(s) that are returned when the expression tree associated with this 
        /// instance of <see cref="T:System.Linq.IQueryable"/> is executed.
        /// </summary>
        /// <value>
        /// A <see cref="T:System.Type"/> that represents the type of the element(s) that are returned when the expression tree associated with this object is executed.
        /// </value>
        public Type ElementType
        {
            get { return this.Query.ElementType; }
        }

        /// <summary>
        /// Gets the expression tree that is associated with the instance of <see cref="T:System.Linq.IQueryable"/>.
        /// </summary>
        /// <value>
        /// The <see cref="T:System.Linq.Expressions.Expression"/> that is associated with this instance of <see cref="T:System.Linq.IQueryable"/>.
        /// </value>
        public Expression Expression
        {
            get { return this.Query.Expression; }
        }

        /// <summary>
        /// Gets the query provider that is associated with this data source.
        /// </summary>
        /// <value>
        /// The <see cref="T:System.Linq.IQueryProvider"/> that is associated with this data source.
        /// </value>
        public IQueryProvider Provider
        {
            get { return this.Query.Provider; }
        }

        /// <summary>
        /// Expands the specified path.
        /// </summary>
        /// <param name="path">The path to expand.</param>
        /// <returns>A new query with the expanded path.</returns>
        public TableServiceQuery<TElement> Expand(string path)
        {
            return new TableServiceQuery<TElement>(this.Query.Expand(path), this.Context);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<TElement> GetEnumerator()
        {
            return this.Execute(null /* RequestOptions */, null /* OperationContext */).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator() as IEnumerator;
        }

        /// <summary>
        /// Executes the request with any specified options.
        /// </summary>
        /// <param name="requestOptions">An object of type <see cref="TableRequestOptions"/>.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>An enumerable collection, specialized for type <c>TElement</c>, of the results of executing the query.</returns>
        [DoesServiceRequest]
        public IEnumerable<TElement> Execute(TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this.Context.ServiceClient);
            operationContext = operationContext ?? new OperationContext();
            long takeCount = TableUtilities.GetQueryTakeCount(this.Query, long.MaxValue);
            return CommonUtility.LazyEnumerable(
                (continuationToken) => this.ExecuteSegmentedCore((TableContinuationToken)continuationToken, requestOptions, operationContext),
                takeCount);
        }

        /// <summary>
        /// Executes a segmented query against the Table service.
        /// </summary>
        /// <param name="continuationToken">The continuation token.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A result segment containing objects of type <typeparamref name="TElement"/>.</returns>
        [DoesServiceRequest]
        public TableQuerySegment<TElement> ExecuteSegmented(TableContinuationToken continuationToken, TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this.Context.ServiceClient);
            operationContext = operationContext ?? new OperationContext();
            return new TableQuerySegment<TElement>(this.ExecuteSegmentedCore(continuationToken, requestOptions, operationContext));
        }

        /// <summary>
        /// Begins an asynchronous operation to execute a query and return the results as a result segment.
        /// </summary>
        /// <param name="currentToken">A continuation token returned by a previous listing operation, can be null.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginExecuteSegmented(TableContinuationToken currentToken, AsyncCallback callback, object state)
        {
            return this.BeginExecuteSegmented(currentToken, null /* RequestOptions */, null /* OperationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to execute a query and return the results as a result segment.
        /// </summary>
        /// <param name="currentToken">A continuation token returned by a previous listing operation, can be null.</param>
        /// <param name="requestOptions">An <see cref="TableRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginExecuteSegmented(TableContinuationToken currentToken, TableRequestOptions requestOptions, OperationContext operationContext, AsyncCallback callback, object state)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this.Context.ServiceClient);
            operationContext = operationContext ?? new OperationContext();
            TableCommand<ResultSegment<TElement>, IEnumerable<TElement>> cmd = this.GenerateExecuteCommand(
                currentToken, requestOptions);
            return TableExecutor.BeginExecuteAsync(cmd, requestOptions.RetryPolicy, operationContext, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to execute a query and return the results as a result segment.
        /// </summary>
        /// <param name="asyncResult">The reference to the pending asynchronous request to finish.</param>
        /// <returns>A result segment containing objects of type <typeparamref name="TElement"/>.</returns>
        public TableQuerySegment<TElement> EndExecuteSegmented(IAsyncResult asyncResult)
        {
            return new TableQuerySegment<TElement>(TableExecutor.EndExecuteAsync<ResultSegment<TElement>, IEnumerable<TElement>>(asyncResult));
        }
        
#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to execute a query and return the results as a result segment.
        /// </summary>
        /// <param name="currentToken">A continuation token returned by a previous listing operation, can be null.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<TableQuerySegment<TElement>> ExecuteSegmentedAsync(TableContinuationToken currentToken)
        {
            return this.ExecuteSegmentedAsync(currentToken, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to execute a query and return the results as a result segment.
        /// </summary>
        /// <param name="currentToken">A continuation token returned by a previous listing operation, can be null.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<TableQuerySegment<TElement>> ExecuteSegmentedAsync(TableContinuationToken currentToken, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginExecuteSegmented, this.EndExecuteSegmented, currentToken, cancellationToken);
        }
        
        /// <summary>
        /// Returns a task that performs an asynchronous operation to execute a query and return the results as a result segment.
        /// </summary>
        /// <param name="currentToken">A continuation token returned by a previous listing operation, can be null.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<TableQuerySegment<TElement>> ExecuteSegmentedAsync(TableContinuationToken currentToken, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            return this.ExecuteSegmentedAsync(currentToken, requestOptions, operationContext, CancellationToken.None);
        }
        
        /// <summary>
        /// Returns a task that performs an asynchronous operation to execute a query and return the results as a result segment.
        /// </summary>
        /// <param name="currentToken">A continuation token returned by a previous listing operation, can be null.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<TableQuerySegment<TElement>> ExecuteSegmentedAsync(TableContinuationToken currentToken, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginExecuteSegmented, this.EndExecuteSegmented, currentToken, requestOptions, operationContext, cancellationToken);
        }
#endif

        internal ResultSegment<TElement> ExecuteSegmentedCore(TableContinuationToken continuationToken, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            TableCommand<ResultSegment<TElement>, IEnumerable<TElement>> cmd = this.GenerateExecuteCommand(continuationToken, requestOptions);

            return TableExecutor.ExecuteSync(cmd, requestOptions.RetryPolicy, operationContext);
        }

        private TableCommand<ResultSegment<TElement>, IEnumerable<TElement>> GenerateExecuteCommand(TableContinuationToken continuationToken, TableRequestOptions requestOptions)
        {
            DataServiceQuery<TElement> localQuery = this.Query;

            // Continuation
            localQuery = TableUtilities.ApplyContinuationToQuery<TElement>(continuationToken, localQuery);

            if (requestOptions.ServerTimeout.HasValue)
            {
                localQuery = localQuery.AddQueryOption("timeout", Convert.ToString(requestOptions.ServerTimeout.Value.TotalSeconds, CultureInfo.InvariantCulture));
            }

            TableCommand<ResultSegment<TElement>, IEnumerable<TElement>> cmd = new TableCommand<ResultSegment<TElement>, IEnumerable<TElement>>();

            cmd.ExecuteFunc = localQuery.Execute;
            cmd.Begin = (callback, state) => localQuery.BeginExecute(callback, state);
            cmd.End = localQuery.EndExecute;
            cmd.ParseResponse = this.ParseTableQueryResponse;
            cmd.ApplyRequestOptions(requestOptions);
            cmd.Context = this.Context;
            return cmd;
        }

        private ResultSegment<TElement> ParseTableQueryResponse(IEnumerable<TElement> dataServiceQueryResponse, RequestResult reqResult, TableCommand<ResultSegment<TElement>, IEnumerable<TElement>> cmd)
        {
            if (reqResult.Exception != null)
            {
                DataServiceClientException dsce = TableUtilities.FindInnerExceptionOfType<DataServiceClientException>(reqResult.Exception);

                if (this.IgnoreResourceNotFoundException && dsce != null && (HttpStatusCode)dsce.StatusCode == HttpStatusCode.NotFound)
                {
                    return new ResultSegment<TElement>(new List<TElement>());
                }

                throw reqResult.Exception;
            }

            QueryOperationResponse response = dataServiceQueryResponse as QueryOperationResponse;

            ResultSegment<TElement> retSeg = new ResultSegment<TElement>(dataServiceQueryResponse.ToList());

            // Get continuation token from response
            retSeg.ContinuationToken = TableUtilities.ContinuationFromResponse(response);

            return retSeg;
        }
    }
}