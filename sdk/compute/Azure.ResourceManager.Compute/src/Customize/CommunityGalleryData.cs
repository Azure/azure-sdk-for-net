// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Compute
{
    public partial class CommunityGalleryData
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

        // Customization: restored as IReadOnlyDictionary<string, string> to preserve the previously-shipped
        // API surface. The new spec emits this as a writable IDictionary, which would be a binary-breaking
        // change for existing consumers.
        /// <summary> The artifact tags of a community gallery resource. </summary>
        public IReadOnlyDictionary<string, string> ArtifactTags
        {
            get
            {
                return Properties is null ? new ChangeTrackingDictionary<string, string>() : (IReadOnlyDictionary<string, string>)Properties.ArtifactTags;
            }
        }
    }
}
