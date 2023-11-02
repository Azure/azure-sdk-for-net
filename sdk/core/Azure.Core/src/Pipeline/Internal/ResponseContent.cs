// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System.IO;
using System.Net.ClientModel.Core;
using System.Net.ClientModel.Internal;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// This class adapts Response.ContentStream and Response.Content to a
    /// PipelineResponse.Content.
    /// </summary>
    internal class ResponseContent : RequestBody
    {
        private const int CopyToBufferSize = 81920;

        // The contract with Response is that if it has content set, it will always
        // have a ContentStream.  Its Content property derives from the stream.
        // So, we can assume that ContentStream is where the content lives and ignore
        // the BinaryData Content property in this adapter.

        private readonly Response _response;

        public ResponseContent(Response response)
        {
            _response = response;
        }

        public override void Dispose()
        {
            // TODO: use Dispose(bool) pattern here instead.

            Stream? contentStream = _response.ContentStream;
            contentStream?.Dispose();
        }

        public override bool TryComputeLength(out long length)
        {
            if (_response.ContentStream is null)
            {
                length = default;
                return false;
            }

            long origin = _response.ContentStream.Position;
            if (_response.ContentStream.CanSeek)
            {
                length = _response.ContentStream.Length - origin;
                return true;
            }

            length = 0;
            return false;
        }

        public override void WriteTo(Stream stream, CancellationToken cancellationToken)
        {
            if (_response.ContentStream is null)
            {
                return;
            }

            // TODO: find a way to reuse the implementation
            Stream contentStream = _response.ContentStream;

            // This is not using CopyTo so that we can honor cancellations.
            byte[] buffer = ArrayPool<byte>.Shared.Rent(CopyToBufferSize);
            try
            {
                while (true)
                {
                    ClientUtilities.ThrowIfCancellationRequested(cancellationToken);
                    var read = contentStream.Read(buffer, 0, buffer.Length);
                    if (read == 0)
                    { break; }
                    ClientUtilities.ThrowIfCancellationRequested(cancellationToken);
                    stream.Write(buffer, 0, read);
                }
            }
            finally
            {
                stream.Flush();
                ArrayPool<byte>.Shared.Return(buffer, true);
            }
        }

        public override async Task WriteToAsync(Stream stream, CancellationToken cancellationToken)
        {
            if (_response.ContentStream is null)
            {
                return;
            }

            await _response.ContentStream.CopyToAsync(stream, CopyToBufferSize, cancellationToken).ConfigureAwait(false);
        }
    }
}
