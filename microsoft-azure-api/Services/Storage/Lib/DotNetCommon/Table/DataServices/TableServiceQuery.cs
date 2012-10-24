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
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Services.Client;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Net;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Table.Protocol;

    public class TableServiceQuery<TElement> : IQueryable<TElement>
    {
        public TableServiceQuery(IQueryable<TElement> query, TableServiceContext context)
        {
            this.Query = query as DataServiceQuery<TElement>;
            this.Context = context;
            this.IgnoreResourceNotFoundException = false;
        }

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

        public IEnumerator<TElement> GetEnumerator()
        {
            return this.Execute(null /* RequestOptions */, null /* OperationContext */).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator() as IEnumerator;
        }

        [DoesServiceRequest]
        public IEnumerable<TElement> Execute(TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this.Context.ServiceClient);
            operationContext = operationContext ?? new OperationContext();
            long takeCount = TableUtilities.GetQueryTakeCount(this.Query, long.MaxValue);
            return
                General.LazyEnumerable(
                    (continuationToken) =>
                    this.ExecuteSegmentedCore((TableContinuationToken)continuationToken, requestOptions, operationContext),
                    takeCount,
                    operationContext);
        }

        /// <summary>
        /// Begins an asynchronous operation to execute a query and return the results as a result segment.
        /// </summary>
        /// <param name="currentToken">A continuation token returned by a previous listing operation, can be null.</param>
        /// <param name="operationContext"> </param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <param name="requestOptions"> </param>
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
        /// <param name="operationContext"> </param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <param name="requestOptions"> </param>
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

        [DoesServiceRequest]
        public TableQuerySegment<TElement> ExecuteSegmented(TableContinuationToken continuationToken, TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this.Context.ServiceClient);
            operationContext = operationContext ?? new OperationContext();
            return new TableQuerySegment<TElement>(this.ExecuteSegmentedCore(continuationToken, requestOptions, operationContext));
        }

        internal ResultSegment<TElement> ExecuteSegmentedCore(
                                                              TableContinuationToken continuationToken,
                                                              TableRequestOptions requestOptions,
                                                              OperationContext operationContext)
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
                localQuery = localQuery.AddQueryOption("timeout", Convert.ToString(requestOptions.ServerTimeout.Value.TotalSeconds));
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

        private ResultSegment<TElement> ParseTableQueryResponse(
                                                                IEnumerable<TElement> dataServiceQueryResponse,
                                                                RequestResult reqResult,
                                                                TableCommand<ResultSegment<TElement>, IEnumerable<TElement>> cmd)
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