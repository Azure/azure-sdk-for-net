// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    internal class UserTypeArgumentBindingProvider : IQueueArgumentBindingProvider
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public UserTypeArgumentBindingProvider(JsonSerializerSettings jsonSerializerSettings)
        {
            _jsonSerializerSettings = jsonSerializerSettings;
        }

        public IArgumentBinding<ServiceBusEntity> TryCreate(ParameterInfo parameter)
        {
            if (!parameter.IsOut)
            {
                return null;
            }

            Type itemType = parameter.ParameterType.GetElementType();

            if (typeof(IEnumerable).IsAssignableFrom(itemType))
            {
                throw new InvalidOperationException("Enumerable types are not supported. Use ICollector<T> or IAsyncCollector<T> instead.");
            }
            else if (typeof(object) == itemType)
            {
                throw new InvalidOperationException("Object element types are not supported.");
            }

            return CreateBinding(itemType);
        }

        private IArgumentBinding<ServiceBusEntity> CreateBinding(Type itemType)
        {
            Type genericType = typeof(UserTypeArgumentBinding<>).MakeGenericType(itemType);
            return (IArgumentBinding<ServiceBusEntity>)Activator.CreateInstance(genericType, _jsonSerializerSettings);
        }

        private class UserTypeArgumentBinding<TInput> : IArgumentBinding<ServiceBusEntity>
        {
            private readonly JsonSerializerSettings _jsonSerializerSettings;

            public UserTypeArgumentBinding(JsonSerializerSettings jsonSerializerSettings)
            {
                _jsonSerializerSettings = jsonSerializerSettings;
            }

            public Type ValueType
            {
                get { return typeof(TInput); }
            }

            public Task<IValueProvider> BindAsync(ServiceBusEntity value, ValueBindingContext context)
            {
                if (context == null)
                {
                    throw new ArgumentNullException(nameof(context));
                }

                IConverter<TInput, ServiceBusMessage> converter = new UserTypeToMessageConverter<TInput>(_jsonSerializerSettings);
                IValueProvider provider = new ConverterValueBinder<TInput>(value, converter,
                    context.FunctionInstanceId);

                return Task.FromResult(provider);
            }
        }
    }
}
