// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Microsoft.Azure.WebJobs.Host.Queues.Triggers
{
    internal class QueueMessageValueProvider : IValueProvider
    {
        private readonly QueueMessage _message;
        private readonly object _value;
        private readonly Type _valueType;

        public QueueMessageValueProvider(QueueMessage message, object value, Type valueType)
        {
            if (value != null && !valueType.IsAssignableFrom(value.GetType()))
            {
                throw new InvalidOperationException("value is not of the correct type.");
            }

            _message = message;
            _value = value;
            _valueType = valueType;
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
            // Potential enhancement: Base64-encoded AsBytes might replay correctly when use to create a new message.
            // return _message.TryGetAsString() ?? Convert.ToBase64String(_message.AsBytes);
            return _message.MessageText; // TODO (kasobol-msft) revisit this when Base64/BinaryData is added to SDK
        }
    }
}
