// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Core;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.PrivateDns;

/// <summary>
/// VirtualNetworkLink.
/// </summary>
public partial class VirtualNetworkLink : ProvisionableResource
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
    /// The ETag of the virtual network link.
    /// </summary>
    public BicepValue<ETag> ETag
    {
        get { Initialize(); return _eTag!; }
        set { Initialize(); _eTag!.Assign(value); }
    }
    private BicepValue<ETag>? _eTag;

    /// <summary>
    /// The resolution policy on the virtual network link. Only applicable for
    /// virtual network links to privatelink zones, and for A,AAAA,CNAME
    /// queries. When set to &apos;NxDomainRedirect&apos;, Azure DNS resolver
    /// falls back to public resolution if private dns query resolution
    /// results in non-existent domain response.
    /// </summary>
    public BicepValue<PrivateDnsResolutionPolicy> PrivateDnsResolutionPolicy
    {
        get { Initialize(); return _privateDnsResolutionPolicy!; }
        set { Initialize(); _privateDnsResolutionPolicy!.Assign(value); }
    }
    private BicepValue<PrivateDnsResolutionPolicy>? _privateDnsResolutionPolicy;

    /// <summary>
    /// Is auto-registration of virtual machine records in the virtual network
    /// in the Private DNS zone enabled?.
    /// </summary>
    public BicepValue<bool> RegistrationEnabled
    {
        get { Initialize(); return _registrationEnabled!; }
        set { Initialize(); _registrationEnabled!.Assign(value); }
    }
    private BicepValue<bool>? _registrationEnabled;

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
    /// Gets or sets Id.
    /// </summary>
    public BicepValue<ResourceIdentifier> VirtualNetworkId
    {
        get { Initialize(); return _virtualNetworkId!; }
        set { Initialize(); _virtualNetworkId!.Assign(value); }
    }
    private BicepValue<ResourceIdentifier>? _virtualNetworkId;

    /// <summary>
    /// Gets the Id.
    /// </summary>
    public BicepValue<ResourceIdentifier> Id
    {
        get { Initialize(); return _id!; }
    }
    private BicepValue<ResourceIdentifier>? _id;

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
    /// The status of the virtual network link to the Private DNS zone.
    /// Possible values are &apos;InProgress&apos; and &apos;Done&apos;. This
    /// is a read-only property and any attempt to set this value will be
    /// ignored.
    /// </summary>
    public BicepValue<VirtualNetworkLinkState> VirtualNetworkLinkState
    {
        get { Initialize(); return _virtualNetworkLinkState!; }
    }
    private BicepValue<VirtualNetworkLinkState>? _virtualNetworkLinkState;

    /// <summary>
    /// Gets or sets a reference to the parent PrivateDnsZone.
    /// </summary>
    public PrivateDnsZone? Parent
    {
        get { Initialize(); return _parent!.Value; }
        set { Initialize(); _parent!.Value = value; }
    }
    private ResourceReference<PrivateDnsZone>? _parent;

    /// <summary>
    /// Creates a new VirtualNetworkLink.
    /// </summary>
    /// <param name="bicepIdentifier">
    /// The the Bicep identifier name of the VirtualNetworkLink resource.  This
    /// can be used to refer to the resource in expressions, but is not the
    /// Azure name of the resource.  This value can contain letters, numbers,
    /// and underscores.
    /// </param>
    /// <param name="resourceVersion">Version of the VirtualNetworkLink.</param>
    public VirtualNetworkLink(string bicepIdentifier, string? resourceVersion = default)
        : base(bicepIdentifier, "Microsoft.Network/privateDnsZones/virtualNetworkLinks", resourceVersion ?? "2024-06-01")
    {
    }

    /// <summary>
    /// Define all the provisionable properties of VirtualNetworkLink.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _name = DefineProperty<string>("Name", ["name"], isRequired: true);
        _location = DefineProperty<AzureLocation>("Location", ["location"], isRequired: true);
        _eTag = DefineProperty<ETag>("ETag", ["etag"]);
        _privateDnsResolutionPolicy = DefineProperty<PrivateDnsResolutionPolicy>("PrivateDnsResolutionPolicy", ["properties", "resolutionPolicy"]);
        _registrationEnabled = DefineProperty<bool>("RegistrationEnabled", ["properties", "registrationEnabled"]);
        _tags = DefineDictionaryProperty<string>("Tags", ["tags"]);
        _virtualNetworkId = DefineProperty<ResourceIdentifier>("VirtualNetworkId", ["properties", "virtualNetwork", "id"]);
        _id = DefineProperty<ResourceIdentifier>("Id", ["id"], isOutput: true);
        _privateDnsProvisioningState = DefineProperty<PrivateDnsProvisioningState>("PrivateDnsProvisioningState", ["properties", "provisioningState"], isOutput: true);
        _systemData = DefineModelProperty<SystemData>("SystemData", ["systemData"], isOutput: true);
        _virtualNetworkLinkState = DefineProperty<VirtualNetworkLinkState>("VirtualNetworkLinkState", ["properties", "virtualNetworkLinkState"], isOutput: true);
        _parent = DefineResource<PrivateDnsZone>("Parent", ["parent"], isRequired: true);
    }

    /// <summary>
    /// Supported VirtualNetworkLink resource versions.
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
    /// Creates a reference to an existing VirtualNetworkLink.
    /// </summary>
    /// <param name="bicepIdentifier">
    /// The the Bicep identifier name of the VirtualNetworkLink resource.  This
    /// can be used to refer to the resource in expressions, but is not the
    /// Azure name of the resource.  This value can contain letters, numbers,
    /// and underscores.
    /// </param>
    /// <param name="resourceVersion">Version of the VirtualNetworkLink.</param>
    /// <returns>The existing VirtualNetworkLink resource.</returns>
    public static VirtualNetworkLink FromExisting(string bicepIdentifier, string? resourceVersion = default) =>
        new(bicepIdentifier, resourceVersion) { IsExistingResource = true };
}
