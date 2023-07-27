// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventHubs.Stress;

/// <summary>
///   The set of configurations that can be specified when creating a <see cref="Processor" />
///   role.
/// </summary>
///
internal class ProcessorConfiguration
{
    /// <summary>
    ///   The value to use for <see cref="EventHubsRetryOptions.TryTimeout" />
    ///   when configuring the <see cref="EventProcessorClient" />.
    /// </summary>
    ///
    public TimeSpan ReadTimeout = TimeSpan.FromMinutes(1);
}