// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;

namespace Azure.Messaging.EventHubs.Stress;

/// <summary>
///   The set of metrics and the <see cref="TelementryClient" /> used to collect information
///   from test runs and send them to Application Insights.
/// </summary>
///
public class Metrics
{
    /// <summary>
    ///   The Client used to communicate with Application Insights.
    /// </summary>
    ///
    public TelemetryClient Client;

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
    ///   This is the metric name used to collect metrics on the number of duplicate events processed by the processor.
    /// </summary>
    ///
    public const string DuplicateEventsDiscarded = "DuplicateEventsDiscarded";

    /// <summary>
    ///   This is the metric name used by the partition publisher to collect metrics on the number of events that failed to publish.
    /// </summary>
    ///
    public const string EventsFailedToPublish = "EventsFailedToPublish";

    /// <summary>
    ///   This is the property name used to send information about the publisher assigned index to Application Insights for further
    ///   investigation.
    /// </summary>
    ///
    public const string PublisherAssignedIndex = "PublisherAssignedIndex";

    /// <summary>
    ///   This is the property name used to send information about the publisher assigned Id to Application Insights for further
    ///   investigation.
    /// </summary>
    ///
    public const string PublisherAssignedId = "PublisherAssignedId";

    /// <summary>
    ///   This is the metric name used by the processor when a received event was received from the partition that it was not intended
    ///   to be sent to.
    /// </summary>
    ///
    public const string EventReceivedFromWrongPartition = "EventReceivedFromWrongPartition";

    /// <summary>
    ///   This is the metric name used by the processor when an event is received in the wrong order or an event is missing.
    /// </summary>
    ///
    public const string MissingOrOutOfOrderEvent = "MissingOrOutOfOrderEvent";

    /// <summary>
    ///   The property to use to send the event body to Application Insights for further investigation.
    /// </summary>
    ///
    public const string EventBody = "EventBody";

    /// <summary>
    ///   This is the metric name used by the processor when an event has an invalid body.
    /// </summary>
    ///
    public const string InvalidBodies = "InvalidBodies";

    /// <summary>
    ///   This is the metric name used by the processor when an unknown event has been processed.
    /// </summary>
    ///
    public const string UnknownEventsProcessed = "UnknownEventsProcessed";

    /// <summary>
    ///   This is the metric name used when the consumer needs to be restarted.
    /// </summary>
    ///
    public const string ConsumerRestarted = "ConsumerRestarted";

    /// <summary>
    ///   This is the event name used by the processor or consumer when an event without a valid index has been processed.
    /// </summary>
    ///
    public const string EventWithInvalidIndex = "EventWithInvalidIndex";

    /// <summary>
    ///   This is the property name used to tell what partition an event was supposed to be sent to when it received from
    ///   a different partition.
    /// </summary>
    ///
    public const string IntendedPartitionId = "IntendedPartitionId";

    /// <summary>
    ///   Initializes a new instance of the <see cref="Metrics" /> class.
    /// </summary>
    ///
    /// <param name="instrumentationKey">The instrumentation key associated with the Application Insights resource.</param>
    ///
    public Metrics(string instrumentationKey)
    {
        var configuration = TelemetryConfiguration.CreateDefault();
#pragma warning disable CS0618 // Type or member is obsolete
        configuration.InstrumentationKey = instrumentationKey;
#pragma warning restore CS0618 // Type or member is obsolete

        Client = new TelemetryClient(configuration);
    }

    /// <summary>
    ///   Collects garbage collection environment metrics and sends them to Application Insights.
    /// </summary>
    ///
    public void UpdateEnvironmentStatistics()
    {
        Client.GetMetric(Metrics.GenerationZeroCollections).TrackValue(GC.CollectionCount(0));
        Client.GetMetric(Metrics.GenerationOneCollections).TrackValue(GC.CollectionCount(1));
        Client.GetMetric(Metrics.GenerationTwoCollections).TrackValue(GC.CollectionCount(2));
    }
}
