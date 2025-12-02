// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.ContainerRegistry.Mocking
{
    public partial class MockableContainerRegistryArmClient
    {
        /// <summary>
        /// Gets an object representing a <see cref="ContainerRegistryAgentPoolResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ContainerRegistryAgentPoolResource.CreateResourceIdentifier" /> to create a <see cref="ContainerRegistryAgentPoolResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ContainerRegistryAgentPoolResource" /> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ContainerRegistryAgentPoolResource GetContainerRegistryAgentPoolResource(ResourceIdentifier id)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Gets an object representing a <see cref="ContainerRegistryRunResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ContainerRegistryRunResource.CreateResourceIdentifier" /> to create a <see cref="ContainerRegistryRunResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ContainerRegistryRunResource" /> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ContainerRegistryRunResource GetContainerRegistryRunResource(ResourceIdentifier id)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Gets an object representing a <see cref="ContainerRegistryTaskRunResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ContainerRegistryTaskRunResource.CreateResourceIdentifier" /> to create a <see cref="ContainerRegistryTaskRunResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ContainerRegistryTaskRunResource" /> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ContainerRegistryTaskRunResource GetContainerRegistryTaskRunResource(ResourceIdentifier id)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Gets an object representing a <see cref="ContainerRegistryTaskResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ContainerRegistryTaskResource.CreateResourceIdentifier" /> to create a <see cref="ContainerRegistryTaskResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ContainerRegistryTaskResource" /> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ContainerRegistryTaskResource GetContainerRegistryTaskResource(ResourceIdentifier id)
        {
            throw new NotSupportedException();
        }
    }
}
