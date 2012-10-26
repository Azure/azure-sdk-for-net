// -----------------------------------------------------------------------------------------
// <copyright file="CloudTableExtensions.cs" company="Microsoft">
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
    using System.Collections.Generic;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Table;
    using Windows.Foundation;

    /// <summary>
    /// Defines the extension methods to the <see cref="CloudTable"/> class. This is a static class.
    /// </summary>
    public static class CloudTableExtensions
    {
        #region TableQuery Execute Methods
        /// <summary>
        /// Executes a query asynchronously in segmented mode with the specified <see cref="TableQuery{T}"/> query and <see cref="TableContinuationToken"/> continuation token.
        /// </summary>
        /// <typeparam name="T">The entity type of the query.</typeparam>
        /// <param name="table">The input <see cref="CloudTable"/>, which acts as the <c>this</c> instance for the extension method.</param>
        /// <param name="query">A <see cref="TableQuery{T}"/> representing the query to execute.</param>
        /// <param name="token">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
        /// <returns>A <see cref="TableQuerySegment{T}"/> object containing the results of executing the query.</returns>
        public static IAsyncOperation<TableQuerySegment<T>> ExecuteQuerySegmentedAsync<T>(this CloudTable table, TableQuery<T> query, TableContinuationToken token) where T : ITableEntity, new()
        {
            return table.ExecuteQuerySegmentedAsync(query, token, null /* requestOptions */, null /* operationContext */);
        }

        /// <summary>
        /// Executes a query asynchronously in segmented mode with the specified <see cref="TableQuery{T}"/> query, <see cref="TableContinuationToken"/> continuation token, <see cref="TableRequestOptions"/> options, and <see cref="OperationContext"/> context.
        /// </summary>
        /// <typeparam name="T">The entity type of the query.</typeparam>
        /// <param name="table">The input <see cref="CloudTable"/>, which acts as the <c>this</c> instance for the extension method.</param>
        /// <param name="query">A <see cref="TableQuery{T}"/> representing the query to execute.</param>
        /// <param name="token">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A <see cref="TableQuerySegment{T}"/> object containing the results of executing the query.</returns>
        public static IAsyncOperation<TableQuerySegment<T>> ExecuteQuerySegmentedAsync<T>(this CloudTable table, TableQuery<T> query, TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext) where T : ITableEntity, new()
        {
            CommonUtils.AssertNotNull("query", query);
            return query.ExecuteQuerySegmentedAsync(token, table.ServiceClient, table.Name, requestOptions, operationContext);
        }

        /// <summary>
        /// Executes a query asynchronously in segmented mode, using the specified <see cref="TableQuery{T}"/> query and <see cref="TableContinuationToken"/> continuation token, and applies the <see cref="EntityResolver"/> to the result.
        /// </summary>
        /// <typeparam name="T">The entity type of the query.</typeparam>
        /// <typeparam name="R">The type into which the <see cref="EntityResolver"/> will project the query results.</typeparam>
        /// <param name="table">The input <see cref="CloudTable"/>, which acts as the <c>this</c> instance for the extension method.</param>
        /// <param name="query">A <see cref="TableQuery{T}"/> representing the query to execute.</param>
        /// <param name="resolver">An <see cref="EntityResolver{R}"/> instance which creates a projection of the table query result entities into the specified type <c>R</c>.</param>
        /// <param name="token">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
        /// <returns>A <see cref="TableQuerySegment{R}"/> containing the projection into type <c>R</c> of the results of executing the query.</returns>
        public static IAsyncOperation<TableQuerySegment<R>> ExecuteQuerySegmentedAsync<T, R>(this CloudTable table, TableQuery<T> query, EntityResolver<R> resolver, TableContinuationToken token) where T : ITableEntity, new()
        {
            return table.ExecuteQuerySegmentedAsync<T, R>(query, resolver, token, null /* requestOptions */, null /* operationContext */);
        }

        /// <summary>
        /// Executes a query asynchronously in segmented mode, using the specified <see cref="TableQuery{T}"/> query, <see cref="TableContinuationToken"/> continuation token, <see cref="TableRequestOptions"/> options, and <see cref="OperationContext"/> context, and applies the <see cref="EntityResolver"/> to the result.
        /// </summary>
        /// <typeparam name="T">The entity type of the query.</typeparam>
        /// <typeparam name="R">The type into which the <see cref="EntityResolver"/> will project the query results.</typeparam>
        /// <param name="table">The input <see cref="CloudTable"/>, which acts as the <c>this</c> instance for the extension method.</param>
        /// <param name="query">A <see cref="TableQuery{T}"/> representing the query to execute.</param>
        /// <param name="resolver">An <see cref="EntityResolver{R}"/> instance which creates a projection of the table query result entities into the specified type <c>R</c>.</param>
        /// <param name="token">A <see cref="TableContinuationToken"/> object representing a continuation token from the server when the operation returns a partial result.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A <see cref="TableQuerySegment{R}"/> containing the projection into type <c>R</c> of the results of executing the query.</returns>
        public static IAsyncOperation<TableQuerySegment<R>> ExecuteQuerySegmentedAsync<T, R>(this CloudTable table, TableQuery<T> query, EntityResolver<R> resolver, TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext) where T : ITableEntity, new()
        {
            CommonUtils.AssertNotNull("query", query);
            CommonUtils.AssertNotNull("resolver", resolver);
            return query.ExecuteQuerySegmentedAsync(token, table.ServiceClient, table.Name, resolver, requestOptions, operationContext);
        }
        #endregion
    }
}
