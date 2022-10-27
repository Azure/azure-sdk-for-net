// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Messaging.ServiceBus.Stress;

/// <summary>
///   The set of configurations that can be specified when creating a <see cref="Sender" />
///   role.
/// </summary>
///
internal class SenderConfiguration
{
    // Test Configuration Values

    /// <summary>
    ///   The number of concurrent sends going to the same <see cref="ServiceBusSender" />.
    /// </summary>
    ///
    public int ConcurrentSends = 3;

    /// <summary>
    ///   The minimum body size in bytes of events to generate when sending to the queue.
    /// </summary>
    ///
    public int SendingBodyMinBytes = 100;

    /// <summary>
    ///   The maximum body size in bytes of events to generate when sending to the queue.
    /// </summary>
    ///
    public int SendingBodyRegularMaxBytes = 262144;

    /// <summary>
    ///   The percentage of generated events for each send that have large bodies in bytes.
    /// </summary>
    ///
    public int LargeMessageRandomFactorPercent = 50;

    /// <summary>
    ///   The amount of time to wait between sending a set of events.
    /// </summary>
    ///
    public TimeSpan? SendingDelay = TimeSpan.FromMilliseconds(400);

    // Producer Configuration Values

    /// <summary>
    ///   The value to use for <see cref="ServiceBusRetryOptions.TryTimeout" /> when configuring
    ///   the <see cref="ServiceBusSender" />.
    /// </summary>
    ///
    public TimeSpan SendTimeout = TimeSpan.FromMinutes(3);
}