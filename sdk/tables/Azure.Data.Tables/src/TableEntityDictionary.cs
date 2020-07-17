// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Data.Tables
{

    public class TableEntityDictionary
    {
        /// <summary>
        /// The partition key is a unique identifier for the partition within a given table and forms the first part of an entity's primary key.
        /// </summary>
        /// <value>A string containing the partition key for the entity.</value>
        public string PartitionKey
        {
            get { return (string)_properties[TableConstants.PropertyNames.PartitionKey]; }
            set { _properties[TableConstants.PropertyNames.PartitionKey] = value; }
        }

        /// <summary>
        /// The row key is a unique identifier for an entity within a given partition. Together the <see cref="PartitionKey" /> and RowKey uniquely identify every entity within a table.
        /// </summary>
        /// <value>A string containing the row key for the entity.</value>
        public string RowKey
        {
            get { return (string)_properties[TableConstants.PropertyNames.RowKey]; }
            set { _properties[TableConstants.PropertyNames.RowKey] = value; }
        }

        /// <summary>
        /// The Timestamp property is a DateTime value that is maintained on the server side to record the time an entity was last modified.
        /// The Table service uses the Timestamp property internally to provide optimistic concurrency. The value of Timestamp is a monotonically increasing value,
        /// meaning that each time the entity is modified, the value of Timestamp increases for that entity. This property should not be set on insert or update operations (the value will be ignored).
        /// </summary>
        /// <value>A <see cref="DateTimeOffset"/> containing the timestamp of the entity.</value>
        public DateTimeOffset Timestamp
        {
            get { return (DateTimeOffset)_properties[TableConstants.PropertyNames.TimeStamp]; }
            set { _properties[TableConstants.PropertyNames.TimeStamp] = value; }
        }

        /// <summary>
        /// Gets or sets the entity's ETag. Set this value to '*' in order to force an overwrite to an entity as part of an update operation.
        /// </summary>
        /// <value>A string containing the ETag value for the entity.</value>
        public string ETag
        {
            get { return (string)_properties[TableConstants.PropertyNames.Etag]; }
            set { _properties[TableConstants.PropertyNames.Etag] = value; }
        }

        private Dictionary<string, object> _properties;

        /// <summary>
        /// Constructs an instance of a <see cref="TableEntity" />.
        /// </summary>
        public TableEntityDictionary()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableEntity"/> class with the specified partition key and row key.
        /// </summary>
        /// <param name="partitionKey">A string containing the partition key of the <see cref="TableEntity"/> to be initialized.</param>
        /// <param name="rowKey">A string containing the row key of the <see cref="TableEntity"/> to be initialized.</param>
        public TableEntityDictionary(string partitionKey, string rowKey)
        {
            PartitionKey = partitionKey;
            RowKey = rowKey;
        }

        /// <summary>
        /// Gets or sets the entity's property, given the name of the property.
        /// </summary>
        /// <param name="key">A string containing the name of the property.</param>
        /// <returns>An object.</returns>
        public object this[string key]
        {
            get { return _properties[key]; }
            set { _properties[key] = value; }
        }
    }
}
