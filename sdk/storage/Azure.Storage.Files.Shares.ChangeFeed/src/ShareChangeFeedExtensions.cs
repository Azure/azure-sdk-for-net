// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
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
        /// of the specified file share. The service client's credentials are propagated
        /// to the underlying blob client used for reading change feed segments.
        /// Shared key, token, and SAS-based authentication are all supported.
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
            Uri fileServiceUri = serviceClient.Uri;
            Uri blobEndpoint = ContainerDiscovery.FileToBlobEndpoint(fileServiceUri);

            BlobServiceClient blobServiceClient = CreateBlobServiceClient(
                blobEndpoint,
                ShareServiceClientInternals.GetSharedKey(serviceClient),
                ShareServiceClientInternals.GetToken(serviceClient));

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
        /// The share client's credentials are propagated to the underlying blob client
        /// used for reading change feed segments.
        /// Shared key, token, and SAS-based authentication are all supported.
        /// </summary>
        /// <param name="shareClient">The <see cref="ShareClient"/> for the file share whose change feed will be read.</param>
        /// <param name="options">Optional <see cref="ShareChangeFeedClientOptions"/> for tuning change feed behavior.</param>
        /// <returns>A new <see cref="ShareChangeFeedClient"/> instance.</returns>
        public static ShareChangeFeedClient GetShareChangeFeedClient(
            this ShareClient shareClient,
            ShareChangeFeedClientOptions options = default)
        {
            UriBuilder builder = new UriBuilder(shareClient.Uri)
            {
                Path = "/",
            };
            Uri fileServiceUri = builder.Uri;
            Uri blobEndpoint = ContainerDiscovery.FileToBlobEndpoint(fileServiceUri);

            BlobServiceClient blobServiceClient = CreateBlobServiceClient(
                blobEndpoint,
                ShareClientInternals.GetSharedKey(shareClient),
                ShareClientInternals.GetToken(shareClient));

            return new ShareChangeFeedClient(
                blobServiceClient,
                shareClient,
                fileServiceUri,
                shareClient.Name,
                options);
        }

        private static BlobServiceClient CreateBlobServiceClient(
            Uri blobEndpoint,
            StorageSharedKeyCredential sharedKeyCredential,
            TokenCredential tokenCredential)
        {
            if (sharedKeyCredential != null)
            {
                return new BlobServiceClient(blobEndpoint, sharedKeyCredential);
            }

            if (tokenCredential != null)
            {
                return new BlobServiceClient(blobEndpoint, tokenCredential);
            }

            // SAS token is embedded in the URI, or anonymous access.
            return new BlobServiceClient(blobEndpoint);
        }

        /// <summary>
        /// Helper to access protected static members of <see cref="ShareServiceClient"/>
        /// that should not be exposed directly to customers.
        /// </summary>
        private class ShareServiceClientInternals : ShareServiceClient
        {
            public static StorageSharedKeyCredential GetSharedKey(ShareServiceClient client)
                => ShareServiceClient.GetSharedKeyCredential(client);

            public static TokenCredential GetToken(ShareServiceClient client)
                => ShareServiceClient.GetTokenCredential(client);
        }

        /// <summary>
        /// Helper to access protected static members of <see cref="ShareClient"/>
        /// that should not be exposed directly to customers.
        /// </summary>
        private class ShareClientInternals : ShareClient
        {
            public static StorageSharedKeyCredential GetSharedKey(ShareClient client)
                => ShareClient.GetSharedKeyCredential(client);

            public static TokenCredential GetToken(ShareClient client)
                => ShareClient.GetTokenCredential(client);
        }
    }
}
