// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// Discovers the change feed blob container name for a given file share
    /// by calling the Get Share Properties REST API.
    /// </summary>
    internal static class ContainerDiscovery
    {
        /// <summary>
        /// Discovers the change feed container name for a file share by reading the
        /// x-ms-file-blob-container-for-xfiles-change-feed response header from
        /// Get Share Properties.
        /// </summary>
        internal static async Task<string> DiscoverContainerNameAsync(
            HttpPipeline pipeline,
            Uri fileServiceUri,
            string shareName,
            bool async,
            CancellationToken cancellationToken)
        {
            // Build the request URI: https://{account}.file.core.windows.net/{shareName}?restype=share
            UriBuilder uriBuilder = new UriBuilder(fileServiceUri);
            uriBuilder.Path = uriBuilder.Path.TrimEnd('/') + "/" + shareName;
            uriBuilder.Query = "restype=share";

            Request request = pipeline.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(uriBuilder.Uri);
            request.Headers.Add("x-ms-version", Constants.FilesChangeFeed.RequiredApiVersion);

            Response response;
            if (async)
            {
                response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                response = pipeline.SendRequest(request, cancellationToken);
            }

            if (response.Status != 200)
            {
                throw new RequestFailedException(response);
            }

            if (!response.Headers.TryGetValue(Constants.FilesChangeFeed.ChangeFeedContainerHeader, out string containerName))
            {
                throw new InvalidOperationException(
                    $"Change Feed is not enabled for share '{shareName}'. " +
                    $"Enable it by setting x-ms-file-enable-change-feed: true when creating or updating the share.");
            }

            return containerName;
        }

        /// <summary>
        /// Converts a file service endpoint URI to a blob service endpoint URI.
        /// e.g., https://account.file.core.windows.net -> https://account.blob.core.windows.net
        /// </summary>
        internal static Uri FileToBlobEndpoint(Uri fileEndpoint)
        {
            UriBuilder builder = new UriBuilder(fileEndpoint);
            builder.Host = builder.Host.Replace(".file.", ".blob.");
            builder.Path = "/";
            builder.Query = null;
            return builder.Uri;
        }
    }
}
