// -----------------------------------------------------------------------------------------
// <copyright file="TableOperationFactory.cs" company="Microsoft">
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
    /// Contains factory methods for creating <see cref="TableOperation"/> objects.
    /// </summary>
    public static class TableOperationFactory
    {
        /// <summary>
        /// Creates a new <see cref="TableOperation"/> object that retrieves an entity with the specified partition key and row key. The entity will be deserialized into the specified class type which extends <see cref="ITableEntity"/>.
        /// </summary>
        /// <param name="partitionKey">A string containing the partition key of the entity to be retrieved.</param>
        /// <param name="rowkey">A string containing the row key of the entity to be retrieved.</param>
        /// <typeparam name="TElement">The class of type for the entity to retrieve.</typeparam>
        /// <returns>A new <see cref="TableOperation"/> object.</returns>
        public static TableOperation Retrieve<TElement>(string partitionKey, string rowkey) where TElement : ITableEntity
        {
            CommonUtility.AssertNotNull("partitionKey", partitionKey);
            CommonUtility.AssertNotNull("rowkey", rowkey);

            // Create and return the table operation.
            return new TableOperation(null /* entity */, TableOperationType.Retrieve) { RetrievePartitionKey = partitionKey, RetrieveRowKey = rowkey, RetrieveResolver = (pk, rk, ts, prop, etag) => EntityUtilities.ResolveEntityByType<TElement>(pk, rk, ts, prop, etag) };
        }

        /// <summary>
        /// Creates a new <see cref="TableOperation"/> object that retrieves an entity with the specified partition key and row key.
        /// </summary>
        /// <param name="partitionKey">A string containing the partition key of the entity to be retrieved.</param>
        /// <param name="rowkey">A string containing the row key of the entity to be retrieved.</param>
        /// <param name="resolver">The <see cref="EntityResolver{R}"/> implementation to project the entity to retrieve as a particular type in the result.</param>
        /// <typeparam name="TResult">The return type which the specified <see cref="EntityResolver{T}"/> will resolve the given entity to.</typeparam>
        /// <returns>A new <see cref="TableOperation"/> object.</returns>
        public static TableOperation Retrieve<TResult>(string partitionKey, string rowkey, EntityResolver<TResult> resolver)
        {
            CommonUtility.AssertNotNull("partitionKey", partitionKey);
            CommonUtility.AssertNotNull("rowkey", rowkey);

            // Create and return the table operation.
            return new TableOperation(null /* entity */, TableOperationType.Retrieve) { RetrievePartitionKey = partitionKey, RetrieveRowKey = rowkey, RetrieveResolver = (pk, rk, ts, prop, etag) => resolver(pk, rk, ts, prop, etag) };
        }
    }
}