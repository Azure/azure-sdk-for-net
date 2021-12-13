// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Data.Tables;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal class PocoEntityValueBinder<TElement> : IValueBinder, IWatchable, IWatcher
    {
        private static readonly PocoToTableEntityConverter<TElement> Converter =
            new PocoToTableEntityConverter<TElement>();

        private readonly TableEntityContext _entityContext;
        private readonly string _eTag;
        private readonly TElement _value;
        // private readonly IDictionary<string, EntityProperty> _originalProperties;

        public PocoEntityValueBinder(TableEntityContext entityContext, string eTag, TElement value)
        {
            _entityContext = entityContext;
            _eTag = eTag;
            _value = value;
            // _originalProperties =
            //     TableEntityValueBinder.DeepClone(Converter.Convert(value).WriteEntity(operationContext: null));
        }

        public Type Type => typeof(TElement);

        public IWatcher Watcher => this;

#pragma warning disable CA1822 // TODO:
        public bool HasChanged => true; //HasChanges(Converter.Convert(_value));
#pragma warning restore CA1822

        public Task<object> GetValueAsync()
        {
            return Task.FromResult<object>(_value);
        }

        public Task SetValueAsync(object value, CancellationToken cancellationToken)
        {
            // Not ByRef, so can ignore value argument.
            ITableEntity entity = Converter.Convert(_value);
            // if (!Converter.ConvertsPartitionKey)
            // {
            //     entity.PartitionKey = _entityContext.PartitionKey;
            // }
            //
            // if (!Converter.ConvertsRowKey)
            // {
            //     entity.RowKey = _entityContext.RowKey;
            // }
            //
            // if (!Converter.ConvertsETag)
            // {
            //     entity.ETag = new ETag(_eTag);
            // }
            entity.PartitionKey = _entityContext.PartitionKey;
            entity.RowKey = _entityContext.RowKey;
            entity.ETag = new ETag(_eTag);
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
                return _entityContext.Table.UpdateEntityAsync(entity, entity.ETag, cancellationToken: cancellationToken);
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

        private static bool HasChanges(ITableEntity current)
        {
            return current != null;
            // TODO:
            //return TableEntityValueBinder.HasChanges(_originalProperties, current.WriteEntity(operationContext: null));
        }
    }
}