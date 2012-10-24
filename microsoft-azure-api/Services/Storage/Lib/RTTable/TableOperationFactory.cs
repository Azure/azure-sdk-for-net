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

    public static class TableOperationFactory
    {
        /// <summary>
        /// Creates a new table operation that replaces the contents of
        /// the given entity in a table.
        /// </summary>
        /// <param name="entity">The entity whose contents are being replaced.</param>
        /// <returns>The table operation.</returns>
        public static TableOperation Retrieve<TElement>(string partitionKey, string rowkey) where TElement : ITableEntity
        {
            CommonUtils.AssertNotNull("partitionKey", partitionKey);
            CommonUtils.AssertNotNull("rowkey", rowkey);

            // Create and return the table operation.
            return new TableOperation(null /* entity */, TableOperationType.Retrieve) { RetrievePartitionKey = partitionKey, RetrieveRowKey = rowkey, RetrieveResolver = (pk, rk, ts, prop, etag) => EntityUtilities.ResolveEntityByType<TElement>(pk, rk, ts, prop, etag) };
        }

        /// <summary>
        /// Creates a new table operation that replaces the contents of
        /// the given entity in a table.
        /// </summary>
        /// <param name="entity">The entity whose contents are being replaced.</param>
        /// <returns>The table operation.</returns>
        public static TableOperation Retrieve<R>(string partitionKey, string rowkey, EntityResolver<R> resolver)
        {
            CommonUtils.AssertNotNull("partitionKey", partitionKey);
            CommonUtils.AssertNotNull("rowkey", rowkey);

            // Create and return the table operation.
            return new TableOperation(null /* entity */, TableOperationType.Retrieve) { RetrievePartitionKey = partitionKey, RetrieveRowKey = rowkey, RetrieveResolver = (pk, rk, ts, prop, etag) => resolver(pk, rk, ts, prop, etag) };
        }
    }
}