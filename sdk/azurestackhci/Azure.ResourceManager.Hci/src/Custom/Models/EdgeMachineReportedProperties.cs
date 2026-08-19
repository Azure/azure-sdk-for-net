// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci.Models
{
    public partial class EdgeMachineReportedProperties
    {
        /// <summary> The time when the workload inventory was last updated. </summary>
        [CodeGenMember("WorkloadInventoryLastUpdated")]
        public DateTimeOffset? WorkloadInventoryLastUpdatedOn { get; }
    }
}
