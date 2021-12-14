// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.Cosmos.Table;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal class PocoEntityValueBinder<TElement> : IValueBinder, IWatchable, IWatcher
    {
        private static readonly PocoToTableEntityConverter<TElement> Converter =
            PocoToTableEntityConverter<TElement>.Create();

        private readonly TableEntityContext _entityContext;
        private readonly string _eTag;
        private readonly TElement _value;
        private readonly IDictionary<string, EntityProperty> _originalProperties;

        public PocoEntityValueBinder(TableEntityContext entityContext, string eTag, TElement value)
        {
            _entityContext = entityContext;
            _eTag = eTag;
            _value = value;
            _originalProperties =
                TableEntityValueBinder.DeepClone(Converter.Convert(value).WriteEntity(operationContext: null));
        }

        public Type Type => typeof(TElement);

        public IWatcher Watcher => this;

        public bool HasChanged => HasChanges(Converter.Convert(_value));

        public Task<object> GetValueAsync()
        {
            return Task.FromResult<object>(_value);
        }

        public Task SetValueAsync(object value, CancellationToken cancellationToken)
        {
            // Not ByRef, so can ignore value argument.
            ITableEntity entity = Converter.Convert(_value);
            if (!Converter.ConvertsPartitionKey)
            {
                entity.PartitionKey = _entityContext.PartitionKey;
            }

            if (!Converter.ConvertsRowKey)
            {
                entity.RowKey = _entityContext.RowKey;
            }

            if (!Converter.ConvertsETag)
            {
                entity.ETag = _eTag;
            }

            if (entity.PartitionKey != _entityContext.PartitionKey)
            {
                throw new InvalidOperationException(
                    "When binding to a table entity, the partition key must not be changed.");
            }

            if (entity.RowKey != _entityContext.RowKey)
            {
                throw new InvalidOperationException(
                    "When binding to a table entity, the row key must not be changed.");
            }

            if (HasChanges(entity))
            {
                var table = _entityContext.Table;
                var operation = TableOperation.Replace(entity);
                return table.ExecuteAsync(operation, cancellationToken);
            }

            return Task.FromResult(0);
        }

        public string ToInvokeString()
        {
            return _entityContext.ToInvokeString();
        }

        public ParameterLog GetStatus()
        {
            return HasChanged ? new TableParameterLog { EntitiesWritten = 1 } : null;
        }

        private bool HasChanges(ITableEntity current)
        {
            return TableEntityValueBinder.HasChanges(_originalProperties, current.WriteEntity(operationContext: null));
        }
    }
}