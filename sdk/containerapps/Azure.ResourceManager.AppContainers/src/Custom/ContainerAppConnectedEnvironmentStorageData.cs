// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.AppContainers.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.AppContainers
{
    public partial class ContainerAppConnectedEnvironmentStorageData : ResourceData
    {
        /// <summary> Azure file properties. </summary>
        [WirePath("properties.azureFile")]
        [EditorBrowsable(state: EditorBrowsableState.Never)]
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
