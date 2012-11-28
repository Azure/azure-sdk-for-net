// -----------------------------------------------------------------------------------------
// <copyright file="CloudTable.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Table
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using Microsoft.WindowsAzure.Storage.Table.Protocol;

    /// <summary>
    /// Represents a Windows Azure Table.
    /// </summary>
    public sealed partial class CloudTable
    {
        #region TableOperation Execute Methods
        /// <summary>
        /// Executes the operation on a table, using the specified <see cref="TableRequestOptions"/> and <see cref="OperationContext"/>.  
        /// </summary>
        /// <param name="operation">A <see cref="TableOperation"/> object that represents the operation to perform.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A <see cref="TableResult"/> containing the result of executing the operation on the table.</returns>
        [DoesServiceRequest]
        public TableResult Execute(TableOperation operation, TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            CommonUtils.AssertNotNull("operation", operation);

            return operation.Execute(this.ServiceClient, this.Name, requestOptions, operationContext);
        }

        /// <summary>
        /// Begins an asynchronous table operation.
        /// </summary>
        /// <param name="operation">A <see cref="TableOperation"/> object that represents the operation to perform.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginExecute(TableOperation operation, AsyncCallback callback, object state)
        {
            CommonUtils.AssertNotNull("batch", operation);
            return this.BeginExecute(operation, null /* RequestOptions */, null /* OperationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous table operation using the specified <see cref="TableRequestOptions"/> and <see cref="OperationContext"/>.
        /// </summary>
        /// <param name="operation">A <see cref="TableOperation"/> object that represents the operation to perform.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginExecute(TableOperation operation, TableRequestOptions requestOptions, OperationContext operationContext, AsyncCallback callback, object state)
        {
            return operation.BeginExecute(this.ServiceClient, this.Name, requestOptions, operationContext, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous table operation.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>A <see cref="TableResult"/> containing the result executing the operation on the table.</returns>
        public TableResult EndExecute(IAsyncResult asyncResult)
        {
            return Executor.EndExecuteAsync<TableResult>(asyncResult);
        }
        #endregion

        #region TableBatchOperation Execute Methods
        /// <summary>
        /// Executes a batch operation on a table as an atomic operation, using the specified <see cref="TableRequestOptions"/> and <see cref="OperationContext"/>.
        /// </summary>
        /// <param name="batch">The <see cref="TableBatchOperation"/> object representing the operations to execute on the table.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>An enumerable collection of <see cref="TableResult"/> objects that contains the results, in order, of each operation in the <see cref="TableBatchOperation"/> on the table.</returns>
        [DoesServiceRequest]
        public IList<TableResult> ExecuteBatch(TableBatchOperation batch, TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            CommonUtils.AssertNotNull("batch", batch);
            return batch.Execute(this.ServiceClient, this.Name, requestOptions, operationContext);
        }

        /// <summary>
        /// Begins an asynchronous operation to execute a batch of operations on a table.
        /// </summary>
        /// <param name="batch">The <see cref="TableBatchOperation"/> object representing the operations to execute on the table.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginExecuteBatch(TableBatchOperation batch, AsyncCallback callback, object state)
        {
            CommonUtils.AssertNotNull("batch", batch);
            return this.BeginExecuteBatch(batch, null /* RequestOptions */, null /* OperationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to execute a batch of operations on a table, using the specified <see cref="TableRequestOptions"/> and <see cref="OperationContext"/>.
        /// </summary>
        /// <param name="batch">The <see cref="TableBatchOperation"/> object representing the operations to execute on the table.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginExecuteBatch(TableBatchOperation batch, TableRequestOptions requestOptions, OperationContext operationContext, AsyncCallback callback, object state)
        {
            return batch.BeginExecute(this.ServiceClient, this.Name, requestOptions, operationContext, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous batch of operations on a table.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>A enumerable collection of type <see cref="TableResult"/> that contains the results, in order, of each operation in the <see cref="TableBatchOperation"/> on the table.</returns>
        [DoesServiceRequest]
        public IList<TableResult> EndExecuteBatch(IAsyncResult asyncResult)
        {
            return Executor.EndExecuteAsync<IList<TableResult>>(asyncResult);
        }

        #endregion

        #region TableQuery Execute Methods
        #region NonGeneric
        /// <summary>
        /// Executes a query on a table, using the specified <see cref="TableRequestOptions"/> and <see cref="OperationContext"/>.
        /// </summary>
        /// <param name="query">A <see cref="TableQuery"/> representing the query to execute.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>An enumerable collection of <see cref="DynamicTableEntity"/> objects, representing table entities returned by the query.</returns>
        [DoesServiceRequest]
        public IEnumerable<DynamicTableEntity> ExecuteQuery(TableQuery query, TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            CommonUtils.AssertNotNull("query", query);
            return query.Execute(this.ServiceClient, this.Name, requestOptions, operationContext);
        }

        /// <summary>
        /// Executes a query in segmented mode with the specified <see cref="TableContinuationToken"/> continuation token, <see cref="TableRequestOptions"/>, and <see cref="OperationContext"/>.
        /// </summary>
        /// <param name="query">A <see cref="TableQuery"/> representing the query to execute.</param>
        /// <param name="token">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A <see cref="TableQuerySegment{T}"/> object containing the results of executing the query.</returns>
        [DoesServiceRequest]
        public TableQuerySegment<DynamicTableEntity> ExecuteQuerySegmented(TableQuery query, TableContinuationToken token, TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            CommonUtils.AssertNotNull("query", query);
            return query.ExecuteQuerySegmented(token, this.ServiceClient, this.Name, requestOptions, operationContext);
        }

        /// <summary>
        /// Begins an asynchronous segmented query operation using the specified <see cref="TableContinuationToken"/> continuation token.
        /// </summary>
        /// <param name="query">A <see cref="TableQuery"/> representing the query to execute.</param>
        /// <param name="token">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginExecuteQuerySegmented(TableQuery query, TableContinuationToken token, AsyncCallback callback, object state)
        {
            CommonUtils.AssertNotNull("query", query);
            return this.BeginExecuteQuerySegmented(query, token, null /* RequestOptions */, null /* OperationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to query a table in segmented mode using the specified <see cref="TableContinuationToken"/> continuation token, <see cref="TableRequestOptions"/>, and <see cref="OperationContext"/>.
        /// </summary>
        /// <param name="query">A <see cref="TableQuery"/> representing the query to execute.</param>
        /// <param name="token">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginExecuteQuerySegmented(TableQuery query, TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext, AsyncCallback callback, object state)
        {
            CommonUtils.AssertNotNull("query", query);
            return query.BeginExecuteQuerySegmented(token, this.ServiceClient, this.Name, requestOptions, operationContext, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous segmented query operation. 
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>A <see cref="TableQuerySegment{T}"/> object containing the results of executing the query.</returns>
        public TableQuerySegment<DynamicTableEntity> EndExecuteQuerySegmented(IAsyncResult asyncResult)
        {
            return Executor.EndExecuteAsync<TableQuerySegment<DynamicTableEntity>>(asyncResult);
        }
        #endregion

        #region Generic

        /// <summary>
        /// Executes a query on a table, using the specified <see cref="TableRequestOptions"/> and <see cref="OperationContext"/>.
        /// </summary>
        /// <typeparam name="TElement">The entity type of the query.</typeparam>
        /// <param name="query">A TableQuery instance specifying the table to query and the query parameters to use, specialized for a type T implementing TableEntity.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>An enumerable collection, specialized for type <c>TElement</c>, of the results of executing the query.</returns>
        [DoesServiceRequest]
        public IEnumerable<TElement> ExecuteQuery<TElement>(TableQuery<TElement> query, TableRequestOptions requestOptions = null, OperationContext operationContext = null) where TElement : ITableEntity, new()
        {
            CommonUtils.AssertNotNull("query", query);
            return query.Execute(this.ServiceClient, this.Name, requestOptions, operationContext);
        }

        /// <summary>
        /// Queries a table in segmented mode using the specified <see cref="TableContinuationToken"/> continuation token, <see cref="TableRequestOptions"/>, and <see cref="OperationContext"/>.
        /// </summary>
        /// <typeparam name="TElement">The entity type of the query.</typeparam>
        /// <param name="query">A <see cref="TableQuery"/> instance specifying the table to query and the query parameters to use, specialized for a type <c>TElement</c>.</param>
        /// <param name="token">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A <see cref="TableQuerySegment{T}"/>, specialized for type <c>TElement</c>, containing the results of executing the query.</returns>
        [DoesServiceRequest]
        public TableQuerySegment<TElement> ExecuteQuerySegmented<TElement>(TableQuery<TElement> query, TableContinuationToken token, TableRequestOptions requestOptions = null, OperationContext operationContext = null) where TElement : ITableEntity, new()
        {
            CommonUtils.AssertNotNull("query", query);
            return query.ExecuteQuerySegmented(token, this.ServiceClient, this.Name, requestOptions, operationContext);
        }

        /// <summary>
        /// Begins an asynchronous operation to query a table in segmented mode, using the specified <see cref="TableContinuationToken"/> continuation token.
        /// </summary>
        /// <typeparam name="TElement">The entity type of the query.</typeparam>
        /// <param name="query">A <see cref="TableQuery"/> instance specifying the table to query and the query parameters to use, specialized for a type <c>TElement</c>.</param>
        /// <param name="token">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginExecuteQuerySegmented<TElement>(TableQuery<TElement> query, TableContinuationToken token, AsyncCallback callback, object state) where TElement : ITableEntity, new()
        {
            CommonUtils.AssertNotNull("query", query);
            return this.BeginExecuteQuerySegmented(query, token, null /* RequestOptions */, null /* OperationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to query a table in segmented mode using the specified <see cref="TableContinuationToken"/> continuation token and <see cref="OperationContext"/>.
        /// </summary>
        /// <typeparam name="TElement">The entity type of the query.</typeparam>
        /// <param name="query">A <see cref="TableQuery"/> instance specifying the table to query and the query parameters to use, specialized for a type <c>TElement</c>.</param>
        /// <param name="token">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginExecuteQuerySegmented<TElement>(TableQuery<TElement> query, TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext, AsyncCallback callback, object state) where TElement : ITableEntity, new()
        {
            CommonUtils.AssertNotNull("query", query);
            return query.BeginExecuteQuerySegmented(token, this.ServiceClient, this.Name, requestOptions, operationContext, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous segmented table query operation.
        /// </summary>
        /// <typeparam name="TElement">The entity type of the query.</typeparam>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>A <see cref="TableQuerySegment{T}"/>, specialized for type <c>TElement</c>, containing the results of executing the query.</returns>
        public TableQuerySegment<TElement> EndExecuteQuerySegmented<TElement>(IAsyncResult asyncResult)
        {
            return Executor.EndExecuteAsync<TableQuerySegment<TElement>>(asyncResult);
        }
        #endregion

        #region With Resolvers
        /// <summary>
        /// Executes a query, using the specified <see cref="TableRequestOptions"/> and <see cref="OperationContext"/>, applying the <see cref="EntityResolver"/> to the result.
        /// </summary>
        /// <typeparam name="TElement">The entity type of the query.</typeparam>
        /// <typeparam name="R">The type into which the <see cref="EntityResolver"/> will project the query results.</typeparam>
        /// <param name="query">A <see cref="TableQuery"/> instance specifying the table to query and the query parameters to use, specialized for a type <c>TElement</c>.</param>
        /// <param name="resolver">An <see cref="EntityResolver"/> instance which creates a projection of the table query result entities into the specified type <c>R</c>.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>An enumerable collection, containing the projection into type <c>R</c>, of the results of executing the query.</returns>
        [DoesServiceRequest]
        public IEnumerable<R> ExecuteQuery<TElement, R>(TableQuery<TElement> query, EntityResolver<R> resolver, TableRequestOptions requestOptions = null, OperationContext operationContext = null) where TElement : ITableEntity, new()
        {
            CommonUtils.AssertNotNull("query", query);
            CommonUtils.AssertNotNull("resolver", resolver);
            return query.Execute(this.ServiceClient, this.Name, resolver, requestOptions, operationContext);
        }

        /// <summary>
        /// Executes a query in segmented mode with the specified <see cref="TableContinuationToken"/> continuation token, using the specified <see cref="TableRequestOptions"/> and <see cref="OperationContext"/>, applying the <see cref="EntityResolver"/> to the results.
        /// </summary>
        /// <typeparam name="TElement">The entity type of the query.</typeparam>
        /// <typeparam name="R">The type into which the <see cref="EntityResolver"/> will project the query results.</typeparam>
        /// <param name="query">A <see cref="TableQuery"/> instance specifying the table to query and the query parameters to use, specialized for a type <c>TElement</c>.</param>
        /// <param name="resolver">An <see cref="EntityResolver"/> instance which creates a projection of the table query result entities into the specified type <c>R</c>.</param>
        /// <param name="token">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A <see cref="TableQuerySegment{T}"/> containing the projection into type <c>R</c> of the results of executing the query. </returns>
        [DoesServiceRequest]
        public TableQuerySegment<R> ExecuteQuerySegmented<TElement, R>(TableQuery<TElement> query, EntityResolver<R> resolver, TableContinuationToken token, TableRequestOptions requestOptions = null, OperationContext operationContext = null) where TElement : ITableEntity, new()
        {
            CommonUtils.AssertNotNull("query", query);
            CommonUtils.AssertNotNull("resolver", resolver);
            return query.ExecuteQuerySegmented(token, this.ServiceClient, this.Name, resolver, requestOptions, operationContext);
        }

        /// <summary>
        /// Begins an asynchronous operation to query a table in segmented mode, using the specified <see cref="EntityResolver"/> and <see cref="TableContinuationToken"/> continuation token.
        /// </summary>
        /// <typeparam name="TElement">The entity type of the query.</typeparam>
        /// <typeparam name="R">The type into which the <see cref="EntityResolver"/> will project the query results.</typeparam>
        /// <param name="query">A <see cref="TableQuery"/> instance specifying the table to query and the query parameters to use, specialized for a type <c>TElement</c>.</param>
        /// <param name="resolver">An <see cref="EntityResolver"/> instance which creates a projection of the table query result entities into the specified type <c>R</c>.</param>
        /// <param name="token">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginExecuteQuerySegmented<TElement, R>(TableQuery<TElement> query, EntityResolver<R> resolver, TableContinuationToken token, AsyncCallback callback, object state) where TElement : ITableEntity, new()
        {
            return this.BeginExecuteQuerySegmented(query, resolver, token, null /* RequestOptions */, null /* OperationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to execute a query in segmented mode with the specified <see cref="TableContinuationToken"/> continuation token, <see cref="TableRequestOptions"/>, and <see cref="OperationContext"/>, applies the <see cref="EntityResolver"/> to the results.
        /// </summary>
        /// <typeparam name="TElement">The entity type of the query.</typeparam>
        /// <typeparam name="R">The type into which the <see cref="EntityResolver"/> will project the query results.</typeparam>
        /// <param name="query">A <see cref="TableQuery"/> instance specifying the table to query and the query parameters to use, specialized for a type <c>TElement</c>.</param>
        /// <param name="resolver">An <see cref="EntityResolver"/> instance which creates a projection of the table query result entities into the specified type <c>R</c>.</param>
        /// <param name="token">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginExecuteQuerySegmented<TElement, R>(TableQuery<TElement> query, EntityResolver<R> resolver, TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext, AsyncCallback callback, object state) where TElement : ITableEntity, new()
        {
            CommonUtils.AssertNotNull("query", query);
            CommonUtils.AssertNotNull("resolver", resolver);
            return query.BeginExecuteQuerySegmented(token, this.ServiceClient, this.Name, resolver, requestOptions, operationContext, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous segmented table query operation.
        /// </summary>
        /// <typeparam name="TElement">The entity type of the query.</typeparam>
        /// <typeparam name="R">The type into which the <see cref="EntityResolver"/> will project the query results.</typeparam>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>A <see cref="TableQuerySegment{T}"/> containing the projection into type <c>R</c> of the results of executing the query. </returns>
        public TableQuerySegment<R> EndExecuteQuerySegmented<TElement, R>(IAsyncResult asyncResult)
        {
            return Executor.EndExecuteAsync<TableQuerySegment<R>>(asyncResult);
        }
        #endregion

        #endregion

        #region Create
        /// <summary>
        /// Begins an asynchronous operation to create a table.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginCreate(AsyncCallback callback, object state)
        {
            return this.BeginCreate(null /* RequestOptions */, null /* OperationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to create a table.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginCreate(TableRequestOptions requestOptions, OperationContext operationContext, AsyncCallback callback, object state)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            DynamicTableEntity tblEntity = new DynamicTableEntity();
            tblEntity.Properties.Add(TableConstants.TableName, new EntityProperty(this.Name));
            TableOperation operation = new TableOperation(tblEntity, TableOperationType.Insert);
            operation.IsTableEntity = true;

            return operation.BeginExecute(this.ServiceClient, TableConstants.TableServiceTablesName, requestOptions, operationContext, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to create a table.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public void EndCreate(IAsyncResult asyncResult)
        {
            Executor.EndExecuteAsync<TableResult>(asyncResult);
        }

        /// <summary>
        /// Creates a table.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        [DoesServiceRequest]
        public void Create(TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            DynamicTableEntity tblEntity = new DynamicTableEntity();
            tblEntity.Properties.Add(TableConstants.TableName, new EntityProperty(this.Name));
            TableOperation operation = new TableOperation(tblEntity, TableOperationType.Insert);
            operation.IsTableEntity = true;

            operation.Execute(this.ServiceClient, TableConstants.TableServiceTablesName, requestOptions, operationContext);
        }

        #endregion

        #region CreateIfNotExists

        /// <summary>
        /// Begins an asynchronous operation to create a table if it does not already exist.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginCreateIfNotExists(AsyncCallback callback, object state)
        {
            return this.BeginCreateIfNotExists(null /* RequestOptions */, null /* OperationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to create a table if it does not already exist.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginCreateIfNotExists(TableRequestOptions requestOptions, OperationContext operationContext, AsyncCallback callback, object state)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            ChainedAsyncResult<bool> retResult = new ChainedAsyncResult<bool>(callback, state)
            {
                RequestOptions = requestOptions,
                OperationContext = operationContext
            };

            operationContext.OperationExpiryTime = requestOptions.MaximumExecutionTime.HasValue
                                                       ? DateTime.Now + requestOptions.MaximumExecutionTime.Value
                                                       : (DateTime?)null;

            lock (retResult.CancellationLockerObject)
            {
                ICancellableAsyncResult currentRes = this.BeginExists(requestOptions, operationContext, this.CreateIfNotExistHandler, retResult);
                retResult.CancelDelegate = currentRes.Cancel;

                // Check if cancellation was requested prior to begin
                if (retResult.CancelRequested)
                {
                    retResult.CancelDelegate();
                }
            }

            return retResult;
        }

        private void CreateIfNotExistHandler(IAsyncResult asyncResult)
        {
            ChainedAsyncResult<bool> chainedResult = asyncResult.AsyncState as ChainedAsyncResult<bool>;
            bool exists = false;

            lock (chainedResult.CancellationLockerObject)
            {
                chainedResult.CancelDelegate = null;
                chainedResult.UpdateCompletedSynchronously(asyncResult.CompletedSynchronously);

                try
                {
                    exists = this.EndExists(asyncResult);

                    if (exists)
                    {
                        chainedResult.Result = false;
                        chainedResult.OnComplete();
                    }
                    else
                    {
                        ICancellableAsyncResult currentRes = this.BeginCreate(
                             (TableRequestOptions)chainedResult.RequestOptions,
                             chainedResult.OperationContext,
                             createRes =>
                             {
                                 chainedResult.CancelDelegate = null;
                                 chainedResult.UpdateCompletedSynchronously(chainedResult.CompletedSynchronously);

                                 try
                                 {
                                     this.EndCreate(createRes);
                                     chainedResult.Result = true;
                                     chainedResult.OnComplete();
                                 }
                                 catch (StorageException storageEx)
                                 {
                                     if (storageEx.RequestInformation.ExtendedErrorInformation != null &&
                                         storageEx.RequestInformation.ExtendedErrorInformation.ErrorCode ==
                                         TableErrorCodeStrings.TableAlreadyExists)
                                     {
                                         chainedResult.Result = false;
                                         chainedResult.OnComplete();
                                     }
                                     else
                                     {
                                         chainedResult.OnComplete(storageEx);
                                     }
                                 }
                                 catch (Exception createEx)
                                 {
                                     chainedResult.OnComplete(createEx);
                                 }
                             },
                             null);

                        chainedResult.CancelDelegate = currentRes.Cancel;
                    }
                }
                catch (Exception ex)
                {
                    chainedResult.OnComplete(ex);
                }
            }
        }

        /// <summary>
        /// Ends an asynchronous operation to determine whether a table exists.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns><c>true</c> if table exists; otherwise, <c>false</c>.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public bool EndCreateIfNotExists(IAsyncResult asyncResult)
        {
            ChainedAsyncResult<bool> res = asyncResult as ChainedAsyncResult<bool>;
            CommonUtils.AssertNotNull("AsyncResult", res);
            res.End();
            return res.Result;
        }

        /// <summary>
        /// Creates the table if it does not already exist.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns><c>true</c> if table was created; otherwise, <c>false</c>.</returns>
        [DoesServiceRequest]
        public bool CreateIfNotExists(TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            if (this.Exists(requestOptions, operationContext))
            {
                return false;
            }
            else
            {
                try
                {
                    this.Create(requestOptions, operationContext);
                    return true;
                }
                catch (StorageException ex)
                {
                    if (ex.RequestInformation.ExtendedErrorInformation != null &&
                        ex.RequestInformation.ExtendedErrorInformation.ErrorCode ==
                        TableErrorCodeStrings.TableAlreadyExists)
                    {
                        return false;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        #endregion

        #region Delete
        /// <summary>
        /// Begins an asynchronous operation to delete a table.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginDelete(AsyncCallback callback, object state)
        {
            return this.BeginDelete(null /* RequestOptions */, null /* OperationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to delete a table.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginDelete(TableRequestOptions requestOptions, OperationContext operationContext, AsyncCallback callback, object state)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            DynamicTableEntity tblEntity = new DynamicTableEntity();
            tblEntity.Properties.Add(TableConstants.TableName, new EntityProperty(this.Name));
            TableOperation operation = new TableOperation(tblEntity, TableOperationType.Delete);
            operation.IsTableEntity = true;

            return operation.BeginExecute(this.ServiceClient, TableConstants.TableServiceTablesName, requestOptions, operationContext, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to delete a table.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public void EndDelete(IAsyncResult asyncResult)
        {
            Executor.EndExecuteAsync<TableResult>(asyncResult);
        }

        /// <summary>
        /// Deletes a table.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        [DoesServiceRequest]
        public void Delete(TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            DynamicTableEntity tblEntity = new DynamicTableEntity();
            tblEntity.Properties.Add(TableConstants.TableName, new EntityProperty(this.Name));
            TableOperation operation = new TableOperation(tblEntity, TableOperationType.Delete);
            operation.IsTableEntity = true;

            operation.Execute(this.ServiceClient, TableConstants.TableServiceTablesName, requestOptions, operationContext);
        }

        #endregion

        #region DeleteIfExists

        /// <summary>
        /// Begins an asynchronous operation to delete the tables if it exists.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginDeleteIfExists(AsyncCallback callback, object state)
        {
            return this.BeginDeleteIfExists(null /* RequestOptions */, null /* OperationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to delete the tables if it exists.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginDeleteIfExists(TableRequestOptions requestOptions, OperationContext operationContext, AsyncCallback callback, object state)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            ChainedAsyncResult<bool> retResult = new ChainedAsyncResult<bool>(callback, state)
            {
                RequestOptions = requestOptions,
                OperationContext = operationContext
            };
            operationContext.OperationExpiryTime = requestOptions.MaximumExecutionTime.HasValue
                                                       ? DateTime.Now + requestOptions.MaximumExecutionTime.Value
                                                       : (DateTime?)null;

            lock (retResult.CancellationLockerObject)
            {
                ICancellableAsyncResult currentRes = this.BeginExists(requestOptions, operationContext, this.DeleteIfExistsHandler, retResult);
                retResult.CancelDelegate = currentRes.Cancel;

                // Check if cancellation was requested prior to begin
                if (retResult.CancelRequested)
                {
                    retResult.CancelDelegate();
                }
            }

            return retResult;
        }

        private void DeleteIfExistsHandler(IAsyncResult asyncResult)
        {
            ChainedAsyncResult<bool> chainedResult = asyncResult.AsyncState as ChainedAsyncResult<bool>;
            bool exists = false;
            lock (chainedResult.CancellationLockerObject)
            {
                chainedResult.CancelDelegate = null;
                chainedResult.UpdateCompletedSynchronously(asyncResult.CompletedSynchronously);

                try
                {
                    exists = this.EndExists(asyncResult);

                    if (!exists)
                    {
                        chainedResult.Result = false;
                        chainedResult.OnComplete();
                    }
                    else
                    {
                        ICancellableAsyncResult currentRes = this.BeginDelete(
                            (TableRequestOptions)chainedResult.RequestOptions,
                            chainedResult.OperationContext,
                            (deleteRes) =>
                            {
                                chainedResult.CancelDelegate = null;
                                chainedResult.UpdateCompletedSynchronously(deleteRes.CompletedSynchronously);

                                try
                                {
                                    this.EndDelete(deleteRes);
                                    chainedResult.Result = true;
                                    chainedResult.OnComplete();
                                }
                                catch (StorageException storageEx)
                                {
                                    if (storageEx.RequestInformation.ExtendedErrorInformation != null &&
                                        storageEx.RequestInformation.ExtendedErrorInformation.ErrorCode == TableErrorCodeStrings.TableNotFound)
                                    {
                                        chainedResult.Result = false;
                                        chainedResult.OnComplete();
                                    }
                                    else
                                    {
                                        chainedResult.OnComplete(storageEx);
                                    }
                                }
                                catch (Exception createEx)
                                {
                                    chainedResult.OnComplete(createEx);
                                }
                            },
                            null);

                        chainedResult.CancelDelegate = currentRes.Cancel;
                    }
                }
                catch (Exception ex)
                {
                    chainedResult.OnComplete(ex);
                }
            }
        }

        /// <summary>
        /// Ends an asynchronous operation to delete the tables if it exists.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns><c>true</c> if the table was deleted; otherwise, <c>false</c>.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation")]
        public bool EndDeleteIfExists(IAsyncResult asyncResult)
        {
            ChainedAsyncResult<bool> res = asyncResult as ChainedAsyncResult<bool>;
            CommonUtils.AssertNotNull("AsyncResult", res);
            res.End();
            return res.Result;
        }

        /// <summary>
        /// Deletes the table if it exists.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns><c>true</c> if the table was deleted; otherwise, <c>false</c>.</returns>
        [DoesServiceRequest]
        public bool DeleteIfExists(TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            if (!this.Exists(requestOptions, operationContext))
            {
                return false;
            }
            else
            {
                try
                {
                    this.Delete(requestOptions, operationContext);
                    return true;
                }
                catch (StorageException storageEx)
                {
                    if (storageEx.RequestInformation.ExtendedErrorInformation != null &&
                        storageEx.RequestInformation.ExtendedErrorInformation.ErrorCode == TableErrorCodeStrings.TableNotFound)
                    {
                        return false;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        #endregion

        #region Exists

        /// <summary>
        /// Begins an asynchronous operation to determine whether a table exists.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginExists(AsyncCallback callback, object state)
        {
            return this.BeginExists(null /* RequestOptions */, null /* OperationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to determine whether a table exists.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginExists(TableRequestOptions requestOptions, OperationContext operationContext, AsyncCallback callback, object state)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            DynamicTableEntity tblEntity = new DynamicTableEntity();
            tblEntity.Properties.Add(TableConstants.TableName, new EntityProperty(this.Name));
            TableOperation operation = new TableOperation(tblEntity, TableOperationType.Retrieve);
            operation.IsTableEntity = true;

            return operation.BeginExecute(this.ServiceClient, TableConstants.TableServiceTablesName, requestOptions, operationContext, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to determine whether a table exists.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns><c>true</c> if table exists; otherwise, <c>false</c>.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public bool EndExists(IAsyncResult asyncResult)
        {
            TableResult res = Executor.EndExecuteAsync<TableResult>(asyncResult);

            // Only other option is not found, other status codes will throw prior to this.            
            return res.HttpStatusCode == (int)HttpStatusCode.OK;
        }

        /// <summary>
        /// Checks whether the table exists.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns><c>true</c> if table exists; otherwise, <c>false</c>.</returns>
        [DoesServiceRequest]
        public bool Exists(TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            DynamicTableEntity tblEntity = new DynamicTableEntity();
            tblEntity.Properties.Add(TableConstants.TableName, new EntityProperty(this.Name));
            TableOperation operation = new TableOperation(tblEntity, TableOperationType.Retrieve);
            operation.IsTableEntity = true;

            TableResult res = operation.Execute(this.ServiceClient, TableConstants.TableServiceTablesName, requestOptions, operationContext);

            // Only other option is not found, other status codes will throw prior to this.            
            return res.HttpStatusCode == (int)HttpStatusCode.OK;
        }

        #endregion

        #region Permissions

        /// <summary>
        /// Begins an asynchronous request to get the permissions settings for the table.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginGetPermissions(AsyncCallback callback, object state)
        {
            return this.BeginGetPermissions(null /* RequestOptions */, null /* OperationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request to get the permissions settings for the table.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginGetPermissions(TableRequestOptions requestOptions, OperationContext operationContext, AsyncCallback callback, object state)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();
            return Executor.BeginExecuteAsync(
                                            this.GetAclImpl(requestOptions),
                                            requestOptions.RetryPolicy,
                                            operationContext,
                                            callback,
                                            state);
        }

        /// <summary>
        /// Returns the asynchronous result of the request to get the permissions settings for the table.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>The table's permissions.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public TablePermissions EndGetPermissions(IAsyncResult asyncResult)
        {
            return Executor.EndExecuteAsync<TablePermissions>(asyncResult);
        }

        /// <summary>
        /// Gets the permissions settings for the table.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>The table's permissions.</returns>
        [DoesServiceRequest]
        public TablePermissions GetPermissions(TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return Executor.ExecuteSync(this.GetAclImpl(requestOptions), requestOptions.RetryPolicy, operationContext);
        }

        private RESTCommand<TablePermissions> GetAclImpl(TableRequestOptions requestOptions)
        {
            RESTCommand<TablePermissions> retCmd = new RESTCommand<TablePermissions>(this.ServiceClient.Credentials, this.Uri);
            retCmd.BuildRequestDelegate = TableHttpWebRequestFactory.GetAcl;
            retCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
            retCmd.RetrieveResponseStream = true;
            retCmd.PreProcessResponse =
                (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(System.Net.HttpStatusCode.OK, resp, null /* retVal */, cmd, ex, ctx);

            retCmd.PostProcessResponse = this.ParseGetAcl;
            retCmd.ApplyRequestOptions(requestOptions);
            return retCmd;
        }

        private TablePermissions ParseGetAcl(RESTCommand<TablePermissions> cmd, HttpWebResponse resp, Exception ex, OperationContext ctx)
        {
            TablePermissions tableAcl = new TablePermissions();

            // Get the policies from the web response.
            TableHttpWebResponseParsers.ReadSharedAccessIdentifiers(cmd.ResponseStream, tableAcl);

            return tableAcl;
        }

        /// <summary>
        /// Begins an asynchronous request to set permissions for the table.
        /// </summary>
        /// <param name="permissions">The permissions to apply to the table.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginSetPermissions(TablePermissions permissions, AsyncCallback callback, object state)
        {
            return this.BeginSetPermissions(permissions, null /* RequestOptions */, null /* OperationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request to set permissions for the table.
        /// </summary>
        /// <param name="permissions">The permissions to apply to the table.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginSetPermissions(TablePermissions permissions, TableRequestOptions requestOptions, OperationContext operationContext, AsyncCallback callback, object state)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();
            return Executor.BeginExecuteAsync(
                                            this.SetAclImpl(permissions, requestOptions),
                                            requestOptions.RetryPolicy,
                                            operationContext,
                                            callback,
                                            state);
        }

        /// <summary>
        /// Returns the asynchronous result of the request to get the permissions settings for the table.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>        
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public void EndSetPermissions(IAsyncResult asyncResult)
        {
            Executor.EndExecuteAsync<NullType>(asyncResult);
        }

        /// <summary>
        /// Sets the permissions settings for the table.
        /// </summary>
        /// <param name="permissions">A <see cref="TablePermissions"/> object that represents the permissions to set.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        [DoesServiceRequest]
        public void SetPermissions(TablePermissions permissions, TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();
            Executor.ExecuteSync(this.SetAclImpl(permissions, requestOptions), requestOptions.RetryPolicy, operationContext);
        }

        private RESTCommand<NullType> SetAclImpl(TablePermissions permissions, TableRequestOptions requestOptions)
        {
            MemoryStream str = new MemoryStream();
            TableRequest.WriteSharedAccessIdentifiers(permissions.SharedAccessPolicies, str);
            str.Seek(0, SeekOrigin.Begin);

            RESTCommand<NullType> retCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, this.Uri);
            retCmd.BuildRequestDelegate = TableHttpWebRequestFactory.SetAcl;
            retCmd.SendStream = str;
            retCmd.RecoveryAction = RecoveryActions.RewindStream;
            retCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
            retCmd.PreProcessResponse =
                (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.NoContent, resp, NullType.Value, cmd, ex, ctx);

            retCmd.ApplyRequestOptions(requestOptions);
            return retCmd;
        }

        #endregion
    }
}