﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Data.Tables;
using Azure.Data.Tables.Models;
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
        private readonly TablesAccountProvider _accountProvider;
        private readonly INameResolver _nameResolver;

        // Property names on TableAttribute
        private const string RowKeyProperty = nameof(TableAttribute.RowKey);
        private const string PartitionKeyProperty = nameof(TableAttribute.PartitionKey);

        public TablesExtensionConfigProvider(TablesAccountProvider accountProvider, INameResolver nameResolver)
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
            if (source == null)
            {
                return null;
            }
            return CreateTableEntityFromJObject(attribute.PartitionKey, attribute.RowKey, source);
        }

        private static JObject ConvertEntityToJObject(TableEntity tableEntity)
        {
            JObject jsonObject = new JObject();
            foreach (var entityProperty in tableEntity)
            {
                // V4 compatibility
                if (string.Compare(entityProperty.Key, "odata.etag", StringComparison.OrdinalIgnoreCase) == 0 ||
                    string.Compare(entityProperty.Key, "timestamp", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    continue;
                }

                jsonObject.Add(entityProperty.Key, new JValue(entityProperty.Value));
            }
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
                if (property.Value is JValue value)
                {
                    tableEntity[property.Name] = value.Value;
                }
                else
                {
                    tableEntity[property.Name] = property.Value.ToString();
                }
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

                try
                {
                    var result = await table.GetEntityAsync<TableEntity>(
                        attribute.PartitionKey,
                        attribute.RowKey,
                        cancellationToken: CancellationToken.None).ConfigureAwait(false);
                    return ConvertEntityToJObject(result);
                }
                catch (RequestFailedException e) when
                    (e.Status == 404 && (e.ErrorCode == TableErrorCode.TableNotFound || e.ErrorCode == TableErrorCode.ResourceNotFound))
                {
                    return null;
                }
            }

            // Build a JArray.
            // Used as an alternative to binding to IQueryable.
            async Task<JArray> IAsyncConverter<TableAttribute, JArray>.ConvertAsync(TableAttribute attribute, CancellationToken cancellation)
            {
                var table = _bindingProvider.GetTable(attribute);

                string filter = attribute.Filter;
                if (!string.IsNullOrEmpty(attribute.PartitionKey))
                {
                    var partitionKeyPredicate = TableClient.CreateQueryFilter($"PartitionKey eq {attribute.PartitionKey}");
                    if (!string.IsNullOrEmpty(attribute.Filter))
                    {
                        filter = $"{partitionKeyPredicate} and {attribute.Filter}";
                    }
                    else
                    {
                        filter = partitionKeyPredicate;
                    }
                }

                int? maxPerPage = null;
                if (attribute.Take > 0)
                {
                    maxPerPage = attribute.Take;
                }

                int countRemaining = attribute.Take;

                JArray entityArray = new JArray();
                var entities = table.QueryAsync<TableEntity>(
                    filter: filter,
                    maxPerPage: maxPerPage,
                    cancellationToken: cancellation).ConfigureAwait(false);

                await foreach (var entity in entities)
                {
                    countRemaining--;
                    entityArray.Add(ConvertEntityToJObject(entity));
                    if (countRemaining == 0)
                    {
                        break;
                    }
                }
                return entityArray;
            }
        }

        // Convert from T --> ITableEntity
        private class ObjectToITableEntityConverter<TElement>
            : IConverter<TElement, ITableEntity>
        {
            private static readonly IConverter<TElement, TableEntity> Converter = new PocoToTableEntityConverter<TElement>();

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