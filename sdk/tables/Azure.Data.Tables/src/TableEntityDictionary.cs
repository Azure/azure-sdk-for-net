// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Azure.Core;

namespace Azure.Data.Tables
{

    public class TableEntityDictionary : IDictionary<string, object>
    {
        private readonly IDictionary<string, object> _properties;

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

        public ICollection<string> Keys => _properties.Keys;

        public ICollection<object> Values => _properties.Values;

        public int Count => _properties.Count;

        public bool IsReadOnly => _properties.IsReadOnly;

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

        public string GetString(string key) => GetValue<string>(key);

        public byte[] GetBinary(string key) => GetValue<byte[]>(key);

        public bool GetBoolean(string key) => GetValue<bool>(key);

        public DateTime GetDateTime(string key) => GetValue<DateTime>(key);

        public double GetDouble(string key) => GetValue<double>(key);

        public Guid GetGuid(string key) => GetValue<Guid>(key);

        public int GetInt32(string key) => GetValue<int>(key);

        public long GetInt64(string key) => GetValue<long>(key);

        /// <summary>
        /// Gets or sets the entity's property, given the name of the property.
        /// </summary>
        /// <param name="key">A string containing the name of the property.</param>
        /// <returns>An object.</returns>
        public object this[string key]
        {
            get { return GetValue(key); }
            set { SetValue(key, value); }
        }

        public void Add(string key, object value)
        {
            SetValue(key, value);
        }

        public bool ContainsKey(string key)
        {
            return _properties.ContainsKey(key);
        }

        public bool Remove(string key)
        {
            return _properties.Remove(key);
        }

        public bool TryGetValue(string key, out object value)
        {
            return _properties.TryGetValue(key, out value);
        }

        public void Add(KeyValuePair<string, object> item)
        {
            SetValue(item.Key, item.Value);
        }

        public void Clear()
        {
            _properties.Clear();
        }

        public bool Contains(KeyValuePair<string, object> item)
        {
            return _properties.Contains(item);
        }

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            _properties.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<string, object> item)
        {
            return _properties.Remove(item);
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return _properties.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_properties).GetEnumerator();
        }

        /// <summary>
        /// Set a document property.
        /// </summary>
        /// <param name="key">The property name.</param>
        /// <param name="value">The property value.</param>
        private protected void SetValue(string key, object value)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));

            if (_properties.TryGetValue(key, out object existingValue))
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
        private protected T GetValue<T>(string key) => (T)GetValue(key, typeof(T));

        /// <summary>
        /// Get an entity property.
        /// </summary>
        /// <param name="key">The property name.</param>
        /// <param name="type">The expected type of the property value.</param>
        /// <returns>The value of the property.</returns>
        private protected object GetValue(string key, Type type = null)
        {
            if (!_properties.TryGetValue(key, out object value))
            {
                KeyNotFoundException exception = new KeyNotFoundException(
                    "Could not find a member called '" + key + "' in the document.");
                exception.Data["MissingName"] = key;
                throw exception;
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
        private void EnforceType(Type requestedType, Type givenType)
        {
            if (givenType != requestedType)
            {
                throw new InvalidOperationException(string.Format(
                    CultureInfo.InvariantCulture,
                    "Cannot return {0} type for a {1} typed property.",
                    requestedType,
                    givenType));
            }
        }
    }
}
