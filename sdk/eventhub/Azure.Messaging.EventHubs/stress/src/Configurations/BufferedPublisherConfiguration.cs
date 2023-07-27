// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventHubs.Stress;

/// <summary>
///   The set of configurations that can be specified when creating a <see cref="BufferedPublisher" />
///   role.
/// </summary>
///
internal class BufferedPublisherConfiguration
{
    // Test Configuration Values

    /// <summary>
    ///   The number of events to generate for each call to
    ///   <see cref="EventHubBufferedProducerClient.EnqueueEventsAsync(IEnumerable{EventData}, EnqueueEventOptions, CancellationToken)" />.
    /// </summary>
    ///
    public int EventEnqueueListSize = 50;

    /// <summary>
    ///   The maximum size in bytes for the list of events to generate per call to
    ///   <see cref="EventHubBufferedProducerClient.EnqueueEventsAsync(IEnumerable{EventData}, EnqueueEventOptions, CancellationToken)" />.
    /// </summary>
    ///
    public long MaximumEventListSize = 1_000_000;

    /// <summary>
    ///   The number of concurrent sends going to the same <see cref="EventHubBufferedProducerClient" />.
    /// </summary>
    ///
    public int ConcurrentSends = 5;

    /// <summary>
    ///   The minimum body size in bytes of events to generate when sending to the event hub.
    /// </summary>
    ///
    public int PublishingBodyMinBytes = 100;

    /// <summary>
    ///   The maximum body size in bytes of events to generate when sending to the event hub.
    /// </summary>
    ///
    public int PublishingBodyRegularMaxBytes = 262144;

    /// <summary>
    ///   The percentage of generated events for each send that have large bodies.
    /// </summary>
    ///
    public int LargeMessageRandomFactorPercent = 50;

    /// <summary>
    ///   The amount of time to wait between enqueuing <see cref="EnqueueListSize"/> events.
    /// </summary>
    ///
    public TimeSpan? ProducerPublishingDelay = TimeSpan.FromMilliseconds(400);

    // Buffered Producer Configuration Values

    /// <summary>
    ///   The value to use for <see cref="EventHubBufferedProducerClientOptions.MaximumWaitTime" />
    ///   when configuring the <see cref="EventHubBufferedProducerClient" />.
    /// </summary>
    ///
    public TimeSpan MaxWaitTime = TimeSpan.FromSeconds(5);

    /// <summary>
    ///   The value to use for <see cref="EventHubsRetryOptions.TryTimeout" /> when configuring
    ///   the <see cref="EventHubBufferedProducerClient" />.
    /// </summary>
    ///
    public TimeSpan SendTimeout = TimeSpan.FromMinutes(3);
}