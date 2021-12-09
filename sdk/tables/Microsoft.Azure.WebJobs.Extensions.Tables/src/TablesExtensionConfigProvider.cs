// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Data.Tables;
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
                .BindToInput<TableClient>(builder);

            binding.BindToCollector<ITableEntity>(BuildFromTableAttribute);

            binding.WhenIsNotNull(PartitionKeyProperty).WhenIsNotNull(RowKeyProperty)
                .BindToInput<JObject>(builder);
            binding.BindToInput<JArray>(builder);
            binding.Bind(original);
        }

        // Get the storage table from the attribute.
        private TableClient GetTable(TableAttribute attribute)
        {
            var account = _accountProvider.Get(attribute.Connection);
            return account.GetTableClient(attribute.TableName);
        }

        private ParameterDescriptor ToParameterDescriptorForCollector(TableAttribute attribute, ParameterInfo parameter, INameResolver nameResolver)
        {
            var account = _accountProvider.Get(attribute.Connection, nameResolver);
            string accountName = account.AccountName;

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

        private static JObject ConvertEntityToJObject(TableEntity tableEntity)
        {
            JObject jsonObject = new JObject();
            foreach (var entityProperty in tableEntity)
            {
                JToken value = JToken.FromObject(entityProperty.Value);

                jsonObject.Add(entityProperty.Key, value);
            }

            jsonObject.Add("PartitionKey", tableEntity.PartitionKey);
            jsonObject.Add("RowKey", tableEntity.RowKey);

            return jsonObject;
        }

        private static TableEntity CreateTableEntityFromJObject(string partitionKey, string rowKey, JObject entity)
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

            TableEntity tableEntity = new TableEntity(partitionKey, rowKey);
            foreach (JProperty property in entity.Properties())
            {
                tableEntity[property.Name] = property.Value;
            }

            return tableEntity;
        }

        // Provide some common builder rules. 
        private class JObjectBuilder :
            IAsyncConverter<TableAttribute, TableClient>,
            IAsyncConverter<TableAttribute, JObject>,
            IAsyncConverter<TableAttribute, JArray>
        {
            private readonly TablesExtensionConfigProvider _bindingProvider;

            public JObjectBuilder(TablesExtensionConfigProvider bindingProvider)
            {
                _bindingProvider = bindingProvider;
            }

            async Task<TableClient> IAsyncConverter<TableAttribute, TableClient>.ConvertAsync(TableAttribute attribute, CancellationToken cancellation)
            {
                var table = _bindingProvider.GetTable(attribute);
                await table.CreateIfNotExistsAsync(CancellationToken.None).ConfigureAwait(false);

                return table;
            }

            async Task<JObject> IAsyncConverter<TableAttribute, JObject>.ConvertAsync(TableAttribute attribute, CancellationToken cancellation)
            {
                var table = _bindingProvider.GetTable(attribute);

                var result = await table.GetEntityAsync<TableEntity>(
                    attribute.PartitionKey,
                    attribute.RowKey,
                    cancellationToken: CancellationToken.None).ConfigureAwait(false);
                TableEntity entity = (TableEntity)result.Value;
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
                    var partitionKeyPredicate = TableClient.CreateQueryFilter($"PartitionKey == {attribute.PartitionKey}");
                    if (!string.IsNullOrEmpty(attribute.Filter))
                    {
                        finalQuery = partitionKeyPredicate + "AND " + attribute.Filter;
                    }
                    else
                    {
                        finalQuery = partitionKeyPredicate;
                    }
                }

                int? take = 0;
                if (attribute.Take > 0)
                {
                    take = attribute.Take;
                }

                int countRemaining = attribute.Take;

                JArray entityArray = new JArray();
                var entities = table.QueryAsync<TableEntity>(finalQuery, take, cancellationToken: cancellation).ConfigureAwait(false);

                await foreach (var entity in entities)
                {
                    countRemaining--;
                    if (countRemaining == 0)
                    {
                        break;
                    }
                    entityArray.Add(ConvertEntityToJObject(entity));
                }
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
                TableClientHelpers.VerifyContainsProperty(t, "RowKey");
                TableClientHelpers.VerifyContainsProperty(t, "PartitionKey");
            }

            public ITableEntity Convert(TElement item)
            {
                return Converter.Convert(item);
            }
        }
    }
}