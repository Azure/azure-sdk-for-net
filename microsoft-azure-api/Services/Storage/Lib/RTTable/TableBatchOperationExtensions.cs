// -----------------------------------------------------------------------------------------
// <copyright file="TableBatchOperationExtensions.cs" company="Microsoft">
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
    using Microsoft.WindowsAzure.Storage.Core.Util;

    /// <summary>
    /// Defines the extension methods to the <see cref="TableBatchOperation"/> class. This is a static class.
    /// </summary>
    public static class TableBatchOperationExtensions
    {
        /// <summary>
        /// Adds a table operation that retrieves an entity with the specified partition key and row key to the batch operation.  The entity will be de-serialized into the specified class type which extends <see cref="ITableEntity"/>.
        /// </summary>
        /// <typeparam name="TElement">The class of type for the entity to retrieve.</typeparam>
        /// <param name="batch">The input <see cref="TableBatchOperation"/>, which acts as the <c>this</c> instance for the extension method.</param>
        /// <param name="partitionKey">A string containing the partition key of the entity to be retrieved.</param>
        /// <param name="rowkey">A string containing the row key of the entity to be retrieved.</param>
        public static void Retrieve<TElement>(this TableBatchOperation batch, string partitionKey, string rowkey) where TElement : ITableEntity
        {
            CommonUtils.AssertNotNull("partitionKey", partitionKey);
            CommonUtils.AssertNotNull("rowkey", rowkey);
            
            // Add the table operation.
            batch.Add(new TableOperation(null /* entity */, TableOperationType.Retrieve) { RetrievePartitionKey = partitionKey, RetrieveRowKey = rowkey, RetrieveResolver = (pk, rk, ts, prop, etag) => EntityUtilities.ResolveEntityByType<TElement>(pk, rk, ts, prop, etag) });
        }

        /// <summary>
        /// Adds a table operation that retrieves an entity with the specified partition key and row key to the batch operation.
        /// </summary>
        /// <typeparam name="R">The return type which the specified <see cref="EntityResolver"/> will resolve the given entity to.</typeparam>
        /// <param name="batch">The input <see cref="TableBatchOperation"/>, which acts as the <c>this</c> instance for the extension method.</param>
        /// <param name="partitionKey">A string containing the partition key of the entity to be retrieved.</param>
        /// <param name="rowkey">A string containing the row key of the entity to be retrieved.</param>
        /// <param name="resolver">The <see cref="EntityResolver{R}"/> implementation to project the entity to retrieve as a particular type in the result.</param>
        public static void Retrieve<R>(this TableBatchOperation batch, string partitionKey, string rowkey, EntityResolver<R> resolver)
        {
            CommonUtils.AssertNotNull("partitionKey", partitionKey);
            CommonUtils.AssertNotNull("rowkey", rowkey);

            // Add the table operation.
            batch.Add(new TableOperation(null /* entity */, TableOperationType.Retrieve) { RetrievePartitionKey = partitionKey, RetrieveRowKey = rowkey, RetrieveResolver = (pk, rk, ts, prop, etag) => resolver(pk, rk, ts, prop, etag) });
        }
    }
}
