// -----------------------------------------------------------------------------------------
// <copyright file="CloudBlobDirectory.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
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
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Blob
{
    using System;
    using Windows.Foundation;

    /// <summary>
    /// Represents a virtual directory of blobs, designated by a delimiter character.
    /// </summary>
    /// <remarks>Containers, which are encapsulated as <see cref="CloudBlobContainer"/> objects, hold directories, and directories hold block blobs and page blobs. Directories can also contain sub-directories.</remarks>
    public sealed partial class CloudBlobDirectory
    {
        /// <summary>
        /// Returns a result segment containing a collection of blob items 
        /// in the container.
        /// </summary>
        /// <param name="currentToken">A <see cref="BlobContinuationToken"/> token returned by a previous listing operation.</param>
        /// <returns>A result segment containing objects that implement <see cref="IListBlobItem"/>.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<BlobResultSegment> ListBlobsSegmentedAsync(BlobContinuationToken currentToken)
        {
            return this.ListBlobsSegmentedAsync(false, BlobListingDetails.None, null /* maxResults */, currentToken, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Returns a result segment containing a collection of blob items 
        /// in the container.
        /// </summary>
        /// <param name="useFlatBlobListing">Whether to list blobs in a flat listing, or whether to list blobs hierarchically, by virtual directory.</param>
        /// <param name="blobListingDetails">A <see cref="BlobListingDetails"/> enumeration describing which items to include in the listing.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is <c>null</c>, the maximum possible number of results will be returned, up to 5000.</param>         
        /// <param name="currentToken">A continuation token returned by a previous listing operation.</param> 
        /// <param name="options">An object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A result segment containing objects that implement <see cref="IListBlobItem"/>.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<BlobResultSegment> ListBlobsSegmentedAsync(bool useFlatBlobListing, BlobListingDetails blobListingDetails, int? maxResults, BlobContinuationToken currentToken, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.Container.ListBlobsSegmentedAsync(this.Prefix, useFlatBlobListing, blobListingDetails, maxResults, currentToken, options, operationContext);
        }
    }
}
