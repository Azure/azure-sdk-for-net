// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Nginx.Models
{
    /// <summary> Nginx Deployment Properties. </summary>
    public partial class NginxDeploymentProperties
    {
        /// <summary> The managed resource group to deploy VNet injection related network resources. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ManagedResourceGroup { get; set; }

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
