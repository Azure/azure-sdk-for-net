// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.HybridCompute.Models
{
    // Backward-compat justification: the GA instance view model exposed the Statuses property directly.
    public partial class MachineRunCommandInstanceView
    {
        /// <summary> The  status information. </summary>
        [WirePath("statuses")]
        public IReadOnlyList<ExtensionsResourceStatus> Statuses { get; }
    }
}
