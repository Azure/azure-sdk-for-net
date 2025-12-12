// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Nginx.Models
{
    /// <summary> Nginx Deployment Update Properties. </summary>
    public partial class NginxDeploymentUpdateProperties
    {
        /// <summary> Gets or sets the scaling capacity. </summary>
        public int? ScalingCapacity
        {
            get => ScalingProperties is null ? default : ScalingProperties.Capacity;
            set
            {
                if (ScalingProperties is null)
                    ScalingProperties = new NginxDeploymentScalingProperties();
                ScalingProperties.Capacity = value;
            }
        }
    }
}
