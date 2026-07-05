// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.DevTestLabs
{
    public partial class DevTestLabVmScheduleResource : ArmResource
    {
        /// <summary> Generate the resource identifier for this resource. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="labName"> The labName. </param>
        /// <param name="vmName"> The virtualMachineName. </param>
        /// <param name="name"> The name. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string vmName, string name)
        {
            string resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/virtualmachines/{vmName}/schedules/{name}";
            return new ResourceIdentifier(resourceId);
        }
    }
}
