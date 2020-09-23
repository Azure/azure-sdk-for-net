// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Azure.Core;

namespace Azure.Data.Tables
{
    /// <summary>
    /// A <see cref="ITableEntity"/> type which allows callers direct access to the property map of the entity.
    /// </summary>
    public partial class TableEntity : ITableEntity
    {
        private readonly IDictionary<string, object> _properties;

        /// <summary>
        /// The partition key is a unique identifier for the partition within a given table and forms the first part of an entity's primary key.
        /// </summary>
        /// <value>A string containing the partition key for the entity.</value>
        public string PartitionKey
        {
            get { return GetString(TableConstants.PropertyNames.PartitionKey); }
            set { _properties[TableConstants.PropertyNames.PartitionKey] = value; }
        }

        /// <summary>
        /// The row key is a unique identifier for an entity within a given partition. Together the <see cref="PartitionKey" /> and RowKey uniquely identify every entity within a table.
        /// </summary>
        /// <value>A string containing the row key for the entity.</value>
        public string RowKey
        {
            get { return GetString(TableConstants.PropertyNames.RowKey); }
            set { _properties[TableConstants.PropertyNames.RowKey] = value; }
        }

        /// <summary>
        /// The Timestamp property is a DateTime value that is maintained on the server side to record the time an entity was last modified.
        /// The Table service uses the Timestamp property internally to provide optimistic concurrency. The value of Timestamp is a monotonically increasing value,
        /// meaning that each time the entity is modified, the value of Timestamp increases for that entity. This property should not be set on insert or update operations (the value will be ignored).
        /// </summary>
        /// <value>A <see cref="DateTimeOffset"/> containing the timestamp of the entity.</value>
        public DateTimeOffset? Timestamp
        {
            get { return GetValue(TableConstants.PropertyNames.TimeStamp) as DateTimeOffset?; }
            set { _properties[TableConstants.PropertyNames.TimeStamp] = value; }
        }

        /// <summary>
        /// Gets or sets the entity's ETag. Set this value to <see cref="ETag.All"/> in order to force an overwrite to an entity as part of an update operation.
        /// </summary>
        /// <value>An <see cref="ETag"/> containing the ETag value for the entity.</value>
        public ETag ETag
        {
            get { return new ETag(GetString(TableConstants.PropertyNames.EtagOdata)); }
            set { _properties[TableConstants.PropertyNames.EtagOdata] = value.ToString(); }
        }

