// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.Compute
{
    public partial class SharedGalleryImageData
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
        /// <summary> The artifact tags of a shared gallery resource. </summary>
        public IReadOnlyDictionary<string, string> ArtifactTags
        {
            get
            {
                return Properties is null ? new ChangeTrackingDictionary<string, string>() : (IReadOnlyDictionary<string, string>)Properties.ArtifactTags;
            }
        }

        // Customization: restored as IReadOnlyList<GalleryImageFeature> to preserve the previously-shipped
        // API surface. The new spec emits this as a writable IList, which would be a binary-breaking change
        // for existing consumers.
        /// <summary> A list of gallery image features. </summary>
        public IReadOnlyList<GalleryImageFeature> Features
        {
            get
            {
                return Properties is null ? new ChangeTrackingList<GalleryImageFeature>() : (IReadOnlyList<GalleryImageFeature>)Properties.Features;
            }
        }
    }
}
