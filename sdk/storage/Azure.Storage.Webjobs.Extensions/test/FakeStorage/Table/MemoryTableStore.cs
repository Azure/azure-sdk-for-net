// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.Azure.Cosmos.Table;

using TableResolver = System.Func<string, string, System.DateTimeOffset, System.Collections.Generic.IDictionary<string, Microsoft.Azure.Cosmos.Table.EntityProperty>, string, object>;

namespace FakeStorage
{
    public class MemoryTableStore
    {
        private readonly ConcurrentDictionary<string, Table> _items = new ConcurrentDictionary<string, Table>();

        public void CreateIfNotExists(string tableName)
        {
            _items.AddOrUpdate(tableName, new Table(), (_, existing) => existing);
        }

        public IQueryable<TElement> CreateQuery<TElement>(string tableName) where TElement : ITableEntity, new()
        {
            return _items[tableName].CreateQuery<TElement>();
        }

        public TableResult Execute(string tableName, TableOperation operation)
        {
            if (!_items.ContainsKey(tableName))
            {
                return new TableResult { HttpStatusCode = 404 };
            }

            return _items[tableName].Execute(operation);
        }

        public TableBatchResult ExecuteBatch(string tableName, TableBatchOperation batch)
        {
            if (!_items.ContainsKey(tableName))
            {
                throw StorageExceptionFactory.CreateTableStorageException(404, "TableNotFound");
            }

            return _items[tableName].ExecuteBatch(batch);
        }

        public bool Exists(string tableName)
        {
            return _items.ContainsKey(tableName);
        }

        private class Table
        {
            private readonly ConcurrentDictionary<Tuple<string, string>, TableItem> _entities =
                new ConcurrentDictionary<Tuple<string, string>, TableItem>();

            public IQueryable<TElement> CreateQuery<TElement>() where TElement : ITableEntity, new()
            {
                // The test implementation of IQueryable will support all operations, not just the subset that Azure
                // Storage handles.
                return _entities.Select(CreateEntity<TElement>).AsQueryable();
            }

            private TElement CreateEntity<TElement>(KeyValuePair<Tuple<string, string>, TableItem> pair)
                where TElement : ITableEntity, new()
            {
                TElement entity = new TElement();
                entity.PartitionKey = pair.Key.Item1;
                entity.RowKey = pair.Key.Item2;
                entity.Timestamp = pair.Value.Timestamp;
                entity.ReadEntity(pair.Value.CloneProperties(), operationContext: null);
                entity.ETag = pair.Value.ETag;
                return entity;
            }

            public TableResult Execute(TableOperation operation)
            {
                TableOperationType operationType = operation.OperationType;
                ITableEntity entity = operation.Entity;
                Tuple<string, string> key;
                IDictionary<string, EntityProperty> writeProperties;

                if (operation.OperationType != TableOperationType.Retrieve)
                {
                    key = new Tuple<string, string>(entity.PartitionKey, entity.RowKey);
                    writeProperties = entity.WriteEntity(operationContext: null);
                }
                else
                {
                    key = new Tuple<string, string>(operation.RetrievePartitionKey(), operation.RetrieveRowKey());
                    writeProperties = null;
                }

                switch (operation.OperationType)
                {
                    case TableOperationType.Retrieve:
                        TableItem item = _entities[key];

                        // Func<string, string, DateTimeOffset, IDictionary<string, EntityProperty>, string, object> 
                        var resolver = operation.RetrieveResolver();
                                                
                        return new TableResult
                        {
                            
                            Result = resolver(operation.RetrievePartitionKey(),
                                operation.RetrieveRowKey(), item.Timestamp, item.CloneProperties(), item.ETag)
                        };

                    case TableOperationType.Insert:
                        if (!_entities.TryAdd(key, new TableItem(writeProperties)))
                        {
                            throw new InvalidOperationException(String.Format(CultureInfo.CurrentCulture,
                                "Entity PK='{0}',RK='{1}' already exists.", entity.PartitionKey, entity.RowKey));
                        }
                        return new TableResult();

                    case TableOperationType.Replace:
                        if (entity.ETag == null)
                        {
                            throw new InvalidOperationException("Replace requires an ETag.");
                        }
                        else if (!_entities.TryUpdate(key, new TableItem(writeProperties), new TableItem(entity.ETag)))
                        {
                            if (entity.ETag == "*")
                            {
                                throw new InvalidOperationException(String.Format(CultureInfo.CurrentCulture,
                                    "Entity PK='{0}',RK='{1}' does not exist.", entity.PartitionKey, entity.RowKey));
                            }
                            else
                            {
                                throw new InvalidOperationException(String.Format(CultureInfo.CurrentCulture,
                                    "Entity PK='{0}',RK='{1}' does not match eTag '{2}'.", entity.PartitionKey,
                                    entity.RowKey, entity.ETag));
                            }
                        }
                        return new TableResult();

                    default:
                        throw new InvalidOperationException(
                            "Unsupported operation type " + operationType.ToString());
                }
            }

