// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.ServiceBus;

namespace Azure.Messaging.ServiceBus.Stress;

/// <summary>
///   The set of configurations that can be specified when creating a <see cref="SessionProcessor" />
///   role.
/// </summary>
///
internal class SessionProcessorConfiguration
{
    /// <summary>
    ///   The value to use for <see cref="ServiceBusSessionProcessorOptions" />
    ///   when configuring the <see cref="ServiceBusSessionProcessor" />.
    /// </summary>
    ///
    public ServiceBusSessionProcessorOptions options = new ServiceBusSessionProcessorOptions();
}