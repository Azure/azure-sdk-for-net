// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    internal class StringArgumentBindingProvider : IQueueArgumentBindingProvider
    {
        public IArgumentBinding<ServiceBusEntity> TryCreate(ParameterInfo parameter)
        {
            if (!parameter.IsOut || parameter.ParameterType != typeof(string).MakeByRefType())
            {
                return null;
            }
            var attribute = TypeUtility.GetResolvedAttribute<ServiceBusAttribute>(parameter);
            return new StringArgumentBinding(attribute.IncludeMetadata);
        }

        private class StringArgumentBinding : IArgumentBinding<ServiceBusEntity>
        {
            private readonly bool _includeMetadata;

            public StringArgumentBinding(bool includeMetadata)
            {
                _includeMetadata = includeMetadata;
            }
            public Type ValueType
            {
                get { return typeof(string); }
            }

            /// <remarks>
            /// The out string parameter is processed as follows:
            /// <list type="bullet">
            /// <item>
            /// <description>
            /// If the value is <see langword="null"/>, no message will be sent.
            /// </description>
            /// </item>
            /// <item>
            /// <description>
            /// If the value is an empty string, a message with empty content will be sent.
            /// </description>
            /// </item>
            /// <item>
            /// <description>
            /// If the value is a non-empty string, a message with that content will be sent.
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

                IValueProvider provider = new NonNullConverterValueBinder<string>(value,
                    new StringToMessageConverter(_includeMetadata), context.FunctionInstanceId);

                return Task.FromResult(provider);
            }
        }
    }
}
