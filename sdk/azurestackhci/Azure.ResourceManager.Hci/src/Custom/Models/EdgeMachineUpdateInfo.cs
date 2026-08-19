// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci.Models
{
    public partial class EdgeMachineUpdateInfo
    {
        /// <summary> Indicates whether a reboot is required. </summary>
        [CodeGenMember("RebootRequired")]
        public bool? IsRebootRequired { get; set; }
    }
}
