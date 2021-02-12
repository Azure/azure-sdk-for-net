// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Azure.Messaging.ServiceBus;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    internal class StringToBrokeredMessageConverter : IConverter<string, ServiceBusMessage>
    {
        public ServiceBusMessage Convert(string input)
        {
            if (input == null)
            {
                throw new InvalidOperationException("A brokered message cannot contain a null string instance.");
            }

            byte[] bytes = StrictEncodings.Utf8.GetBytes(input);

            return new ServiceBusMessage(bytes)
            {
                ContentType = ContentTypes.TextPlain
            };
        }
    }
}
