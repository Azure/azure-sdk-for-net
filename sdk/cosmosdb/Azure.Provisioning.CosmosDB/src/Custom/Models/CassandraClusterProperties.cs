// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Restore the preview-only ClusterType property exposed by the previous GA package.
public partial class CassandraClusterProperties
{
    private BicepValue<CassandraClusterType> _clusterType;
    private BicepValue<ScheduledEventStrategy> _scheduledEventStrategy;

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

    // CUSTOMIZATION: Preserve the legacy property type while retaining the newly generated enum under a distinct property name.
    /// <summary>
    /// How the nodes in the cluster react to scheduled events.
    /// </summary>
    [CodeGenMember("ScheduledEventStrategy")]
    public BicepValue<ScheduledEventStrategy> ScheduledEventStrategy
    {
        get
        {
            Initialize();
            return _scheduledEventStrategy;
        }
        set
        {
            Initialize();
            _scheduledEventStrategy.Assign(value);
        }
    }

    /// <summary>
    /// How the nodes in the cluster react to scheduled events.
    /// </summary>
    public BicepValue<CassandraScheduledEventStrategy> CassandraScheduledEventStrategy
    {
        get
        {
            Initialize();
            if (((IBicepValue)_scheduledEventStrategy).Kind == BicepValueKind.Literal)
            {
                return (global::Azure.Provisioning.CosmosDB.CassandraScheduledEventStrategy)(int)_scheduledEventStrategy.Value;
            }

            return _scheduledEventStrategy.Compile();
        }
        set
        {
            Initialize();
            if (value is null)
            {
                _scheduledEventStrategy.Assign(null);
            }
            else if (((IBicepValue)value).Kind == BicepValueKind.Literal)
            {
                _scheduledEventStrategy.Assign((global::Azure.Provisioning.CosmosDB.ScheduledEventStrategy)(int)value.Value);
            }
            else
            {
                ((IBicepValue)_scheduledEventStrategy).Assign(value);
            }
        }
    }

    partial void DefineAdditionalProperties()
    {
        _clusterType = DefineProperty<CassandraClusterType>(nameof(ClusterType), new string[] { "clusterType" });
        _scheduledEventStrategy = DefineProperty<ScheduledEventStrategy>(nameof(ScheduledEventStrategy), new string[] { "scheduledEventStrategy" });
    }
}
