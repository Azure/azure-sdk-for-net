// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage
{
    internal static partial class ContentHasher
    {
        /// <summary>
        /// Applies structured message encoding or content hashing for upload operations,
        /// then attaches the progress handler to the content stream.
        /// When <paramref name="allowStructuredMessage"/> is <c>true</c> and
        /// <paramref name="validationOptions"/> requests CRC64, the content is wrapped in a
        /// structured message encoding stream and progress is reported in terms of the original
        /// (unencoded) byte count. Otherwise the content hash is computed before the progress
        /// handler is attached.
        /// </summary>
        /// <param name="content">The upload content stream. May be <c>null</c>.</param>
        /// <param name="validationOptions">Upload validation options, or <c>null</c> for none.</param>
        /// <param name="allowStructuredMessage">
        /// Whether structured message encoding is permitted for this request.
        /// Pass <c>false</c> to disable it (e.g. when client-side encryption is active).
        /// </param>
        /// <param name="progressHandler">Optional progress handler.</param>
        /// <param name="async">Whether to run asynchronously.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>
        /// A tuple of the (potentially wrapped) content stream, the computed hash result
        /// (or <c>null</c> when structured message encoding was applied), the structured body type
        /// header value, and the structured content length (both <c>null</c> when structured
        /// message was not used).
        /// </returns>
        public static async Task<(Stream Content, GetHashResult HashResult, string StructuredBodyType, long? StructuredContentLength)> ApplyUploadEncodingInternal(
            Stream content,
            UploadTransferValidationOptions validationOptions,
            bool allowStructuredMessage,
            IProgress<long> progressHandler,
            bool async,
            CancellationToken cancellationToken)
        {
            if (content == null)
            {
                return (content, null, null, null);
            }

            GetHashResult hashResult = null;
            long? structuredContentLength = default;
            string structuredBodyType = null;

            if (allowStructuredMessage
                && validationOptions != null
                && validationOptions.ChecksumAlgorithm.ResolveAuto() == StorageChecksumAlgorithm.StorageCrc64)
            {
                // Report progress in terms of caller bytes, not encoded bytes.
                structuredContentLength = content.Length - content.Position;
                structuredBodyType = Constants.StructuredMessage.CrcStructuredMessage;
                content = content.WithNoDispose().WithProgress(progressHandler);
                content = validationOptions.PrecalculatedChecksum.IsEmpty
                    ? new StructuredMessageEncodingStream(
                        content,
                        Constants.StructuredMessage.DefaultSegmentContentLength,
                        StructuredMessage.Flags.StorageCrc64)
                    : new StructuredMessagePrecalculatedCrcWrapperStream(
                        content,
                        validationOptions.PrecalculatedChecksum.Span);
            }
            else
            {
                // Compute hash BEFORE attaching progress handler.
                hashResult = await GetHashOrDefaultInternal(
                    content,
                    validationOptions,
                    async,
                    cancellationToken).ConfigureAwait(false);
                content = content.WithNoDispose().WithProgress(progressHandler);
            }

            return (content, hashResult, structuredBodyType, structuredContentLength);
        }
    }
}
