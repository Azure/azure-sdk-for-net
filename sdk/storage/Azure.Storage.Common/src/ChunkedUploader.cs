// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Common;

namespace Azure.Storage
{
    /// <summary>
    /// Helper to upload a <see cref="Stream"/> in chunks.
    /// </summary>
    internal static class ChunkedUploader
    {
        /// <summary>
        /// Attempt to get the length of a <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="length">The stream's length.</param>
        /// <returns>
        /// True if we obtained the length without the stream throwing, false
        /// otherwise.
        /// </returns>
        private static bool TryGetStreamLength(Stream stream, out long length)
        {
            length = 0;
            try
            {
                length = stream.Length;
                return true;
            }
            catch
            {
            }
            return false;
        }

        /// <summary>
        /// Upload a <see cref="Stream"/> in chunks.
        /// </summary>
        /// <typeparam name="T">
        /// Response type when uploading the entire stream of commiting a
        /// sequence of chunks.
        /// </typeparam>
        /// <typeparam name="C">
        /// Response type when uploading a single chunk.
        /// </typeparam>
        /// <param name="uploadStreamAsync">
        /// Returns a Task that will upload the entire stream (given the stream,
        /// whether to execute it async, and a cancellation token).
        /// </param>
        /// <param name="uploadChunkAsync">
        /// Returns a Task that will upload a single chunk stream (given the
        /// chunk's stream, chunk's sequence number,  whether to execute it
        /// async, and a cancellation token).
        /// </param>
        /// <param name="commitAsync">
        /// Returns a task that will commit a series of chunk uploads (given
        /// whether to execute it async and a cancellation token).
        /// </param>
        /// <param name="content">
        /// The entire stream to upload.
        /// </param>
        /// <param name="singleUploadThreshold">
        /// The maximum size of the stream to allow using
        /// <paramref name="uploadStreamAsync"/>.
        /// </param>
        /// <param name="chunkSize">
        /// The size of chunks to upload.
        /// </param>
        /// <param name="async">
        /// Whether to perform the upload asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns></returns>
        public static async Task<Response<T>> UploadAsync<T, C>(
            Func<Stream, bool, CancellationToken, Task<Response<T>>> uploadStreamAsync,
            Func<Stream, int, bool, CancellationToken, Task<Response<C>>> uploadChunkAsync,
            Func<bool, CancellationToken, Task<Response<T>>> commitAsync,
            Stream content,
            long singleUploadThreshold,
            int chunkSize,
            bool async = true,
            CancellationToken cancellationToken = default)
        {
            if (TryGetStreamLength(content, out var length) &&
                length < singleUploadThreshold)
            {
                // When possible, upload as a single chunk
                var uploadTask = uploadStreamAsync(content, async, cancellationToken);
                return async ?
                    await uploadTask.ConfigureAwait(false) :
                    uploadTask.EnsureCompleted();
            }
            else
            {
                // Split the stream into 4MB chunks and upload as individual blocks
                using (var partitions = new StreamPartitioner(content))
                {
                    for (var chunkNumber = 0; /* Does not terminate - you must break */; chunkNumber++)
                    {
                        var position = content.Position;
                        var readTask = partitions.ReadAsync(chunkSize, async, cancellationToken);
                        using (var chunk = async ?
                            await readTask.ConfigureAwait(false) :
                            readTask.EnsureCompleted())
                        {
                            if (chunk.Length == 0)
                            {
                                // We've exhausted the content and can stop looping
                                break;
                            }
                            else
                            {
                                // Otherwise upload the chunk
                                var uploadTask = uploadChunkAsync(chunk, chunkNumber, async, cancellationToken);
                                var blockInfo = async ?
                                    await uploadTask.ConfigureAwait(false) :
                                    uploadTask.EnsureCompleted();
                            }
                        }
                    }

                    // Complete the upload
                    var commitTask = commitAsync(async, cancellationToken);
                    return async ?
                        await commitTask.ConfigureAwait(false) :
                        commitTask.EnsureCompleted();
                }
            }
        }
    }
}
