// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Messaging.ServiceBus.Stress;

/// <summary>
///   The set of configurations that can be specified when creating a <see cref="TransactionSender" />
///   role.
/// </summary>
///
internal class TransactionSenderConfiguration
{
    // Test Configuration Values

    /// <summary>
    ///   If the <see cref="ServiceBusSender" /> should use batches to send.
    /// </summary>
    ///
    public bool UseBatches = false;

    /// <summary>
    ///   The number of messages being sent during the transaction.
    /// </summary>
    ///
    public int MessagesPerTransaction = 3;

    /// <summary>
    ///   The minimum body size in bytes of events to generate when sending to the queue.
    /// </summary>
    ///
    public int MessageBodyMinBytes = 50;

    /// <summary>
    ///   The maximum body size in bytes of events to generate when sending to the queue.
    /// </summary>
    ///
    public int MessageBodyMaxBytes = 262144;

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

    /// <summary>
    ///   The <see cref=""/> when configuring the <see cref="ServiceBusSender" />.
    /// </summary>
    ///
    public ServiceBusSenderOptions senderOptions = default;

    /// <summary>
    ///   The <see cref=""/> when configuring the <see cref="ServiceBusClient" />.
    /// </summary>
    ///
    public ServiceBusClientOptions clientOptions = new ServiceBusClientOptions { EnableCrossEntityTransactions = true };
}