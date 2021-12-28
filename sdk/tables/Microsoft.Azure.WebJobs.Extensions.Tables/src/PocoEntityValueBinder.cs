// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Data.Tables;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal class PocoEntityValueBinder<TElement> : IValueBinder, IWatchable, IWatcher
    {
        private readonly TableEntityContext _entityContext;
        private readonly ValueBindingContext _valueBindingContext;
        private readonly TableEntity _originalEntity;
        private readonly FuncAsyncConverter _entityToPocoConverter;
        private readonly FuncAsyncConverter _pocoToEntityConverter;

        public PocoEntityValueBinder(
            TableEntityContext entityContext,
            ValueBindingContext context,
            TableEntity originalEntity,
            FuncAsyncConverter entityToPocoConverter,
            FuncAsyncConverter pocoToEntityConverter)
        {
            _entityContext = entityContext;
            _valueBindingContext = context;
            _originalEntity = originalEntity;
            _entityToPocoConverter = entityToPocoConverter;
            _pocoToEntityConverter = pocoToEntityConverter;
        }

        public Type Type => typeof(TElement);

        public IWatcher Watcher => this;

        public Task<object> GetValueAsync()
        {
            return _entityToPocoConverter(_originalEntity, null, _valueBindingContext);
        }

        public async Task SetValueAsync(object value, CancellationToken cancellationToken)
        {
            // Not ByRef, so can ignore value argument.
            TableEntity entity = (TableEntity)await _pocoToEntityConverter(value, null, _valueBindingContext).ConfigureAwait(false);

            if (entity.ETag == default)
            {
                entity.ETag = _originalEntity.ETag;
            }

            entity.RowKey ??= _originalEntity.RowKey;
            entity.PartitionKey ??= _originalEntity.PartitionKey;

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

            if (TableEntityValueBinder.HasChanges(_originalEntity, entity))
            {
                await _entityContext.Table.UpdateEntityAsync(entity, entity.ETag, TableUpdateMode.Replace, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
        }

        public string ToInvokeString()
        {
            return _entityContext.ToInvokeString();
        }

        public ParameterLog GetStatus()
        {
            return new TableParameterLog { EntitiesWritten = 1 };
        }
    }
}