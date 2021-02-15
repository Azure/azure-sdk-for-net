// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Protocols;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Triggers;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues.Triggers
{
    internal class UserTypeArgumentBindingProvider : IQueueTriggerArgumentBindingProvider
    {
        private readonly ILoggerFactory _loggerFactory;

        public UserTypeArgumentBindingProvider(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public ITriggerDataArgumentBinding<QueueMessage> TryCreate(ParameterInfo parameter)
        {
            // At indexing time, attempt to bind all types.
            // (Whether or not actual binding is possible depends on the message shape at runtime.)
            return new UserTypeArgumentBinding(parameter.ParameterType, _loggerFactory);
        }

        private class UserTypeArgumentBinding : ITriggerDataArgumentBinding<QueueMessage>
        {
            private readonly Type _valueType;
            private readonly IBindingDataProvider _bindingDataProvider;
            private readonly ILoggerFactory _loggerFactory;

            public UserTypeArgumentBinding(Type valueType, ILoggerFactory loggerFactory)
            {
                _valueType = valueType;
                _bindingDataProvider = BindingDataProvider.FromType(_valueType);
                _loggerFactory = loggerFactory;
            }

            public Type ValueType
            {
                get { return _valueType; }
            }

            public IReadOnlyDictionary<string, Type> BindingDataContract
            {
                get { return _bindingDataProvider != null ? _bindingDataProvider.Contract : null; }
            }

            public Task<ITriggerData> BindAsync(QueueMessage value, ValueBindingContext context)
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                object convertedValue;
                try
                {
                    convertedValue = JsonConvert.DeserializeObject(value.Body.ToValidUTF8String(), ValueType, JsonSerialization.Settings);
                }
                catch (JsonException e)
                {
                    // Easy to have the queue payload not deserialize properly. So give a useful error.
                    string msg = String.Format(CultureInfo.CurrentCulture,
@"Binding parameters to complex objects (such as '{0}') uses Json.NET serialization. 
1. Bind the parameter type as 'string' instead of '{0}' to get the raw values and avoid JSON deserialization, or
2. Change the queue payload to be valid json. The JSON parser failed: {1}
", _valueType.Name, e.Message);
                    throw new InvalidOperationException(msg);
                }

                IValueProvider provider = new QueueMessageValueProvider(value, convertedValue, ValueType, _loggerFactory);

                IReadOnlyDictionary<string, object> bindingData = (_bindingDataProvider != null)
                    ? _bindingDataProvider.GetBindingData(convertedValue) : null;

                return Task.FromResult<ITriggerData>(new TriggerData(provider, bindingData));
            }
        }
    }
}
