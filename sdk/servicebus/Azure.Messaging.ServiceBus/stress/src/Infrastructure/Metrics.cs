// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;

namespace Azure.Messaging.ServiceBus.Stress;

/// <summary>
///   The set of metrics and the <see cref="TelemetryClient" /> used to collect information
///   from test runs and send them to Application Insights.
/// </summary>
///
public class Metrics
{
    /// <summary>
    ///   The Client used to communicate with Application Insights.
    /// </summary>
    ///
    public TelemetryClient Client { get; }

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

    /// <summary>
    ///   This is the metric name used to collect metrics on how many batches
    ///   are published by the ServiceBusSender.
    /// </summary>
    ///
    public const string BatchesSent = "BatchesSent";

    /// <summary>
    ///   This is the metric name used to collect metrics on how many times
    ///   the Sender client needs to restart.
    /// </summary>
    ///
    public const string SenderRestarted = "SenderRestarted";

    /// <summary>
    ///   This is the metric name used to collect metrics on the number of messages successfully
    ///   sent by the Service Bus Sender.
    /// </summary>
    ///
    public const string MessagesSent = "MessagesSent";

    /// <summary>
    ///   This is the metric name used to collect metrics on the number of session messages successfully
    ///   sent by the Service Bus Sender.
    /// </summary>
    ///
    public const string SessionMessagesSent = "SessionMessagesSent";

    /// <summary>
    ///   This is the metric name used to collect metrics on the total number of bytes that have been
    ///   Sent to the Service Bus Queue over the course of the test run.
    /// </summary>
    ///
    public const string TotalSentSizeBytes = "TotalSentSizeBytes";

    /// <summary>
    ///   This is the metric name used to collect metrics on the number of times the event handler was
    ///   called when the processor is running.
    /// </summary>
    ///
    public const string MessageHandlerCalls = "MessageHandlerCalls";

    /// <summary>
    ///   This is the metric name used to collect metrics on the number of times the processor had to restart.
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
    ///   This is the metric name used to collect metrics on the number of messages read by the processor.
    /// </summary>
    ///
    public const string MessagesRead = "MessagesRead";

    /// <summary>
    ///   This is the metric name used to collect metrics on the number of messages received by the receiver.
    /// </summary>
    ///
    public const string MessagesReceived = "MessagesReceived";

    /// <summary>
    ///   This is the metric name used to collect metrics on the number of messages completed by a receiver or processor.
    /// </summary>
    ///
    public const string MessagesCompleted = "MessagesCompleted";

    /// <summary>
    ///   This is the metric name used to collect metrics on the number of messages processed by the processor.
    /// </summary>
    ///
    public const string MessagesProcessed = "MessagesProcessed";

    /// <summary>
    ///   This is the metric name used to collect metrics on the number of messages processed by the processor.
    /// </summary>
    ///
    public const string TotalMessagesProcessed = "TotalMessagesProcessed";

    /// <summary>
    ///   This is the metric name used to collect metrics on the number of session messages processed by the session processor.
    /// </summary>
    ///
    public const string SessionMessagesProcessed = "SessionMessagesProcessed";

    /// <summary>
    ///   This is the metric name used to collect metrics on the number of duplicate messages processed by the processor.
    /// </summary>
    ///
    public const string DuplicateMessagesDiscarded = "DuplicateMessagesDiscarded";

    /// <summary>
    ///   This is the metric name used to collect metrics on if a session id in the args does not match the session id in the message.
    /// </summary>
    ///
    public const string MismatchedSessionId = "MismatchedSessionId";

    /// <summary>
    ///   This is the property name used to send information about the application defined index to Application Insights for further
    ///   investigation.
    /// </summary>
    ///
    public const string ApplicationDefinedIndex = "ApplicationDefinedIndex";

    /// <summary>
    ///   This is the property name used to send information about the Application assigned Id to Application Insights for further
    ///   investigation.
    /// </summary>
    ///
    public const string SenderDefinedId = "SenderDefinedId";

    /// <summary>
    ///   The property to use to send the message body to Application Insights for further investigation.
    /// </summary>
    ///
    public const string MessageBody = "MessageBody";

    /// <summary>
    ///   This is the metric name used by the processor when a message has an invalid body.
    /// </summary>
    ///
    public const string InvalidBodies = "InvalidBodies";

    /// <summary>
    ///   This is the metric name used by the processor when an unknown message has been processed.
    /// </summary>
    ///
    public const string UnknownMessagesProcessed = "UnknownMessagesProcessed";

    /// <summary>
    ///   This is the metric name used when the receiver needs to be restarted.
    /// </summary>
    ///
    public const string ReceiverRestarted = "ReceiverRestarted";

    /// <summary>
    ///   This is the dimension name used to hold which identifier is associated with a
    ///   given processor.
    /// </summary>
    ///
    public const string Identifier = "Identifier";

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
