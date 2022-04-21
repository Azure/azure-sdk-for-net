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
        public MetricIdentifier MemorySamples = new MetricIdentifier("MemorySamples");
        public MetricIdentifier GenerationZeroCollections = new MetricIdentifier("GenerationZeroCollections");
        public MetricIdentifier GenerationOneCollections = new MetricIdentifier("GenerationOneCollections");
        public MetricIdentifier GenerationTwoCollections = new MetricIdentifier("GenerationTwoCollections");

        // Publisher statistics
        public MetricIdentifier BatchesCount = new MetricIdentifier("BatchesCount");
        public MetricIdentifier SentEventsCount = new MetricIdentifier("SentEventsCount");
        public MetricIdentifier SuccessfullyReceivedEventsCount = new MetricIdentifier("SuccessfullyReceivedEventsCount");
        public MetricIdentifier ProducerFailureCount = new MetricIdentifier("ProducerFailureCount");
        public MetricIdentifier ConsumerFailureCount = new MetricIdentifier("ConsumerFailureCount");
        public MetricIdentifier CorruptedBodyFailureCount = new MetricIdentifier("CorruptedBodyFailureCount");
        public MetricIdentifier LostEventsCount = new MetricIdentifier("LostEventsCount");

        // Buffered Producer statistics
        public MetricIdentifier EventsEnqueuedPerTest = new MetricIdentifier("EventsEnqueuedPerTest");
        public MetricIdentifier EventsNotSentAfterEnqueue = new MetricIdentifier("EventsNotSentAfterEnqueue");
        public MetricIdentifier SuccessfullyPublishedFromQueue = new MetricIdentifier("SuccessfullyPublishedFromQueue");
        public MetricIdentifier BufferedProducerRestarted = new MetricIdentifier("BufferedProducerRestarted");

        // Statistics
        public MetricIdentifier TotalServiceOperations = new MetricIdentifier("TotalServiceOperations");
        public MetricIdentifier EventsPublished = new MetricIdentifier("EventsPublished");
        public MetricIdentifier EventsRead = new MetricIdentifier("EventsRead");
        public MetricIdentifier EventsProcessed = new MetricIdentifier("EventsProcessed");
        public MetricIdentifier PublishAttempts = new MetricIdentifier("PublishAttempts");
        public MetricIdentifier BatchesPublished = new MetricIdentifier("BatchesPublished");
        public MetricIdentifier TotalPublishedSizeBytes = new MetricIdentifier("TotalPublishedSizeBytes");

        // Event validation issues
        public MetricIdentifier InvalidBodies = new MetricIdentifier("InvalidBodies");
        public MetricIdentifier InvalidProperties = new MetricIdentifier("InvalidProperties");
        public MetricIdentifier EventsNotReceived = new MetricIdentifier("EventsNotReceived");
        public MetricIdentifier EventsOutOfOrder = new MetricIdentifier("EventsOutOfOrder");
        public MetricIdentifier EventsFromWrongPartition = new MetricIdentifier("EventsFromWrongPartition");
        public MetricIdentifier UnknownEventsProcessed = new MetricIdentifier("UnknownEventsProcessed");
        public MetricIdentifier DuplicateEventsDiscarded = new MetricIdentifier("DuplicateEventsDiscarded");

        public Metrics(string instrumentationKey)
        {
            var configuration = TelemetryConfiguration.CreateDefault();
            configuration.InstrumentationKey = instrumentationKey;

            // TODO: dispose??
            Client = new TelemetryClient(configuration);
        }

        public void UpdateEnvironmentStatistics(Process currentProcess, TelemetryClient client)
        {
            client.GetMetric(MemorySamples).TrackValue(1);
            client.GetMetric(GenerationZeroCollections).TrackValue(GC.CollectionCount(0));
            client.GetMetric(GenerationOneCollections).TrackValue(GC.CollectionCount(1));
            client.GetMetric(GenerationTwoCollections).TrackValue(GC.CollectionCount(2));
        }
    }
}