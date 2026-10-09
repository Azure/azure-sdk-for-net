// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Network;

/// <summary> The legacy data model for a VPN site link. </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("This type is deprecated and it will be removed in a future version. Please use VpnSiteLink instead.")]
public partial class VpnSiteLinkData : ProvisionableConstruct
{
    private BicepValue<ETag> _eTag;
    private VpnLinkProviderProperties _linkProperties;
    private BicepValue<string> _iPAddress;
    private BicepValue<string> _fqdn;
    private VpnLinkBgpSettings _bgpProperties;
    private BicepValue<NetworkProvisioningState> _provisioningState;
    private BicepValue<ResourceIdentifier> _id;
    private BicepValue<string> _name;
    private BicepValue<ResourceType> _resourceType;

    /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
    public BicepValue<ETag> ETag { get { Initialize(); return _eTag; } }

    /// <summary> The link provider properties. </summary>
    public VpnLinkProviderProperties LinkProperties
    {
        get { Initialize(); return _linkProperties; }
        set { Initialize(); AssignOrReplace(ref _linkProperties, value); }
    }

    /// <summary> The IP address for the VPN site link. </summary>
    public BicepValue<string> IPAddress
    {
        get { Initialize(); return _iPAddress; }
        set { Initialize(); _iPAddress.Assign(value); }
    }

    /// <summary> FQDN of the VPN site link. </summary>
    public BicepValue<string> Fqdn
    {
        get { Initialize(); return _fqdn; }
        set { Initialize(); _fqdn.Assign(value); }
    }

    /// <summary> The BGP properties. </summary>
    public VpnLinkBgpSettings BgpProperties
    {
        get { Initialize(); return _bgpProperties; }
        set { Initialize(); AssignOrReplace(ref _bgpProperties, value); }
    }

    /// <summary> The provisioning state of the VPN site link. </summary>
    public BicepValue<NetworkProvisioningState> ProvisioningState { get { Initialize(); return _provisioningState; } }

    /// <summary> Resource ID. </summary>
    public BicepValue<ResourceIdentifier> Id
    {
        get { Initialize(); return _id; }
        set { Initialize(); _id.Assign(value); }
    }

    /// <summary> Resource name. </summary>
    public BicepValue<string> Name
    {
        get { Initialize(); return _name; }
        set { Initialize(); _name.Assign(value); }
    }

    /// <summary> Resource type. </summary>
    public BicepValue<ResourceType> ResourceType { get { Initialize(); return _resourceType; } }

    /// <summary> Creates a new VpnSiteLinkData. </summary>
    public VpnSiteLinkData()
    {
    }

    /// <inheritdoc/>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _eTag = DefineProperty<ETag>(nameof(ETag), new string[] { "etag" }, isOutput: true);
        _linkProperties = DefineModelProperty<VpnLinkProviderProperties>(nameof(LinkProperties), new string[] { "properties", "linkProperties" });
        _iPAddress = DefineProperty<string>(nameof(IPAddress), new string[] { "properties", "ipAddress" });
        _fqdn = DefineProperty<string>(nameof(Fqdn), new string[] { "properties", "fqdn" });
        _bgpProperties = DefineModelProperty<VpnLinkBgpSettings>(nameof(BgpProperties), new string[] { "properties", "bgpProperties" });
        _provisioningState = DefineProperty<NetworkProvisioningState>(nameof(ProvisioningState), new string[] { "properties", "provisioningState" }, isOutput: true);
        _id = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
        _name = DefineProperty<string>(nameof(Name), new string[] { "name" });
        _resourceType = DefineProperty<ResourceType>(nameof(ResourceType), new string[] { "type" }, isOutput: true);
    }
}
