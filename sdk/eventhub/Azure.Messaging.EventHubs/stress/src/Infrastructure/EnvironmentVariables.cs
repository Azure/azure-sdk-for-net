// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventHubs.Stress
{
    public static class EnvironmentVariables
    {
        // Shared Resources
        public const string ApplicationInsightsKey = "APPINSIGHTS_INSTRUMENTATIONKEY";
        public const string EventHubsConnectionString = "EVENTHUB_NAMESPACE_CONNECTION_STRING";

        // Event Hub Names
        public const string EventHubBufferedProducerTest = "EVENTHUB_NAME_BUFFERED_PRODUCER_TEST";
        public const string EventHubEventProducerTest = "EVENTHUB_NAME_EVENT_PRODUCER_TEST";
        public const string EventHubBurstBufferedProducerTest = "EVENTHUB_NAME_BURST_BUFFERED_PRODUCER_TEST";
        public const string EventHubConcurrentBufferedProducerTest = "EVENTHUB_NAME_CONCURRENT_BUFFERED_PRODUCER_TEST";
    }
}