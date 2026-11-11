// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for PageBlobClient.UpdateSequenceNumber.
    /// </summary>
    public class PageBlobUpdateSequenceNumberOptions
    {
        /// <summary>
        /// An updated sequence number of your choosing, if
        /// <c>action</c> is <see cref="SequenceNumberAction.Max"/>
        /// or <see cref="SequenceNumberAction.Update"/>.  The value should
        /// not be provided if <c>action</c> is
        /// <see cref="SequenceNumberAction.Increment"/>.  The sequence number
        /// is a user-controlled property that you can use to track requests
        /// and manage concurrency issues via <see cref="PageBlobRequestConditions"/>.
        /// </summary>
        public long? SequenceNumber { get; set; }

        /// <summary>
        /// Optional <see cref="PageBlobRequestConditions"/> to add conditions
        /// on updating the sequence number of this page blob.
        /// </summary>
        public PageBlobRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional. Sets the priority of this request, from 0 through 7.
        /// If not set, or if the value is outside that range, the service uses 3.
        /// </summary>
        public int? RequestPriority { get; set; }
    }
}
