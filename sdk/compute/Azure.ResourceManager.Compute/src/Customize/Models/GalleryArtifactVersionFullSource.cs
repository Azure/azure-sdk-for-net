// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class GalleryArtifactVersionFullSource
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Uri Uri { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override ResourceIdentifier StorageAccountId { get; set; }
    }
}