        /// <summary>
        /// Constructs an instance of a <see cref="ITableEntity" />.
        /// </summary>
        public TableEntity()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableEntity"/> class with the specified partition key and row key.
        /// </summary>
        /// <param name="partitionKey">A string containing the partition key of the <see cref="TableEntity"/> to be initialized.</param>
        /// <param name="rowKey">A string containing the row key of the <see cref="TableEntity"/> to be initialized.</param>
        public TableEntity(string partitionKey, string rowKey)
            : this(null)
        {
            PartitionKey = partitionKey;
            RowKey = rowKey;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableEntity"/> class with properties in the <see cref="IDictionary"/>.
        /// </summary>
        /// <param name="values">A <see cref="IDictionary"/> containing the initial values of the entity.</param>
        public TableEntity(IDictionary<string, object> values)
        {
            _properties = values != null ?
                new Dictionary<string, object>(values) :
                new Dictionary<string, object>();
        }

        /// <summary>
        /// Get the value of a <see cref="TableEntity"/>'s
        /// <see cref="String"/> property called
        /// <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The name of the property.</param>
        /// <returns>The value of the property.</returns>
        /// <exception cref="InvalidOperationException">Value associated with given <paramref name="key"/> is not of type <see cref="string" />.</exception>
        public string GetString(string key) => GetValue<string>(key);

        /// <summary>
        /// Get the value of a <see cref="TableEntity"/>'s
        /// <see cref="byte"/> property called
        /// <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The name of the property.</param>
        /// <returns>The value of the property.</returns>
        /// <exception cref="InvalidOperationException">Value associated with given <paramref name="key"/> is not of type byte array.</exception>
        public byte[] GetBinary(string key) => GetValue<byte[]>(key);

        /// <summary>
        /// Get the value of a <see cref="TableEntity"/>'s
        /// <see cref="String"/> property called
        /// <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The name of the property.</param>
        /// <returns>The value of the property.</returns>
        /// <exception cref="InvalidOperationException">Value associated with given <paramref name="key"/> is not of type <see cref="bool" />.</exception>
        public bool? GetBoolean(string key) => GetValue<bool?>(key);

        /// <summary>
        /// Get the value of a <see cref="TableEntity"/>'s
        /// <see cref="DateTime"/> property called
        /// <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The name of the property.</param>
        /// <returns>The value of the property.</returns>
        /// <exception cref="InvalidOperationException">Value associated with given <paramref name="key"/> is not of type <see cref="DateTime" />.</exception>
        public DateTime? GetDateTime(string key) => GetValue<DateTime?>(key);

        /// <summary>
        /// Get the value of a <see cref="TableEntity"/>'s
        /// <see cref="Double"/> property called
        /// <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The name of the property.</param>
        /// <returns>The value of the property.</returns>
        /// <exception cref="InvalidOperationException">Value associated with given <paramref name="key"/> is not of type <see cref="double" />.</exception>
        public double? GetDouble(string key) => GetValue<double?>(key);

        /// <summary>
        /// Get the value of a <see cref="TableEntity"/>'s
        /// <see cref="Guid"/> property called
        /// <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The name of the property.</param>
        /// <returns>The value of the property.</returns>
        /// <exception cref="InvalidOperationException">Value associated with given <paramref name="key"/> is not of type <see cref="Guid" />.</exception>
        public Guid? GetGuid(string key) => GetValue<Guid?>(key);

        /// <summary>
        /// Get the value of a <see cref="TableEntity"/>'s
        /// <see cref="Int32"/> property called
        /// <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The name of the property.</param>
        /// <returns>The value of the property.</returns>
        /// <exception cref="InvalidOperationException">Value associated with given <paramref name="key"/> is not of type <see cref="int" />.</exception>
        public int? GetInt32(string key) => GetValue<int?>(key);

        /// <summary>
        /// Get the value of a <see cref="TableEntity"/>'s
        /// <see cref="Int64"/> property called
        /// <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The name of the property.</param>
        /// <returns>The value of the property.</returns>
        /// <exception cref="InvalidOperationException">Value associated with given <paramref name="key"/> is not of type <see cref="long" />.</exception>
        public long? GetInt64(string key) => GetValue<long?>(key);

        /// <summary>
        /// Set a document property.
        /// </summary>
        /// <param name="key">The property name.</param>
        /// <param name="value">The property value.</param>
        /// <exception cref="InvalidOperationException">The given <paramref name="value"/> does not match the type of the existing value associated with given <paramref name="key"/>.</exception>
        private protected void SetValue(string key, object value)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));

            if (value != null && _properties.TryGetValue(key, out object existingValue) && existingValue != null)
            {
                EnforceType(existingValue.GetType(), value.GetType());
            }
            _properties[key] = value;
        }

        /// <summary>
        /// Get an entity property.
        /// </summary>
        /// <typeparam name="T">The expected type of the property value.</typeparam>
        /// <param name="key">The property name.</param>
        /// <returns>The value of the property.</returns>
        /// <exception cref="InvalidOperationException">Value associated with given <paramref name="key"/> is not of given type <typeparamref name="T"/>.</exception>
        private protected T GetValue<T>(string key) => (T)GetValue(key, typeof(T));

        /// <summary>
        /// Get an entity property.
        /// </summary>
        /// <param name="key">The property name.</param>
        /// <param name="type">The expected type of the property value.</param>
        /// <returns>The value of the property.</returns>
        /// <exception cref="InvalidOperationException">Value associated with given <paramref name="key"/> is not of type <paramref name="type"/>.</exception>
        private protected object GetValue(string key, Type type = null)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            if (!_properties.TryGetValue(key, out object value) || value == null)
            {
                return null;
            }

            if (type != null)
            {
                EnforceType(type, value.GetType());
            }

            return value;
        }

        /// <summary>
        /// Ensures that the given type matches the type of the existing
        /// property; throws an exception if the types do not match.
        /// </summary>
        private static void EnforceType(Type requestedType, Type givenType)
        {
            if (!requestedType.IsAssignableFrom(givenType))
            {
                throw new InvalidOperationException(string.Format(
                    CultureInfo.InvariantCulture,
                    $"Cannot return {requestedType} type for a {givenType} typed property."));
            }
        }
    }
}
