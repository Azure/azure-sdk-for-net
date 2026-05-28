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
    ///   If the <see cref="ServiceBusSender" /> should use batches to send.
    /// </summary>
    ///
    public bool UseBatches = false;

    /// <summary>
    ///   The number of concurrent sends going to the same <see cref="ServiceBusSender" />.
    /// </summary>
    ///
    public int ConcurrentSends = 1;

    /// <summary>
    ///   The minimum body size in bytes of events to generate when sending to the queue.
    /// </summary>
    ///
    public int MessageBodyMinBytes = 15;

    /// <summary>
    ///   The maximum number of messages to send in each iteration of the test.
    /// </summary>
    ///
    public int MaxNumberOfMessages = 100;

    /// <summary>
    ///   The maximum body size in bytes of events to generate when sending to the queue.
    /// </summary>
    ///
    public int MessageBodyMaxBytes = 83886;

    /// <summary>
    ///   The percentage of generated events for each send that have large bodies in bytes.
    /// </summary>
    ///
    public int LargeMessageRandomFactorPercent = 5;

    /// <summary>
    ///   The amount of time to wait between sending a set of events.
    /// </summary>
    ///
    public TimeSpan? SendingDelay = TimeSpan.FromMilliseconds(900);

    // Producer Configuration Values

    /// <summary>
    ///   The <see cref="ServiceBusSenderOptions"> to use when configuring the <see cref="ServiceBusSender" />.
    /// </summary>
    ///
    public ServiceBusSenderOptions options = default;
}