// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    [Extension("AzureStorageTables", "Tables")]
    internal class TablesExtensionConfigProvider : IExtensionConfigProvider
    {
        private readonly StorageAccountProvider _accountProvider;
        private readonly INameResolver _nameResolver;

        // Property names on TableAttribute
        private const string RowKeyProperty = nameof(TableAttribute.RowKey);
        private const string PartitionKeyProperty = nameof(TableAttribute.PartitionKey);

        public TablesExtensionConfigProvider(StorageAccountProvider accountProvider, INameResolver nameResolver)
        {
            _accountProvider = accountProvider;
            _nameResolver = nameResolver;
        }

        public void Initialize(ExtensionConfigContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            // rules for single entity.
            var original = new TableAttributeBindingProvider(_nameResolver, _accountProvider);

            var builder = new JObjectBuilder(this);

            var binding = context.AddBindingRule<TableAttribute>();

            binding
                .AddConverter<JObject, ITableEntity>(JObjectToTableEntityConverterFunc)
                .AddOpenConverter<object, ITableEntity>(typeof(ObjectToITableEntityConverter<>));

            binding.WhenIsNull(RowKeyProperty)
                .SetPostResolveHook(ToParameterDescriptorForCollector)
                .BindToInput<CloudTable>(builder);

            binding.BindToCollector<ITableEntity>(BuildFromTableAttribute);

            binding.WhenIsNotNull(PartitionKeyProperty).WhenIsNotNull(RowKeyProperty)
                .BindToInput<JObject>(builder);
            binding.BindToInput<JArray>(builder);
            binding.Bind(original);
        }

        // Get the storage table from the attribute.
        private CloudTable GetTable(TableAttribute attribute)
        {
            var account = _accountProvider.Get(attribute.Connection);
            var tableClient = account.CreateCloudTableClient();
            return tableClient.GetTableReference(attribute.TableName);
        }

        private ParameterDescriptor ToParameterDescriptorForCollector(TableAttribute attribute, ParameterInfo parameter, INameResolver nameResolver)
        {
            var account = _accountProvider.Get(attribute.Connection, nameResolver);
            string accountName = account.Name;

            return new TableParameterDescriptor
            {
                Name = parameter.Name,
                AccountName = accountName,
                TableName = Resolve(attribute.TableName, nameResolver),
                Access = FileAccess.ReadWrite
            };
        }

        private static string Resolve(string name, INameResolver nameResolver)
        {
            if (nameResolver == null)
            {
                return name;
            }

            return nameResolver.ResolveWholeString(name);
        }

        private IAsyncCollector<ITableEntity> BuildFromTableAttribute(TableAttribute attribute)
        {
            var table = GetTable(attribute);

            var writer = new TableEntityWriter<ITableEntity>(table);
            return writer;
        }

        public ITableEntity JObjectToTableEntityConverterFunc(JObject source, TableAttribute attribute)
        {
            var result = CreateTableEntityFromJObject(attribute.PartitionKey, attribute.RowKey, source);
            return result;
        }

        private static JObject ConvertEntityToJObject(DynamicTableEntity tableEntity)
        {
            JObject jsonObject = new JObject();
            foreach (var entityProperty in tableEntity.Properties)
            {
                JValue value = null;
                switch (entityProperty.Value.PropertyType)
                {
                    case EdmType.String:
                        value = new JValue(entityProperty.Value.StringValue);
                        break;
                    case EdmType.Int32:
                        value = new JValue(entityProperty.Value.Int32Value);
                        break;
                    case EdmType.Int64:
                        value = new JValue(entityProperty.Value.Int64Value);
                        break;
                    case EdmType.DateTime:
                        value = new JValue(entityProperty.Value.DateTime);
                        break;
                    case EdmType.Boolean:
                        value = new JValue(entityProperty.Value.BooleanValue);
                        break;
                    case EdmType.Guid:
                        value = new JValue(entityProperty.Value.GuidValue);
                        break;
                    case EdmType.Double:
                        value = new JValue(entityProperty.Value.DoubleValue);
                        break;
                    case EdmType.Binary:
                        value = new JValue(entityProperty.Value.BinaryValue);
                        break;
                }

                jsonObject.Add(entityProperty.Key, value);
            }

            jsonObject.Add("PartitionKey", tableEntity.PartitionKey);
            jsonObject.Add("RowKey", tableEntity.RowKey);

            return jsonObject;
        }

        private static DynamicTableEntity CreateTableEntityFromJObject(string partitionKey, string rowKey, JObject entity)
        {
            // any key values specified on the entity override any values
            // specified in the binding
            JProperty keyProperty = entity.Properties().SingleOrDefault(p => string.Compare(p.Name, "partitionKey", StringComparison.OrdinalIgnoreCase) == 0);
            if (keyProperty != null)
            {
                partitionKey = (string)keyProperty.Value;
                entity.Remove(keyProperty.Name);
            }

            keyProperty = entity.Properties().SingleOrDefault(p => string.Compare(p.Name, "rowKey", StringComparison.OrdinalIgnoreCase) == 0);
            if (keyProperty != null)
            {
                rowKey = (string)keyProperty.Value;
                entity.Remove(keyProperty.Name);
            }

            DynamicTableEntity tableEntity = new DynamicTableEntity(partitionKey, rowKey);
            foreach (JProperty property in entity.Properties())
            {
                EntityProperty entityProperty = CreateEntityPropertyFromJProperty(property);
                tableEntity.Properties.Add(property.Name, entityProperty);
            }

            return tableEntity;
        }

        private static EntityProperty CreateEntityPropertyFromJProperty(JProperty property)
        {
            switch (property.Value.Type)
            {
                case JTokenType.String:
                    return EntityProperty.GeneratePropertyForString((string)property.Value);
                case JTokenType.Integer:
                    return EntityProperty.GeneratePropertyForInt((int)property.Value);
                case JTokenType.Boolean:
                    return EntityProperty.GeneratePropertyForBool((bool)property.Value);
                case JTokenType.Guid:
                    return EntityProperty.GeneratePropertyForGuid((Guid)property.Value);
                case JTokenType.Float:
                    return EntityProperty.GeneratePropertyForDouble((double)property.Value);
                default:
                    return EntityProperty.CreateEntityPropertyFromObject((object)property.Value);
            }
        }

        // Provide some common builder rules. 
        private class JObjectBuilder :
            IAsyncConverter<TableAttribute, CloudTable>,
            IAsyncConverter<TableAttribute, JObject>,
            IAsyncConverter<TableAttribute, JArray>
        {
            private readonly TablesExtensionConfigProvider _bindingProvider;

            public JObjectBuilder(TablesExtensionConfigProvider bindingProvider)
            {
                _bindingProvider = bindingProvider;
            }

            async Task<CloudTable> IAsyncConverter<TableAttribute, CloudTable>.ConvertAsync(TableAttribute attribute, CancellationToken cancellation)
            {
                var table = _bindingProvider.GetTable(attribute);
                await table.CreateIfNotExistsAsync(CancellationToken.None).ConfigureAwait(false);

                return table;
            }

            async Task<JObject> IAsyncConverter<TableAttribute, JObject>.ConvertAsync(TableAttribute attribute, CancellationToken cancellation)
            {
                var table = _bindingProvider.GetTable(attribute);

                var retrieve = table.CreateRetrieveOperation<DynamicTableEntity>(attribute.PartitionKey, attribute.RowKey);
                TableResult result = await table.ExecuteAsync(retrieve, CancellationToken.None).ConfigureAwait(false);
                DynamicTableEntity entity = (DynamicTableEntity)result.Result;
                if (entity == null)
                {
                    return null;
                }
                else
                {
                    return ConvertEntityToJObject(entity);
                }
            }

            // Build a JArray.
            // Used as an alternative to binding to IQueryable.
            async Task<JArray> IAsyncConverter<TableAttribute, JArray>.ConvertAsync(TableAttribute attribute, CancellationToken cancellation)
            {
                var table = _bindingProvider.GetTable(attribute);

                string finalQuery = attribute.Filter;
                if (!string.IsNullOrEmpty(attribute.PartitionKey))
                {
                    var partitionKeyPredicate = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, attribute.PartitionKey);
                    if (!string.IsNullOrEmpty(attribute.Filter))
                    {
                        finalQuery = TableQuery.CombineFilters(attribute.Filter, TableOperators.And, partitionKeyPredicate);
                    }
                    else
                    {
                        finalQuery = partitionKeyPredicate;
                    }
                }

                TableQuery tableQuery = new TableQuery
                {
                    FilterString = finalQuery
                };
                if (attribute.Take > 0)
                {
                    tableQuery.TakeCount = attribute.Take;
                }

                int countRemaining = attribute.Take;

                JArray entityArray = new JArray();
                TableContinuationToken token = null;

                do
                {
                    var segment = await table.ExecuteQuerySegmentedAsync(tableQuery, token, cancellation).ConfigureAwait(false);
                    var entities = segment.Results;

                    token = segment.ContinuationToken;

                    foreach (var entity in entities)
                    {
                        countRemaining--;
                        entityArray.Add(ConvertEntityToJObject(entity));

                        if (countRemaining == 0)
                        {
                            token = null;
                            break;
                        }
                    }
                } while (token != null);

                return entityArray;
            }
        }

        // Convert from T --> ITableEntity
        private class ObjectToITableEntityConverter<TElement>
            : IConverter<TElement, ITableEntity>
        {
            private static readonly IConverter<TElement, ITableEntity> Converter = PocoToTableEntityConverter<TElement>.Create();

            public ObjectToITableEntityConverter()
            {
                // JObject case should have been claimed by another converter. 
                // So we can statically enforce an ITableEntity compatible contract
                var t = typeof(TElement);
                TableClient.VerifyContainsProperty(t, "RowKey");
                TableClient.VerifyContainsProperty(t, "PartitionKey");
            }

            public ITableEntity Convert(TElement item)
            {
                return Converter.Convert(item);
            }
        }
    }
}