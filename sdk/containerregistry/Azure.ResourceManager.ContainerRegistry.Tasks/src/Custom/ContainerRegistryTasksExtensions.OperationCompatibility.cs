// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ContainerRegistry.Tasks.Mocking;
using Azure.ResourceManager.ContainerRegistry.Tasks.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ContainerRegistry.Tasks
{
    [CodeGenSuppress("GetBuildSourceUploadUriAsync", typeof(ResourceGroupResource), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetBuildSourceUploadUri", typeof(ResourceGroupResource), typeof(string), typeof(CancellationToken))]
    public static partial class ContainerRegistryTasksExtensions
    {
        // TODO: Remove these custom methods after https://github.com/microsoft/typespec/issues/11708 is fixed.
        /// <summary> Gets the upload location for the user to be able to upload the source. </summary>
        public static Task<Response<ContainerRegistryTaskSourceUploadResult>> GetBuildSourceUploadUrlAsync(this ResourceGroupResource resourceGroupResource, string registryName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableContainerRegistryTasksResourceGroupResource(resourceGroupResource).GetBuildSourceUploadUrlAsync(registryName, cancellationToken);
        }

        /// <summary> Gets the upload location for the user to be able to upload the source. </summary>
        public static Response<ContainerRegistryTaskSourceUploadResult> GetBuildSourceUploadUrl(this ResourceGroupResource resourceGroupResource, string registryName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableContainerRegistryTasksResourceGroupResource(resourceGroupResource).GetBuildSourceUploadUrl(registryName, cancellationToken);
        }
    }
}
