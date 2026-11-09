// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Restore the preview-only enum exposed by the previous GA package.
/// <summary>
/// Type of the cluster. If set to Production, some operations might not be
/// permitted on cluster.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public enum CassandraClusterType
{
    /// <summary>
    /// Production.
    /// </summary>
    Production,

    /// <summary>
    /// NonProduction.
    /// </summary>
    NonProduction,
}
