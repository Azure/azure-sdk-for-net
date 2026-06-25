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
    // Customized: restore GA limits model type over the generated command-job limit shape.
    [CodeGenSuppress("Limits")]
    public partial class MachineLearningCommandJob
    {
        /// <summary> Command Job limit. </summary>
        [WirePath("limits")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningCommandJobLimits Limits { get; set; }
    }
}
