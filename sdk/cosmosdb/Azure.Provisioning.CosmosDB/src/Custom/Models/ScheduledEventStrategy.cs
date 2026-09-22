// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Restore the scheduled-event strategy enum exposed by the previous GA package.
/// <summary>
/// How the nodes in the cluster react to scheduled events.
/// </summary>
public enum ScheduledEventStrategy
{
    /// <summary>
    /// Ignore.
    /// </summary>
    Ignore,

    /// <summary>
    /// StopAny.
    /// </summary>
    StopAny,

    /// <summary>
    /// StopByRack.
    /// </summary>
    StopByRack,
}
