// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

#nullable disable

namespace Azure.ResourceManager.ContainerService.Models
{
    /// <summary> Workload Auto-scaler profile for the managed cluster. </summary>
    [CodeGenSuppress("KedaEnabled")]
    public partial class ManagedClusterWorkloadAutoScalerProfile
    {
        /// <summary> Whether to enable KEDA. </summary>
        public bool? IsKedaEnabled
        {
            get => Keda is null ? default(bool?) : Keda.Enabled;
            set
            {
                Keda = value.HasValue ? new ManagedClusterWorkloadAutoScalerProfileKeda(value.Value) : null;
            }
        }
    }
}
