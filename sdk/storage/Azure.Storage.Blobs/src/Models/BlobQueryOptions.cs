// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs.Specialized;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for <see cref="BlockBlobClient.QueryAsync(string, BlobQueryOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class BlobQueryOptions
    {
        /// <summary>
        /// Optional input text configuration.
        /// </summary>
        public BlobQueryTextConfiguration InputTextConfiguration { get; set; }

        /// <summary>
        /// Optional output text configuration.
        /// </summary>
        public BlobQueryTextConfiguration OutputTextConfiguration { get; set; }

        /// <summary>
        /// Optional callback for error handling.
        /// </summary>
        public Action<BlobQueryError> ErrorHandler { get; set; }

        /// <summary>
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on the query.
        /// </summary>
        public BlobRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional progress handler.
        /// </summary>
        public IProgress<long> ProgressHandler { get; set; }
    }
}
