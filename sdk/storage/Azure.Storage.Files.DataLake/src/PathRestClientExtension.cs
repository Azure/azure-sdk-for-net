// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Files.DataLake.Models;

namespace Azure.Storage.Files.DataLake
{
    internal partial class PathRestClient
    {
        [DllImport("CompressionModule.dll")]
        private static extern int Xp9Compress(
            IntPtr pUncompressedBuffer,
            long uUncompressedSize,
            IntPtr pCompressedBuffer,
            long uCompressedBufferSize,
            out long uCompressedBytes,
            out long uUncompressedCrc64);

        public static async Task<CompressedMemoryStream> GetCompressedMemoryStream(
            Stream content,
            AutoBuffer contentBytes,
            AutoBuffer compressedBytes,
            bool async,
            CancellationToken cancellationToken)
        {
            if (content == null || !content.CanSeek || contentBytes.Buffer == null || compressedBytes.Buffer == null)
            {
                return null;
            }

            if (content.Length - content.Position > 4 * 1024 * 1024)
            {
                return null;
            }

            int contentLength = (int)(content.Length - content.Position);
            long position = content.Position;
            int contentBytesOffset = 0;

            while (contentBytesOffset < contentLength)
            {
                if (async)
                {
                    contentBytesOffset += await content.ReadAsync(
                        buffer: contentBytes.Buffer,
                        offset: contentBytesOffset,
                        count: contentLength - contentBytesOffset,
                        cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    contentBytesOffset += content.Read(
                        buffer: contentBytes.Buffer,
                        offset: contentBytesOffset,
                        count: contentLength - contentBytesOffset);
                }
            }

            using (AutoPinner orig = new AutoPinner(contentBytes.Buffer))
            {
                using (AutoPinner comp = new AutoPinner(compressedBytes.Buffer))
                {
                    long crc64;
                    long compressedSize;
                    if (0 != Xp9Compress(orig, contentLength, comp, compressedBytes.Size, out compressedSize, out crc64))
                    {
                        content.Seek(position, SeekOrigin.Begin);
                    }
                    else
                    {
                        return new CompressedMemoryStream(compressedBytes.Buffer, (int)compressedSize, contentLength);
                    }
                }
            }

            return null;
        }

        public async Task<ResponseWithHeaders<PathConcurrentAppendHeaders>> CompressedConcurrentAppendAsync(
            CompressedMemoryStream body,
            int? timeout = null,
            AppendMode? appendMode = null,
            long? contentLength = null,
            byte[] transactionalContentHash = null,
            CancellationToken cancellationToken = default)
        {
            if (body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            using var message = CreateConcurrentAppendRequest(body, timeout, appendMode, contentLength, transactionalContentHash);
            message.Request.Headers.Add("x-ms-original-content-length", body.UncompressedLength.ToString(CultureInfo.InvariantCulture));
            message.Request.Headers.Add("x-ms-compressed-chunk-count", "1");

            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new PathConcurrentAppendHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        public ResponseWithHeaders<PathConcurrentAppendHeaders> CompressedConcurrentAppend(
            CompressedMemoryStream body,
            int? timeout = null,
            AppendMode? appendMode = null,
            long? contentLength = null,
            byte[] transactionalContentHash = null,
            CancellationToken cancellationToken = default)
        {
            if (body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            using var message = CreateConcurrentAppendRequest(body, timeout, appendMode, contentLength, transactionalContentHash);
            message.Request.Headers.Add("x-ms-original-content-length", body.UncompressedLength.ToString(CultureInfo.InvariantCulture));
            message.Request.Headers.Add("x-ms-compressed-chunk-count", "1");

            _pipeline.Send(message, cancellationToken);
            var headers = new PathConcurrentAppendHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }
    }
}