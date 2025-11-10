// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.AppContainers.Models
{
    public partial class ArmAppContainersModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="AppContainers.ContainerAppManagedEnvironmentStorageData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="managedEnvironmentStorageAzureFile"> Storage properties. </param>
        /// <returns> A new <see cref="AppContainers.ContainerAppManagedEnvironmentStorageData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerAppManagedEnvironmentStorageData ContainerAppManagedEnvironmentStorageData(ResourceIdentifier id, string name, ResourceType resourceType,
            SystemData systemData, ContainerAppAzureFileProperties managedEnvironmentStorageAzureFile = null)
        {
            return ContainerAppManagedEnvironmentStorageData(id: id, name: name, resourceType: resourceType, systemData: systemData, properties: new ManagedEnvironmentStorageProperties() { AzureFile = managedEnvironmentStorageAzureFile });
        }

        /// <summary> Initializes a new instance of <see cref="AppContainers.ContainerAppConnectedEnvironmentStorageData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="connectedEnvironmentStorageAzureFile"> Storage properties. </param>
        /// <returns> A new <see cref="AppContainers.ContainerAppConnectedEnvironmentStorageData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerAppConnectedEnvironmentStorageData ContainerAppConnectedEnvironmentStorageData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ContainerAppAzureFileProperties connectedEnvironmentStorageAzureFile = null)
        {
            return ContainerAppConnectedEnvironmentStorageData(
                id,
                name,
                resourceType,
                systemData,
                 new ConnectedEnvironmentStorageProperties()
                 {
                     AzureFile = connectedEnvironmentStorageAzureFile
                 });
        }
    }
}
