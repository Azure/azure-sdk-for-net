// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Provisioning;

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Restore the preview-only ClusterType property exposed by the previous GA package.
public partial class CassandraClusterProperties
{
    private BicepValue<CassandraClusterType> _clusterType;

    /// <summary>
    /// Type of the cluster. If set to Production, some operations might not be
    /// permitted on cluster.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<CassandraClusterType> ClusterType
    {
        get
        {
            Initialize();
            return _clusterType;
        }
        set
        {
            Initialize();
            _clusterType.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _clusterType = DefineProperty<CassandraClusterType>(nameof(ClusterType), new string[] { "clusterType" });
    }
}
