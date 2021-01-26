// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Converters;
using Microsoft.Azure.ServiceBus;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    internal class CollectorArgumentBindingProvider : IQueueArgumentBindingProvider
    {
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

        private static IArgumentBinding<ServiceBusEntity> CreateBinding(Type itemType)
        {
            MethodInfo method = typeof(CollectorArgumentBindingProvider).GetMethod("CreateBindingGeneric",
                BindingFlags.NonPublic | BindingFlags.Static);
            Debug.Assert(method != null);
            MethodInfo genericMethod = method.MakeGenericMethod(itemType);
            Debug.Assert(genericMethod != null);
            Func<IArgumentBinding<ServiceBusEntity>> lambda =
                (Func<IArgumentBinding<ServiceBusEntity>>)Delegate.CreateDelegate(
                typeof(Func<IArgumentBinding<ServiceBusEntity>>), genericMethod);
            return lambda.Invoke();
        }

        private static IArgumentBinding<ServiceBusEntity> CreateBindingGeneric<TItem>()
        {
            return new CollectorArgumentBinding<TItem>(MessageConverterFactory.Create<TItem>());
        }

        private class CollectorArgumentBinding<TItem> : IArgumentBinding<ServiceBusEntity>
        {
            private readonly IConverter<TItem, Message> _converter;

            public CollectorArgumentBinding(IConverter<TItem, Message> converter)
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
