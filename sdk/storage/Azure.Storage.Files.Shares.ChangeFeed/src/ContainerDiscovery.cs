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
    /// TODO: Replace this raw REST call by calling into Azure.Storage.Files.Shares
    /// ShareClient.GetProperties() once that package exposes the change feed container header.
    /// </summary>
    internal static class ContainerDiscovery
    {
        /// <summary>
        /// Discovers the change feed container name for a file share by sending an
        /// authenticated GET request to the file service's Get Share Properties REST API
        /// and reading the <c>x-ms-file-blob-container-for-xfiles-change-feed</c> response header.
        /// </summary>
        /// <param name="pipeline">The HTTP pipeline configured with authentication for the file endpoint.</param>
        /// <param name="fileServiceUri">The file service base URI (e.g., https://account.file.core.windows.net).</param>
        /// <param name="shareName">The file share name to query.</param>
        /// <param name="async">Whether to execute the request asynchronously.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The blob container name that stores the change feed data for this share.</returns>
        internal static async Task<string> DiscoverContainerNameAsync(
            HttpPipeline pipeline,
            Uri fileServiceUri,
            string shareName,
            bool async,
            CancellationToken cancellationToken)
        {
            // Build the REST call to: GET https://{account}.file.core.windows.net/{shareName}?restype=share
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
