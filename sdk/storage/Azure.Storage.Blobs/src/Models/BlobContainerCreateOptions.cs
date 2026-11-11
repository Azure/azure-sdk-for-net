// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for <see cref="BlobContainerClient.Create(BlobContainerCreateOptions, System.Threading.CancellationToken)"/>.
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
        public IDictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// Optional encryption scope options to set for this container.
        /// </summary>
        public BlobContainerEncryptionScopeOptions EncryptionScopeOptions { get; set; }

        /// <summary>
        /// Optional. Sets the priority of this request, from 0 through 7.
        /// If not set, or if the value is outside that range, the service uses 3.
        /// </summary>
        public int? RequestPriority { get; set; }
    }
}
