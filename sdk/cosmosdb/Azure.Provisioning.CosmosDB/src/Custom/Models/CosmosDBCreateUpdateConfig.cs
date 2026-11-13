// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Restore the create-body options model required by the legacy public API.
// Remove this customization when https://github.com/Azure/azure-sdk-for-net/issues/61011 is fixed.
/// <summary>
/// A list of key-value pairs that describe a Cosmos DB resource create or update request.
/// </summary>
public partial class CosmosDBCreateUpdateConfig : ProvisionableConstruct
{
    private BicepValue<int> _throughput;
    private BicepValue<int> _autoscaleMaxThroughput;

    /// <summary>
    /// Request Units per second.
    /// </summary>
    public BicepValue<int> Throughput
    {
        get { Initialize(); return _throughput; }
        set { Initialize(); _throughput.Assign(value); }
    }

    /// <summary>
    /// Represents maximum throughput the resource can scale up to.
    /// </summary>
    public BicepValue<int> AutoscaleMaxThroughput
    {
        get { Initialize(); return _autoscaleMaxThroughput; }
        set { Initialize(); _autoscaleMaxThroughput.Assign(value); }
    }

    /// <summary>
    /// Creates a new CosmosDBCreateUpdateConfig.
    /// </summary>
    public CosmosDBCreateUpdateConfig()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of CosmosDBCreateUpdateConfig.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _throughput = DefineProperty<int>(nameof(Throughput), new string[] { "throughput" });
        _autoscaleMaxThroughput = DefineProperty<int>(nameof(AutoscaleMaxThroughput), new string[] { "autoscaleSettings", "maxThroughput" });
    }
}
