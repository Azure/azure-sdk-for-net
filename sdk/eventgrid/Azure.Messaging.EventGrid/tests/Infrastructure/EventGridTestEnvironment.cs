// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Messaging.EventGrid.Tests
{
    public class EventGridTestEnvironment : TestEnvironment
    {
        public EventGridTestEnvironment() : base("eventgrid")
        {
        }
        public static EventGridTestEnvironment Instance { get; } = new EventGridTestEnvironment();
        public string TopicHost => new Uri(GetRecordedVariable("EVENT_GRID_TOPIC_ENDPOINT")).Host;
        public string TopicKey => GetVariable("EVENT_GRID_TOPIC_KEY");
    }
}
