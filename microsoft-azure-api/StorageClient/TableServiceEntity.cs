//-----------------------------------------------------------------------
// <copyright file="TableServiceEntity.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
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
