// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

#nullable disable

namespace Azure.Core
{
    /// <summary>
    /// Provides support for creating and parsing multipart/mixed content.
    /// This is implementing a couple of layered standards as mentioned at
    /// https://docs.microsoft.com/en-us/rest/api/storageservices/blob-batch and
    /// https://docs.microsoft.com/en-us/rest/api/storageservices/performing-entity-group-transactions
    /// including https://www.odata.org/documentation/odata-version-3-0/batch-processing/
    /// and https://www.ietf.org/rfc/rfc2046.txt.
    /// </summary>
    internal static class Multipart
    {
        private const int KB = 1024;
        private const int ResponseLineSize = 4 * KB;
        private const string MultipartContentTypePrefix = "multipart/mixed; boundary=";
        private const string ContentIdName = "Content-ID";
        internal static InvalidOperationException InvalidBatchContentType(string contentType) =>
            new InvalidOperationException($"Expected {HttpHeader.Names.ContentType} to start with {MultipartContentTypePrefix} but received {contentType}");

        internal static InvalidOperationException InvalidHttpStatusLine(string statusLine) =>
            new InvalidOperationException($"Expected an HTTP status line, not {statusLine}");

        internal static InvalidOperationException InvalidHttpHeaderLine(string headerLine) =>
            new InvalidOperationException($"Expected an HTTP header line, not {headerLine}");

        /// <summary>
        /// Parse a multipart/mixed response body into several responses.
        /// </summary>
        /// <param name="batchContent">The response content.</param>
        /// <param name="batchContentType">The response content type.</param>
        /// <param name="expectBoundariesWithCRLF">Controls whether the parser will expect all multi-part boundaries to use CRLF line breaks. This should be true unless more permissive line break parsing is required.</param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be cancelled.
        /// </param>
        /// <returns>The parsed <see cref="Response"/>s.</returns>
        internal static async Task<Response[]> ParseAsync(
            Stream batchContent,
            string batchContentType,
            bool expectBoundariesWithCRLF,
            bool async,
            CancellationToken cancellationToken)
        {
            // Get the batch boundary
            if (!GetBoundary(batchContentType, out string batchBoundary))
            {
                throw InvalidBatchContentType(batchContentType);
            }

            // Collect the responses in a dictionary (in case the Content-ID
            // values come back out of order)
            Dictionary<int, Response> responses = new Dictionary<int, Response>();

            // Collect responses without a Content-ID in a List
            List<Response> responsesWithoutId = new List<Response>();

            // Read through the batch body one section at a time until the
            // reader returns null
            MultipartReader reader = new MultipartReader(batchBoundary, batchContent) { ExpectBoundariesWithCRLF = expectBoundariesWithCRLF };
            for (MultipartSection section = await reader.GetNextSectionAsync(async, cancellationToken).ConfigureAwait(false);
                section != null;
                section = await reader.GetNextSectionAsync(async, cancellationToken).ConfigureAwait(false))
            {
                bool contentIdFound = true;
                if (section.Headers.TryGetValue(HttpHeader.Names.ContentType, out string[] contentTypeValues) &&
                        contentTypeValues.Length == 1 &&
                        GetBoundary(contentTypeValues[0], out string subBoundary))
                {
                    // ExpectBoundariesWithCRLF should always be true for the Body.
                    reader = new MultipartReader(subBoundary, section.Body){ ExpectBoundariesWithCRLF = true };
                    continue;
                }
                // Get the Content-ID header
                if (!section.Headers.TryGetValue(ContentIdName, out string[] contentIdValues) ||
                    contentIdValues.Length != 1 ||
                    !int.TryParse(contentIdValues[0], out int contentId))
                {
                    // If the header wasn't found, this is either:
                    // - a failed request with the details being sent as the first sub-operation
                    // - a tables batch request, which does not utilize Content-ID headers
                    // so we default the Content-ID to 0 and track that no Content-ID was found.
                    contentId = 0;
                    contentIdFound = false;
                }

                // Build a response
                MemoryResponse response = new MemoryResponse();
                if (contentIdFound)
                {
                    // track responses by Content-ID
                    responses[contentId] = response;
                }
                else
                {
                    // track responses without a Content-ID
                    responsesWithoutId.Add(response);
                }

                // We're going to read the section's response body line by line
                using var body = new BufferedReadStream(section.Body, ResponseLineSize);

                // The first line is the status like "HTTP/1.1 202 Accepted"
                string line = await body.ReadLineAsync(async, cancellationToken).ConfigureAwait(false);
                string[] status = line.Split(new char[] { ' ' }, 3, StringSplitOptions.RemoveEmptyEntries);
                if (status.Length != 3)
                {
                    throw InvalidHttpStatusLine(line);
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
                        throw InvalidHttpHeaderLine(line);
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

            // Collect the responses and order by Content-ID, when available.
            // Otherwise collect them as we received them.
            Response[] ordered = new Response[responses.Count + responsesWithoutId.Count];
            for (int i = 0; i < responses.Count; i++)
            {
                ordered[i] = responses[i];
            }
            for (int i = responses.Count; i < ordered.Length; i++)
            {
                ordered[i] = responsesWithoutId[i - responses.Count];
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
                await stream.ReadLineAsync(ResponseLineSize, cancellationToken).ConfigureAwait(false) :
                stream.ReadLine(ResponseLineSize);

        /// <summary>
        /// Read the next multipart section.
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

        private static bool GetBoundary(string contentType, out string batchBoundary)
        {
            if (contentType == null || !contentType.StartsWith(MultipartContentTypePrefix, StringComparison.Ordinal))
            {
                batchBoundary = null;
                return false;
            }
            batchBoundary = contentType.Substring(MultipartContentTypePrefix.Length);
            return true;
        }
    }
}
