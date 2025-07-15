// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;

namespace Azure.Provisioning.EventHubs;

/// <summary>
/// EventHubsNamespace.
/// </summary>
public partial class EventHubsNamespace
{
    /// <summary>
    /// Geo Data Replication settings for the namespace.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public NamespaceGeoDataReplicationProperties GeoDataReplication
    {
        get => throw new NotSupportedException("TODO: Needs to be implemented using extensibility API.");
        set => throw new NotSupportedException("TODO: Needs to be implemented using extensibility API.");
    }
}
