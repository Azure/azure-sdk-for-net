// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Specialized;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    internal class BlobNotification
    {
        public BlobNotification(BlobWithContainer<BlobBaseClient> blob, string originalClientRequestId)
        {
            Blob = blob;
            PollId = originalClientRequestId;
        }

        public BlobWithContainer<BlobBaseClient> Blob { get; private set; }

        /// <summary>
        /// The PollId when this blob was found. This can be null if the notification
        /// happened internally without polling.
        /// </summary>
        public string PollId { get; set; }
    }
}
