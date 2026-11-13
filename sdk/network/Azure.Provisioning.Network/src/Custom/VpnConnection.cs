// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Network;

public partial class VpnConnection
{
    /// <summary> Gets or sets the VPN site link connection resources. </summary>
    [CodeGenMember("VpnLinkConnections")]
    public BicepList<VpnSiteLinkConnection> VpnLinkConnectionResources
    {
        get => Properties is null ? default : Properties.VpnLinkConnections;
        set
        {
            if (Properties is null)
            {
                Properties = new VpnConnectionProperties();
            }
            Properties.VpnLinkConnections = value;
        }
    }

    /// <summary> Gets or sets the VPN site link connection data models. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use VpnLinkConnectionResources instead.")]
    public BicepList<VpnSiteLinkConnectionData> VpnLinkConnections
    {
        get
        {
            if (Properties is null)
            {
                Properties = new VpnConnectionProperties();
            }
            return Properties.VpnLinkConnectionData;
        }
        set
        {
            if (Properties is null)
            {
                Properties = new VpnConnectionProperties();
            }
            Properties.VpnLinkConnectionData = value;
        }
    }

    partial void DefineAdditionalProperties()
    {
    }
}

internal partial class VpnConnectionProperties
{
#pragma warning disable CS0618
    private BicepList<VpnSiteLinkConnectionData> _vpnLinkConnectionData;

    internal BicepList<VpnSiteLinkConnectionData> VpnLinkConnectionData
    {
        get { Initialize(); return _vpnLinkConnectionData; }
        set { Initialize(); _vpnLinkConnectionData.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        _vpnLinkConnectionData = DefineListProperty<VpnSiteLinkConnectionData>("VpnLinkConnections", new string[] { "vpnLinkConnections" });
    }
#pragma warning restore CS0618
}
