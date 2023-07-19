// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventHubs.Stress;

/// <summary>
///   The set of configurations that can be specified when creating a <see cref="PartitionPublisher" />
///   role.
/// </summary>
///
internal class PartitionPublisherConfiguration
{
    /// <summary>
    ///   The number of events to generate and put into a batch during each iteration of
    ///   <see cref="EventHubProducerClient.SendAsync" />.
    /// </summary>
    ///
    public int PublishBatchSize = 50;

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
    ///   The percentage of generated events for each send that have large bodies in bytes
    /// </summary>
    ///
    public int LargeMessageRandomFactorPercent = 50;

    /// <summary>
    ///   The amount of time to wait between enqueuing <see cref="PublishBatchSize"/> events.
    /// </summary>
    ///
    public TimeSpan? ProducerPublishingDelay = TimeSpan.FromMilliseconds(400);

    // Producer Configuration Values

    /// <summary>
    ///   The value to use for <see cref="EventHubsRetryOptions.TryTimeout" /> when configuring
    ///   the <see cref="EventHubProducerClient" />.
    /// </summary>
    ///
    public TimeSpan SendTimeout = TimeSpan.FromMinutes(3);
}