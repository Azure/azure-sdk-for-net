// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    internal class ByteArrayArgumentBindingProvider : IQueueArgumentBindingProvider
    {
        public IArgumentBinding<ServiceBusEntity> TryCreate(ParameterInfo parameter)
        {
            if (!parameter.IsOut || parameter.ParameterType != typeof(byte[]).MakeByRefType())
            {
                return null;
            }

            return new ByteArrayArgumentBinding();
        }

        private class ByteArrayArgumentBinding : IArgumentBinding<ServiceBusEntity>
        {
            public Type ValueType
            {
                get { return typeof(byte[]); }
            }

            /// <remarks>
            /// The out byte array parameter is processed as follows:
            /// <list type="bullet">
            /// <item>
            /// <description>
            /// If the value is <see langword="null"/>, no message will be sent.
            /// </description>
            /// </item>
            /// <item>
            /// <description>
            /// If the value is an empty byte array, a message with empty content will be sent.
            /// </description>
            /// </item>
            /// <item>
            /// <description>
            /// If the value is a non-empty byte array, a message with that content will be sent.
            /// </description>
            /// </item>
            /// </list>
            /// </remarks>
            public Task<IValueProvider> BindAsync(ServiceBusEntity value, ValueBindingContext context)
            {
                if (context == null)
                {
                    throw new ArgumentNullException(nameof(context));
                }

                IValueProvider provider = new NonNullConverterValueBinder<byte[]>(value,
                    new ByteArrayToBrokeredMessageConverter(), context.FunctionInstanceId);

                return Task.FromResult(provider);
            }
        }
    }
}
