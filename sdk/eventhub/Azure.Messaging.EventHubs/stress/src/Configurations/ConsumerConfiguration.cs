// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventHubs.Stress;

/// <summary>
///   The set of configurations that can be specified when creating a <see cref="Consumer" />
///   role.
/// </summary>
///
internal class ConsumerConfiguration
{
    /// <summary>
    ///   The value to use for <see cref="ReadEventOptions.MaximumWaitTime" />
    ///   when reading events using an <see cref="EventHubConsumerClient" />.
    /// </summary>
    ///
    public TimeSpan MaximumWaitTime = TimeSpan.FromSeconds(5);
}