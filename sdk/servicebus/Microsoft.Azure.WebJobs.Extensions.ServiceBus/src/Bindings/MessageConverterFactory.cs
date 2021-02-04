// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using Microsoft.Azure.WebJobs.Host.Converters;
using Azure.Messaging.ServiceBus;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    internal static class MessageConverterFactory
    {
        internal static IConverter<TInput, ServiceBusMessage> Create<TInput>()
        {
            if (typeof(TInput) == typeof(ServiceBusMessage))
            {
                return (IConverter<TInput, ServiceBusMessage>)new IdentityConverter<TInput>();
            }
            else if (typeof(TInput) == typeof(string))
            {
                return (IConverter<TInput, ServiceBusMessage>)new StringToBrokeredMessageConverter();
            }
            else if (typeof(TInput) == typeof(byte[]))
            {
                return (IConverter<TInput, ServiceBusMessage>)new ByteArrayToMessageConverter();
            }
            else
            {
                if (typeof(TInput).IsPrimitive)
                {
                    throw new NotSupportedException("Primitive types are not supported.");
                }

                if (typeof(IEnumerable).IsAssignableFrom(typeof(TInput)))
                {
                    throw new InvalidOperationException("Nested collections are not supported.");
                }

                return new UserTypeToBrokeredMessageConverter<TInput>();
            }
        }
    }
}
