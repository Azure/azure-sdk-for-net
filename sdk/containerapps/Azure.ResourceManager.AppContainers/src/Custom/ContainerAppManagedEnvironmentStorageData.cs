// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.ResourceManager.AppContainers.Models;

namespace Azure.ResourceManager.AppContainers
{
    public partial class ContainerAppManagedEnvironmentStorageData
    {
        /// <summary>
        /// Azure file properties for backward compatibility.
        /// </summary>
        public ContainerAppAzureFileProperties ManagedEnvironmentStorageAzureFile
        {
            get => Properties is null ? default : Properties.AzureFile;
            set
            {
                if (Properties is null)
                    Properties = new ManagedEnvironmentStorageProperties();
                Properties.AzureFile = value;
            }
        }
        /// <summary>
        /// NFS Azure file properties.
        /// </summary>
        public ContainerAppNfsAzureFileProperties ManagedEnvironmentStorageNfsAzureFile
        {
            get => Properties is null ? default : Properties.NfsAzureFile;
            set
            {
                if (Properties is null)
                    Properties = new ManagedEnvironmentStorageProperties();
                Properties.NfsAzureFile = value;
            }
        }
    }
}
