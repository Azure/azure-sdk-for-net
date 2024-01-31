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
    internal class PersistedEventRecording
    {
        public List<RecordedServiceBusReceivedMessage> Entries { get; set; } = new List<RecordedServiceBusReceivedMessage>();
    }
}
