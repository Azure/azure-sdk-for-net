// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs;
using Azure.Storage.Files.Shares;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// Extension methods for creating <see cref="ShareChangeFeedClient"/> instances
    /// from existing Azure Files clients.
    /// </summary>
    public static class ShareChangeFeedExtensions
    {
        /// <summary>
        /// Creates a <see cref="ShareChangeFeedClient"/> for reading the change feed
        /// of the specified file share. The service client's credentials and pipeline
        /// are reused for both the file service discovery call and blob reads.
        /// </summary>
        /// <param name="serviceClient">The <see cref="ShareServiceClient"/> that provides authentication and endpoint information.</param>
        /// <param name="shareName">The name of the file share whose change feed will be read.</param>
        /// <param name="options">Optional <see cref="ShareChangeFeedClientOptions"/> for tuning change feed behavior.</param>
        /// <returns>A new <see cref="ShareChangeFeedClient"/> instance.</returns>
        public static ShareChangeFeedClient GetShareChangeFeedClient(
            this ShareServiceClient serviceClient,
            string shareName,
            ShareChangeFeedClientOptions options = default)
        {
            // Build the file service URI from the ShareServiceClient (preserves any SAS token).
            Uri fileServiceUri = serviceClient.Uri;

            // Derive the blob endpoint for reading change feed Avro segments.
            Uri blobEndpoint = ContainerDiscovery.FileToBlobEndpoint(fileServiceUri);
            BlobServiceClient blobServiceClient = new BlobServiceClient(blobEndpoint);

            // Reuse the ShareServiceClient's pipeline for the file service discovery call.
            // ShareServiceClient.GetShareClient() builds a ShareClient that carries the same
            // credentials/pipeline, so we go through it to get an authenticated share URI.
            ShareClient shareClient = serviceClient.GetShareClient(shareName);

            return new ShareChangeFeedClient(
                blobServiceClient,
                shareClient,
                fileServiceUri,
                shareName,
                options);
        }

        /// <summary>
        /// Creates a <see cref="ShareChangeFeedClient"/> for reading the change feed
        /// of the file share represented by this <see cref="ShareClient"/>.
        /// The share client's credentials and pipeline are reused for authentication.
        /// </summary>
        /// <param name="shareClient">The <see cref="ShareClient"/> for the file share whose change feed will be read.</param>
        /// <param name="options">Optional <see cref="ShareChangeFeedClientOptions"/> for tuning change feed behavior.</param>
        /// <returns>A new <see cref="ShareChangeFeedClient"/> instance.</returns>
        public static ShareChangeFeedClient GetShareChangeFeedClient(
            this ShareClient shareClient,
            ShareChangeFeedClientOptions options = default)
        {
            // Derive the file service endpoint from the share URI.
            var builder = new UriBuilder(shareClient.Uri)
            {
                Path = "/",
            };
            Uri fileServiceUri = builder.Uri;

            // Derive the blob endpoint for reading change feed Avro segments.
            Uri blobEndpoint = ContainerDiscovery.FileToBlobEndpoint(fileServiceUri);
            BlobServiceClient blobServiceClient = new BlobServiceClient(blobEndpoint);

            return new ShareChangeFeedClient(
                blobServiceClient,
                shareClient,
                fileServiceUri,
                shareClient.Name,
                options);
        }
    }
}
