// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService.Models
{
    public partial class ManagedClusterWorkloadAutoScalerProfile
    {
        /// <summary> Whether to enable VPA. Default value is false. </summary>
        [WirePath("verticalPodAutoscaler.enabled")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsVpaEnabled
        {
            get => VerticalPodAutoscaler is null ? default(bool?) : VerticalPodAutoscaler.IsVpaEnabled;
            set
            {
                VerticalPodAutoscaler = value.HasValue ? new ManagedClusterVerticalPodAutoscaler(value.Value) : null;
            }
        }
    }
}
