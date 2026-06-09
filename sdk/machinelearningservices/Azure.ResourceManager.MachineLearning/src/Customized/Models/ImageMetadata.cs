// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore legacy property names over generated TypeSpec-normalized names.
    public partial class ImageMetadata
    {
        /// <summary> Whether this compute instance is running on the latest operating system image. </summary>
        [WirePath("isLatestOsImageVersion")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsLatestOSImageVersion => IsLatestOsImageVersion;
    }
}
