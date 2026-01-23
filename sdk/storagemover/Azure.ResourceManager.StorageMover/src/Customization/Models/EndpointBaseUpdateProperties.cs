// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.StorageMover.Models
{
    /// <summary>
    /// The Endpoint resource, which contains information about file sources and targets.
    /// Please note this is the abstract base class. The derived classes available for instantiation are: <see cref="AzureStorageBlobContainerEndpointUpdateProperties"/>, <see cref="NfsMountEndpointUpdateProperties"/>, <see cref="AzureStorageSmbFileShareEndpointUpdateProperties"/>, <see cref="AzureStorageNfsFileShareEndpointUpdateProperties"/>, <see cref="AzureMultiCloudConnectorEndpointUpdateProperties"/>, and <see cref="SmbMountEndpointUpdateProperties"/>.
    /// </summary>
    public abstract partial class EndpointBaseUpdateProperties
    {
        /// <summary> Initializes a new instance of <see cref="EndpointBaseUpdateProperties"/> for deserialization. </summary>
        protected EndpointBaseUpdateProperties()     // The new MPG made this constructor private; change it back to protected to preserve backward compatibility.
        {
        }
    }
}
