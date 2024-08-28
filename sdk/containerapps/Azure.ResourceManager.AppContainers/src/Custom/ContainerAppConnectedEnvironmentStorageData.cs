// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.ResourceManager.AppContainers.Models;

namespace Azure.ResourceManager.AppContainers
{
    public partial class ContainerAppConnectedEnvironmentStorageData
    {
        /// <summary>
        /// Azure file properties for backward compatibility.
        /// </summary>
        public ContainerAppAzureFileProperties ConnectedEnvironmentStorageAzureFile
        {
            get => Properties is null ? default : Properties.AzureFile;
            set
            {
                if (Properties is null)
                    Properties = new ConnectedEnvironmentStorageProperties();
                Properties.AzureFile = value;
            }
        }
    }
}
