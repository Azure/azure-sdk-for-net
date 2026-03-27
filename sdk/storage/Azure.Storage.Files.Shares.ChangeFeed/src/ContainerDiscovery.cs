// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// Discovers the change feed blob container name for a given file share
    /// by calling <see cref="ShareClient.GetProperties(CancellationToken)"/> and reading
    /// the <c>x-ms-file-blob-container-for-xfiles-change-feed</c> response header.
    /// </summary>
    internal static class ContainerDiscovery
    {
        /// <summary>
        /// Discovers the change feed container name by calling <see cref="ShareClient.GetProperties(CancellationToken)"/>
        /// and reading the change feed container header from the raw response.
        /// This is the preferred path when a <see cref="ShareClient"/> is available, as it
        /// reuses the client's authenticated pipeline.
        /// </summary>
        /// <param name="shareClient">An authenticated <see cref="ShareClient"/>.</param>
        /// <param name="async">Whether to execute the request asynchronously.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The blob container name that stores the change feed data for this share.</returns>
        internal static async Task<string> DiscoverContainerNameAsync(
            ShareClient shareClient,
            bool async,
            CancellationToken cancellationToken)
        {
            Response<ShareProperties> response;
            if (async)
            {
                response = await shareClient.GetPropertiesAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            else
            {
                response = shareClient.GetProperties(cancellationToken: cancellationToken);
            }

            // The change feed container name is returned as a raw response header
            // that isn't yet surfaced in the ShareProperties model.
            Response rawResponse = response.GetRawResponse();
            if (!rawResponse.Headers.TryGetValue(Constants.FilesChangeFeed.ChangeFeedContainerHeader, out string containerName))
            {
                throw new InvalidOperationException(
                    $"Change Feed is not enabled for share '{shareClient.Name}'. " +
                    $"Enable it by setting x-ms-file-enable-change-feed: true when creating or updating the share.");
            }

            return containerName;
        }

        /// <summary>
        /// Converts a file service endpoint URI to the corresponding blob service endpoint URI
        /// by replacing ".file." with ".blob." in the host name.
        /// For example, <c>https://account.file.core.windows.net</c> becomes
        /// <c>https://account.blob.core.windows.net</c>.
        /// </summary>
        /// <param name="fileEndpoint">The file service endpoint URI to convert.</param>
        /// <returns>The equivalent blob service endpoint URI.</returns>
        internal static Uri FileToBlobEndpoint(Uri fileEndpoint)
        {
            // Replace the ".file." subdomain with ".blob." to derive the blob endpoint.
            UriBuilder builder = new UriBuilder(fileEndpoint);
            builder.Host = builder.Host.Replace(".file.", ".blob.");
            builder.Path = "/";
            builder.Query = null;
            return builder.Uri;
        }
    }
}
