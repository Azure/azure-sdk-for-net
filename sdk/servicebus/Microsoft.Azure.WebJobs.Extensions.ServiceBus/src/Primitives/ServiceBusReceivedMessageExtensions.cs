// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.ServiceBus;

namespace Microsoft.Azure.WebJobs.ServiceBus
{
    static class ServiceBusReceivedMessageExtensions
    {
        public static bool TryGetServiceBusMessageState(this ServiceBusReceivedMessage receivedMessage, out ServiceBusMessageState? state)
        {
            var amqpAnnotatedMessage = receivedMessage.GetRawAmqpMessage();
            if (amqpAnnotatedMessage.MessageAnnotations.TryGetValue(Constants.MessageStateName, out var enumValue)
                && Enum.IsDefined(typeof(ServiceBusMessageState), enumValue))
            {
                state = (ServiceBusMessageState)enumValue;
                return true;
            }

            state = default;
            return false;
        }
    }
}