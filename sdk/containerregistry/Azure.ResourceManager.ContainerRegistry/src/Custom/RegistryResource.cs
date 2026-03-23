// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ContainerRegistry.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ContainerRegistry
{
    // Generator bug: generated GetArchives/GetArchive/GetArchiveAsync methods don't pass
    // the required `packageType` parameter to the ContainerRegistryArchiveCollection constructor.
    // Suppressing the generated methods and providing a corrected implementation.
    [CodeGenSuppress("GetContainerRegistryArchives", typeof(string))]
    [CodeGenSuppress("GetContainerRegistryArchiveAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetContainerRegistryArchive", typeof(string), typeof(CancellationToken))]
    public partial class ContainerRegistryResource : ArmResource
    {
        /// <summary> Gets a collection of ContainerRegistryArchives in the <see cref="ContainerRegistryResource"/>. </summary>
        /// <param name="packageType"> The packageType for the resource. </param>
        /// <returns> An object representing collection of ContainerRegistryArchives and their operations over a ContainerRegistryArchiveResource. </returns>
        public virtual ContainerRegistryArchiveCollection GetContainerRegistryArchives(string packageType)
        {
            return this.GetCachedClient(client => new ContainerRegistryArchiveCollection(client, Id, packageType));
        }

        /// <summary>
        /// Gets an existing archive resource with the given name under the given package type.
        /// <list type="bullet">
        /// <item><term>Request Path</term><description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/packages/{packageType}/archives/{archiveName}</description></item>
        /// <item><term>Operation Id</term><description>Archives_Get</description></item>
        /// </list>
        /// </summary>
        /// <param name="packageType"> The type of the package resource. </param>
        /// <param name="archiveName"> The name of the archive resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual async Task<Response<ContainerRegistryArchiveResource>> GetContainerRegistryArchiveAsync(string packageType, string archiveName, CancellationToken cancellationToken = default)
        {
            return await GetContainerRegistryArchives(packageType).GetAsync(archiveName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets an existing archive resource with the given name under the given package type.
        /// <list type="bullet">
        /// <item><term>Request Path</term><description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/packages/{packageType}/archives/{archiveName}</description></item>
        /// <item><term>Operation Id</term><description>Archives_Get</description></item>
        /// </list>
        /// </summary>
        /// <param name="packageType"> The type of the package resource. </param>
        /// <param name="archiveName"> The name of the archive resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Response<ContainerRegistryArchiveResource> GetContainerRegistryArchive(string packageType, string archiveName, CancellationToken cancellationToken = default)
        {
            return GetContainerRegistryArchives(packageType).Get(archiveName, cancellationToken);
        }
    }
}
