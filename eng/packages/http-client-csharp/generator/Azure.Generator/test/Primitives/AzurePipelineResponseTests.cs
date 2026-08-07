// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Moq;
using NUnit.Framework;

namespace Azure.Generator.Tests.Primitives
{
    public class AzurePipelineResponseTests
    {
        [Test]
        public void DisposeDelegatesToAzureResponse()
        {
            var response = new Mock<Response>();
            var pipelineResponse = new AzurePipelineResponse(response.Object);

            pipelineResponse.Dispose();

            response.Verify(r => r.Dispose(), Times.Once);
        }

        [Test]
        public void BufferContentDisposesNetworkStream()
        {
            var response = new Mock<Response> { CallBase = true };
            var networkStream = new TrackingStream([1, 2, 3]);
            response.SetupProperty(r => r.ContentStream, networkStream);
            var pipelineResponse = new AzurePipelineResponse(response.Object);

            BinaryData content = pipelineResponse.BufferContent();

            Assert.IsTrue(networkStream.IsDisposed);
            Assert.AreEqual(new byte[] { 1, 2, 3 }, content.ToArray());
            Assert.IsInstanceOf<MemoryStream>(response.Object.ContentStream);
        }

        [Test]
        public void BufferContentHonorsCancellationToken()
        {
            var response = new Mock<Response> { CallBase = true };
            var networkStream = new TrackingStream([1, 2, 3]);
            response.SetupProperty(r => r.ContentStream, networkStream);
            var pipelineResponse = new AzurePipelineResponse(response.Object);
            var cancellationToken = new CancellationToken(canceled: true);

            Assert.Throws<OperationCanceledException>(() => pipelineResponse.BufferContent(cancellationToken));
        }

        [Test]
        public async Task BufferContentAsyncDisposesNetworkStream()
        {
            var response = new Mock<Response> { CallBase = true };
            var networkStream = new TrackingStream([1, 2, 3]);
            response.SetupProperty(r => r.ContentStream, networkStream);
            var pipelineResponse = new AzurePipelineResponse(response.Object);

            BinaryData content = await pipelineResponse.BufferContentAsync();

            Assert.IsTrue(networkStream.IsDisposed);
            Assert.AreEqual(new byte[] { 1, 2, 3 }, content.ToArray());
            Assert.IsInstanceOf<MemoryStream>(response.Object.ContentStream);
        }

        private sealed class TrackingStream : Stream
        {
            private readonly MemoryStream _inner;

            public TrackingStream(byte[] content)
            {
                _inner = new MemoryStream(content);
            }

            public bool IsDisposed { get; private set; }

            public override bool CanRead => _inner.CanRead;
            public override bool CanSeek => _inner.CanSeek;
            public override bool CanWrite => _inner.CanWrite;
            public override long Length => _inner.Length;

            public override long Position
            {
                get => _inner.Position;
                set => _inner.Position = value;
            }

            public override void Flush() => _inner.Flush();

            public override int Read(byte[] buffer, int offset, int count)
                => _inner.Read(buffer, offset, count);

            public override long Seek(long offset, SeekOrigin origin)
                => _inner.Seek(offset, origin);

            public override void SetLength(long value)
                => _inner.SetLength(value);

            public override void Write(byte[] buffer, int offset, int count)
                => _inner.Write(buffer, offset, count);

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    IsDisposed = true;
                    _inner.Dispose();
                }

                base.Dispose(disposing);
            }
        }
    }
}
