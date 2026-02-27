// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Maintenance
{
    // Rename ApplyUpdateResource to MaintenanceApplyUpdateResource to maintain backward compatibility
    [CodeGenType("ApplyUpdateResource")]
    public partial class MaintenanceApplyUpdateResource
    {
        /// <summary> Generate the resource identifier for this resource (without parent). </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="providerName"> The providerName. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="resourceName"> The resourceName. </param>
        /// <param name="applyUpdateName"> The applyUpdateName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string providerName, string resourceType, string resourceName, string applyUpdateName)
        {
            string resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{providerName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/applyUpdates/{applyUpdateName}";
            return new ResourceIdentifier(resourceId);
        }
    }
}
