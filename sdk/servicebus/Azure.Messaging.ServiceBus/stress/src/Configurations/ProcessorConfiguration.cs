// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.ServiceBus.Stress;

/// <summary>
///   The set of configurations that can be specified when creating a <see cref="Processor" />
///   role.
/// </summary>
///
internal class ProcessorConfiguration
{
    /// <summary>
    ///   The value to use for <see cref="ServiceBusProcessorOptions.MaxConcurrentCalls" />
    ///   when configuring the <see cref="ServiceBusProcessor" />.
    /// </summary>
    ///
    public int MaxConcurrentCalls = 2;

    /// <summary>
    ///   The value to use for <see cref="ServiceBusProcessorOptions.AutoCompleteMessages" />
    ///   when configuring the <see cref="ServiceBusProcessor" />.
    /// </summary>
    ///
    public bool AutoCompleteMessages = true;
}