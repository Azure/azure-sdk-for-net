// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
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

        // Backward-compat shim (get-only). v1.14.0 baseline exposed both `ExcludeFromLatest`
        // and `IsExcludedFromLatest`; the Is* form is the new canonical name.
        /// <summary>
        /// If set to true, Virtual Machines deployed from the latest version of the Image Definition won&apos;t use this Image Version.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? ExcludeFromLatest { get => IsExcludedFromLatest; }

        // Customization: restored as IReadOnlyDictionary<string, string> to preserve the previously-shipped
        // API surface. The new spec emits this as a writable IDictionary, which would be a binary-breaking
        // change for existing consumers.
        public IReadOnlyDictionary<string, string> ArtifactTags
        {
            get
            {
                return Properties is null ? new ChangeTrackingDictionary<string, string>() : (IReadOnlyDictionary<string, string>)Properties.ArtifactTags;
            }
        }
    }
}
