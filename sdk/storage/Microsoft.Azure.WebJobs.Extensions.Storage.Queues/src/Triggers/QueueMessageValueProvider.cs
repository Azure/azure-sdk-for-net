// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues.Triggers
{
    internal class QueueMessageValueProvider : IValueProvider
    {
        private readonly QueueMessage _message;
        private readonly object _value;
        private readonly Type _valueType;
        private readonly ILogger<QueueMessageValueProvider> _logger;

        public QueueMessageValueProvider(QueueMessage message, object value, Type valueType, ILoggerFactory loggerFactory)
        {
            if (value != null && !valueType.IsAssignableFrom(value.GetType()))
            {
                throw new InvalidOperationException("value is not of the correct type.");
            }

            _message = message;
            _value = value;
            _valueType = valueType;
            _logger = loggerFactory.CreateLogger<QueueMessageValueProvider>();
        }

        public Type Type
        {
            get { return _valueType; }
        }

        public Task<object> GetValueAsync()
        {
            return Task.FromResult(_value);
        }

        public string ToInvokeString()
        {
            return _message.TryGetAsString(_logger);
        }
    }
}
