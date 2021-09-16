// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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