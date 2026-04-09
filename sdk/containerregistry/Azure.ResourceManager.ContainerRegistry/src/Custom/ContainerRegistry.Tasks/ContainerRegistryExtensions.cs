// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.ContainerRegistry
{
    // Backward compatibility: extension methods for deprecated Task/Run/AgentPool resources
    /// <summary>
    /// Provides backward-compatible extension methods for the task-related resources that moved to the separate tasks package.
    /// </summary>
    public static partial class ContainerRegistryExtensions
    {
        /// <summary>
        /// Gets an object representing a <see cref="ContainerRegistryAgentPoolResource"/> along with the instance operations that can be performed on it but with no data.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="Azure.ResourceManager.ContainerRegistry.Mocking.MockableContainerRegistryArmClient.GetContainerRegistryAgentPoolResource"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="ContainerRegistryAgentPoolResource"/> object. </returns>
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryAgentPoolResource GetContainerRegistryAgentPoolResource(this ArmClient client, ResourceIdentifier id) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary>
        /// Gets an object representing a <see cref="ContainerRegistryRunResource"/> along with the instance operations that can be performed on it but with no data.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="Azure.ResourceManager.ContainerRegistry.Mocking.MockableContainerRegistryArmClient.GetContainerRegistryRunResource"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="ContainerRegistryRunResource"/> object. </returns>
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryRunResource GetContainerRegistryRunResource(this ArmClient client, ResourceIdentifier id) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary>
        /// Gets an object representing a <see cref="ContainerRegistryTaskResource"/> along with the instance operations that can be performed on it but with no data.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="Azure.ResourceManager.ContainerRegistry.Mocking.MockableContainerRegistryArmClient.GetContainerRegistryTaskResource"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="ContainerRegistryTaskResource"/> object. </returns>
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryTaskResource GetContainerRegistryTaskResource(this ArmClient client, ResourceIdentifier id) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary>
        /// Gets an object representing a <see cref="ContainerRegistryTaskRunResource"/> along with the instance operations that can be performed on it but with no data.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="Azure.ResourceManager.ContainerRegistry.Mocking.MockableContainerRegistryArmClient.GetContainerRegistryTaskRunResource"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="ContainerRegistryTaskRunResource"/> object. </returns>
        [Obsolete("This method has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryTaskRunResource GetContainerRegistryTaskRunResource(this ArmClient client, ResourceIdentifier id) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
    }
}
