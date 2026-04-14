// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Maintenance
{
    // Backward-compat: the old Swagger-based SDK (1.1.3) had CreateResourceIdentifier with 6 parameters
    // (subscriptionId, resourceGroupName, providerName, resourceType, resourceName, applyUpdateName).
    // The TypeSpec generator produces an 8-parameter version (adding resourceParentType, resourceParentName).
    // This custom overload preserves the old 6-parameter API surface to avoid breaking existing consumers.
    // [CodeGenType("ApplyUpdateResource")] renames the generated ApplyUpdateResource to
    // MaintenanceApplyUpdateResource, matching the old SDK naming convention.
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
