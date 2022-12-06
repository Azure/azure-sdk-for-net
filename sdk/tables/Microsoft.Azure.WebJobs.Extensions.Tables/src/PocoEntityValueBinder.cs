// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Data.Tables;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal class PocoEntityValueBinder<TElement> : IValueBinder
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

        public async Task<object> GetValueAsync()
        {
            // Create a copy of the original entity so that we can properly
            // track changes to byte arrays. This also handles the case
            // where the customer binds directly to TableEntity as we return
            // a new instance with copied values.
            var copiedEntity = new TableEntity(_originalEntity);
            // copy the keys to avoid collection modified errors
            var keys = copiedEntity.Keys.ToList();
            foreach (var key in keys)
            {
                if (copiedEntity[key] is byte[] bytes)
                {
                    var copy = new byte[bytes.Length];
                    Array.Copy(bytes, copy, bytes.Length);
                    copiedEntity[key] = copy;
                }
            }
            var conversionResult = await _entityToPocoConverter(copiedEntity, null, _valueBindingContext).ConfigureAwait(false);

            return conversionResult;
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

            if (HasChanges(_originalEntity, entity))
            {
                await _entityContext.Table.UpdateEntityAsync(entity, entity.ETag, TableUpdateMode.Replace, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
        }

        public string ToInvokeString()
        {
            return _entityContext.ToInvokeString();
        }

        internal static bool HasChanges(TableEntity originalProperties, TableEntity currentProperties)
        {
            var allKeys = new HashSet<string>();
            allKeys.UnionWith(originalProperties.Keys);
            allKeys.UnionWith(currentProperties.Keys);
            // Ignore timestamp in matching
            allKeys.Remove("Timestamp");

            foreach (string key in allKeys)
            {
                originalProperties.TryGetValue(key, out var originalValue);
                currentProperties.TryGetValue(key, out var newValue);
                if (originalValue == null)
                {
                    if (newValue != null)
                    {
                        return true;
                    }
                    else
                    {
                        continue;
                    }
                }

                // do a by-value comparison when dealing with byte arrays
                if (originalValue is byte[] originalBytes && newValue is byte[] newBytes)
                {
                    return !originalBytes.SequenceEqual(newBytes);
                }

                if (!originalValue.Equals(newValue))
                {
                    return true;
                }
            }

            return false;
        }
    }
}