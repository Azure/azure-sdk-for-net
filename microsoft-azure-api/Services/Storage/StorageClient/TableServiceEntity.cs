//-----------------------------------------------------------------------
// <copyright file="TableServiceEntity.cs" company="Microsoft">
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
// <summary>
//    Contains code for the TableServiceEntity class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Data.Services.Common;

    /// <summary>
    /// Represents an entity in the Windows Azure Table service.
    /// </summary>
    [CLSCompliant(false)]
    [DataServiceKey("PartitionKey", "RowKey")]
    public abstract class TableServiceEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TableServiceEntity"/> class.
        /// </summary>
        /// <param name="partitionKey">The partition key.</param>
        /// <param name="rowKey">The row key.</param>
        protected TableServiceEntity(string partitionKey, string rowKey)
        {
            this.PartitionKey = partitionKey;
            this.RowKey = rowKey;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableServiceEntity"/> class.
        /// </summary>
        protected TableServiceEntity()
        {
        }

        /// <summary>
        /// Gets or sets the timestamp for the entity.
        /// </summary>
        /// <value>The entity's timestamp.</value>
        public DateTime Timestamp
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the partition key of a table entity.
        /// </summary>
        /// <value>The partition key.</value>
        public virtual string PartitionKey
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the row key of a table entity.
        /// </summary>
        /// <value>The row key.</value>
        public virtual string RowKey
        {
            get;
            set;
        }
    }
}
