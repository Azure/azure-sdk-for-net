// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Text.Json;
using Azure.Messaging.ServiceBus;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    internal class StringToMessageConverter : IConverter<string, ServiceBusMessage>
    {
        private readonly bool _includeMessageMetadata;

        public StringToMessageConverter(bool includeMessageMetadata)
        {
            _includeMessageMetadata = includeMessageMetadata;
        }
        public ServiceBusMessage Convert(string input)
        {
            if (input == null)
            {
                throw new InvalidOperationException("A brokered message cannot contain a null string instance.");
            }

            if (_includeMessageMetadata)
            {
                return JsonSerializer.Deserialize<ServiceBusMessage>(input, new JsonSerializerOptions { Converters = { new ServiceBusMessageConverter()}});
            }

            byte[] bytes = StrictEncodings.Utf8.GetBytes(input);

            return new ServiceBusMessage(bytes)
            {
                ContentType = ContentTypes.TextPlain
            };
        }
    }
}
