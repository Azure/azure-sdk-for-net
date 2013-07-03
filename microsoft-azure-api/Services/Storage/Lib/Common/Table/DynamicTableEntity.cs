// -----------------------------------------------------------------------------------------
// <copyright file="DynamicTableEntity.cs" company="Microsoft">
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
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// A <see cref="ITableEntity"/> type which allows callers direct access to the property map of the entity. This class eliminates the use of reflection for serialization and deserialization.
    /// </summary>    
    public sealed class DynamicTableEntity : ITableEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicTableEntity"/> class.
        /// </summary>
        public DynamicTableEntity()
        {
            this.Properties = new Dictionary<string, EntityProperty>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicTableEntity"/> class with the specified partition key and row key.
        /// </summary>
        /// <param name="partitionKey">The partition key value for the entity.</param>
        /// <param name="rowKey">The row key value for the entity.</param>
        public DynamicTableEntity(string partitionKey, string rowKey)
            : this(partitionKey, rowKey, DateTimeOffset.MinValue, null /* timestamp */, new Dictionary<string, EntityProperty>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicTableEntity"/> class with the entity's partition key, row key, ETag (if available/required), and properties.
        /// </summary>
        /// <param name="partitionKey">The entity's partition key.</param>
        /// <param name="rowKey">The entity's row key.</param>
        /// <param name="etag">The entity's current ETag.</param>
        /// <param name="properties">The entity's properties, indexed by property name.</param>
        public DynamicTableEntity(string partitionKey, string rowKey, string etag, IDictionary<string, EntityProperty> properties)
            : this(partitionKey, rowKey, DateTimeOffset.MinValue, etag, properties)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicTableEntity"/> class with the entity's partition key, row key, time stamp, ETag (if available/required), and properties.
        /// </summary>
        /// <param name="partitionKey">The entity's partition key.</param>
        /// <param name="rowKey">The entity's row key.</param>
        /// <param name="timestamp">The timestamp for this entity as returned by Windows Azure.</param>
        /// <param name="etag">The entity's current ETag; set to null to ignore the ETag during subsequent update operations.</param>
        /// <param name="properties">An <see cref="IDictionary{TKey,TElement}"/> containing a map of <see cref="string"/> property names to <see cref="EntityProperty"/> data typed values to store in the new <see cref="DynamicTableEntity"/>.</param>
        internal DynamicTableEntity(string partitionKey, string rowKey, DateTimeOffset timestamp, string etag, IDictionary<string, EntityProperty> properties)
        {
            CommonUtility.AssertNotNull("partitionKey", partitionKey);
            CommonUtility.AssertNotNull("rowKey", rowKey);
            CommonUtility.AssertNotNull("properties", properties);

            // Store the information about this entity.  Make a copy of
            // the properties list, in case the caller decides to reuse
            // the list.
            this.PartitionKey = partitionKey;
            this.RowKey = rowKey;
            this.Timestamp = timestamp;
            this.ETag = etag;

            this.Properties = properties;
        }

        /// <summary>
        /// Gets or sets the properties in the table entity, indexed by property name.
        /// </summary>
        /// <value>The entity properties.</value>
        public IDictionary<string, EntityProperty> Properties { get; set; }

        /// <summary>
        /// Gets or sets the entity's partition key.
        /// </summary>
        /// <value>The entity partition key.</value>
        public string PartitionKey { get; set; }

        /// <summary>
        /// Gets or sets the entity's row key.
        /// </summary>
        /// <value>The entity row key.</value>
        public string RowKey { get; set; }

        /// <summary>
        /// Gets or sets the entity's time stamp.
        /// </summary>
        /// <value>The entity time stamp.</value>
        public DateTimeOffset Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the entity's current ETag.  Set this value to '*' in order to blindly overwrite an entity as part of an update operation.
        /// </summary>
        /// <value>The entity Etag.</value>
        public string ETag { get; set; }

#if !WINDOWS_RT
        /// <summary>
        /// Gets or sets the entity's property, given the name of the property.
        /// </summary>
        /// <param name="key">The name of the property.</param>
        /// <returns>The property.</returns>
        public EntityProperty this[string key]
        {
            get { return this.Properties[key]; }
            set { this.Properties[key] = value; }
        }
#endif

        /// <summary>
        /// Deserializes this <see cref="DynamicTableEntity"/> instance using the specified <see cref="Dictionary{TKey,TValue}"/> of property names to <see cref="EntityProperty"/> data typed values.
        /// </summary>
        /// <param name="properties">A collection containing the <see cref="Dictionary{TKey,TValue}"/> of string property names mapped to <see cref="EntityProperty"/> data typed values to store in this <see cref="DynamicTableEntity"/> instance.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object used to track the execution of the operation.</param>
        public void ReadEntity(IDictionary<string, EntityProperty> properties, OperationContext operationContext)
        {
            this.Properties = properties;
        }

        /// <summary>
        /// Serializes the <see cref="Dictionary{TKey,TValue}"/> of property names mapped to <see cref="EntityProperty"/> data values from this <see cref="DynamicTableEntity"/> instance.
        /// </summary>
        /// <param name="operationContext">An <see cref="OperationContext"/> object used to track the execution of the operation.</param>
        /// <returns>A collection containing the map of <c>string</c> property names to <see cref="EntityProperty"/> data typed values stored in this <see cref="DynamicTableEntity"/> instance.</returns>
        public IDictionary<string, EntityProperty> WriteEntity(OperationContext operationContext)
        {
            return this.Properties;
        }
    }
}