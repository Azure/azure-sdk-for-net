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
    // Customized: restore GA IsEnabled alias over generated Enabled for the same wire path.
    public partial class MachineLearningAutoPauseProperties
    {
        /// <summary> Gets or sets whether auto pause is enabled. </summary>
        [WirePath("enabled")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsEnabled
        {
            get => Enabled;
            set => Enabled = value;
        }
    }
}
