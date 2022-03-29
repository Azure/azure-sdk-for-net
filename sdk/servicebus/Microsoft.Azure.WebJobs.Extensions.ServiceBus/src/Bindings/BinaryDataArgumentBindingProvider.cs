// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    internal class BinaryDataArgumentBindingProvider : IQueueArgumentBindingProvider
    {
        public IArgumentBinding<ServiceBusEntity> TryCreate(ParameterInfo parameter)
        {
            if (!parameter.IsOut || parameter.ParameterType != typeof(BinaryData).MakeByRefType())
            {
                return null;
            }

            return new BinaryDataArgumentBinding();
        }

        private class BinaryDataArgumentBinding : IArgumentBinding<ServiceBusEntity>
        {
            public Type ValueType
            {
                get { return typeof(BinaryData); }
            }

            /// <remarks>
            /// The out BinaryData parameter is processed as follows:
            /// <list type="bullet">
            /// <item>
            /// <description>
            /// If the value is <see langword="null"/>, no message will be sent.
            /// </description>
            /// </item>
            /// <item>
            /// <description>
            /// If the value is an empty BinaryData instance, a message with empty content will be sent.
            /// </description>
            /// </item>
            /// <item>
            /// <description>
            /// If the value is a non-empty BinaryData, a message with that content will be sent.
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

                IValueProvider provider = new NonNullConverterValueBinder<BinaryData>(value,
                    new BinaryDataToMessageConverter(), context.FunctionInstanceId);

                return Task.FromResult(provider);
            }
        }
    }
}
