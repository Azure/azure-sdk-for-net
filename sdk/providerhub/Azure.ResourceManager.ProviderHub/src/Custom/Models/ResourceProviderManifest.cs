// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ProviderHub.Models
{
    /// <summary> The ResourceProviderManifest. </summary>
    public partial class ResourceProviderManifest
    {
        /// <summary> Gets the opt in headers. </summary>
        public OptInHeaderType? OptInHeaders
        {
            get => RequestHeaderOptions?.OptInHeaders;
        }
    }
}
