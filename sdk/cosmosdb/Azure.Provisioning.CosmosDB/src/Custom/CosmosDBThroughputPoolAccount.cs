// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ComponentModel;
using Azure.Core;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Restore the preview-only throughput pool API from the previous GA package because
// the selected stable TypeSpec version does not generate it.
/// <summary>
/// CosmosDBThroughputPoolAccount.
/// </summary>
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

    /// <summary>
    /// Cosmos DB global database account in a Throughput Pool.
    /// </summary>
    public BicepValue<string> Name
    {
        get { Initialize(); return _name!; }
        set { Initialize(); _name!.Assign(value); }
    }

    /// <summary>
    /// The location of  global database account in the throughputPool.
    /// </summary>
    public BicepValue<AzureLocation> AccountLocation
    {
        get { Initialize(); return _accountLocation!; }
        set { Initialize(); _accountLocation!.Assign(value); }
    }

    /// <summary>
    /// The resource identifier of global database account in the
    /// throughputPool.
    /// </summary>
    public BicepValue<ResourceIdentifier> AccountResourceIdentifier
    {
        get { Initialize(); return _accountResourceIdentifier!; }
        set { Initialize(); _accountResourceIdentifier!.Assign(value); }
    }

    /// <summary>
    /// A provisioning state of the ThroughputPool Account.
    /// </summary>
    public BicepValue<CosmosDBStatus> ProvisioningState
    {
        get { Initialize(); return _provisioningState!; }
        set { Initialize(); _provisioningState!.Assign(value); }
    }

    /// <summary>
    /// The instance id of global database account in the throughputPool.
    /// </summary>
    public BicepValue<string> AccountInstanceId
    {
        get { Initialize(); return _accountInstanceId!; }
    }

    /// <summary>
    /// Gets the Id.
    /// </summary>
    public BicepValue<ResourceIdentifier> Id
    {
        get { Initialize(); return _id!; }
    }

    /// <summary>
    /// Gets the SystemData.
    /// </summary>
    public SystemData SystemData
    {
        get { Initialize(); return _systemData!; }
    }

    /// <summary>
    /// Gets or sets a reference to the parent CosmosDBThroughputPool.
    /// </summary>
    public CosmosDBThroughputPool? Parent
    {
        get { Initialize(); return _parent!.Value; }
        set { Initialize(); _parent!.Value = value; }
    }

    /// <summary>
    /// Creates a new CosmosDBThroughputPoolAccount.
    /// </summary>
    /// <param name="bicepIdentifier">
    /// The the Bicep identifier name of the CosmosDBThroughputPoolAccount
    /// resource.  This can be used to refer to the resource in expressions,
    /// but is not the Azure name of the resource.  This value can contain
    /// letters, numbers, and underscores.
    /// </param>
    /// <param name="resourceVersion">Version of the CosmosDBThroughputPoolAccount.</param>
    public CosmosDBThroughputPoolAccount(string bicepIdentifier, string? resourceVersion = default)
        : base(bicepIdentifier, "Microsoft.DocumentDB/throughputPools/throughputPoolAccounts", resourceVersion)
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// CosmosDBThroughputPoolAccount.
    /// </summary>
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

    /// <summary>
    /// Supported CosmosDBThroughputPoolAccount resource versions.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ResourceVersions
    {
    }

    /// <summary>
    /// Creates a reference to an existing CosmosDBThroughputPoolAccount.
    /// </summary>
    /// <param name="bicepIdentifier">
    /// The the Bicep identifier name of the CosmosDBThroughputPoolAccount
    /// resource.  This can be used to refer to the resource in expressions,
    /// but is not the Azure name of the resource.  This value can contain
    /// letters, numbers, and underscores.
    /// </param>
    /// <param name="resourceVersion">Version of the CosmosDBThroughputPoolAccount.</param>
    /// <returns>The existing CosmosDBThroughputPoolAccount resource.</returns>
    public static CosmosDBThroughputPoolAccount FromExisting(string bicepIdentifier, string? resourceVersion = default) =>
        new(bicepIdentifier, resourceVersion) { IsExistingResource = true };
}
