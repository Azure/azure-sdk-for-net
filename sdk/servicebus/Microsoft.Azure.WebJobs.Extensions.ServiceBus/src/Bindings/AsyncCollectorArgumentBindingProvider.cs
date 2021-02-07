// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Converters;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    internal class AsyncCollectorArgumentBindingProvider : IQueueArgumentBindingProvider
    {
        public IArgumentBinding<ServiceBusEntity> TryCreate(ParameterInfo parameter)
        {
            Type parameterType = parameter.ParameterType;

            if (!parameterType.IsGenericType)
            {
                return null;
            }

            Type genericTypeDefinition = parameterType.GetGenericTypeDefinition();

            if (genericTypeDefinition != typeof(IAsyncCollector<>))
            {
                return null;
            }

            Type itemType = parameterType.GetGenericArguments()[0];
            return CreateBinding(itemType);
        }

        private static IArgumentBinding<ServiceBusEntity> CreateBinding(Type itemType)
        {
            MethodInfo method = typeof(AsyncCollectorArgumentBindingProvider).GetMethod("CreateBindingGeneric",
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
            return new AsyncCollectorArgumentBinding<TItem>(MessageConverterFactory.Create<TItem>());
        }

        private class AsyncCollectorArgumentBinding<TItem> : IArgumentBinding<ServiceBusEntity>
        {
            private readonly IConverter<TItem, Message> _converter;

            public AsyncCollectorArgumentBinding(IConverter<TItem, Message> converter)
            {
                _converter = converter;
            }

            public Type ValueType
            {
                get { return typeof(IAsyncCollector<TItem>); }
            }

            public Task<IValueProvider> BindAsync(ServiceBusEntity value, ValueBindingContext context)
            {
                if (context == null)
                {
                    throw new ArgumentNullException(nameof(context));
                }

                IAsyncCollector<TItem> collector = new MessageSenderAsyncCollector<TItem>(value, _converter,
                    context.FunctionInstanceId);
                IValueProvider provider = new CollectorValueProvider(value, collector, typeof(IAsyncCollector<TItem>));

                return Task.FromResult(provider);
            }
        }
    }
}
