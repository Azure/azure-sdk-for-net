// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Blobs.DataMovement.Models
{
    internal class BlobBaseConfiguration
    {
        /// <summary>
        /// Gets the blob's primary <see cref="Uri"/> endpoint.
        ///
        /// We shouldn't worry about storing the snapshot and versionId since it will be contained in the uri
        /// </summary>
        public virtual Uri Uri { get; internal set; }

        /// <summary>
        /// The Storage account name corresponding to the blob client.
        /// </summary>
        public string AccountName { get; internal set; }

        /// <summary>
        /// Gets the container name corresponding to the blob client.
        /// </summary>
        public string BlobContainerName { get; internal set; }

        /// <summary>
        /// Gets the name of the blob.
        /// </summary>
        public string Name { get; internal set; }
    }
}
