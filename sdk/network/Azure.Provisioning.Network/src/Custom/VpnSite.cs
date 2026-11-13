// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Network;

public partial class VpnSite
{
    /// <summary> Gets or sets the VPN site link resources. </summary>
    [CodeGenMember("VpnSiteLinks")]
    public BicepList<VpnSiteLink> VpnSiteLinkResources
    {
        get => Properties is null ? default : Properties.VpnSiteLinks;
        set
        {
            if (Properties is null)
            {
                Properties = new VpnSiteProperties();
            }
            Properties.VpnSiteLinks = value;
        }
    }

    /// <summary> Gets or sets the VPN site link data models. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use VpnSiteLinkResources instead.")]
    public BicepList<VpnSiteLinkData> VpnSiteLinks
    {
        get
        {
            if (Properties is null)
            {
                Properties = new VpnSiteProperties();
            }
            return Properties.VpnSiteLinkData;
        }
        set
        {
            if (Properties is null)
            {
                Properties = new VpnSiteProperties();
            }
            Properties.VpnSiteLinkData = value;
        }
    }

    partial void DefineAdditionalProperties()
    {
    }
}

internal partial class VpnSiteProperties
{
#pragma warning disable CS0618
    private BicepList<VpnSiteLinkData> _vpnSiteLinkData;

    internal BicepList<VpnSiteLinkData> VpnSiteLinkData
    {
        get { Initialize(); return _vpnSiteLinkData; }
        set { Initialize(); _vpnSiteLinkData.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        _vpnSiteLinkData = DefineListProperty<VpnSiteLinkData>("VpnSiteLinks", new string[] { "vpnSiteLinks" });
    }
#pragma warning restore CS0618
}
