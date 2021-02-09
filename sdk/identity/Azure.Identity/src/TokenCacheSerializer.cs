// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core;

namespace Azure.Identity
{
    /// <summary>
    /// A cache for Tokens.
    /// </summary>
    public static class TokenCacheSerializer
    {
        /// <summary>
        /// Serializes the <see cref="TokenCache"/> to the specified <see cref="Stream"/>.
        /// </summary>
        /// <param name="tokenCache">The <see cref="TokenCache"/> to serialize.</param>
        /// <param name="stream">The <see cref="Stream"/> which the serialized <see cref="TokenCache"/> will be written to.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public static void Serialize(TokenCache tokenCache, Stream stream, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tokenCache, nameof(tokenCache));
            Argument.AssertNotNull(stream, nameof(stream));

            SerializeAsync(tokenCache, stream, false, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Serializes the <see cref="TokenCache"/> to the specified <see cref="Stream"/>.
        /// </summary>
        /// <param name="tokenCache">The <see cref="TokenCache"/> to serialize.</param>
        /// <param name="stream">The <see cref="Stream"/> to which the serialized <see cref="TokenCache"/> will be written.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public static async Task SerializeAsync(TokenCache tokenCache, Stream stream, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tokenCache, nameof(tokenCache));
            Argument.AssertNotNull(stream, nameof(stream));

            await SerializeAsync(tokenCache, stream, true, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Deserializes the <see cref="TokenCache"/> from the specified <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> from which the serialized <see cref="TokenCache"/> will be read.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public static TokenCache Deserialize(Stream stream, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            return DeserializeAsync(stream, false, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Deserializes the <see cref="TokenCache"/> from the specified <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> from which the serialized <see cref="TokenCache"/> will be read.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public static async Task<TokenCache> DeserializeAsync(Stream stream, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            return await DeserializeAsync(stream, true, cancellationToken).ConfigureAwait(false);
        }

        private static async Task SerializeAsync(TokenCache tokenCache, Stream stream, bool async, CancellationToken cancellationToken)
        {
            if (async)
            {
                await stream.WriteAsync(tokenCache.Data, 0, tokenCache.Data.Length, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                stream.Write(tokenCache.Data, 0, tokenCache.Data.Length);
            }
        }

        private static async Task<TokenCache> DeserializeAsync(Stream stream, bool async, CancellationToken cancellationToken)
        {
            var data = new byte[stream.Length - stream.Position];

            if (async)
            {
                await stream.ReadAsync(data, 0, data.Length, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                stream.Read(data, 0, data.Length);
            }

            return new TokenCache(data);
        }
    }
}
