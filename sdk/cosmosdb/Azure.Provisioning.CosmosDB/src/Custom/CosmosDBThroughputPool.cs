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
/// CosmosDBThroughputPool.
/// </summary>
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

    /// <summary>
    /// Cosmos DB Throughput Pool name.
    /// </summary>
    public BicepValue<string> Name
    {
        get { Initialize(); return _name!; }
        set { Initialize(); _name!.Assign(value); }
    }

    /// <summary>
    /// Gets or sets the Location.
    /// </summary>
    public BicepValue<AzureLocation> Location
    {
        get { Initialize(); return _location!; }
        set { Initialize(); _location!.Assign(value); }
    }

    /// <summary>
    /// Value for throughput to be shared among CosmosDB resources in the pool.
    /// </summary>
    public BicepValue<int> MaxThroughput
    {
        get { Initialize(); return _maxThroughput!; }
        set { Initialize(); _maxThroughput!.Assign(value); }
    }

    /// <summary>
    /// A provisioning state of the ThroughputPool.
    /// </summary>
    public BicepValue<CosmosDBStatus> ProvisioningState
    {
        get { Initialize(); return _provisioningState!; }
        set { Initialize(); _provisioningState!.Assign(value); }
    }

    /// <summary>
    /// Gets or sets the Tags.
    /// </summary>
    public BicepDictionary<string> Tags
    {
        get { Initialize(); return _tags!; }
        set { Initialize(); _tags!.Assign(value); }
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
    /// Creates a new CosmosDBThroughputPool.
    /// </summary>
    /// <param name="bicepIdentifier">
    /// The the Bicep identifier name of the CosmosDBThroughputPool resource.
    /// This can be used to refer to the resource in expressions, but is not
    /// the Azure name of the resource.  This value can contain letters,
    /// numbers, and underscores.
    /// </param>
    /// <param name="resourceVersion">Version of the CosmosDBThroughputPool.</param>
    public CosmosDBThroughputPool(string bicepIdentifier, string? resourceVersion = default)
        : base(bicepIdentifier, "Microsoft.DocumentDB/throughputPools", resourceVersion)
    {
    }

    /// <summary>
    /// Define all the provisionable properties of CosmosDBThroughputPool.
    /// </summary>
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

    /// <summary>
    /// Creates a reference to an existing CosmosDBThroughputPool.
    /// </summary>
    /// <param name="bicepIdentifier">
    /// The the Bicep identifier name of the CosmosDBThroughputPool resource.
    /// This can be used to refer to the resource in expressions, but is not
    /// the Azure name of the resource.  This value can contain letters,
    /// numbers, and underscores.
    /// </param>
    /// <param name="resourceVersion">Version of the CosmosDBThroughputPool.</param>
    /// <returns>The existing CosmosDBThroughputPool resource.</returns>
    public static CosmosDBThroughputPool FromExisting(string bicepIdentifier, string? resourceVersion = default) =>
        new(bicepIdentifier, resourceVersion) { IsExistingResource = true };
}
