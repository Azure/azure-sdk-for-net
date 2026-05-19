// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AppContainers
{
    // TODO: Remove these detector property suppressions after https://github.com/Azure/azure-sdk-for-net/issues/59322 is fixed.
    [CodeGenSuppress("GetContainerAppDetectorProperties")]
    [CodeGenSuppress("GetContainerAppDetectorProperty", typeof(CancellationToken))]
    [CodeGenSuppress("GetContainerAppDetectorPropertyAsync", typeof(CancellationToken))]
    public partial class ContainerAppResource
    {
        // Preserve the previous zero-argument overload; the resource implementation is generated.
        /// <summary> Get the properties of a Container App. </summary>
        public virtual ContainerAppDetectorPropertyResource GetContainerAppDetectorProperty()
        {
            return GetContainerAppDetectorProperty(default);
        }

        internal virtual ContainerAppDetectorPropertyCollection GetContainerAppDetectorProperties()
        {
            return GetCachedClient(client => new ContainerAppDetectorPropertyCollection(client, Id));
        }

        /// <summary> Get the properties of a Container App. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        internal virtual async Task<Response<ContainerAppDetectorPropertyResource>> GetContainerAppDetectorPropertyAsync(CancellationToken cancellationToken)
        {
            return await GetContainerAppDetectorProperties().GetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get the properties of a Container App. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        internal virtual Response<ContainerAppDetectorPropertyResource> GetContainerAppDetectorProperty(CancellationToken cancellationToken)
        {
            return GetContainerAppDetectorProperties().Get(cancellationToken);
        }
    }
}
