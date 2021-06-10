// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// CallingServerClient _contentDownloader methods extentions class.
    /// </summary>
    public static class DownloadExtentions
    {
        /// <summary>
        /// The <see cref="DownloadStreamingAsync(CallingServerClient, Uri, HttpRange, CancellationToken)"/>
        /// operation downloads the recording's content.
        ///
        /// </summary>
        /// <param name="callingServerClient">
        /// The Azure Communication Services Calling Server client.
        /// </param>
        /// <param name="sourceEndpoint">
        /// Recording's content's url location.
        /// </param>
        /// <param name="range">
        /// If provided, only download the bytes of the content in the specified range.
        /// If not provided, download the entire content.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Stream}"/> containing the
        /// downloaded content.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public static async Task<Response<Stream>> DownloadStreamingAsync(
            this CallingServerClient callingServerClient,
            Uri sourceEndpoint,
            HttpRange range = default,
            CancellationToken cancellationToken = default) =>
            await callingServerClient._contentDownloader.DownloadStreamingInternal(
                sourceEndpoint,
                range,
                async: true,
                cancellationToken)
            .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DownloadStreaming(CallingServerClient, Uri, HttpRange, CancellationToken)"/>
        /// operation downloads the recording's content.
        ///
        /// </summary>
        /// <param name="callingServerClient">
        /// The Azure Communication Services Calling Server client.
        /// </param>
        /// <param name="sourceEndpoint">
        /// Recording's content's url location.
        /// </param>
        /// <param name="range">
        /// If provided, only download the bytes of the content in the specified range.
        /// If not provided, download the entire content.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Stream}"/> containing the
        /// downloaded content.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public static Response<Stream> DownloadStreaming(
            this CallingServerClient callingServerClient,
            Uri sourceEndpoint,
            HttpRange range = default,
            CancellationToken cancellationToken = default) =>
            callingServerClient._contentDownloader.DownloadStreamingInternal(
                sourceEndpoint,
                range,
                async: false,
                cancellationToken)
            .EnsureCompleted();

        /// <summary>
        /// The <see cref="DownloadTo(CallingServerClient, Uri, Stream, ContentTransferOptions, CancellationToken)"/>
        /// operation downloads the specified content using parallel requests,
        /// and writes the content to <paramref name="destinationStream"/>.
        /// </summary>
        /// <param name="callingServerClient">
        /// The Azure Communication Services Calling Server client.
        /// </param>
        /// <param name="sourceEndpoint">
        /// A <see cref="Uri"/> with the Recording's content's url location.
        /// </param>
        /// <param name="destinationStream">
        /// A <see cref="Stream"/> to write the downloaded content to.
        /// </param>
        /// <param name="transferOptions">
        /// Optional <see cref="ContentTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public static Response DownloadTo(this CallingServerClient callingServerClient, Uri sourceEndpoint, Stream destinationStream,
            ContentTransferOptions transferOptions = default, CancellationToken cancellationToken = default) =>
            callingServerClient._contentDownloader.StagedDownloadAsync(sourceEndpoint, destinationStream, transferOptions, async: false, cancellationToken: cancellationToken).EnsureCompleted();

        /// <summary>
        /// The <see cref="DownloadToAsync(CallingServerClient, Uri, Stream, ContentTransferOptions, CancellationToken)"/>
        /// operation downloads the specified content using parallel requests,
        /// and writes the content to <paramref name="destinationStream"/>.
        /// </summary>
        /// <param name="callingServerClient">
        /// The Azure Communication Services Calling Server client.
        /// </param>
        /// <param name="sourceEndpoint">
        /// A <see cref="Uri"/> with the Recording's content's url location.
        /// </param>
        /// <param name="destinationStream">
        /// A <see cref="Stream"/> to write the downloaded content to.
        /// </param>
        /// <param name="transferOptions">
        /// Optional <see cref="ContentTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public static async Task<Response> DownloadToAsync(this CallingServerClient callingServerClient, Uri sourceEndpoint, Stream destinationStream, ContentTransferOptions transferOptions = default, CancellationToken cancellationToken = default) =>
            await callingServerClient._contentDownloader.StagedDownloadAsync(sourceEndpoint, destinationStream, transferOptions, async: true, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DownloadTo(CallingServerClient, Uri, string, ContentTransferOptions, CancellationToken)"/>
        /// operation downloads the specified content using parallel requests,
        /// and writes the content to <paramref name="destinationPath"/>.
        /// </summary>
        /// <param name="callingServerClient">
        /// The Azure Communication Services Calling Server client.
        /// </param>
        /// <param name="sourceEndpoint">
        /// A <see cref="Uri"/> with the Recording's content's url location.
        /// </param>
        /// <param name="destinationPath">
        /// A file path to write the downloaded content to.
        /// </param>
        /// <param name="transferOptions">
        /// Optional <see cref="ContentTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public static Response DownloadTo(this CallingServerClient callingServerClient, Uri sourceEndpoint, string destinationPath,
            ContentTransferOptions transferOptions = default, CancellationToken cancellationToken = default)
        {
            using Stream destination = File.Create(destinationPath);
            return callingServerClient._contentDownloader.StagedDownloadAsync(sourceEndpoint, destination, transferOptions,
                async: false, cancellationToken: cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// The <see cref="DownloadToAsync(CallingServerClient, Uri, string, ContentTransferOptions, CancellationToken)"/>
        /// operation downloads the specified content using parallel requests,
        /// and writes the content to <paramref name="destinationPath"/>.
        /// </summary>
        /// <param name="callingServerClient">
        /// The Azure Communication Services Calling Server client.
        /// </param>
        /// <param name="sourceEndpoint">
        /// A <see cref="Uri"/> with the Recording's content's url location.
        /// </param>
        /// <param name="destinationPath">
        /// A file path to write the downloaded content to.
        /// </param>
        /// <param name="transferOptions">
        /// Optional <see cref="ContentTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public static async Task<Response> DownloadToAsync(this CallingServerClient callingServerClient, Uri sourceEndpoint, string destinationPath,
            ContentTransferOptions transferOptions = default, CancellationToken cancellationToken = default)
        {
            using Stream destination = File.Create(destinationPath);
            return await callingServerClient._contentDownloader.StagedDownloadAsync(sourceEndpoint, destination, transferOptions,
                async: true, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
