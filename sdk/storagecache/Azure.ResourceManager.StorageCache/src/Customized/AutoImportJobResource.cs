// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.StorageCache
{
    public partial class AutoImportJobResource : ArmResource
    {
        /// <summary> Generate the resource identifier for this resource. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="amlFileSystemName"> The amlFileSystemName. </param>
        /// <param name="autoImportJobName"> The autoImportJobName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string amlFileSystemName, string autoImportJobName)
        {
            string resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.StorageCache/amlFilesystems/{amlFileSystemName}/autoImportJobs/{autoImportJobName}";
            return new ResourceIdentifier(resourceId);
        }
    }
}
