// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Provisioning;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.Dns;

public partial class DnsZone
{
    /// <summary> Gets or sets the virtual networks that register hostnames in this DNS zone. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is obsolete and will be removed in a future version. Please use RegistrationVirtualNetworkReferences instead.")]
    public BicepList<WritableSubResource> RegistrationVirtualNetworks
    {
        get
        {
            if (Properties is null)
            {
                Properties = new ZoneProperties();
            }
            return Properties.RegistrationVirtualNetworks;
        }
        set
        {
            if (Properties is null)
            {
                Properties = new ZoneProperties();
            }
            Properties.RegistrationVirtualNetworks = value;
        }
    }

    /// <summary> Gets or sets the virtual networks that resolve records in this DNS zone. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is obsolete and will be removed in a future version. Please use ResolutionVirtualNetworkReferences instead.")]
    public BicepList<WritableSubResource> ResolutionVirtualNetworks
    {
        get
        {
            if (Properties is null)
            {
                Properties = new ZoneProperties();
            }
            return Properties.ResolutionVirtualNetworks;
        }
        set
        {
            if (Properties is null)
            {
                Properties = new ZoneProperties();
            }
            Properties.ResolutionVirtualNetworks = value;
        }
    }

    /// <summary> Supported DnsZone resource versions. </summary>
    public static partial class ResourceVersions
    {
        /// <summary> 2018-05-01. </summary>
        public static readonly string V2018_05_01 = "2018-05-01";

        /// <summary> 2017-10-01. </summary>
        public static readonly string V2017_10_01 = "2017-10-01";

        /// <summary> 2017-09-01. </summary>
        public static readonly string V2017_09_01 = "2017-09-01";

        /// <summary> 2016-04-01. </summary>
        public static readonly string V2016_04_01 = "2016-04-01";
    }
}
