// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class GalleryArtifactVersionSource
    {
        /// <summary> The uri of the gallery artifact version source. Currently used to specify vhd/blob source. </summary>
        public virtual Uri Uri { get; set; }
    }
}
