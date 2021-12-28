// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Azure.Data.Tables;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal class TableEntityValueBinder : IValueBinder, IWatchable, IWatcher
    {
        private readonly TableEntityContext _entityContext;
        private readonly TableEntity _value;
        private readonly TableEntity _originalProperties;

        public TableEntityValueBinder(TableEntityContext entityContext, TableEntity entity, Type valueType)
        {
            Type = valueType;

            _entityContext = entityContext;
            _value = entity;
            _originalProperties = new TableEntity(entity);
        }

        public Type Type { get; }

        public IWatcher Watcher => this;

        public bool HasChanged => HasChanges(_originalProperties, _value);

        public Task<object> GetValueAsync()
        {
            return Task.FromResult<object>(_value);
        }

        public Task SetValueAsync(object value, CancellationToken cancellationToken)
        {
            // Not ByRef, so can ignore value argument.
            if (_value.PartitionKey != _entityContext.PartitionKey || _value.RowKey != _entityContext.RowKey)
            {
                throw new InvalidOperationException(
                    "When binding to a table entity, the partition key and row key must not be changed.");
            }

            if (HasChanged)
            {
                var table = _entityContext.Table;
                return table.UpdateEntityAsync(_value, _value.ETag, TableUpdateMode.Replace, cancellationToken: cancellationToken);
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

                if (!originalValue.Equals(newValue))
                {
                    return true;
                }
            }

            return false;
        }
    }
}