// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Core;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.PrivateDns;

/// <summary>
/// PrivateDnsZone.
/// </summary>
public partial class PrivateDnsZone : ProvisionableResource
{
    /// <summary>
    /// Gets or sets the Name.
    /// </summary>
    public BicepValue<string> Name
    {
        get { Initialize(); return _name!; }
        set { Initialize(); _name!.Assign(value); }
    }
    private BicepValue<string>? _name;

    /// <summary>
    /// Gets or sets the Location.
    /// </summary>
    public BicepValue<AzureLocation> Location
    {
        get { Initialize(); return _location!; }
        set { Initialize(); _location!.Assign(value); }
    }
    private BicepValue<AzureLocation>? _location;

    /// <summary>
    /// The ETag of the zone.
    /// </summary>
    public BicepValue<ETag> ETag
    {
        get { Initialize(); return _eTag!; }
        set { Initialize(); _eTag!.Assign(value); }
    }
    private BicepValue<ETag>? _eTag;

    /// <summary>
    /// Gets or sets the Tags.
    /// </summary>
    public BicepDictionary<string> Tags
    {
        get { Initialize(); return _tags!; }
        set { Initialize(); _tags!.Assign(value); }
    }
    private BicepDictionary<string>? _tags;

    /// <summary>
    /// Gets the Id.
    /// </summary>
    public BicepValue<ResourceIdentifier> Id
    {
        get { Initialize(); return _id!; }
    }
    private BicepValue<ResourceIdentifier>? _id;

    /// <summary>
    /// Private zone internal Id.
    /// </summary>
    public BicepValue<string> InternalId
    {
        get { Initialize(); return _internalId!; }
    }
    private BicepValue<string>? _internalId;

    /// <summary>
    /// The maximum number of record sets that can be created in this Private
    /// DNS zone. This is a read-only property and any attempt to set this
    /// value will be ignored.
    /// </summary>
    public BicepValue<long> MaxNumberOfRecords
    {
        get { Initialize(); return _maxNumberOfRecords!; }
    }
    private BicepValue<long>? _maxNumberOfRecords;

    /// <summary>
    /// The maximum number of virtual networks that can be linked to this
    /// Private DNS zone. This is a read-only property and any attempt to set
    /// this value will be ignored.
    /// </summary>
    public BicepValue<long> MaxNumberOfVirtualNetworkLinks
    {
        get { Initialize(); return _maxNumberOfVirtualNetworkLinks!; }
    }
    private BicepValue<long>? _maxNumberOfVirtualNetworkLinks;

    /// <summary>
    /// The maximum number of virtual networks that can be linked to this
    /// Private DNS zone with registration enabled. This is a read-only
    /// property and any attempt to set this value will be ignored.
    /// </summary>
    public BicepValue<long> MaxNumberOfVirtualNetworkLinksWithRegistration
    {
        get { Initialize(); return _maxNumberOfVirtualNetworkLinksWithRegistration!; }
    }
    private BicepValue<long>? _maxNumberOfVirtualNetworkLinksWithRegistration;

    /// <summary>
    /// The current number of record sets in this Private DNS zone. This is a
    /// read-only property and any attempt to set this value will be ignored.
    /// </summary>
    public BicepValue<long> NumberOfRecords
    {
        get { Initialize(); return _numberOfRecords!; }
    }
    private BicepValue<long>? _numberOfRecords;

    /// <summary>
    /// The current number of virtual networks that are linked to this Private
    /// DNS zone. This is a read-only property and any attempt to set this
    /// value will be ignored.
    /// </summary>
    public BicepValue<long> NumberOfVirtualNetworkLinks
    {
        get { Initialize(); return _numberOfVirtualNetworkLinks!; }
    }
    private BicepValue<long>? _numberOfVirtualNetworkLinks;

    /// <summary>
    /// The current number of virtual networks that are linked to this Private
    /// DNS zone with registration enabled. This is a read-only property and
    /// any attempt to set this value will be ignored.
    /// </summary>
    public BicepValue<long> NumberOfVirtualNetworkLinksWithRegistration
    {
        get { Initialize(); return _numberOfVirtualNetworkLinksWithRegistration!; }
    }
    private BicepValue<long>? _numberOfVirtualNetworkLinksWithRegistration;

    /// <summary>
    /// The provisioning state of the resource. This is a read-only property
    /// and any attempt to set this value will be ignored.
    /// </summary>
    public BicepValue<PrivateDnsProvisioningState> PrivateDnsProvisioningState
    {
        get { Initialize(); return _privateDnsProvisioningState!; }
    }
    private BicepValue<PrivateDnsProvisioningState>? _privateDnsProvisioningState;

