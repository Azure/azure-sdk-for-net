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
    internal class Metrics
    {
        public TelemetryClient Client;

        public string CorruptedPropertiesEvent = "CorruptedPropertiesEvent";
        public string CorruptedBodyEvent = "CorruptedBodyEvent";
        public string LostEventDataEvent = "LostEventDataEvent";

        // Environment statistics
        public MetricIdentifier GenerationZeroCollections = new MetricIdentifier("GenerationZeroCollections");
        public MetricIdentifier GenerationOneCollections = new MetricIdentifier("GenerationOneCollections");
        public MetricIdentifier GenerationTwoCollections = new MetricIdentifier("GenerationTwoCollections");

        // Producer statistics
        public MetricIdentifier BatchesCount = new MetricIdentifier("BatchesCount");
        public MetricIdentifier SentEventsCount = new MetricIdentifier("SentEventsCount");
        public MetricIdentifier SuccessfullyReceivedEventsCount = new MetricIdentifier("SuccessfullyReceivedEventsCount");
        public MetricIdentifier ProducerFailureCount = new MetricIdentifier("ProducerFailureCount");
        public MetricIdentifier ConsumerFailureCount = new MetricIdentifier("ConsumerFailureCount");
        public MetricIdentifier CorruptedBodyFailureCount = new MetricIdentifier("CorruptedBodyFailureCount");
        public MetricIdentifier LostEventsCount = new MetricIdentifier("LostEventsCount");

        // Buffered Producer statistics
        public string EventsNotSentAfterEnqueue = "EventsNotSentAfterEnqueue";
        public string SuccessfullySentFromQueue = "SuccessfullySentFromQueue";
        public MetricIdentifier EventsEnqueued = new MetricIdentifier("EventsEnqueued");
        public MetricIdentifier BufferedProducerRestarted = new MetricIdentifier("BufferedProducerRestarted");

        // Event Producer Statistics
        public MetricIdentifier TotalServiceOperations = new MetricIdentifier("TotalServiceOperations");
        public MetricIdentifier EventsPublished = new MetricIdentifier("EventsPublished");
        public MetricIdentifier PublishAttempts = new MetricIdentifier("PublishAttempts");
        public MetricIdentifier BatchesPublished = new MetricIdentifier("BatchesPublished");
        public MetricIdentifier TotalPublishedSizeBytes = new MetricIdentifier("TotalPublishedSizeBytes");
        public MetricIdentifier EventProducerRestarted = new MetricIdentifier("EventProducerRestarted");

        public Metrics(string instrumentationKey)
        {
            var configuration = TelemetryConfiguration.CreateDefault();
            configuration.InstrumentationKey = instrumentationKey;

            Client = new TelemetryClient(configuration);
        }
    }
}