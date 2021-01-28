// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using Microsoft.Azure.WebJobs.Host.Converters;
using Microsoft.Azure.ServiceBus;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    internal static class MessageConverterFactory
    {
        internal static IConverter<TInput, Message> Create<TInput>()
        {
            if (typeof(TInput) == typeof(Message))
            {
                return (IConverter<TInput, Message>)new IdentityConverter<TInput>();
            }
            else if (typeof(TInput) == typeof(string))
            {
                return (IConverter<TInput, Message>)new StringToBrokeredMessageConverter();
            }
            else if (typeof(TInput) == typeof(byte[]))
            {
                return (IConverter<TInput, Message>)new ByteArrayToBrokeredMessageConverter();
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
