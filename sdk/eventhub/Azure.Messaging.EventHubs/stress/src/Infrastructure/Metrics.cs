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

        // Environment statistics
        public MetricIdentifier MemorySamples = new MetricIdentifier("MemorySamples");
        public MetricIdentifier GenerationZeroCollections = new MetricIdentifier("GenerationZeroCollections");
        public MetricIdentifier GenerationOneCollections = new MetricIdentifier("GenerationOneCollections");
        public MetricIdentifier GenerationTwoCollections = new MetricIdentifier("GenerationTwoCollections");

        // Publisher statistics
        public MetricIdentifier BatchesCount = new MetricIdentifier("BatchesCount");
        public MetricIdentifier SentEventsCount = new MetricIdentifier("SentEventsCount");
        public MetricIdentifier SuccessfullyReceivedEventsCountPerTest = new MetricIdentifier("SuccessfullyReceivedEventsCount", "SuccessfullyReceivedEventsCount", "Test");
        public MetricIdentifier ProducerFailureCount = new MetricIdentifier("ProducerFailureCount");
        public MetricIdentifier ConsumerFailureCount = new MetricIdentifier("ConsumerFailureCount");
        public MetricIdentifier CorruptedBodyFailureCount = new MetricIdentifier("CorruptedBodyFailureCount");
        public MetricIdentifier CorruptedPropertiesFailureCount = new MetricIdentifier("CorruptedPropertiesFailureCount");

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

        // Exceptions
        public MetricIdentifier SendExceptions = new MetricIdentifier("SendExceptions");
        public MetricIdentifier CanceledSendExceptions = new MetricIdentifier("CanceledSendExceptions");
        public MetricIdentifier ProcessingExceptions = new MetricIdentifier("ProcessingExceptions");
        public MetricIdentifier TotalExceptions = new MetricIdentifier("TotalExceptions");
        public MetricIdentifier GeneralExceptions = new MetricIdentifier("GeneralExceptions");
        public MetricIdentifier TimeoutExceptions = new MetricIdentifier("TimeoutExceptions");
        public MetricIdentifier CommunicationExceptions = new MetricIdentifier("CommunicationExceptions");
        public MetricIdentifier ServiceBusyExceptions = new MetricIdentifier("ServiceBusyExceptions");
        public MetricIdentifier ProcessorRestarted = new MetricIdentifier("ProcessorRestarted");
        public MetricIdentifier ProducerRestarted = new MetricIdentifier("ProducerRestarted");

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