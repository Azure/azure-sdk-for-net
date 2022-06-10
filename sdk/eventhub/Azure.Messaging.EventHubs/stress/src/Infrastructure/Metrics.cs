// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Metrics;
using Microsoft.ApplicationInsights.Extensibility;

namespace Azure.Messaging.EventHubs.Stress;

/// <summary>
///   The set of metrics and the <see cref="TelementryClient" /> used to collect information
///   from test runs and send them to Application Insights.
/// </summary>
///
internal class Metrics
{
    /// <summary>
    ///   The Client used to communicate with Application Insights.
    /// </summary>
    ///
    public TelemetryClient Client;

    // Test names for dimensions

    /// <summary>
    ///   The name of the Event Producer test scenario, for use within metrics dimensions.
    ///   This allows metrics to be easily filterable by test in both Cluster deployed test
    ///   runs and local test runs.
    /// </summary>
    ///
    public const string EventProducerTest = "EventProducerTest";

    /// <summary>
    ///   The name of the Buffered Producer test scenario, for use within metrics dimensions.
    ///   This allows metrics to be easily filterable by test in both Cluster deployed test
    ///   runs and local test runs.
    /// </summary>
    ///
    public const string BufferedProducerTest = "BufferedProducerTest";

    /// <summary>
    ///   The name of the basic Processor test scenario, for use within metrics dimensions.
    ///   This allows metrics to be easily filterable by test in both Cluster deployed test
    ///   runs and local test runs.
    /// </summary>
    ///
    public const string BasicProcessorTest = "BasicProcessorTest";

    /// <summary>
    ///   The name of the basic read test scenario, for use within metrics dimensions.
    ///   This allows metrics to be easily filterable by test in both Cluster deployed test
    ///   runs and local test runs.
    /// </summary>
    ///
    public const string BasicReadTest = "BasicReadTest";

    // Environment statistics - Garbage Collection

    /// <summary>
    ///   This is the metric name used to collect metrics on generation zero
    ///   garbage collection.
    /// </summary>
    ///
    public const string GenerationZeroCollections = "GenerationZeroCollections";

    /// <summary>
    ///   This is the metric name used to collect metrics on generation one
    ///   garbage collection.
    /// </summary>
    ///
    public const string GenerationOneCollections = "GenerationOneCollections";

    /// <summary>
    ///   This is the metric name used to collect metrics on generation two
    ///   garbage collection.
    /// </summary>
    ///
    public const string GenerationTwoCollections = "GenerationTwoCollections";

    // Dimension names

    /// <summary>
    ///   This is the dimension name to hold which test is collecting metrics.
    /// </summary>
    ///
    public const string TestName = "TestName";

    /// <summary>
    ///   This is the dimension name used to hold which partition an event send or read
    ///   is associated with.
    /// </summary>
    ///
    public const string PartitionId = "PartitionId";

    /// <summary>
    ///   This is the dimension name used to hold which identifier is associated with a
    ///   given processor.
    /// </summary>
    ///
    public const string Identifier = "Identifier";

    // Shared Producer statistics

    /// <summary>
    ///   This is the metric name used to collect metrics on how many batches
    ///   are published by the Event Producer or Buffered Producer client.
    /// </summary>
    ///
    public const string BatchesPublished = "BatchesPublished";

    /// <summary>
    ///   This is the metric name used to collect metrics on how many times
    ///   the Event Producer or Buffered Producer client needs to restart.
    /// </summary>
    ///
    public const string ProducerRestarted = "ProducerRestarted";

    // Buffered Producer statistics

    /// <summary>
    ///   This is the metric name used to collect metrics on how many events
    ///   are not sent after the Buffered Producer successfully enqueued them.
    /// </summary>
    ///
    public const string EventsNotSentAfterEnqueue = "EventsNotSentAfterEnqueue";

    /// <summary>
    ///   This is the metric name used to collect metrics on how many events
    ///   were successfully sent after the Buffered Producer successfully enqueued them.
    /// </summary>
    ///
    public const string SuccessfullySentFromQueue = "SuccessfullySentFromQueue";

    /// <summary>
    ///   This is the metric name used to collect metrics on how many events were successfully
    ///   added to the queue in the Buffered Producer.
    /// </summary>
    ///
    public const string EventsEnqueued = "EventsEnqueued";

    // Event Producer statistics

    /// <summary>
    ///   This is the metric name used to collect metrics on the number of events successfully
    ///   published by the Event Producer client.
    /// </summary>
    ///
    public const string EventsPublished = "EventsPublished";

    /// <summary>
    ///   This is the metric name used to collect metrics on the number of times the Event Producer client
    ///   tried to publish an event, regardless of if the event was successfully published or not.
    /// </summary>
    ///
    public const string PublishAttempts = "PublishAttempts";

    /// <summary>
    ///   This is the metric name used to collect metrics on the total number of bytes that have been
    ///   published to the Event Hub over the course of the test run.
    /// </summary>
    ///
    public const string TotalPublishedSizeBytes = "TotalPublishedSizeBytes";

    // Processor statistics

    /// <summary>
    ///   This is the metric name used to collect metrics on the number of times the event handler was
    ///   called when the processor is running.
    /// </summary>
    ///
    public const string EventHandlerCalls = "EventHandlerCalls";

    /// <summary>
    ///   This is the metric name used to collect metrics on the number of times the process had to restart.
    /// </summary>
    ///
    public const string ProcessorRestarted = "ProcessorRestarted";

    /// <summary>
    ///   This is the metric name used to collect metrics on the number of service operations done by the
    ///   processor.
    /// </summary>
    ///
    public const string TotalServiceOperations = "TotalServiceOperations";

    /// <summary>
    ///   This is the metric name used to collect metrics on the number of events read by the processor.
    /// </summary>
    ///
    public const string EventsRead = "EventsRead";

    /// <summary>
    ///   This is the metric name used to collect metrics on the number of events processed by the processor.
    /// </summary>
    ///
    public const string EventsProcessed = "EventsProcessed";

    /// <summary>
    ///   Initializes a new instance of the <see cref="Metrics" /> class.
    /// </summary>
    ///
    /// <param name="instrumentationKey">The instrumentation key associated with the Application Insights resource.</param>
    ///
    public Metrics(string instrumentationKey)
    {
        var configuration = TelemetryConfiguration.CreateDefault();
        configuration.InstrumentationKey = instrumentationKey;

        Client = new TelemetryClient(configuration);
    }
}