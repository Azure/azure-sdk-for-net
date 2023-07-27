// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace Azure.Communication.CallAutomation.Tests.EventCatcher
{
    internal static class MessageConverter
    {
        public static RecordedServiceBusReceivedMessage ConvertToRecordedMessage(ServiceBusReceivedMessage receivedMessage)
        {
            var result = new RecordedServiceBusReceivedMessage()
            {
                Body = receivedMessage.Body.ToString(),
                MessageId = receivedMessage.MessageId,
                PartitionKey = receivedMessage.PartitionKey,
                SessionId = receivedMessage.SessionId,
                ReplyToSessionId = receivedMessage.ReplyToSessionId,
                CorrelationId = receivedMessage.CorrelationId,
                Subject = receivedMessage.Subject,
                ContentType = receivedMessage.ContentType,
                ReplyTo = receivedMessage.ReplyTo,
                ApplicationProperties = receivedMessage.ApplicationProperties,
            };
            return result;
        }
    }
}
