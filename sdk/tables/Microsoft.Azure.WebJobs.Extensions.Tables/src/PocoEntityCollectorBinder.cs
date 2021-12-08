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
    internal class PocoEntityCollectorBinder<T> : IValueBinder, IWatchable
    {
        private readonly CloudTable _table;
        private readonly PocoEntityWriter<T> _value;
        private readonly Type _valueType;

        public PocoEntityCollectorBinder(CloudTable table, PocoEntityWriter<T> value, Type valueType)
        {
            if (value != null && !valueType.IsAssignableFrom(value.GetType()))
            {
                throw new InvalidOperationException("value is not of the correct type.");
            }

            _table = table;
            _value = value;
            _valueType = valueType;
        }

        public Type Type => _valueType;

        public IWatcher Watcher => _value;

        public Task<object> GetValueAsync()
        {
            return Task.FromResult<object>(_value);
        }

        public string ToInvokeString()
        {
            return _table.Name;
        }

        public Task SetValueAsync(object value, CancellationToken cancellationToken)
        {
            return _value.FlushAsync(cancellationToken);
        }

        public ParameterLog GetStatus()
        {
            return _value.GetStatus();
        }
    }
}