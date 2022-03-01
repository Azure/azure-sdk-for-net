// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary> Deployment What-if properties. </summary>
    public partial class DeploymentWhatIfProperties : DeploymentProperties
    {
        /// <summary> Initializes a new instance of DeploymentWhatIfProperties. </summary>
        /// <param name="mode"> The mode that is used to deploy resources. This value can be either Incremental or Complete. In Incremental mode, resources are deployed without deleting existing resources that are not included in the template. In Complete mode, resources are deployed and existing resources in the resource group that are not included in the template are deleted. Be careful when using Complete mode as you may unintentionally delete resources. </param>
        public DeploymentWhatIfProperties(DeploymentMode mode) : base(mode)
        {
        }

        /// <summary> Optional What-If operation settings. </summary>
        internal DeploymentWhatIfSettings WhatIfSettings { get; set; }
        /// <summary> The format of the What-If results. </summary>
        public WhatIfResultFormat? WhatIfResultFormat
        {
            get => WhatIfSettings is null ? default : WhatIfSettings.ResultFormat;
            set
            {
                if (WhatIfSettings is null)
                    WhatIfSettings = new DeploymentWhatIfSettings();
                WhatIfSettings.ResultFormat = value;
            }
        }
    }
}
