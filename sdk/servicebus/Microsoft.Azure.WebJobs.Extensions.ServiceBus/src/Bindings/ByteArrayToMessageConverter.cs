// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;
using Azure.Messaging.ServiceBus;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    internal class ByteArrayToMessageConverter : IConverter<byte[], ServiceBusMessage>
    {
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public ServiceBusMessage Convert(byte[] input)
        {
            if (input == null)
            {
                throw new InvalidOperationException("A brokered message cannot contain a null byte array instance.");
            }

            return new ServiceBusMessage(input)
            {
                ContentType = ContentTypes.ApplicationOctetStream
            };
        }
    }
}
