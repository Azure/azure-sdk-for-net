// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.ServiceModel.Rest.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// This class adapts Response.ContentStream and Response.Content to a
    /// PipelineResponse.Content.
    /// </summary>
    internal class ResponseContent : MessageContent
    {
        //private const int CopyToBufferSize = 81920;

        // The contract with Response is that if it has content set, it will always
        // have a ContentStream.  Its Content property derives from the stream.
        // So, we can assume that ContentStream is where the content lives and ignore
        // the BinaryData Content property in this adapter.

        private readonly Response _response;

        //private readonly Stream _stream;
        //private readonly long _origin;

        public ResponseContent(Response response)
        {
            _response = response;

            // This is copied from RequestContent's StreamContent.
            // TODO: do we need both?

            //if (!stream.CanSeek)
            //    throw new ArgumentException("Stream must be seekable", nameof(stream));
            //_origin = stream.Position;
            //_stream = stream;
        }

        public override void Dispose()
        {
            // TODO:
            //_stream.Dispose();
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

        public override void WriteTo(Stream stream, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public override Task WriteToAsync(Stream stream, CancellationToken cancellation)
        {
            throw new NotImplementedException();
            //_stream.Seek(_origin, SeekOrigin.Begin);
            //await _stream.CopyToAsync(stream, CopyToBufferSize, cancellation).ConfigureAwait(false);
        }
    }
}
