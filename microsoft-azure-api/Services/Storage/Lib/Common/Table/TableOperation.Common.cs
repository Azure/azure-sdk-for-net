// -----------------------------------------------------------------------------------------
// <copyright file="TableOperation.Common.cs" company="Microsoft">
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
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Table.Protocol;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;

    /// <summary>
    /// Represents a single table operation.
    /// </summary>
    public sealed partial class TableOperation
    {
        /// <summary>
        /// Creates a new instance of the TableOperation class given the
        /// entity to operate on and the type of operation that is being
        /// performed.
        /// </summary>
        /// <param name="entity">The entity that is being operated upon.</param>
        /// <param name="operationType">The type of operation.</param>
        internal TableOperation(ITableEntity entity, TableOperationType operationType)
        {
            if (entity == null && operationType != TableOperationType.Retrieve)
            {
                throw new ArgumentNullException("entity");
            }

            this.Entity = entity;
            this.OperationType = operationType;
        }

        private bool isTableEntity = false;

        internal bool IsTableEntity
        {
            get { return this.isTableEntity; }
            set { this.isTableEntity = value; }
        }

        // Retrieve operation, typically this would be in a derived class, but since we want to export to winmd, it is specialized via the below locals
        internal string RetrievePartitionKey { get; set; }

        internal string RetrieveRowKey { get; set; }

        private Func<string, string, DateTimeOffset, IDictionary<string, EntityProperty>, string, object> retrieveResolver = DynamicEntityResolver;

        internal Func<string, string, DateTimeOffset, IDictionary<string, EntityProperty>, string, object> RetrieveResolver
        {
            get { return this.retrieveResolver; }
            set { this.retrieveResolver = value; }
        }

        /// <summary>
        /// Gets the entity that is being operated upon.
        /// </summary>
        internal ITableEntity Entity { get; private set; }

        /// <summary>
        /// Gets the type of operation.
        /// </summary>
        internal TableOperationType OperationType { get; private set; }

        /// <summary>
        /// Creates a new table operation that deletes the given entity
        /// from a table.
        /// </summary>
        /// <param name="entity">The entity to be deleted from the table.</param>
        /// <returns>The table operation.</returns>
        public static TableOperation Delete(ITableEntity entity)
        {
            // Validate the arguments.
            CommonUtility.AssertNotNull("entity", entity);

            // Delete requires an ETag.
            if (string.IsNullOrEmpty(entity.ETag))
            {
                throw new ArgumentException(SR.ETagMissingForDelete);
            }

            // Create and return the table operation.
            return new TableOperation(entity, TableOperationType.Delete);
        }

        /// <summary>
        /// Creates a new table operation that inserts the given entity
        /// into a table.
        /// </summary>
        /// <param name="entity">The entity to be inserted into the table.</param>
        /// <returns>The table operation.</returns>
        public static TableOperation Insert(ITableEntity entity)
        {
            // Validate the arguments.
            CommonUtility.AssertNotNull("entity", entity);

            // Create and return the table operation.
            return new TableOperation(entity, TableOperationType.Insert);
        }

        /// <summary>
        /// Creates a new table operation that inserts the given entity
        /// into a table if the entity does not exist; if the entity does
        /// exist then its contents are merged with the provided entity.
        /// </summary>
        /// <param name="entity">The entity whose contents are being inserted
        /// or merged.</param>
        /// <returns>The table operation.</returns>
        public static TableOperation InsertOrMerge(ITableEntity entity)
        {
            // Validate the arguments.
            CommonUtility.AssertNotNull("entity", entity);

            // Create and return the table operation.
            return new TableOperation(entity, TableOperationType.InsertOrMerge);
        }

        /// <summary>
        /// Creates a new table operation that inserts the given entity
        /// into a table if the entity does not exist; if the entity does
        /// exist then its contents are replaced with the provided entity.
        /// </summary>
        /// <param name="entity">The entity whose contents are being inserted
        /// or replaced.</param>
        /// <returns>The table operation.</returns>
        public static TableOperation InsertOrReplace(ITableEntity entity)
        {
            // Validate the arguments.
            CommonUtility.AssertNotNull("entity", entity);

            // Create and return the table operation.
            return new TableOperation(entity, TableOperationType.InsertOrReplace);
        }

        /// <summary>
        /// Creates a new table operation that merges the contents of
        /// the given entity with the existing entity in a table.
        /// </summary>
        /// <param name="entity">The entity whose contents are being merged.</param>
        /// <returns>The table operation.</returns>
        public static TableOperation Merge(ITableEntity entity)
        {
            // Validate the arguments.
            CommonUtility.AssertNotNull("entity", entity);

            // Merge requires an ETag.
            if (string.IsNullOrEmpty(entity.ETag))
            {
                throw new ArgumentException(SR.ETagMissingForMerge);
            }

            // Create and return the table operation.
            return new TableOperation(entity, TableOperationType.Merge);
        }

        /// <summary>
        /// Creates a new table operation that replaces the contents of
        /// the given entity in a table.
        /// </summary>
        /// <param name="entity">The entity whose contents are being replaced.</param>
        /// <returns>The table operation.</returns>
        public static TableOperation Replace(ITableEntity entity)
        {
            // Validate the arguments.
            CommonUtility.AssertNotNull("entity", entity);

            // Replace requires an ETag.
            if (string.IsNullOrEmpty(entity.ETag))
            {
                throw new ArgumentException(SR.ETagMissingForReplace);
            }

            // Create and return the table operation.
            return new TableOperation(entity, TableOperationType.Replace);
        }

        /// <summary>
        /// Creates a new table operation that replaces the contents of
        /// the given entity in a table.
        /// </summary>
        /// <param name="partitionKey">The partition key of the entity to be replaced.</param>
        /// <param name="rowkey">The row key of the entity to be replaced.</param>
        /// <returns>The table operation.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "rowkey", Justification = "Reviewed : rowkey is allowed.")]
        public static TableOperation Retrieve(string partitionKey, string rowkey)
        {
            CommonUtility.AssertNotNull("partitionKey", partitionKey);
            CommonUtility.AssertNotNull("rowkey", rowkey);

            // Create and return the table operation.
            return new TableOperation(null /* entity */, TableOperationType.Retrieve) { RetrievePartitionKey = partitionKey, RetrieveRowKey = rowkey };
        }

        private static object DynamicEntityResolver(string partitionKey, string rowKey, DateTimeOffset timestamp, IDictionary<string, EntityProperty> properties, string etag)
        {
            ITableEntity entity = new DynamicTableEntity();

            entity.PartitionKey = partitionKey;
            entity.RowKey = rowKey;
            entity.Timestamp = timestamp;
            entity.ReadEntity(properties, null);
            entity.ETag = etag;

            return entity;
        }

        internal Uri GenerateRequestURI(Uri baseUri, string tableName)
        {
            if (this.OperationType == TableOperationType.Insert)
            {
                return NavigationHelper.AppendPathToUri(baseUri, tableName + "()");
            }
            else
            {
                string identity = null;
                if (this.isTableEntity)
                {
                    // Note tableEntity is only used internally, so we can assume operationContext is not needed
                    identity = string.Format(CultureInfo.InvariantCulture, "'{0}'", this.Entity.WriteEntity(null /* OperationContext  */)[TableConstants.TableName].StringValue);
                }
                else if (this.OperationType == TableOperationType.Retrieve)
                {
                    identity = string.Format(CultureInfo.InvariantCulture, "{0}='{1}',{2}='{3}'", TableConstants.PartitionKey, this.RetrievePartitionKey, TableConstants.RowKey, this.RetrieveRowKey);
                }
                else
                {
                    identity = string.Format(CultureInfo.InvariantCulture, "{0}='{1}',{2}='{3}'", TableConstants.PartitionKey, this.Entity.PartitionKey, TableConstants.RowKey, this.Entity.RowKey);
                }

                return NavigationHelper.AppendPathToUri(baseUri, string.Format(CultureInfo.InvariantCulture, "{0}({1})", tableName, identity));
            }
        }
    }
}
