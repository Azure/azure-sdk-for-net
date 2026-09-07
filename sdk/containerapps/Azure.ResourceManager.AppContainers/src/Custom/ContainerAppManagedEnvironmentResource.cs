// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.ResourceManager.AppContainers
{
    public partial class ContainerAppManagedEnvironmentResource
    {
        // Preserve the released accessor names after the stable API added another private endpoint
        // connection resource and the generator disambiguated the managed-environment operations.
        /// <summary> Gets a collection of private endpoint connections in this managed environment. </summary>
        public virtual ContainerAppPrivateEndpointConnectionCollection GetContainerAppPrivateEndpointConnections()
        {
            return GetManagedEnvironmentPrivateEndpointConnections();
        }

        /// <summary> Gets a private endpoint connection in this managed environment. </summary>
        /// <param name="privateEndpointConnectionName"> Name of the private endpoint connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<Response<ContainerAppPrivateEndpointConnectionResource>> GetContainerAppPrivateEndpointConnectionAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            return GetManagedEnvironmentPrivateEndpointConnectionAsync(privateEndpointConnectionName, cancellationToken);
        }

        /// <summary> Gets a private endpoint connection in this managed environment. </summary>
        /// <param name="privateEndpointConnectionName"> Name of the private endpoint connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ContainerAppPrivateEndpointConnectionResource> GetContainerAppPrivateEndpointConnection(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            return GetManagedEnvironmentPrivateEndpointConnection(privateEndpointConnectionName, cancellationToken);
        }
    }
}
