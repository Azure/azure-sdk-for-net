// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    internal class SyncCollectorArgumentBindingProvider : IQueueArgumentBindingProvider
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public SyncCollectorArgumentBindingProvider(JsonSerializerSettings jsonSerializerSettings)
        {
            _jsonSerializerSettings = jsonSerializerSettings;
        }

        public IArgumentBinding<ServiceBusEntity> TryCreate(ParameterInfo parameter)
        {
            Type parameterType = parameter.ParameterType;

            if (!parameterType.IsGenericType)
            {
                return null;
            }

            Type genericTypeDefinition = parameterType.GetGenericTypeDefinition();

            if (genericTypeDefinition != typeof(ICollector<>))
            {
                return null;
            }

            Type itemType = parameterType.GetGenericArguments()[0];
            return CreateBinding(itemType);
        }

        private IArgumentBinding<ServiceBusEntity> CreateBinding(Type itemType)
        {
            MethodInfo method = typeof(SyncCollectorArgumentBindingProvider).GetMethod("CreateBindingGeneric",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Debug.Assert(method != null);
            MethodInfo genericMethod = method.MakeGenericMethod(itemType);
            Debug.Assert(genericMethod != null);
            Func<IArgumentBinding<ServiceBusEntity>> lambda =
                (Func<IArgumentBinding<ServiceBusEntity>>)Delegate.CreateDelegate(
                typeof(Func<IArgumentBinding<ServiceBusEntity>>), this, genericMethod);
            return lambda.Invoke();
        }

        private IArgumentBinding<ServiceBusEntity> CreateBindingGeneric<TItem>()
        {
            return new CollectorArgumentBinding<TItem>(MessageConverterFactory.Create<TItem>(_jsonSerializerSettings));
        }

        private class CollectorArgumentBinding<TItem> : IArgumentBinding<ServiceBusEntity>
        {
            private readonly IConverter<TItem, ServiceBusMessage> _converter;

            public CollectorArgumentBinding(IConverter<TItem, ServiceBusMessage> converter)
            {
                _converter = converter;
            }

            public Type ValueType
            {
                get { return typeof(ICollector<TItem>); }
            }

            public Task<IValueProvider> BindAsync(ServiceBusEntity value, ValueBindingContext context)
            {
                if (context == null)
                {
                    throw new ArgumentNullException(nameof(context));
                }

                ICollector<TItem> collector = new MessageSenderCollector<TItem>(value, _converter,
                    context.FunctionInstanceId);
                IValueProvider provider = new CollectorValueProvider(value, collector, typeof(ICollector<TItem>));

                return Task.FromResult(provider);
            }
        }
    }
}
