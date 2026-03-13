// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds hidden enum aliases (Blob, Container, File, Share) for
// generated single-letter members (b, c, f, s). Could use @@clientName on enum values.

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public readonly partial struct ServiceSasSignedResourceType
    {
        /// <summary> b. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ServiceSasSignedResourceType Blob => B;

        /// <summary> c. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ServiceSasSignedResourceType Container => C;

        /// <summary> f. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ServiceSasSignedResourceType File => F;

        /// <summary> s. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ServiceSasSignedResourceType Share => S;
    }
}
