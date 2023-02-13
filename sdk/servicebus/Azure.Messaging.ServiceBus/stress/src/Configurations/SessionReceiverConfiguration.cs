// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.ServiceBus.Stress;

/// <summary>
///   The set of configurations that can be specified when creating a <see cref="Receiver" />
///   role.
/// </summary>
///
internal class SessionReceiverConfiguration
{
    /// <summary>
    ///   The value to use for <see cref="ReadEventOptions.MaximumWaitTime" />
    ///   when reading events using an <see cref="ServiceBusSessionReceiver" />.
    /// </summary>
    ///
    public TimeSpan MaximumWaitTime = TimeSpan.FromSeconds(5);

    /// <summary>
    ///   The value to use for <see cref="ServiceBusReceiverOptions" />
    ///   when configuring an <see cref="ServiceBusSessionReceiver" />.
    /// </summary>
    ///
    public ServiceBusReceiverOptions options = new ServiceBusReceiverOptions();
}