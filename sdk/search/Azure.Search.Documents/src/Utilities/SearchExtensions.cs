// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Search extension methods.
    /// </summary>
    internal static partial class SearchExtensions
    {
        /// <summary>
        /// Assert that the given URI uses HTTPS as its scheme.
        /// </summary>
        /// <param name="endpoint">The URI to validate.</param>
        /// <param name="paramName">
        /// The name of the parameter for this URI, to use with an
        /// <see cref="ArgumentException"/>.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown when the <paramref name="endpoint"/> is not using HTTPS as
        /// its scheme.
        /// </exception>
        public static void AssertHttpsScheme(this Uri endpoint, string paramName)
        {
            Debug.Assert(endpoint != null);
            if (!string.Equals(endpoint.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException($"{paramName} only supports {Uri.UriSchemeHttps}.", paramName);
            }
        }

        /// <summary>
        /// Get the name of the Search Service from its
        /// <paramref name="endpoint"/>.
        /// </summary>
        /// <param name="endpoint">The endpoint of the Search Service.</param>
        /// <returns>The name of the Search Service.</returns>
        public static string GetSearchServiceName(this Uri endpoint)
        {
            Debug.Assert(endpoint != null);
            string host = endpoint.Host;
            int separator = host.IndexOf('.');
            return (separator > 0) ?
                host.Substring(0, separator) :
                null;
        }

        /// <summary>
        /// Join a collection of strings into a single comma separated string.
        /// If the collection is null or empty, a null string will be returned.
        /// </summary>
        /// <param name="items">The items to join.</param>
        /// <returns>The items joined together by commas.</returns>
        public static string CommaJoin(this IEnumerable<string> items) =>
            items != null && items.Any() ? string.Join(",", items) : null;

        /// <summary>
        /// Split a collection of strings by commas.
        /// </summary>
        /// <param name="value">The value to split.</param>
        /// <returns>A collection of individual values.</returns>
        public static IList<string> CommaSplit(string value) =>
            string.IsNullOrEmpty(value) ?
                new List<string>() :
                // TODO: #10600 - Verify we don't need to worry about escaping
                new List<string>(value.Split(','));

        /// <summary>
        /// Copy from a source stream to a destination either synchronously or
        /// asynchronously.
        /// </summary>
        /// <param name="source">The stream to read from.</param>
        /// <param name="destination">The stream to write to.</param>
        /// <param name="async">Whether to execute sync or async.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>A Task representing the computation.</returns>
        public static async Task CopyToAsync(
            this Stream source,
            Stream destination,
            bool async,
            CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(source, nameof(source));
            Argument.AssertNotNull(destination, nameof(destination));

            if (async)
            {
                await source.CopyToAsync(
                    destination,
                    Constants.CopyBufferSize,
                    cancellationToken)
                    .ConfigureAwait(false);
            }
            else
            {
                // This is not using CopyTo so we can honor cancellations
                byte[] buffer = ArrayPool<byte>.Shared.Rent(Constants.CopyBufferSize);
                try
                {
                    while (true)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        int read = source.Read(buffer, 0, buffer.Length);
                        if (read <= 0) { break; }
                        cancellationToken.ThrowIfCancellationRequested();
                        destination.Write(buffer, 0, read);
                    }
                }
                finally
                {
                    destination.Flush();
                    ArrayPool<byte>.Shared.Return(buffer, true);
                }
            }
        }

        /// <summary>
        /// Copy a Stream into memory.
        /// </summary>
        /// <param name="source">The stream to read.</param>
        /// <param name="async">Whether to execute sync or async.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>The source stream as a MemoryStream.</returns>
        public static async Task<MemoryStream> CopyToMemoryStreamAsync(
            this Stream source,
            bool async,
            CancellationToken cancellationToken)
        {
            MemoryStream destination = new MemoryStream();
            await source.CopyToAsync(destination, async, cancellationToken).ConfigureAwait(false);
            return destination;
        }
    }
}
