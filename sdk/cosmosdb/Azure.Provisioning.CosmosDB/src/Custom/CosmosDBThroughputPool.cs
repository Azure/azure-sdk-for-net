// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
#pragma warning disable CS1591

using System.ComponentModel;
using Azure.Core;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.CosmosDB;

[EditorBrowsable(EditorBrowsableState.Never)]
public partial class CosmosDBThroughputPool : ProvisionableResource
{
    private BicepValue<string>? _name;
    private BicepValue<AzureLocation>? _location;
    private BicepValue<int>? _maxThroughput;
    private BicepValue<CosmosDBStatus>? _provisioningState;
    private BicepDictionary<string>? _tags;
    private BicepValue<ResourceIdentifier>? _id;
    private SystemData? _systemData;

    public BicepValue<string> Name
    {
        get { Initialize(); return _name!; }
        set { Initialize(); _name!.Assign(value); }
    }

    public BicepValue<AzureLocation> Location
    {
        get { Initialize(); return _location!; }
        set { Initialize(); _location!.Assign(value); }
    }

    public BicepValue<int> MaxThroughput
    {
        get { Initialize(); return _maxThroughput!; }
        set { Initialize(); _maxThroughput!.Assign(value); }
    }

    public BicepValue<CosmosDBStatus> ProvisioningState
    {
        get { Initialize(); return _provisioningState!; }
        set { Initialize(); _provisioningState!.Assign(value); }
    }

    public BicepDictionary<string> Tags
    {
        get { Initialize(); return _tags!; }
        set { Initialize(); _tags!.Assign(value); }
    }

    public BicepValue<ResourceIdentifier> Id
    {
        get { Initialize(); return _id!; }
    }

    public SystemData SystemData
    {
        get { Initialize(); return _systemData!; }
    }

    public CosmosDBThroughputPool(string bicepIdentifier, string? resourceVersion = default)
        : base(bicepIdentifier, "Microsoft.DocumentDB/throughputPools", resourceVersion)
    {
    }

    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _name = DefineProperty<string>("Name", ["name"], isRequired: true);
        _location = DefineProperty<AzureLocation>("Location", ["location"], isRequired: true);
        _maxThroughput = DefineProperty<int>("MaxThroughput", ["properties", "maxThroughput"]);
        _provisioningState = DefineProperty<CosmosDBStatus>("ProvisioningState", ["properties", "provisioningState"]);
        _tags = DefineDictionaryProperty<string>("Tags", ["tags"]);
        _id = DefineProperty<ResourceIdentifier>("Id", ["id"], isOutput: true);
        _systemData = DefineModelProperty<SystemData>("SystemData", ["systemData"], isOutput: true);
    }

    public static CosmosDBThroughputPool FromExisting(string bicepIdentifier, string? resourceVersion = default) =>
        new(bicepIdentifier, resourceVersion) { IsExistingResource = true };
}
