// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.Cosmos.Table;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal class TableEntityCollectorBinder<T> : IValueBinder, IWatchable
        where T : ITableEntity
    {
        private readonly CloudTable _table;
        private readonly TableEntityWriter<T> _tableWriter;
        private readonly Type _valueType;

        public TableEntityCollectorBinder(CloudTable table, TableEntityWriter<T> tableWriter, Type valueType)
        {
            if (tableWriter != null && !valueType.IsAssignableFrom(tableWriter.GetType()))
            {
                throw new InvalidOperationException("value is not of the correct type.");
            }

            _table = table;
            _tableWriter = tableWriter;
            _valueType = valueType;
        }

        public Type Type => _valueType;

        public IWatcher Watcher => _tableWriter;

        public Task<object> GetValueAsync()
        {
            return Task.FromResult<object>(_tableWriter);
        }

        public string ToInvokeString()
        {
            return _table.Name;
        }

        public Task SetValueAsync(object value, CancellationToken cancellationToken)
        {
            return _tableWriter.FlushAsync(cancellationToken);
        }

        public ParameterLog GetStatus()
        {
            return _tableWriter.GetStatus();
        }
    }
}