// Copyright (c) .NET Foundation. All rights reserved.
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
        private readonly IConverterManager _converterManager;

        // Property names on TableAttribute
        private const string RowKeyProperty = nameof(TableAttribute.RowKey);

        public TablesExtensionConfigProvider(TablesAccountProvider accountProvider, INameResolver nameResolver, IConverterManager converterManager)
        {
            _accountProvider = accountProvider;
            _nameResolver = nameResolver;
            _converterManager = converterManager;
        }

        public void Initialize(ExtensionConfigContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            // rules for single entity.
            var original = new TableAttributeBindingProvider(_nameResolver, _accountProvider, _converterManager);

            var builder = new JObjectBuilder(this);

            var binding = context.AddBindingRule<TableAttribute>();

            binding
                .AddConverter<JObject, TableEntity>(CreateTableEntityFromJObject)
                .AddConverter<TableEntity, JObject>(ConvertEntityToJObject)
                .AddConverter<ITableEntity, TableEntity>(entity =>
                {
                    if (entity is not TableEntity tableEntity)
                    {
                        throw new InvalidOperationException($"Expected ITableEntity instance to have TableEntity type but was {entity.GetType()}");
                    }

                    return tableEntity;
                })
                .AddConverter<TableEntity, ITableEntity>(entity => entity)
                .AddOpenConverter<object, TableEntity>(typeof(PocoToTableEntityConverter<>))
                .AddOpenConverter<TableEntity, object>(typeof(TableEntityToPocoConverter<>));

            binding.WhenIsNull(RowKeyProperty)
                .SetPostResolveHook(ToParameterDescriptorForCollector)
                .BindToInput<TableClient>(builder);

            binding.BindToCollector<TableEntity>(BuildFromTableAttribute);

            binding.Bind(original);
            binding.BindToInput<JArray>(builder);
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

        private IAsyncCollector<TableEntity> BuildFromTableAttribute(TableAttribute attribute)
        {
            var table = GetTable(attribute);

            return new TableEntityWriter(table, attribute.PartitionKey, attribute.RowKey);
        }

        private static JObject ConvertEntityToJObject(TableEntity tableEntity)
        {
            JObject jsonObject = new JObject();
            foreach (var entityProperty in tableEntity)
            {
                JToken value = JToken.FromObject(entityProperty.Value);

                jsonObject.Add(entityProperty.Key, value);
            }
            return jsonObject;
        }

        private static TableEntity CreateTableEntityFromJObject(JObject entity)
        {
            TableEntity tableEntity = new TableEntity();
            foreach (JProperty property in entity.Properties())
            {
                // TODO: validation?
                tableEntity[property.Name] = ((JValue)property.Value).Value;
            }

            return tableEntity;
        }

        // Provide some common builder rules.
        private class JObjectBuilder :
            IAsyncConverter<TableAttribute, TableClient>,
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
    }
}