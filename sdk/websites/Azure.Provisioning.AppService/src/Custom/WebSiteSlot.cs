// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Provisioning;

namespace Azure.Provisioning.AppService;

public partial class WebSiteSlot
{
    // Preserve the legacy flattened properties and wire paths for compatibility. New code should use OutboundVnetRouting.

    /// <summary> To enable Backup and Restore operations over virtual network. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<bool> IsVnetBackupRestoreEnabled
    {
        get
        {
            return Properties is null ? default : Properties.IsVnetBackupRestoreEnabled;
        }
        set
        {
            if (Properties is null)
            {
                Properties = new SiteProperties();
            }
            Properties.IsVnetBackupRestoreEnabled = value;
        }
    }

    /// <summary> To enable accessing content over virtual network. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<bool> IsVnetContentShareEnabled
    {
        get
        {
            return Properties is null ? default : Properties.IsVnetContentShareEnabled;
        }
        set
        {
            if (Properties is null)
            {
                Properties = new SiteProperties();
            }
            Properties.IsVnetContentShareEnabled = value;
        }
    }

    /// <summary> To enable pulling image over Virtual Network. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<bool> IsVnetImagePullEnabled
    {
        get
        {
            return Properties is null ? default : Properties.IsVnetImagePullEnabled;
        }
        set
        {
            if (Properties is null)
            {
                Properties = new SiteProperties();
            }
            Properties.IsVnetImagePullEnabled = value;
        }
    }

    /// <summary> Virtual Network Route All enabled. This causes all outbound traffic to have Virtual Network Security Groups and User Defined Routes applied. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<bool> IsVnetRouteAllEnabled
    {
        get
        {
            return Properties is null ? default : Properties.IsVnetRouteAllEnabled;
        }
        set
        {
            if (Properties is null)
            {
                Properties = new SiteProperties();
            }
            Properties.IsVnetRouteAllEnabled = value;
        }
    }
}
