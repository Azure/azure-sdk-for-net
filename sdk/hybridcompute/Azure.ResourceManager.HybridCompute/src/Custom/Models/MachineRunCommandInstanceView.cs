// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.HybridCompute.Models
{
    // Backward-compat justification: the generator emits IList for "statuses", but the existing API exposed Statuses as IReadOnlyList.
    public partial class MachineRunCommandInstanceView
    {
        /// <summary> The  status information. </summary>
        [WirePath("statuses")]
        public IReadOnlyList<ExtensionsResourceStatus> Statuses { get; }
    }
}
