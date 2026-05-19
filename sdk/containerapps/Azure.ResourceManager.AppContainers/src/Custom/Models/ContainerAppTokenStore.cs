// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.AppContainers;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AppContainers.Models
{
    [CodeGenSuppress("SasUrlSettingName")]
    [CodeGenSuppress("BlobContainerUri")]
    [CodeGenSuppress("ClientId")]
    [CodeGenSuppress("ManagedIdentityResourceId")]
    public partial class ContainerAppTokenStore
    {
        /// <summary> The name of the app secrets containing the SAS URL of the blob storage containing the tokens. Should not be used along with blobContainerUri. </summary>
        [WirePath("azureBlobStorage.sasUrlSettingName")]
        public string AzureBlobStorageSasUrlSettingName
        {
            get
            {
                return AzureBlobStorage is null ? default : AzureBlobStorage.SasUrlSettingName;
            }
            set
            {
                if (AzureBlobStorage is null)
                {
                    AzureBlobStorage = new BlobStorageTokenStore();
                }
                AzureBlobStorage.SasUrlSettingName = value;
            }
        }
    }
}
