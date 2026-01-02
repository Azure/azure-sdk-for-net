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
        public string ManagedResourceGroup { get; set; }        // This was a spec breaking change, so we’re adding the property back to restore backward compatibility.

        /// <summary> Gets or sets the scaling capacity. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
