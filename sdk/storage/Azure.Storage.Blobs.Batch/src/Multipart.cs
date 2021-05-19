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
        public static Task<(Stream, string)> CreateAsync(
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
        /// Parse a multipart/mixed response body into several responses.
        /// </summary>
        /// <param name="batchContent">The response content.</param>
        /// <param name="batchContentType">The response content type.</param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be cancelled.
        /// </param>
        /// <returns>The parsed <see cref="Response"/>s.</returns>
        public static async Task<Response[]> ParseAsync(
            Stream batchContent,
            string batchContentType,
            bool async,
            CancellationToken cancellationToken)
        {
            // Get the batch boundary
            if (batchContentType == null ||
                !batchContentType.StartsWith(BatchConstants.MultipartContentTypePrefix, StringComparison.Ordinal))
            {
                throw BatchErrors.InvalidBatchContentType(batchContentType);
            }
            string batchBoundary = batchContentType.Substring(BatchConstants.MultipartContentTypePrefix.Length);

            // Collect the responses in a dictionary (in case the Content-ID
            // values come back out of order)
            Dictionary<int, Response> responses = new Dictionary<int, Response>();

            // Read through the batch body one section at a time until the
            // reader returns null
            MultipartReader reader = new MultipartReader(batchBoundary, batchContent);
            for (MultipartSection section = await reader.GetNextSectionAsync(async, cancellationToken).ConfigureAwait(false);
                section != null;
                section = await reader.GetNextSectionAsync(async, cancellationToken).ConfigureAwait(false))
            {
                // Get the Content-ID header
                if (!section.Headers.TryGetValue(BatchConstants.ContentIdName, out StringValues contentIdValues) ||
                    contentIdValues.Count != 1 ||
                    !int.TryParse(contentIdValues[0], out int contentId))
                {
                    // If the header wasn't found, this is a failed request
                    // with the details being sent as the first sub-operation
                    // so we default the Content-ID to 0
                    contentId = 0;
                }

                // Build a response
                MemoryResponse response = new MemoryResponse();
                responses[contentId] = response;

                // We're going to read the section's response body line by line
                using var body = new BufferedReadStream(section.Body, BatchConstants.ResponseLineSize);

                // The first line is the status like "HTTP/1.1 202 Accepted"
                string line = await body.ReadLineAsync(async, cancellationToken).ConfigureAwait(false);
                string[] status = line.Split(new char[] { ' ' }, 3, StringSplitOptions.RemoveEmptyEntries);
                if (status.Length != 3)
                {
                    throw BatchErrors.InvalidHttpStatusLine(line);
                }
                response.SetStatus(int.Parse(status[1], CultureInfo.InvariantCulture));
                response.SetReasonPhrase(status[2]);

                // Continue reading headers until we reach a blank line
                line = await body.ReadLineAsync(async, cancellationToken).ConfigureAwait(false);
                while (!string.IsNullOrEmpty(line))
                {
                    // Split the header into the name and value
                    int splitIndex = line.IndexOf(':');
                    if (splitIndex <= 0)
                    {
                        throw BatchErrors.InvalidHttpHeaderLine(line);
                    }
                    var name = line.Substring(0, splitIndex);
                    var value = line.Substring(splitIndex + 1, line.Length - splitIndex - 1).Trim();
                    response.AddHeader(name, value);

                    line = await body.ReadLineAsync(async, cancellationToken).ConfigureAwait(false);
                }

                // Copy the rest of the body as the response content
                var responseContent = new MemoryStream();
                if (async)
                {
                    await body.CopyToAsync(responseContent).ConfigureAwait(false);
                }
                else
                {
                    body.CopyTo(responseContent);
                }
                responseContent.Seek(0, SeekOrigin.Begin);
                response.ContentStream = responseContent;
            }

            // Collect the responses and order by Content-ID
            Response[] ordered = new Response[responses.Count];
            for (int i = 0; i < ordered.Length; i++)
            {
                ordered[i] = responses[i];
            }
            return ordered;
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

        /// <summary>
        /// Read the next multipart section
        /// </summary>
        /// <param name="reader">The reader to parse with.</param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be cancelled.
        /// </param>
        /// <returns>The next multipart section.</returns>
        internal static async Task<MultipartSection> GetNextSectionAsync(
            this MultipartReader reader,
            bool async,
            CancellationToken cancellationToken) =>
            async ?
                await reader.ReadNextSectionAsync(cancellationToken).ConfigureAwait(false) :
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
                reader.ReadNextSectionAsync(cancellationToken).GetAwaiter().GetResult(); // #7972: Decide if we need a proper sync API here
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
    }
}
