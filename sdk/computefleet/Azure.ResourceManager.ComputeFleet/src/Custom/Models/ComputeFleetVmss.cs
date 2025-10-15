// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ComputeFleet.Models
{
    public partial class ComputeFleetVmss
    {
        /// <summary> Type of the virtualMachineScaleSet. </summary>
        public string Type => ResourceType.ToString();
    }
}
