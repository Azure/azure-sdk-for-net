// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.AppService.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.AppService
{
    /// <summary>
    /// A class representing the WebSite data model.
    /// A web app, a mobile app backend, or an API app.
    /// </summary>
    public partial class WebSiteData : TrackedResourceData
    {
        /// <summary> Virtual Network Route All enabled. This causes all outbound traffic to have Virtual Network Security Groups and User Defined Routes applied. </summary>
        [WirePath("properties.vnetRouteAllEnabled")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsVnetRouteAllEnabled { get => OutboundVnetRouting.IsAllTrafficEnabled; set => OutboundVnetRouting.IsAllTrafficEnabled = value; }
        /// <summary> To enable pulling image over Virtual Network. </summary>
        [WirePath("properties.vnetImagePullEnabled")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsVnetImagePullEnabled { get => OutboundVnetRouting.IsImagePullTrafficEnabled; set => OutboundVnetRouting.IsImagePullTrafficEnabled = value; }
        /// <summary> To enable accessing content over virtual network. </summary>
        [WirePath("properties.vnetContentShareEnabled")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsVnetContentShareEnabled { get => OutboundVnetRouting.IsContentShareTrafficEnabled; set => OutboundVnetRouting.IsContentShareTrafficEnabled = value; }
        /// <summary> To enable Backup and Restore operations over virtual network. </summary>
        [WirePath("properties.vnetBackupRestoreEnabled")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsVnetBackupRestoreEnabled { get => OutboundVnetRouting.IsBackupRestoreTrafficEnabled; set => OutboundVnetRouting.IsBackupRestoreTrafficEnabled = value; }
    }
}
