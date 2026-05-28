// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.StorageCache
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("CreateResourceIdentifier", typeof(string), typeof(string), typeof(string), typeof(string))]
    public partial class StorageCacheImportJobResource : ArmResource
    {
        /// <summary> Generate the resource identifier for this resource. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="amlFileSystemName"> The amlFileSystemName. </param>
        /// <param name="importJobName"> The importJobName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string amlFileSystemName, string importJobName)
        {
            string resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.StorageCache/amlFilesystems/{amlFileSystemName}/importJobs/{importJobName}";
            return new ResourceIdentifier(resourceId);
        }
    }
}
