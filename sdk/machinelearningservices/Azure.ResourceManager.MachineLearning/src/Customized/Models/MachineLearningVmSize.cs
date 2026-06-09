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
    public partial class MachineLearningVmSize
    {
        /// <summary> The number of vCPUs supported by the virtual machine size. </summary>
        [WirePath("vCPUs")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? VCpus => VCPUs;

        /// <summary> The OS VHD disk size, in MB, allowed by the virtual machine size. </summary>
        [WirePath("osVhdSizeMB")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? OSVhdSizeMB => OsVhdSizeMB;

        /// <summary> Specifies if the virtual machine size supports premium IO. </summary>
        [WirePath("premiumIO")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsPremiumIOSupported => PremiumIO;
    }
}
