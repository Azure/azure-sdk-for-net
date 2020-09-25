// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Triggers;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Triggers;

namespace Microsoft.Azure.WebJobs.Host.Queues.Triggers
{
    internal class ConverterArgumentBindingProvider<T> : IQueueTriggerArgumentBindingProvider
    {
        private readonly IConverter<QueueMessage, T> _converter;

        public ConverterArgumentBindingProvider(IConverter<QueueMessage, T> converter)
        {
            _converter = converter;
        }

        public ITriggerDataArgumentBinding<QueueMessage> TryCreate(ParameterInfo parameter)
        {
            if (parameter.ParameterType != typeof(T))
            {
                return null;
            }

            return new ConverterArgumentBinding(_converter);
        }

        internal class ConverterArgumentBinding : ITriggerDataArgumentBinding<QueueMessage>
        {
            private readonly IConverter<QueueMessage, T> _converter;

            public ConverterArgumentBinding(IConverter<QueueMessage, T> converter)
            {
                _converter = converter;
            }

            public Type ValueType
            {
                get { return typeof(T); }
            }

            public IReadOnlyDictionary<string, Type> BindingDataContract
            {
                get { return null; }
            }

            public Task<ITriggerData> BindAsync(QueueMessage value, ValueBindingContext context)
            {
                object converted = _converter.Convert(value);
                IValueProvider provider = new QueueMessageValueProvider(value, converted, typeof(T));
                return Task.FromResult<ITriggerData>(new TriggerData(provider, null));
            }
        }
    }
}
