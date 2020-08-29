// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Listeners
{
    internal class BlobNotification
    {
        public BlobNotification(BlobContainerClient blobContainerClient, BlobBaseClient blob, string originalClientRequestId)
        {
            Container = blobContainerClient;
            Blob = blob;
            PollId = originalClientRequestId;
        }

        public BlobBaseClient Blob { get; private set; }

        public BlobContainerClient Container { get; private set; }

        /// <summary>
        /// The PollId when this blob was found. This can be null if the notification
        /// happened internally without polling.
        /// </summary>
        public string PollId { get; set; }
    }
}
