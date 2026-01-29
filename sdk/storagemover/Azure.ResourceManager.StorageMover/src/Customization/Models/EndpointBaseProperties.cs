// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.StorageMover.Models
{
    /// <summary>
    /// The resource specific properties for the Storage Mover resource.
    /// Please note this is the abstract base class. The derived classes available for instantiation are: <see cref="AzureStorageBlobContainerEndpointProperties"/>, <see cref="NfsMountEndpointProperties"/>, <see cref="AzureStorageSmbFileShareEndpointProperties"/>, <see cref="SmbMountEndpointProperties"/>, <see cref="AzureStorageNfsFileShareEndpointProperties"/>, and <see cref="AzureMultiCloudConnectorEndpointProperties"/>.
    /// </summary>
    public abstract partial class EndpointBaseProperties
    {
        /// <summary> Initializes a new instance of <see cref="EndpointBaseProperties"/> for deserialization. </summary>
        protected EndpointBaseProperties()      // The new MPG made this constructor private; change it back to protected to preserve backward compatibility.
        {
        }
    }
}
