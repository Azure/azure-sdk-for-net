// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for creating a Blob Container.
    /// </summary>
    public class BlobContainerCreateOptions
    {
        /// <summary>
        /// Optionally specifies whether data in the container may be accessed
        /// publicly and the level of access. <see cref="PublicAccessType.BlobContainer"/>
        /// specifies full public read access for container and blob data.
        /// Clients can enumerate blobs within the container via anonymous
        /// request, but cannot enumerate containers within the storage
        /// account.  <see cref="PublicAccessType.Blob"/> specifies public
        /// read access for blobs.  Blob data within this container can be
        /// read via anonymous request, but container data is not available.
        /// Clients cannot enumerate blobs within the container via anonymous
        /// request.  <see cref="PublicAccessType.None"/> specifies that the
        /// container data is private to the account owner.
        /// </summary>
        public PublicAccessType PublicAccessType { get; set; }

        /// <summary>
        /// Optional custom metadata to set for this container.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be read only
        public Metadata Metadata { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

        /// <summary>
        /// Optional encryption scope options to set for this container.
        /// </summary>
        public BlobContainerEncryptionScopeOptions EncryptionScopeOptions { get; set; }

        /// <summary>
        /// Optional. The name of the Blob Access Point configuration to bind to the container.
        /// The binding cannot be changed after the container is created.
        /// </summary>
        public string BlobAccessPointConfigurationName { get; set; }

        /// <summary>
        /// Optional. The unique ID of the Blob Access Point configuration to bind to the container.
        /// When supplied together with <see cref="BlobAccessPointConfigurationName"/>, the service
        /// validates that both identify the same configuration.
        /// </summary>
        public string BlobAccessPointConfigurationUniqueId { get; set; }
    }
}
