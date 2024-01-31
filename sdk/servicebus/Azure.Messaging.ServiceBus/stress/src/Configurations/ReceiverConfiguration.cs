// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.ServiceBus.Stress;

/// <summary>
///   The set of configurations that can be specified when creating a <see cref="Receiver" />
///   role.
/// </summary>
///
internal class ReceiverConfiguration
{
    /// <summary>
    ///   The <see cref="ServiceBusReceiverOptions" /> to use when
    ///   creating a <see cref="ServiceBusReceiver" />.
    /// </summary>
    ///
    public ServiceBusReceiverOptions options = default;
}