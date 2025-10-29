// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.ProviderHub.Models
{
    /// <summary> The ResourceTypeSkuLocationInfo. </summary>
    public partial class ResourceTypeSkuLocationInfo
    {
        /// <summary> Gets or sets the extended location type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ProviderHubExtendedLocationType? ExtendedLocationType { get => LocationType.ToString().ToProviderHubExtendedLocationType(); set => LocationType = value?.ToString(); }
    }
}