    /// <summary>
    /// Gets the SystemData.
    /// </summary>
    public SystemData SystemData
    {
        get { Initialize(); return _systemData!; }
    }
    private SystemData? _systemData;

    /// <summary>
    /// Creates a new PrivateDnsZone.
    /// </summary>
    /// <param name="bicepIdentifier">
    /// The the Bicep identifier name of the PrivateDnsZone resource.  This can
    /// be used to refer to the resource in expressions, but is not the Azure
    /// name of the resource.  This value can contain letters, numbers, and
    /// underscores.
    /// </param>
    /// <param name="resourceVersion">Version of the PrivateDnsZone.</param>
    public PrivateDnsZone(string bicepIdentifier, string? resourceVersion = default)
        : base(bicepIdentifier, "Microsoft.Network/privateDnsZones", resourceVersion ?? "2024-06-01")
    {
    }

    /// <summary>
    /// Define all the provisionable properties of PrivateDnsZone.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _name = DefineProperty<string>("Name", ["name"], isRequired: true);
        _location = DefineProperty<AzureLocation>("Location", ["location"], isRequired: true);
        _eTag = DefineProperty<ETag>("ETag", ["etag"]);
        _tags = DefineDictionaryProperty<string>("Tags", ["tags"]);
        _id = DefineProperty<ResourceIdentifier>("Id", ["id"], isOutput: true);
        _internalId = DefineProperty<string>("InternalId", ["properties", "internalId"], isOutput: true);
        _maxNumberOfRecords = DefineProperty<long>("MaxNumberOfRecords", ["properties", "maxNumberOfRecordSets"], isOutput: true);
        _maxNumberOfVirtualNetworkLinks = DefineProperty<long>("MaxNumberOfVirtualNetworkLinks", ["properties", "maxNumberOfVirtualNetworkLinks"], isOutput: true);
        _maxNumberOfVirtualNetworkLinksWithRegistration = DefineProperty<long>("MaxNumberOfVirtualNetworkLinksWithRegistration", ["properties", "maxNumberOfVirtualNetworkLinksWithRegistration"], isOutput: true);
        _numberOfRecords = DefineProperty<long>("NumberOfRecords", ["properties", "numberOfRecordSets"], isOutput: true);
        _numberOfVirtualNetworkLinks = DefineProperty<long>("NumberOfVirtualNetworkLinks", ["properties", "numberOfVirtualNetworkLinks"], isOutput: true);
        _numberOfVirtualNetworkLinksWithRegistration = DefineProperty<long>("NumberOfVirtualNetworkLinksWithRegistration", ["properties", "numberOfVirtualNetworkLinksWithRegistration"], isOutput: true);
        _privateDnsProvisioningState = DefineProperty<PrivateDnsProvisioningState>("PrivateDnsProvisioningState", ["properties", "provisioningState"], isOutput: true);
        _systemData = DefineModelProperty<SystemData>("SystemData", ["systemData"], isOutput: true);
    }

    /// <summary>
    /// Supported PrivateDnsZone resource versions.
    /// </summary>
    public static class ResourceVersions
    {
        /// <summary>
        /// 2024-06-01.
        /// </summary>
        public static readonly string V2024_06_01 = "2024-06-01";

        /// <summary>
        /// 2020-06-01.
        /// </summary>
        public static readonly string V2020_06_01 = "2020-06-01";

        /// <summary>
        /// 2020-01-01.
        /// </summary>
        public static readonly string V2020_01_01 = "2020-01-01";

        /// <summary>
        /// 2018-09-01.
        /// </summary>
        public static readonly string V2018_09_01 = "2018-09-01";
    }

    /// <summary>
    /// Creates a reference to an existing PrivateDnsZone.
    /// </summary>
    /// <param name="bicepIdentifier">
    /// The the Bicep identifier name of the PrivateDnsZone resource.  This can
    /// be used to refer to the resource in expressions, but is not the Azure
    /// name of the resource.  This value can contain letters, numbers, and
    /// underscores.
    /// </param>
    /// <param name="resourceVersion">Version of the PrivateDnsZone.</param>
    /// <returns>The existing PrivateDnsZone resource.</returns>
    public static PrivateDnsZone FromExisting(string bicepIdentifier, string? resourceVersion = default) =>
        new(bicepIdentifier, resourceVersion) { IsExistingResource = true };
}
