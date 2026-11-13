// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.ComputeFleet.Models
{
    public static partial class ArmComputeFleetModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.ComputeFleetVmss"/>. </summary>
        /// <param name="id">
        /// The compute RP resource id of the virtualMachineScaleSet
        /// "subscriptions/{subId}/resourceGroups/{rgName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmssName}"
        /// </param>
        /// <param name="type"> Type of the virtualMachineScaleSet. </param>
        /// <param name="operationStatus"> This represents the operationStatus of the VMSS in response to the last operation that was performed on it by Azure Fleet resource. </param>
        /// <param name="error"> Error Information when `operationStatus` is `Failed`. </param>
        /// <returns> A new <see cref="Models.ComputeFleetVmss"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ComputeFleetVmss ComputeFleetVmss(ResourceIdentifier id, string type, ComputeFleetProvisioningState operationStatus = default, ComputeFleetApiError error = null)
        {
            return ComputeFleetVmss(id: id, name: null, resourceType: type != null ? new ResourceType(type) : default, operationStatus: operationStatus, error: error);
        }
    }
}
