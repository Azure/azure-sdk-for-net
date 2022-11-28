// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.ServiceBus.Stress;

/// <summary>
///   The set of configurations that can be specified when creating a <see cref="TransactionReceiver" />
///   role.
/// </summary>
///
internal class TransactionReceiverConfiguration
{
    /// <summary>
    ///   The value to use for <see cref="ReadEventOptions.MaximumWaitTime" />
    ///   when reading events using an <see cref="ServiceBusReceiver" />.
    /// </summary>
    ///
    public TimeSpan MaximumWaitTime = TimeSpan.FromSeconds(5);

    /// <summary>
    ///   If the <see cref="ServiceBusReceiver" /> should use batches to receive messages.
    /// </summary>
    ///
    public bool UseBatches = false;
}