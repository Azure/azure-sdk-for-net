// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.ResourceManager.Automation.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation
{
    public partial class AutomationJobData
    {
        /// <summary> The current provisioning state of the job. </summary>
        [CodeGenMember("ProvisioningState")]
        public JobProvisioningState? ProvisioningState
        {
            get => Properties is null ? default : Properties.ProvisioningState;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set
            {
                if (Properties is null)
                {
                    Properties = new JobProperties();
                }
                Properties.ProvisioningState = value;
            }
        }
    }
}