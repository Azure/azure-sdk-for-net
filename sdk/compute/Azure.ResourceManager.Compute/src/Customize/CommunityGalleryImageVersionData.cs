// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Compute
{
    public partial class CommunityGalleryImageVersionData
    {
        // we also must add back this property to avoid breaking changes, but its payload never have this property.
        /// <summary>
        /// The resource identifier.
        ///
        /// This property is depracated and will be removed in a future release.
        /// There is possibility that this property will be null.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier Id { get; internal set; }
    }
}
