// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage.Test.Shared
{
    internal class TamperStreamContentsPolicy : HttpPipelineSynchronousPolicy
    {
        /// <summary>
        /// Default tampering that changes the first byte of the stream.
        /// </summary>
        private static readonly Func<Stream, Stream> _defaultStreamTransform = stream =>
        {
            if (stream is not MemoryStream)
            {
                var buffer = new MemoryStream();
                stream.CopyTo(buffer);
                stream = buffer;
            }

            stream.Position = 0;
            var firstByte = stream.ReadByte();

            stream.Position = 0;
            stream.WriteByte((byte)((firstByte + 1) % byte.MaxValue));

            stream.Position = 0;
            return stream;
        };

        private readonly Func<Stream, Stream> _streamTransform;

        public TamperStreamContentsPolicy(Func<Stream, Stream> streamTransform = default)
        {
            _streamTransform = streamTransform ?? _defaultStreamTransform;
        }

        public bool TransformRequestBody { get; set; }

        public bool TransformResponseBody { get; set; }

        public override void OnSendingRequest(HttpMessage message)
        {
            if (TransformRequestBody && message.Request.Content != default)
            {
                var sendContents = new MemoryStream();
                message.Request.Content.WriteTo(sendContents, CancellationToken.None);
                message.Request.Content = RequestContent.Create(_streamTransform(sendContents));
            }
        }

        public override void OnReceivedResponse(HttpMessage message)
        {
            if (TransformResponseBody && message.Response.ContentStream != default)
            {
                message.Response.ContentStream = _streamTransform(message.Response.ContentStream);
            }
        }
    }
}
