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
        public MetricIdentifier TotalMemoryUsedIdent = new MetricIdentifier("TotalMemoryUsed");
        public long TotalMemoryUsed = 0;
        public MetricIdentifier MemoryUsed = new MetricIdentifier("MemoryUsed");
        public MetricIdentifier PeakPhysicalMemory = new MetricIdentifier("PeakPhysicalMemory");
        public MetricIdentifier TotalAllocatedBytes = new MetricIdentifier("TotalAllocatedBytes");
        public MetricIdentifier GenerationZeroCollections = new MetricIdentifier("GenerationZeroCollections");
        public MetricIdentifier GenerationOneCollections = new MetricIdentifier("GenerationOneCollections");
        public MetricIdentifier GenerationTwoCollections = new MetricIdentifier("GenerationTwoCollections");
        public MetricIdentifier TotalProcessorTime = new MetricIdentifier("TotalProcessorTime");
        public MetricIdentifier RunDuration = new MetricIdentifier("RunDuration");

        // Publisher statistics
        public MetricIdentifier BatchesCount = new MetricIdentifier("BatchesCount");
        public MetricIdentifier SentEventsCount = new MetricIdentifier("SentEventsCount");
        public MetricIdentifier SuccessfullyReceivedEventsCount = new MetricIdentifier("SuccessfullyReceivedEventsCount");
        public MetricIdentifier ProducerFailureCount = new MetricIdentifier("ProducerFailureCount");
        public MetricIdentifier ConsumerFailureCount = new MetricIdentifier("ConsumerFailureCount");
        public MetricIdentifier CorruptedBodyFailureCount = new MetricIdentifier("CorruptedBodyFailureCount");
        public MetricIdentifier CorruptedPropertiesFailureCount = new MetricIdentifier("CorruptedPropertiesFailureCount");

        // Buffered Producer statistics
        public MetricIdentifier EventsEnqueued = new MetricIdentifier("EventsEnqueued");

        // Statistics
        public MetricIdentifier TotalServiceOperations = new MetricIdentifier("MemorySamples");
        public MetricIdentifier EventsPublished = new MetricIdentifier("MemorySamples");
        public MetricIdentifier EventsRead = new MetricIdentifier("MemorySamples");
        public MetricIdentifier EventsProcessed = new MetricIdentifier("MemorySamples");
        public double RunDurationMilliseconds = 0;
        //public ConcurrentDictionary<string, int> EventHandlerCalls = new ConcurrentDictionary<string, int>();
        public MetricIdentifier PublishAttempts = new MetricIdentifier("PublishAttempts");
        public MetricIdentifier BatchesPublished = new MetricIdentifier("BatchesPublished");
        public MetricIdentifier TotalPublishedSizeBytes = new MetricIdentifier("TotalPublishedSizeBytes");

        // Event validation issues
        public MetricIdentifier InvalidBodies = new MetricIdentifier("MemorySamples");
        public MetricIdentifier InvalidProperties = new MetricIdentifier("MemorySamples");
        public MetricIdentifier EventsNotReceived = new MetricIdentifier("MemorySamples");
        public MetricIdentifier EventsOutOfOrder = new MetricIdentifier("MemorySamples");
        public MetricIdentifier EventsFromWrongPartition = new MetricIdentifier("MemorySamples");
        public MetricIdentifier UnknownEventsProcessed = new MetricIdentifier("MemorySamples");
        public MetricIdentifier DuplicateEventsDiscarded = new MetricIdentifier("MemorySamples");

        // Exceptions
        public MetricIdentifier SendExceptions = new MetricIdentifier("MemorySamples");
        public MetricIdentifier CanceledSendExceptions = new MetricIdentifier("CanceledSendExceptions");
        public MetricIdentifier ProcessingExceptions = new MetricIdentifier("MemorySamples");
        public MetricIdentifier TotalExceptions = new MetricIdentifier("MemorySamples");
        public MetricIdentifier GeneralExceptions = new MetricIdentifier("MemorySamples");
        public MetricIdentifier TimeoutExceptions = new MetricIdentifier("MemorySamples");
        public MetricIdentifier CommunicationExceptions = new MetricIdentifier("MemorySamples");
        public MetricIdentifier ServiceBusyExceptions = new MetricIdentifier("MemorySamples");
        public MetricIdentifier ProcessorRestarted = new MetricIdentifier("MemorySamples");
        public MetricIdentifier ProducerRestarted = new MetricIdentifier("MemorySamples");

        public Metrics(string instrumentationKey)
        {
            var configuration = TelemetryConfiguration.CreateDefault();
            configuration.InstrumentationKey = instrumentationKey;

            // TODO: dispose??
            Client = new TelemetryClient(configuration);
        }

        public void UpdateEnvironmentStatistics(Process currentProcess, TelemetryClient client)
        {
            var memoryUsed = GC.GetTotalMemory(false);

            client.GetMetric(MemorySamples).TrackValue(1);
            // client.GetMetric(TotalMemoryUsed).TrackValue(memoryUsed);
            Interlocked.Add(ref TotalMemoryUsed, memoryUsed);
            client.GetMetric(MemoryUsed).TrackValue(memoryUsed);
            client.GetMetric(GenerationZeroCollections).TrackValue(GC.CollectionCount(0));
            client.GetMetric(GenerationOneCollections).TrackValue(GC.CollectionCount(1));
            client.GetMetric(GenerationTwoCollections).TrackValue(GC.CollectionCount(2));

            // TODO: transfer to AppInsights
            // if (memoryUsed > Interlocked.Read(ref PeakPhysicalMemory))
            // {
            //     Interlocked.Exchange(ref PeakPhysicalMemory, memoryUsed);
            // }

            // if (memoryUsed > Interlocked.Read(ref PeakPhysicalMemory))
            // {
            //     Interlocked.Exchange(ref PeakPhysicalMemory, memoryUsed);
            // }
            //TotalProcessorTime = currentProcess.TotalProcessorTime;
            client.GetMetric(TotalProcessorTime).TrackValue(currentProcess.TotalProcessorTime);
        }
    }
}