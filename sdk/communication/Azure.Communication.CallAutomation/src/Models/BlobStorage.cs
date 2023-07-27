// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Used to specify Blob container url for storing recordings.
    /// </summary>
    public class BlobStorage : ExternalStorage
    {
        /// <summary>
        /// Url of a container or a location within a container.
        /// </summary>
        public Uri ContainerUri { get; }

        /// <summary>
        /// Initializes a new instance of BlobStorage.
        /// </summary>
        /// <param name="containerUri">Url of a container or a location within a container. </param>
        public BlobStorage(Uri containerUri)
        {
            Argument.AssertNotNull(containerUri, nameof(containerUri));
            ContainerUri = containerUri;
            StorageType = RecordingStorageType.BlobStorage;
        }
    }
}
