// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Extensions.Logging;
using Microsoft.Azure.Storage.Blob;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Listeners
{
    internal class BlobNotification
    {
        public BlobNotification(ICloudBlob blob, string originalClientRequestId)
        {
            Blob = blob;
            PollId = originalClientRequestId;
        }

        public ICloudBlob Blob { get; private set; }

        /// <summary>
        /// The PollId when this blob was found. This can be null if the notification
        /// happened internally without polling.
        /// </summary>
        public string PollId { get; set; }
    }
}
