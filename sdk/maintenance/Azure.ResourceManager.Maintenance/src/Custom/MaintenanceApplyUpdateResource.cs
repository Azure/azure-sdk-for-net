// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Maintenance
{
    // Backward-compat: old API had CreateResourceIdentifier with (subscriptionId, resourceGroupName,
    // providerName, resourceType, resourceName, applyUpdateName). Generated code has a different signature.
    // The @@clientName in spec handles the rename; no [CodeGenType] needed.
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
