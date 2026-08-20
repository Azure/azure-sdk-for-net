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
public partial class CosmosDBThroughputPoolAccount : ProvisionableResource
{
    private BicepValue<string>? _name;
    private BicepValue<AzureLocation>? _accountLocation;
    private BicepValue<ResourceIdentifier>? _accountResourceIdentifier;
    private BicepValue<CosmosDBStatus>? _provisioningState;
    private BicepValue<string>? _accountInstanceId;
    private BicepValue<ResourceIdentifier>? _id;
    private SystemData? _systemData;
    private ResourceReference<CosmosDBThroughputPool>? _parent;

    public BicepValue<string> Name
    {
        get { Initialize(); return _name!; }
        set { Initialize(); _name!.Assign(value); }
    }

    public BicepValue<AzureLocation> AccountLocation
    {
        get { Initialize(); return _accountLocation!; }
        set { Initialize(); _accountLocation!.Assign(value); }
    }

    public BicepValue<ResourceIdentifier> AccountResourceIdentifier
    {
        get { Initialize(); return _accountResourceIdentifier!; }
        set { Initialize(); _accountResourceIdentifier!.Assign(value); }
    }

    public BicepValue<CosmosDBStatus> ProvisioningState
    {
        get { Initialize(); return _provisioningState!; }
        set { Initialize(); _provisioningState!.Assign(value); }
    }

    public BicepValue<string> AccountInstanceId
    {
        get { Initialize(); return _accountInstanceId!; }
    }

    public BicepValue<ResourceIdentifier> Id
    {
        get { Initialize(); return _id!; }
    }

    public SystemData SystemData
    {
        get { Initialize(); return _systemData!; }
    }

    public CosmosDBThroughputPool? Parent
    {
        get { Initialize(); return _parent!.Value; }
        set { Initialize(); _parent!.Value = value; }
    }

    public CosmosDBThroughputPoolAccount(string bicepIdentifier, string? resourceVersion = default)
        : base(bicepIdentifier, "Microsoft.DocumentDB/throughputPools/throughputPoolAccounts", resourceVersion)
    {
    }

    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _name = DefineProperty<string>("Name", ["name"], isRequired: true);
        _accountLocation = DefineProperty<AzureLocation>("AccountLocation", ["properties", "accountLocation"]);
        _accountResourceIdentifier = DefineProperty<ResourceIdentifier>("AccountResourceIdentifier", ["properties", "accountResourceIdentifier"]);
        _provisioningState = DefineProperty<CosmosDBStatus>("ProvisioningState", ["properties", "provisioningState"]);
        _accountInstanceId = DefineProperty<string>("AccountInstanceId", ["properties", "accountInstanceId"], isOutput: true);
        _id = DefineProperty<ResourceIdentifier>("Id", ["id"], isOutput: true);
        _systemData = DefineModelProperty<SystemData>("SystemData", ["systemData"], isOutput: true);
        _parent = DefineResource<CosmosDBThroughputPool>("Parent", ["parent"], isRequired: true);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ResourceVersions
    {
    }

    public static CosmosDBThroughputPoolAccount FromExisting(string bicepIdentifier, string? resourceVersion = default) =>
        new(bicepIdentifier, resourceVersion) { IsExistingResource = true };
}
