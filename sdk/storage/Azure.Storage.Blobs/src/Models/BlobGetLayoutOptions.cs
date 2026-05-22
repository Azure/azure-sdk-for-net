// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for
    /// <see cref="BlobBaseClient.GetLayout(BlobGetLayoutOptions, System.Threading.CancellationToken)"/> and
    /// <see cref="BlobBaseClient.GetLayoutAsync(BlobGetLayoutOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class BlobGetLayoutOptions
    {
        /// <summary>
        /// If provided, returns layout only for the specified range.
        /// If not provided, returns the layout for the entire blob.
        /// </summary>
        public HttpRange Range { get; set; }

        /// <summary>
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on getting the blob's properties and layout.
        /// </summary>
        public BlobRequestConditions Conditions { get; set; }
    }
}
