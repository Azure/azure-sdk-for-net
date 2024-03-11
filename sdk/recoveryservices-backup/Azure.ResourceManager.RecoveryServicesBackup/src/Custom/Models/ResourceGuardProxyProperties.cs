// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.RecoveryServicesBackup.Models
{
    /// <summary> The ResourceGuardProxyProperties. </summary>
    public partial class ResourceGuardProxyProperties
    {
        /// <summary> Initializes a new instance of <see cref="ResourceGuardProxyProperties"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceGuardProxyProperties()
        {
            ResourceGuardOperationDetails = new ChangeTrackingList<ResourceGuardOperationDetail>();
        }
    }
}
