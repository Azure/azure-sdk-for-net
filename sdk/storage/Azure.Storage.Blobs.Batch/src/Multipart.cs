// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Http.Multipart;

namespace Azure.Storage.Blobs.Specialized
{
    /// <summary>
    /// Provides support for creating and parsing multipart/mixed content.
    /// This is implementing a couple of layered standards as mentioned at
    /// https://docs.microsoft.com/en-us/rest/api/storageservices/blob-batch
    /// including https://www.odata.org/documentation/odata-version-3-0/batch-processing/
    /// and https://www.ietf.org/rfc/rfc2046.txt.
    /// </summary>
    internal static class Multipart
    {
        /// <summary>
        /// Get a random GUID to use as our multipart boundary.  This is a hack
        /// to allow for repeatable boundaries in our recorded unit tests.
        /// </summary>
        internal static Func<Guid> GetRandomGuid { get; set; } = () => Guid.NewGuid();

        /// <summary>
        /// Create a multipart/mixed request body that combines several
        /// messages.
        /// </summary>
        /// <param name="messages">
        /// The batch sub-operation messages to submit together.
        /// </param>
        /// <param name="prefix">
        /// A prefix used for the multipart/mixed boundary.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A tuple containing the batch sub-operation messages merged into a
        /// single multipart/mixed content stream and content type.
        /// </returns>
        public static Task<(Stream ContentStream, string ContentType)> CreateAsync(
            IEnumerable<HttpMessage> messages,
            string prefix,
#pragma warning disable CA1801 // Remove unused parameter (leaving for future changes)
#pragma warning disable IDE0060 // Remove unused parameter
            bool async,
            CancellationToken cancellationToken)
#pragma warning restore IDE0060 // Remove unused parameter
#pragma warning restore CA1801 // Remove unused parameter
        {
            // Set the content-type
            var boundary = $"{prefix}_{GetRandomGuid().ToString()}";
            var contentType = BatchConstants.MultipartContentTypePrefix + boundary;

            // TODO: Investigate whether to use a StreamWriter instead of a
            // StringBuilder we turn into a MemoryStream (this will have to
            // happen once we support binary content anyway).
            var content = new StringBuilder(1024);

            // We're implementing the limited subset of
            // https://www.ietf.org/rfc/rfc2046.txt required for Storage
            // batching.  The format needs to be followed precisely for the
            // service to correctly parse the request.

            const string newline = "\r\n";
            var operationId = 0;
            foreach (HttpMessage message in messages)
            {
                // Write the boundary
                content.Append(BatchConstants.BatchSeparator).Append(boundary).Append(newline);
                content.Append(BatchConstants.RequestContentType).Append(newline);
                content.Append(BatchConstants.RequestContentTransferEncoding).Append(newline);
                content.Append(BatchConstants.ContentIdName).Append(": ").Append(operationId++.ToString(CultureInfo.InvariantCulture)).Append(newline);
                content.Append(newline);

                // Write the request URI
                content
                    .Append(message.Request.Method.Method)
                    .Append(' ')
                    .Append(message.Request.Uri.PathAndQuery)
                    .Append(' ')
                    .Append(BatchConstants.HttpVersion)
                    .Append(newline);

                // Write the request headers
                foreach (HttpHeader header in message.Request.Headers)
                {
                    content.Append(header.Name).Append(": ").Append(header.Value).Append(newline);
                }

                // Write the request content (or lack thereof since none of
                // the current possible operations includes a request body)
                content.Append(BatchConstants.ContentLengthName).Append(": 0").Append(newline);

                // Add an extra line
                content.Append(newline);
            }

            // Write the final boundary
            content.Append(BatchConstants.BatchSeparator).Append(boundary).Append(BatchConstants.BatchSeparator).Append(newline);

            // Convert the content into a request stream
            Stream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(content.ToString()));

            // Return the content and type
            return Task.FromResult((stream, contentType));
        }

        /// <summary>
        /// Read the next line of text.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be cancelled.
        /// </param>
        /// <returns>The next line of text.</returns>
        internal static async Task<string> ReadLineAsync(
            this BufferedReadStream stream,
            bool async,
            CancellationToken cancellationToken) =>
            async ?
                await stream.ReadLineAsync(BatchConstants.ResponseLineSize, cancellationToken).ConfigureAwait(false) :
                stream.ReadLine(BatchConstants.ResponseLineSize);
    }
}
