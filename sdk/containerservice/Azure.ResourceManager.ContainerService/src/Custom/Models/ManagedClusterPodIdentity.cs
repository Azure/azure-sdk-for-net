// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService.Models
{
    public partial class ManagedClusterPodIdentity
    {
        /// <summary> Details about the error. </summary>
        [WirePath("provisioningInfo.error.error")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResponseError ErrorDetail
        {
            get => new ResponseError( ProvisioningInfo?.ErrorDetail?.Code, ProvisioningInfo?.ErrorDetail?.Message );
        }
    }
}
