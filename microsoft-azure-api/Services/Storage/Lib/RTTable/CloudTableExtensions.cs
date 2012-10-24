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

    public static class CloudTableExtensions
    {
        #region TableQuery Execute Methods
        public static IAsyncOperation<TableQuerySegment<T>> ExecuteQuerySegmentedAsync<T>(this CloudTable table, TableQuery<T> query, TableContinuationToken token) where T : ITableEntity, new()
        {
            return table.ExecuteQuerySegmentedAsync(query, token, null /* requestOptions */, null /* operationContext */);
        }

        public static IAsyncOperation<TableQuerySegment<T>> ExecuteQuerySegmentedAsync<T>(this CloudTable table, TableQuery<T> query, TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext) where T : ITableEntity, new()
        {
            CommonUtils.AssertNotNull("query", query);
            return query.ExecuteQuerySegmentedAsync(token, table.ServiceClient, table.Name, requestOptions, operationContext);
        }

        // With Resolvers
        public static IAsyncOperation<TableQuerySegment<R>> ExecuteQuerySegmentedAsync<T, R>(this CloudTable table, TableQuery<T> query, EntityResolver<R> resolver, TableContinuationToken token) where T : ITableEntity, new()
        {
            return table.ExecuteQuerySegmentedAsync<T, R>(query, resolver, token, null /* requestOptions */, null /* operationContext */);
        }

        public static IAsyncOperation<TableQuerySegment<R>> ExecuteQuerySegmentedAsync<T, R>(this CloudTable table, TableQuery<T> query, EntityResolver<R> resolver, TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext) where T : ITableEntity, new()
        {
            CommonUtils.AssertNotNull("query", query);
            CommonUtils.AssertNotNull("resolver", resolver);
            return query.ExecuteQuerySegmentedAsync(token, table.ServiceClient, table.Name, resolver, requestOptions, operationContext);
        }
        #endregion
    }
}
