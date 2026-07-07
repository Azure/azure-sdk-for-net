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
    // Customized: restore GA ImageType alias while keeping generated Type for the same wire path.
    public partial class ImageSetting
    {
        /// <summary> Type of the image. </summary>
        [WirePath("type")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageType? ImageType
        {
            get => Type;
            set => Type = value;
        }
    }
}
