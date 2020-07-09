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
using Microsoft.Azure.Management.EventGrid.Models;
using NUnit.Framework;

namespace Azure.Messaging.EventGrid.Tests
{
    internal partial class TestEvent
    {
        public TestEvent()
        {
        }

        public string dataVersion { get; set; }
        public DateTimeOffset eventTime { get; set; }
        public string eventType { get; set; }
        public string id { get; set; }
        public string subject { get; set; }
        public string topic { get; set; }
    }
}
