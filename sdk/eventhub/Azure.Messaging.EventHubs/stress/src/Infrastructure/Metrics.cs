// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Metrics;
using Microsoft.ApplicationInsights.Extensibility;

namespace Azure.Messaging.EventHubs.Stress
{
    // Metrics names are shared between tests, since test information is collected through
    // the container orchestration. Metrics are still filterable by test with application insights.
    internal class Metrics
    {
        public TelemetryClient Client;

        // Environment statistics - Garbage Collection
        public MetricIdentifier GenerationZeroCollections = new MetricIdentifier("GenerationZeroCollections");
        public MetricIdentifier GenerationOneCollections = new MetricIdentifier("GenerationOneCollections");
        public MetricIdentifier GenerationTwoCollections = new MetricIdentifier("GenerationTwoCollections");

        // Shared Producer statistics
        public MetricIdentifier BatchesPublished = new MetricIdentifier("BatchesPublished");
        public MetricIdentifier ProducerRestarted = new MetricIdentifier("ProducerRestarted");

        // Buffered Producer statistics
        public string EventsNotSentAfterEnqueue = "EventsNotSentAfterEnqueue";
        public string SuccessfullySentFromQueue = "SuccessfullySentFromQueue";
        public MetricIdentifier EventsEnqueued = new MetricIdentifier("EventsEnqueued");

        // Event Producer statistics
        public MetricIdentifier EventsPublished = new MetricIdentifier("EventsPublished");
        public MetricIdentifier PublishAttempts = new MetricIdentifier("PublishAttempts");
        public MetricIdentifier TotalPublishedSizeBytes = new MetricIdentifier("TotalPublishedSizeBytes");

        public Metrics(string instrumentationKey)
        {
            var configuration = TelemetryConfiguration.CreateDefault();
            configuration.InstrumentationKey = instrumentationKey;

            Client = new TelemetryClient(configuration);
        }
    }
}