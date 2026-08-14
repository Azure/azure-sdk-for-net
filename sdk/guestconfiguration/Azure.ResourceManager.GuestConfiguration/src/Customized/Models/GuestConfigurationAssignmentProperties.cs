// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.GuestConfiguration.Models
{
    public partial class GuestConfigurationAssignmentProperties
    {
        /// <summary> The list of VM Compliance data for VMSS. </summary>
        [WirePath("vmssVMList")]
        public IList<GuestConfigurationVmssVmInfo> VmssVmList { get; set; }
    }
}
