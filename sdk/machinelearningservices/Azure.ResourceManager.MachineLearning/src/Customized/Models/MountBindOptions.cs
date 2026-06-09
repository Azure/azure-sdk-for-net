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
    public partial class MountBindOptions
    {
        /// <summary> Indicate whether to create host path. </summary>
        [WirePath("createHostPath")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? DoesCreateHostPath
        {
            get => CreateHostPath;
            set => CreateHostPath = value;
        }
    }
}
