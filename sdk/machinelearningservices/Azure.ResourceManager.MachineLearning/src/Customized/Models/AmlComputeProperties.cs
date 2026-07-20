// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    [CodeGenSuppress("Errors")]
    public partial class AmlComputeProperties
    {
        // Customized: restore legacy property name; TypeSpec rename is not applied to this generated property declaration.
        /// <summary> Collection of errors encountered by various compute nodes during node setup. </summary>
        [WirePath("errors")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<MachineLearningError> Errors { get; }
    }
}
