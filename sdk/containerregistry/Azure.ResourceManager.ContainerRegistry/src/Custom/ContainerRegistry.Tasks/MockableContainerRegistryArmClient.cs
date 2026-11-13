// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.ContainerRegistry.Mocking
{
    /// <summary>
    /// Provides backward-compatible mock entry points for task-related resources.
    /// </summary>
    public partial class MockableContainerRegistryArmClient
    {
        /// <summary> Gets an object representing a <see cref="ContainerRegistryAgentPoolResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ContainerRegistryAgentPoolResource"/> object. </returns>
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ContainerRegistryAgentPoolResource GetContainerRegistryAgentPoolResource(ResourceIdentifier id) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Gets an object representing a <see cref="ContainerRegistryRunResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ContainerRegistryRunResource"/> object. </returns>
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ContainerRegistryRunResource GetContainerRegistryRunResource(ResourceIdentifier id) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Gets an object representing a <see cref="ContainerRegistryTaskResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ContainerRegistryTaskResource"/> object. </returns>
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ContainerRegistryTaskResource GetContainerRegistryTaskResource(ResourceIdentifier id) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Gets an object representing a <see cref="ContainerRegistryTaskRunResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ContainerRegistryTaskRunResource"/> object. </returns>
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ContainerRegistryTaskRunResource GetContainerRegistryTaskRunResource(ResourceIdentifier id) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
    }
}
