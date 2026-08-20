// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
#pragma warning disable CS1591

using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CosmosDB;

[EditorBrowsable(EditorBrowsableState.Never)]
public partial class CassandraViewGetPropertiesOptions : ProvisionableConstruct
{
    private BicepValue<int>? _throughput;
    private BicepValue<int>? _autoscaleMaxThroughput;

    public BicepValue<int> Throughput
    {
        get { Initialize(); return _throughput!; }
        set { Initialize(); _throughput!.Assign(value); }
    }

    public BicepValue<int> AutoscaleMaxThroughput
    {
        get { Initialize(); return _autoscaleMaxThroughput!; }
        set { Initialize(); _autoscaleMaxThroughput!.Assign(value); }
    }

    public CassandraViewGetPropertiesOptions()
    {
    }

    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _throughput = DefineProperty<int>("Throughput", ["throughput"]);
        _autoscaleMaxThroughput = DefineProperty<int>("AutoscaleMaxThroughput", ["autoscaleSettings", "maxThroughput"]);
    }
}
