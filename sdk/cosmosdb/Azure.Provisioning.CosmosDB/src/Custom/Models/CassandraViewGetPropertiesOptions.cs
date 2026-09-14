// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Restore a supporting type for the preview-only Cassandra view API exposed by the
// previous GA package but omitted from the selected stable TypeSpec version.
/// <summary>
/// The CassandraViewGetPropertiesOptions.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public partial class CassandraViewGetPropertiesOptions : ProvisionableConstruct
{
    private BicepValue<int>? _throughput;
    private BicepValue<int>? _autoscaleMaxThroughput;

    /// <summary>
    /// Value of the Cosmos DB resource throughput or autoscaleSettings. Use
    /// the ThroughputSetting resource when retrieving offer details.
    /// </summary>
    public BicepValue<int> Throughput
    {
        get { Initialize(); return _throughput!; }
        set { Initialize(); _throughput!.Assign(value); }
    }

    /// <summary>
    /// Represents maximum throughput, the resource can scale up to.
    /// </summary>
    public BicepValue<int> AutoscaleMaxThroughput
    {
        get { Initialize(); return _autoscaleMaxThroughput!; }
        set { Initialize(); _autoscaleMaxThroughput!.Assign(value); }
    }

    /// <summary>
    /// Creates a new CassandraViewGetPropertiesOptions.
    /// </summary>
    public CassandraViewGetPropertiesOptions()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// CassandraViewGetPropertiesOptions.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _throughput = DefineProperty<int>("Throughput", ["throughput"]);
        _autoscaleMaxThroughput = DefineProperty<int>("AutoscaleMaxThroughput", ["autoscaleSettings", "maxThroughput"]);
    }
}
