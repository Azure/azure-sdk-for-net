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
    internal class RecordedServiceBusReceivedMessage
    {
        public string Body { get; set; }
        public string MessageId { get; set; }

        public string PartitionKey { get; set; }

        public string SessionId { get; set; }

        public string ReplyToSessionId { get; set; }

        public string CorrelationId { get; set; }

        public string Subject { get; set; }

        public string ContentType { get; set; }

        public string ReplyTo { get; set; }

        public IReadOnlyDictionary<string, object> ApplicationProperties { get; set; }

        public DateTimeOffset EnqueuedTime { get; set; }

#pragma warning disable CS8618
        public RecordedServiceBusReceivedMessage()
#pragma warning restore CS8618
        {
        }
    }
}
