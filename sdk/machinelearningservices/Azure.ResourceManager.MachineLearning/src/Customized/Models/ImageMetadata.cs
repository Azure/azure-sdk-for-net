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
    public partial class ImageMetadata
    {
        // TODO: Remove this workaround after https://github.com/microsoft/typespec/issues/11696 is fixed.
        /// <summary> Whether this compute instance is running on the latest operating system image. </summary>
        [CodeGenMember("IsLatestOsImageVersion")]
        [WirePath("isLatestOsImageVersion")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsLatestOSImageVersion { get; }
    }
}
