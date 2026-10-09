// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;

namespace Azure.Provisioning.AppService;

internal partial class SiteProperties
{
    // Preserve the legacy flattened VNet wire paths for WebSite and WebSiteSlot compatibility properties.

    /// <summary> To enable Backup and Restore operations over virtual network. </summary>
    internal BicepValue<bool> IsVnetBackupRestoreEnabled
    {
        get { Initialize(); return _isVnetBackupRestoreEnabled; }
        set { Initialize(); _isVnetBackupRestoreEnabled.Assign(value); }
    }
    private BicepValue<bool> _isVnetBackupRestoreEnabled;

    /// <summary> To enable accessing content over virtual network. </summary>
    internal BicepValue<bool> IsVnetContentShareEnabled
    {
        get { Initialize(); return _isVnetContentShareEnabled; }
        set { Initialize(); _isVnetContentShareEnabled.Assign(value); }
    }
    private BicepValue<bool> _isVnetContentShareEnabled;

    /// <summary> To enable pulling image over Virtual Network. </summary>
    internal BicepValue<bool> IsVnetImagePullEnabled
    {
        get { Initialize(); return _isVnetImagePullEnabled; }
        set { Initialize(); _isVnetImagePullEnabled.Assign(value); }
    }
    private BicepValue<bool> _isVnetImagePullEnabled;

    /// <summary> Virtual Network Route All enabled. This causes all outbound traffic to have Virtual Network Security Groups and User Defined Routes applied. </summary>
    internal BicepValue<bool> IsVnetRouteAllEnabled
    {
        get { Initialize(); return _isVnetRouteAllEnabled; }
        set { Initialize(); _isVnetRouteAllEnabled.Assign(value); }
    }
    private BicepValue<bool> _isVnetRouteAllEnabled;

    partial void DefineAdditionalProperties()
    {
        _isVnetBackupRestoreEnabled = DefineProperty<bool>(nameof(IsVnetBackupRestoreEnabled), ["vnetBackupRestoreEnabled"]);
        _isVnetContentShareEnabled = DefineProperty<bool>(nameof(IsVnetContentShareEnabled), ["vnetContentShareEnabled"]);
        _isVnetImagePullEnabled = DefineProperty<bool>(nameof(IsVnetImagePullEnabled), ["vnetImagePullEnabled"]);
        _isVnetRouteAllEnabled = DefineProperty<bool>(nameof(IsVnetRouteAllEnabled), ["vnetRouteAllEnabled"]);
    }
}
