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
    public partial class MachineLearningVmSize
    {
        /// <summary> The number of vCPUs supported by the virtual machine size. </summary>
        [WirePath("vCPUs")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? VCpus => VCPUs;

        // TODO: Remove this workaround after https://github.com/microsoft/typespec/issues/11696 is fixed.
        /// <summary> The OS VHD disk size, in MB, allowed by the virtual machine size. </summary>
        [CodeGenMember("OsVhdSizeMB")]
        [WirePath("osVhdSizeMB")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? OSVhdSizeMB { get; }

        /// <summary> Specifies if the virtual machine size supports premium IO. </summary>
        [WirePath("premiumIO")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsPremiumIOSupported => SupportsPremiumIO;
    }
}
