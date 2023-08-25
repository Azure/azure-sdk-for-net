// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.ServiceBus;

namespace Azure.Messaging.ServiceBus.Stress;

/// <summary>
///   The set of configurations that can be specified when creating a <see cref="Processor" />
///   role.
/// </summary>
///
internal class ProcessorConfiguration
{
    /// <summary>
    ///   The value to use for <see cref="ServiceBusProcessorOptions" /> when configuring
    ///   the <see cref="ServiceBusProcessor" />.
    /// </summary>
    ///
    public ServiceBusProcessorOptions options = new ServiceBusProcessorOptions();
}