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
        private static readonly PocoToTableEntityConverter<TElement> Converter = new();

        private readonly TableEntityContext _entityContext;
        private readonly string _eTag;
        private readonly TElement _value;
        private readonly TableEntity _originalProperties;

        public PocoEntityValueBinder(TableEntityContext entityContext, string eTag, TElement value)
        {
            _entityContext = entityContext;
            _eTag = eTag;
            _value = value;
            _originalProperties = Converter.Convert(value);
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
            TableEntity entity = Converter.Convert(_value);
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
                entity.ETag = new ETag(_eTag);
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

        private bool HasChanges(TableEntity current)
        {
            return TableEntityValueBinder.HasChanges(_originalProperties, current);
        }
    }
}