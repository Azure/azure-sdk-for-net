// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class GalleryArtifactVersionSource
    {
        // Backward compatibility: previously-shipped surface exposed a virtual System.Uri
        // `Uri` accessor on the base class (overridden in GalleryArtifactVersionFullSource).
        // Today's spec moves the wire `uri` field to the derived GalleryDiskImageSource as
        // a plain string. This shim restores the deprecated base accessor as an in-memory
        // value with no wire serialization, matching the historical no-op behavior of the
        // base accessor for sibling derived types.
        /// <summary> The uri of the gallery artifact version source. Currently used to specify vhd/blob source. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Uri Uri { get; set; }
    }
}
