// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591, SA1402, SA1508, CS0618

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.ContainerRegistry.Mocking
{
    // Backward compatibility: mockable methods for deprecated Task/Run/AgentPool resources
    public partial class MockableContainerRegistryArmClient
    {
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ContainerRegistryAgentPoolResource GetContainerRegistryAgentPoolResource(ResourceIdentifier id)
            => throw new NotSupportedException("RegistryTasks operations have been moved to Azure.ResourceManager.ContainerRegistryTasks.");

        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ContainerRegistryRunResource GetContainerRegistryRunResource(ResourceIdentifier id)
            => throw new NotSupportedException("RegistryTasks operations have been moved to Azure.ResourceManager.ContainerRegistryTasks.");

        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ContainerRegistryTaskResource GetContainerRegistryTaskResource(ResourceIdentifier id)
            => throw new NotSupportedException("RegistryTasks operations have been moved to Azure.ResourceManager.ContainerRegistryTasks.");

        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ContainerRegistryTaskRunResource GetContainerRegistryTaskRunResource(ResourceIdentifier id)
            => throw new NotSupportedException("RegistryTasks operations have been moved to Azure.ResourceManager.ContainerRegistryTasks.");
    }
}
