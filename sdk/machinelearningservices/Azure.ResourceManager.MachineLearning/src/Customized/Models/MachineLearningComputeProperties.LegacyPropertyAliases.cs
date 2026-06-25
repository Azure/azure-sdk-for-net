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
    // Customized: restore GA provisioning errors declaration because generation references this
    // property from constructors/serialization but does not emit the public declaration.
    [CodeGenSuppress("ProvisioningErrors")]
    public abstract partial class MachineLearningComputeProperties
    {
        /// <summary> Errors during provisioning. </summary>
        [WirePath("provisioningErrors")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<MachineLearningError> ProvisioningErrors { get; }
    }
}
