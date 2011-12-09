//-----------------------------------------------------------------------
// <copyright file="BlobRequestOptions.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the BlobRequestOptions.cs class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;

    /// <summary>
    /// Represents a set of options that may be specified on a request.
    /// </summary>
    public class BlobRequestOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlobRequestOptions"/> class.
        /// </summary>
        public BlobRequestOptions()
        {
            this.AccessCondition = AccessCondition.None;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobRequestOptions"/> class based on an 
        /// existing instance.
        /// </summary>
        /// <param name="other">The set of request options to clone.</param>
        public BlobRequestOptions(BlobRequestOptions other)
        {
            this.Timeout = other.Timeout;
            this.RetryPolicy = other.RetryPolicy;
            this.AccessCondition = other.AccessCondition;

            this.CopySourceAccessCondition = other.CopySourceAccessCondition;
            this.DeleteSnapshotsOption = other.DeleteSnapshotsOption;
            this.BlobListingDetails = other.BlobListingDetails;
            this.UseFlatBlobListing = other.UseFlatBlobListing;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobRequestOptions"/> class.
        /// </summary>
        /// <param name="service">An object of type <see cref="CloudBlobClient"/>.</param>
        internal BlobRequestOptions(CloudBlobClient service)
            : this()
        {
            this.ApplyDefaults(service);
        }

        /// <summary>
        /// Gets or sets the retry policy for the request.
        /// </summary>
        /// <value>The retry policy delegate.</value>
        public RetryPolicy RetryPolicy { get; set; }

        /// <summary>
        /// Gets or sets the server and client timeout for the request. 
        /// </summary>
        /// <value>The server and client timeout interval for the request.</value>
        public TimeSpan? Timeout { get; set; }

        /// <summary>
        /// Gets or sets the access condition for the request.
        /// </summary>
        /// <value>A structure that specifies any conditional parameters on the request.</value>
        public AccessCondition AccessCondition { get; set; }

        /// <summary>
        /// Gets or sets the access condition on the source blob, when the request is to copy a blob.
        /// </summary>
        /// <value>A structure that specifies any conditional parameters on the request.</value>
        /// <remarks>
        /// This property is applicable only to a request that will copy a blob.
        /// </remarks>
        public AccessCondition CopySourceAccessCondition { get; set; }

        /// <summary>
        /// Gets or sets options for deleting snapshots when a blob is to be deleted.
        /// </summary>
        /// <value>One of the enumeration values that specifies whether to delete blobs and snapshots, delete blobs only, or delete snapshots only.</value>
        /// <remarks>
        /// This property is applicable only to a request that will delete a blob.
        /// </remarks>
        public DeleteSnapshotsOption DeleteSnapshotsOption { get; set; }

        /// <summary>
        /// Gets or sets options for listing blobs.
        /// </summary>
        /// <value>One of the enumeration values that indicates what items a listing operation will return.</value>
        /// <remarks>
        /// This property is applicable only to a request to list blobs.
        /// </remarks>
        public BlobListingDetails BlobListingDetails { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the blob listing operation will list all blobs in a container in a flat listing,
        /// or whether it will list blobs hierarchically, by virtual directory.
        /// </summary>
        /// <value><c>True</c> if blobs will be listed in a flat listing; otherwise, <c>false</c>. The default value is <c>false</c>.</value>
        /// <remarks>
        /// This property is applicable only to a request to list blobs.
        /// </remarks>
        public bool UseFlatBlobListing { get; set; }

        /// <summary>
        /// Creates the full modifier.
        /// </summary>
        /// <typeparam name="T">The type of the options.</typeparam>
        /// <param name="service">The service.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A full modifier of the requested type.</returns>
        internal static T CreateFullModifier<T>(CloudBlobClient service, T options)
            where T : BlobRequestOptions, new()
        {
            T fullModifier = null;

            if (options != null)
            {
                fullModifier = options.Clone() as T;
            }
            else
            {
                fullModifier = new T();
            }

            fullModifier.ApplyDefaults(service);
            return fullModifier;
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A clone of the instance.</returns>
        internal virtual BlobRequestOptions Clone()
        {
            return new BlobRequestOptions(this);
        }

        /// <summary>
        /// Applies the defaults.
        /// </summary>
        /// <param name="service">The service.</param>
        internal virtual void ApplyDefaults(CloudBlobClient service)
        {
            this.Timeout = this.Timeout ?? service.Timeout;
            this.RetryPolicy = this.RetryPolicy ?? service.RetryPolicy;
        }
    }
}
