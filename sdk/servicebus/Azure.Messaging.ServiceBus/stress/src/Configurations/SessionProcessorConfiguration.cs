// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.ServiceBus.Stress;

/// <summary>
///   The set of configurations that can be specified when creating a <see cref="SessionProcessor" />
///   role.
/// </summary>
///
internal class SessionProcessorConfiguration
{
    /// <summary>
    ///   The value to use for <see cref="ServiceBusSessionProcessorOptions.MaxConcurrentCalls" />
    ///   when configuring the <see cref="ServiceBusSessionProcessor" />.
    /// </summary>
    ///
    public int MaxConcurrentCalls = 5;

    /// <summary>
    ///   The value to use for <see cref="ServiceBusSessionProcessorOptions.AutoCompleteMessages" />
    ///   when configuring the <see cref="ServiceBusSessionProcessor" />.
    /// </summary>
    ///
    public bool AutoCompleteMessages = true;

    /// <summary>
    ///   The value to use for <see cref="ServiceBusSessionProcessorOptions.MaxConcurrentCallsPerSession" />
    ///   when configuring the <see cref="ServiceBusSessionProcessor" />.
    /// </summary>
    ///
    public int MaxConcurrentCallsPerSession = 2;

    // /// <summary>
    // ///   The value to use for <see cref="ServiceBusSessionProcessorOptions.MaxConcurrentCallsPerSession" />
    // ///   when configuring the <see cref="ServiceBusSessionProcessor" />.
    // /// </summary>
    // ///
    // public  SessionIds; TODO
}