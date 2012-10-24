// -----------------------------------------------------------------------------------------
// <copyright file="TableBatchOperationBase.cs" company="Microsoft">
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
    using System.Net;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using Microsoft.WindowsAzure.Storage.Table.Protocol;

    /// <summary>
    /// Represents a batch operation on a table.
    /// </summary>
    /// <remarks><para>A batch operation is a collection of table operations which are executed by the Storage Service REST API as a single atomic operation, by invoking an 
    /// <a href="http://msdn.microsoft.com/en-us/library/windowsazure/dd894038.aspx">Entity Group Transaction</a>.</para><para>A batch operation may contain up to 100 individual 
    /// table operations, with the requirement that each operation entity must have same partition key. A batch with a retrieve operation cannot contain any other operations. 
    /// Note that the total payload of a batch operation is limited to 4MB.</para></remarks>
    public sealed partial class TableBatchOperation : IList<TableOperation>
    {
        private bool hasQuery = false;
        private string partitionKey = null;
        private List<TableOperation> operations = new List<TableOperation>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TableBatchOperation"/> class.
        /// </summary>
        public TableBatchOperation()
        {
        }

        #region Operation Factories

        /// <summary>
        /// Adds a <see cref="TableOperation"/> to the <see cref="TableBatchOperation"/> that deletes the specified entity from a table.
        /// </summary>
        /// <param name="entity">The entity to be deleted from the table.</param>
        public void Delete(ITableEntity entity)
        {
            // Validate the arguments.
            CommonUtils.AssertNotNull("entity", entity);

            // Delete requires an ETag.
            if (string.IsNullOrEmpty(entity.ETag))
            {
                throw new ArgumentException(SR.ETagMissingForDelete);
            }

            // Add the table operation.
            this.Add(new TableOperation(entity, TableOperationType.Delete));
        }

        /// <summary>
        /// Adds a <see cref="TableOperation"/> to the <see cref="TableBatchOperation"/> that inserts the specified entity into a table.
        /// </summary>
        /// <param name="entity">The entity to be inserted into the table.</param>
        public void Insert(ITableEntity entity)
        {
            // Validate the arguments.
            CommonUtils.AssertNotNull("entity", entity);

            // Add the table operation.
            this.Add(new TableOperation(entity, TableOperationType.Insert));
        }

        /// <summary>
        /// Adds a <see cref="TableOperation"/> to the <see cref="TableBatchOperation"/> that inserts the specified entity into a table if the entity does not exist; if the entity does exist then its contents are merged with the provided entity.
        /// </summary>
        /// <param name="entity">The entity whose contents are being inserted or merged.</param>
        public void InsertOrMerge(ITableEntity entity)
        {
            // Validate the arguments.
            CommonUtils.AssertNotNull("entity", entity);

            // Add the table operation.
            this.Add(new TableOperation(entity, TableOperationType.InsertOrMerge));
        }

        /// <summary>
        /// Adds a <see cref="TableOperation"/> to the <see cref="TableBatchOperation"/> that inserts the specified entity into a table if the entity does not exist; if the entity does exist then its contents are replaced with the provided entity.
        /// </summary>
        /// <param name="entity">The entity whose contents are being inserted or replaced.</param>
        public void InsertOrReplace(ITableEntity entity)
        {
            // Validate the arguments.
            CommonUtils.AssertNotNull("entity", entity);

            // Add the table operation.
            this.Add(new TableOperation(entity, TableOperationType.InsertOrReplace));
        }

        /// <summary>
        /// Adds a <see cref="TableOperation"/> to the <see cref="TableBatchOperation"/> that merges the contents of the specified entity with the existing entity in a table.
        /// </summary>
        /// <param name="entity">The entity whose contents are being merged.</param>
        public void Merge(ITableEntity entity)
        {
            // Validate the arguments.
            CommonUtils.AssertNotNull("entity", entity);

            // Merge requires an ETag.
            if (string.IsNullOrEmpty(entity.ETag))
            {
                throw new ArgumentException(SR.ETagMissingForMerge);
            }

            // Add the table operation.
            this.Add(new TableOperation(entity, TableOperationType.Merge));
        }

        /// <summary>
        /// Adds a <see cref="TableOperation"/> to the <see cref="TableBatchOperation"/> that replaces the contents of the specified entity in a table.
        /// </summary>
        /// <param name="entity">The entity whose contents are being replaced.</param>
        public void Replace(ITableEntity entity)
        {
            // Validate the arguments.
            CommonUtils.AssertNotNull("entity", entity);

            // Replace requires an ETag.
            if (string.IsNullOrEmpty(entity.ETag))
            {
                throw new ArgumentException(SR.ETagMissingForReplace);
            }

            // Add the table operation.
            this.Add(new TableOperation(entity, TableOperationType.Replace));
        }

        /// <summary>
        /// CAdds a <see cref="TableOperation"/> to the <see cref="TableBatchOperation"/> that retrieves an entity with the specified partition key and row key.
        /// </summary>
        /// <param name="partitionKey">A string containing the partition key of the entity to retrieve.</param>
        /// <param name="rowkey">A string containing the row key of the entity to retrieve.</param>
        public void Retrieve(string partitionKey, string rowkey)
        {
            CommonUtils.AssertNotNull("partitionKey", partitionKey);
            CommonUtils.AssertNotNull("rowkey", rowkey);

            // Add the table operation.
            this.Add(new TableOperation(null /* entity */, TableOperationType.Retrieve) { RetrievePartitionKey = partitionKey, RetrieveRowKey = rowkey });
        }
        #endregion

        #region IList

        /// <summary>
        /// Returns the zero-based index of the first occurrence of the specified <see cref="TableOperation"/> item, or -1 if the <see cref="TableBatchOperation"/> does not contain the item.
        /// </summary>
        /// <param name="item">The <see cref="TableOperation"/> item to search for.</param>
        /// <returns>The zero-based index of the first occurrence of item within the <see cref="TableBatchOperation"/>, if found; otherwise, –1.</returns>
        public int IndexOf(TableOperation item)
        {
            return this.operations.IndexOf(item);
        }

        /// <summary>
        /// Inserts a <see cref="TableOperation"/> into the <see cref="TableBatchOperation"/> at the specified index.
        /// </summary>
        /// <param name="index">The index at which to insert the <see cref="TableOperation"/>.</param>
        /// <param name="item">The <see cref="TableOperation"/> item to insert.</param>
        public void Insert(int index, TableOperation item)
        {
            CommonUtils.AssertNotNull("item", item);
            this.CheckSingleQueryPerBatch(item);
            this.LockToPartitionKey(item.OperationType == TableOperationType.Retrieve ? item.RetrievePartitionKey : item.Entity.PartitionKey);

            this.operations.Insert(index, item);
        }

        /// <summary>
        /// Removes the <see cref="TableOperation"/> at the specified index from the <see cref="TableBatchOperation"/>.
        /// </summary>
        /// <param name="index">The index of the <see cref="TableOperation"/> to remove from the <see cref="TableBatchOperation"/>.</param>
        public void RemoveAt(int index)
        {
            this.operations.RemoveAt(index);

            if (this.operations.Count == 0)
            {
                this.partitionKey = null;
                this.hasQuery = false;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="TableOperation"/> item at the specified index.
        /// </summary>
        /// <param name="index">The index at which to get or set the TableOperation.</param>
        /// <returns>The <see cref="TableOperation"/> item at the specified index.</returns>
        public TableOperation this[int index]
        {
            get
            {
                return this.operations[index];
            }

            set
            {
                throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Adds the <see cref="TableOperation"/> to the <see cref="TableBatchOperation"/>.
        /// </summary>
        /// <param name="item">The <see cref="TableOperation"/> item to add to the <see cref="TableBatchOperation"/>.</param>
        public void Add(TableOperation item)
        {
            CommonUtils.AssertNotNull("item", item);
            this.CheckSingleQueryPerBatch(item);
            this.LockToPartitionKey(item.OperationType == TableOperationType.Retrieve ? item.RetrievePartitionKey : item.Entity.PartitionKey);

            this.operations.Add(item);
        }

        /// <summary>
        /// Clears all <see cref="TableOperation"/> objects from the <see cref="TableBatchOperation"/>.
        /// </summary>
        public void Clear()
        {
            this.operations.Clear();
            this.partitionKey = null;
            this.hasQuery = false;
        }

        /// <summary>
        /// Returns <code>true</code> if this <see cref="TableBatchOperation"/> contains the specified element.
        /// </summary>
        /// <param name="item">The <see cref="TableOperation"/> item to search for.</param>
        /// <returns><code>true</code> if the item is contained in the <see cref="TableBatchOperation"/>; <code>false</code>, otherwise.</returns>
        public bool Contains(TableOperation item)
        {
            return this.operations.Contains(item);
        }

        /// <summary>
        /// Copies all the elements of the <see cref="TableBatchOperation"/> to the specified one-dimensional array starting at the specified destination array index. 
        /// </summary>
        /// <param name="array">The one-dimensional array that is the destination of the elements copied from the <see cref="TableBatchOperation"/>.</param>
        /// <param name="arrayIndex">The index in the destination array at which copying begins.</param>
        public void CopyTo(TableOperation[] array, int arrayIndex)
        {
            this.operations.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Gets the number of operations in this <see cref="TableBatchOperation"/>.
        /// </summary>
        /// <value>The number of operations in the <see cref="TableBatchOperation"/>.</value>
        public int Count
        {
            get { return this.operations.Count; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="TableBatchOperation"/> is read-only.
        /// </summary>
        /// <value><code>true</code> if the <see cref="TableBatchOperation"/> is read-only; <code>false</code>, otherwise.</value>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Removes the specified <see cref="TableOperation"/> item from the <see cref="TableBatchOperation"/>.
        /// </summary>
        /// <param name="item">The <see cref="TableOperation"/> item to remove.</param>
        /// <returns><code>true</code> if the item was successfully removed; <code>false</code>, otherwise.</returns>
        public bool Remove(TableOperation item)
        {
            CommonUtils.AssertNotNull("item", item);

            bool retVal = this.operations.Remove(item);

            if (this.operations.Count == 0)
            {
                this.partitionKey = null;
                this.hasQuery = false;
            }

            return retVal;
        }

        /// <summary>
        /// Returns an <see cref="IEnumerator"/> for the <see cref="TableBatchOperation"/>.
        /// </summary>
        /// <returns>An enumerable collection of <see cref="TableOperation"/> items.</returns>
        public IEnumerator<TableOperation> GetEnumerator()
        {
            return this.operations.GetEnumerator();
        }

        /// <summary>
        /// Returns an <see cref="IEnumerator"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerator"/> for the <see cref="TableBatchOperation"/>.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.operations.GetEnumerator();
        }
        #endregion

        #region Private Validators
        private void CheckSingleQueryPerBatch(TableOperation item)
        {
            if (this.hasQuery)
            {
                throw new ArgumentException(SR.BatchWithRetreiveContainsOtherOperations);
            }

            if (item.OperationType == TableOperationType.Retrieve)
            {
                if (this.operations.Count > 0)
                {
                    throw new ArgumentException(SR.BatchWithRetreiveContainsOtherOperations);
                }
                else
                {
                    this.hasQuery = true;
                }
            }
        }

        private void LockToPartitionKey(string partitionKey)
        {
            if (this.partitionKey == null)
            {
                this.partitionKey = partitionKey;
            }
            else
            {
                if (partitionKey != this.partitionKey)
                {
                    throw new ArgumentException(SR.PartitionKey);
                }
            }
        }

        #endregion
    }
}
