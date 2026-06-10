// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Compute
{
    [CodeGenSuppress("CreateResourceIdentifier", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string))]
    public partial class DiskRestorePointResource
    {
        // Backward compatibility: the generated helper now names the third parameter
        // restorePointCollectionName from the ARM path segment, but the shipped SDK exposed
        // this member with restorePointGroupName. Keep the old parameter name so the public
        // API listing remains source-compatible while producing the same resource ID.
        /// <summary> Generate the resource identifier for this resource. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="restorePointGroupName"> The restorePointGroupName. </param>
        /// <param name="vmRestorePointName"> The vmRestorePointName. </param>
        /// <param name="diskRestorePointName"> The diskRestorePointName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string restorePointGroupName, string vmRestorePointName, string diskRestorePointName)
        {
            string resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/restorePointCollections/{restorePointGroupName}/restorePoints/{vmRestorePointName}/diskRestorePoints/{diskRestorePointName}";
            return new ResourceIdentifier(resourceId);
        }
    }
}
