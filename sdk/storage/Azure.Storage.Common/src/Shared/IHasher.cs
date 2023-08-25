// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage
{
    /// <summary>
    /// Interface to wrap either a HashAlgorithm or a NonCryptographicHashAlgorithm
    /// to provide a common interface for hashing a stream.
    /// </summary>
    internal interface IHasher : IDisposable
    {
        /// <summary>
        /// Hash length in bytes.
        /// </summary>
        int HashSizeInBytes { get; }

        /// <summary>
        /// Hashes the contents of the stream.
        /// </summary>
        /// <param name="stream">Content</param>
        /// <param name="async">Whether to perform the operation asynchronously.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        Task<byte[]> ComputeHashInternal(Stream stream, bool async, CancellationToken cancellationToken);

        /// <summary>
        /// Appends content to hash calculation.
        /// </summary>
        /// <param name="content">Content to hash.</param>
        void AppendHash(ReadOnlySpan<byte> content);

        /// <summary>
        /// Writes the current hash calculation to the given buffer.
        /// Note that some implementations have an explicit hash finalization step.
        /// Therefore this method should NOT be called to observe a partial calculation.
        /// </summary>
        /// <param name="hashDestination">Buffer to write hash value to.</param>
        /// <returns>Number of bytes written to buffer.</returns>
        int GetFinalHash(Span<byte> hashDestination);
    }
}
