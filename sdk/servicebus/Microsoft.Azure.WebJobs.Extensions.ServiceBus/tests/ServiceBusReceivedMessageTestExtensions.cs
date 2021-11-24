// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.ServiceBus;

namespace Microsoft.Azure.WebJobs.ServiceBus.Tests
{
    // can be removed once the SDK is upgraded to the version that supports the message state
    internal static class ServiceBusReceivedMessageTestExtensions
    {
        public static void SetMessageState(this ServiceBusReceivedMessage receivedMessage, ServiceBusMessageState state = default)
        {
            var amqpAnnotatedMessage = receivedMessage.GetRawAmqpMessage();
            amqpAnnotatedMessage.MessageAnnotations[Constants.MessageStateName] = (int) state;
        }
    }
}