            public TableBatchResult ExecuteBatch(TableBatchOperation batch)
            {
                TableOperation[] operations = batch.ToArray();

                if (operations.Length == 0)
                {
                    return new TableBatchResult();
                }

                // Ensure all operations are for the same partition.
                string firstPartitionKey = operations[0].Entity.PartitionKey;

                if (operations.Any(o => o.Entity.PartitionKey != firstPartitionKey))
                {
                    throw new InvalidOperationException("All operations in a batch must have the same partition key.");
                }

                // Ensure each row key is only present once.
                if (operations.GroupBy(o => o.Entity.RowKey).Any(g => g.Count() > 1))
                {
                    throw new InvalidOperationException("All operations in a batch must have distinct row keys.");
                }

                var results = new TableBatchResult();

                foreach (TableOperation operation in operations)
                {
                    // For test purposes, use an easier (non-atomic) implementation.
                    TableResult result = Execute(operation);
                    results.Add(result);
                }

                return results;
            }
        }

        private class TableItem : IEquatable<TableItem>
        {
            private readonly string _eTag;
            private readonly DateTimeOffset _timestamp;
            private readonly IDictionary<string, EntityProperty> _properties = new Dictionary<string, EntityProperty>();

            public TableItem(string eTag)
            {
                _eTag = eTag;
            }

            public TableItem(IDictionary<string, EntityProperty> properties)
            {
                _eTag = Guid.NewGuid().ToString();
                _timestamp = DateTimeOffset.Now;
                // Clone properties when persisting, so changes to source value in memory don't affect the persisted
                // data.
                _properties = DeepClone(properties);
            }

            public DateTimeOffset Timestamp
            {
                get { return _timestamp; }
            }

            public string ETag
            {
                get { return _eTag; }
            }

            public IDictionary<string, EntityProperty> CloneProperties()
            {
                // Clone properties when retrieving, so changes to the retrieved value in memory don't affect the
                // persisted data.
                return DeepClone(_properties);
            }

            public bool Equals(TableItem other)
            {
                if (other == null)
                {
                    return false;
                }

                if (other._eTag == "*")
                {
                    return true;
                }

                return _eTag == other._eTag;
            }
        } // class TableITem


        internal static IDictionary<string, EntityProperty> DeepClone(IDictionary<string, EntityProperty> value)
        {
            if (value == null)
            {
                return null;
            }

            IDictionary<string, EntityProperty> clone = new Dictionary<string, EntityProperty>();

            foreach (KeyValuePair<string, EntityProperty> item in value)
            {
                clone.Add(item.Key, DeepClone(item.Value));
            }

            return clone;
        }

        internal static EntityProperty DeepClone(EntityProperty property)
        {
            EdmType propertyType = property.PropertyType;

            switch (propertyType)
            {
                case EdmType.Binary:
                    byte[] existingBytes = property.BinaryValue;
                    byte[] clonedBytes;

                    if (existingBytes == null)
                    {
                        clonedBytes = null;
                    }
                    else
                    {
                        clonedBytes = new byte[existingBytes.LongLength];
                        Array.Copy(existingBytes, clonedBytes, existingBytes.LongLength);
                    }

                    return new EntityProperty(clonedBytes);
                case EdmType.Boolean:
                    return new EntityProperty(property.BooleanValue);
                case EdmType.DateTime:
                    return new EntityProperty(property.DateTime);
                case EdmType.Double:
                    return new EntityProperty(property.DoubleValue);
                case EdmType.Guid:
                    return new EntityProperty(property.GuidValue);
                case EdmType.Int32:
                    return new EntityProperty(property.Int32Value);
                case EdmType.Int64:
                    return new EntityProperty(property.Int64Value);
                case EdmType.String:
                    return new EntityProperty(property.StringValue);
                default:
                    string message = String.Format(CultureInfo.CurrentCulture, "Unknown PropertyType {0}.",
                        propertyType);
                    throw new NotSupportedException(message);
            }
        }
    }

    static class Ext
    {
        public static string RetrievePartitionKey(this TableOperation operation)
        {
            return GetInternalField<string>(operation, "RetrievePartitionKey");
        }

        public static string RetrieveRowKey(this TableOperation operation)
        {
            return GetInternalField<string>(operation, "RetrieveRowKey");
        }

        public static TableResolver RetrieveResolver(this TableOperation operation)
        {
            return GetInternalField<TableResolver>(operation, "RetrieveResolver");
        }

        private static T GetInternalField<T>(object obj, string fieldName)
        {
            var t = obj.GetType();
            var prop = t.GetProperty(fieldName, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            var val = prop.GetValue(obj);
            return (T)val;
        }
    }
}
