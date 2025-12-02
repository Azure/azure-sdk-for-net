// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.ContainerRegistry.Tasks;

namespace Azure.ResourceManager.ContainerRegistry
{
    /// <summary>
    /// A class to add extension methods to Azure.ResourceManager.ContainerRegistry.
    /// </summary>
    public static partial class ContainerRegistryExtensions
    {
        /// <summary>
        /// Gets an object representing a <see cref="ContainerRegistryAgentPoolResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ContainerRegistryAgentPoolResource.CreateResourceIdentifier" /> to create a <see cref="ContainerRegistryAgentPoolResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ContainerRegistryAgentPoolResource" /> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryAgentPoolResource GetContainerRegistryAgentPoolResource(this ArmClient client, ResourceIdentifier id)
        {
            return ContainerRegistryTasksExtensions.GetContainerRegistryAgentPoolResource(client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="ContainerRegistryRunResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ContainerRegistryRunResource.CreateResourceIdentifier" /> to create a <see cref="ContainerRegistryRunResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ContainerRegistryRunResource" /> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryRunResource GetContainerRegistryRunResource(this ArmClient client, ResourceIdentifier id)
        {
            return ContainerRegistryTasksExtensions.GetContainerRegistryRunResource(client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="ContainerRegistryTaskRunResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ContainerRegistryTaskRunResource.CreateResourceIdentifier" /> to create a <see cref="ContainerRegistryTaskRunResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ContainerRegistryTaskRunResource" /> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryTaskRunResource GetContainerRegistryTaskRunResource(this ArmClient client, ResourceIdentifier id)
        {
            return ContainerRegistryTasksExtensions.GetContainerRegistryTaskRunResource(client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="ContainerRegistryTaskResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ContainerRegistryTaskResource.CreateResourceIdentifier" /> to create a <see cref="ContainerRegistryTaskResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ContainerRegistryTaskResource" /> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryTaskResource GetContainerRegistryTaskResource(this ArmClient client, ResourceIdentifier id)
        {
            return ContainerRegistryTasksExtensions.GetContainerRegistryTaskResource(client, id);
        }
    }
}
