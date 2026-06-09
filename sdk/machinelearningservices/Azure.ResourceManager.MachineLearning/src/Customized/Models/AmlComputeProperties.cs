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
        // Customized: TypeSpec property renaming is not applied to this generated property declaration.
        [WirePath("errors")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<MachineLearningError> Errors { get; }
    }
}
