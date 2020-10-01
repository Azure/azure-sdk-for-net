// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Messaging.EventGrid;
using Azure.Messaging.EventGrid.Models;
using NUnit.Framework;

namespace Azure.Messaging.EventGrid.Tests
{
    internal partial class TestEvent
    {
        public TestEvent()
        {
        }

        public string DataVersion { get; set; }
        public DateTimeOffset EventTime { get; set; }
        public string EventType { get; set; }
        public string Id { get; set; }
        public string Subject { get; set; }
        public string Topic { get; set; }
    }
}
