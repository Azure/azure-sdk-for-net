// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Azure.Data.Tables;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Converters;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal class TableEntityBinding : IBinding
    {
        private readonly string _parameterName;
        private readonly IArgumentBinding<TableEntityContext> _argumentBinding;
        private readonly TableServiceClient _client;
        private readonly string _accountName;
        private readonly IBindableTableEntityPath _path;
        private readonly IObjectToTypeConverter<TableEntityContext> _converter;

        public TableEntityBinding(string parameterName, IArgumentBinding<TableEntityContext> argumentBinding,
            TableServiceClient client, IBindableTableEntityPath path)
        {
            _parameterName = parameterName;
            _argumentBinding = argumentBinding;
            _client = client;
            _accountName = TableClientHelpers.GetAccountName(client);
            _path = path;
            _converter = CreateConverter(client, path);
        }

        public bool FromAttribute => true;

        public string TableName => _path.TableNamePattern;

        public string PartitionKey => _path.PartitionKeyPattern;

        public string RowKey => _path.RowKeyPattern;

        private static IObjectToTypeConverter<TableEntityContext> CreateConverter(TableServiceClient client, IBindableTableEntityPath path)
        {
            return new CompositeObjectToTypeConverter<TableEntityContext>(
                new EntityOutputConverter<TableEntityContext>(new IdentityConverter<TableEntityContext>()),
                new EntityOutputConverter<string>(new StringToTableEntityContextConverter(client, path)));
        }

        private Task<IValueProvider> BindEntityAsync(TableEntityContext entityContext, ValueBindingContext context)
        {
            return _argumentBinding.BindAsync(entityContext, context);
        }

        public Task<IValueProvider> BindAsync(BindingContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            TableEntityPath boundPath = _path.Bind(context.BindingData);
            var table = _client.GetTableClient(boundPath.TableName);
            TableEntityContext entityContext = new TableEntityContext
            {
                Table = table,
                PartitionKey = boundPath.PartitionKey,
                RowKey = boundPath.RowKey
            };
            return BindEntityAsync(entityContext, context.ValueContext);
        }

        public Task<IValueProvider> BindAsync(object value, ValueBindingContext context)
        {
            TableEntityContext entityContext = null;
            if (!_converter.TryConvert(value, out entityContext))
            {
                throw new InvalidOperationException("Unable to convert value to TableEntityContext.");
            }

            TableClientHelpers.ValidateAzureTableKeyValue(entityContext.PartitionKey);
            TableClientHelpers.ValidateAzureTableKeyValue(entityContext.RowKey);
            return BindEntityAsync(entityContext, context);
        }

        public ParameterDescriptor ToParameterDescriptor()
        {
            return new TableEntityParameterDescriptor
            {
                Name = _parameterName,
                AccountName = _accountName,
                TableName = _path.TableNamePattern,
                PartitionKey = _path.PartitionKeyPattern,
                RowKey = _path.RowKeyPattern
            };
        }
    }
}