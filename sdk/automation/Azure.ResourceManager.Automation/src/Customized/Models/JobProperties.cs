// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation.Models
{
    internal partial class JobProperties
    {
        /// <summary> The current provisioning state of the job. </summary>
        [CodeGenMember("ProvisioningState")]
        public JobProvisioningState? ProvisioningState { get; [EditorBrowsable(EditorBrowsableState.Never)] set; }
    }
}