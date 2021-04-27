// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Data.Tables
{
    /// <summary>
    /// An interface defining the required properties for a table entity model. Custom entity model types must implement this interface.
    /// </summary>
    ///
    /// <remarks>
    /// Two options exist for impelemtations of <see cref="ITableEntity"/>: Strongly typed custom entity model classes, and the provided <see cref="TableEntity"/> model.
    /// </remarks>
    public interface ITableEntity
    {
        /// <summary>
        /// The partition key is a unique identifier for the partition within a given table and forms the first part of an entity's primary key.
        /// </summary>
        /// <value>A string containing the partition key for the entity.</value>
        string PartitionKey { get; set; }

        /// <summary>
        /// The row key is a unique identifier for an entity within a given partition. Together the <see cref="PartitionKey" /> and RowKey uniquely identify every entity within a table.
        /// </summary>
        /// <value>A string containing the row key for the entity.</value>
        string RowKey { get; set; }

        /// <summary>
        /// The Timestamp property is a DateTime value that is maintained on the server side to record the time an entity was last modified.
        /// The Table service uses the Timestamp property internally to provide optimistic concurrency. The value of Timestamp is a monotonically increasing value,
        /// meaning that each time the entity is modified, the value of Timestamp increases for that entity. This property should not be set on insert or update operations (the value will be ignored).
        /// </summary>
        /// <value>A <see cref="DateTimeOffset"/> containing the timestamp of the entity.</value>
        DateTimeOffset? Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the entity's ETag. Set this value to '*' in order to force an overwrite to an entity as part of an update operation.
        /// </summary>
        /// <value>A string containing the ETag value for the entity.</value>
        ETag ETag { get; set; }
    }
}
