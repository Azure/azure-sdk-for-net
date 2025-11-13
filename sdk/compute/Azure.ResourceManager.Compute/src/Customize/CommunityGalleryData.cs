// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Compute
{
    // we have this customization here to change its namespace to avoid breaking changes
    [CodeGenType("CommunityGalleryData")]
    public partial class CommunityGalleryData
    {
        // we also must add back this property to avoid breaking changes, but its payload never have this property.
        /// <summary> The resource identifier. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier Id { get; internal set; }
    }
}
