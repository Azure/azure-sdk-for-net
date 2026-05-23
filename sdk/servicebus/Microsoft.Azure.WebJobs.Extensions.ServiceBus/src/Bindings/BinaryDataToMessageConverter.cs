// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.ServiceBus;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    internal class BinaryDataToMessageConverter : IConverter<BinaryData, ServiceBusMessage>
    {
        public ServiceBusMessage Convert(BinaryData input)
        {
            return new ServiceBusMessage(input);
        }
    }
}