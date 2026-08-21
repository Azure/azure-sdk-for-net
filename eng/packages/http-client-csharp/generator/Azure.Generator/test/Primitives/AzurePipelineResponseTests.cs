// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Moq;
using Moq.Protected;
using NUnit.Framework;

namespace Azure.Generator.Tests.Primitives
{
    public class AzurePipelineResponseTests
    {
        [Test]
        public void ResponseSurvivesHttpMessageDisposal()
        {
            var response = new Mock<Response> { CallBase = true };
            response.SetupGet(r => r.Status).Returns(200);
            response.SetupGet(r => r.ReasonPhrase).Returns("OK");
            response.Protected()
                .Setup<IEnumerable<HttpHeader>>("EnumerateHeaders")
                .Returns([new HttpHeader("x-test", "value")]);
            var networkStream = new TrackingStream([1, 2, 3]);
            response.SetupProperty(r => r.ContentStream, networkStream);
            using var message = CreateMessage(response.Object);
            using var pipelineResponse = new AzurePipelineResponse(message);

            message.Dispose();

            Assert.AreEqual(200, pipelineResponse.Status);
            Assert.AreEqual("OK", pipelineResponse.ReasonPhrase);
            Assert.IsTrue(pipelineResponse.Headers.TryGetValue("x-test", out string? headerValue));
            Assert.AreEqual("value", headerValue);
            Assert.AreSame(networkStream, pipelineResponse.ContentStream);
            Assert.IsFalse(networkStream.IsDisposed);
        }

        [Test]
        public void BufferContentDisposesNetworkStream()
        {
            var response = new Mock<Response> { CallBase = true };
            var networkStream = new TrackingStream([1, 2, 3]);
            response.SetupProperty(r => r.ContentStream, networkStream);
            using var message = CreateMessage(response.Object);
            using var pipelineResponse = new AzurePipelineResponse(message);
            message.Dispose();

            BinaryData content = pipelineResponse.BufferContent();

            Assert.IsTrue(networkStream.IsDisposed);
            Assert.AreEqual(new byte[] { 1, 2, 3 }, content.ToArray());
            Assert.IsInstanceOf<MemoryStream>(pipelineResponse.ContentStream);
        }

        [Test]
        public void BufferContentHonorsCancellationToken()
        {
            var response = new Mock<Response> { CallBase = true };
            var networkStream = new TrackingStream([1, 2, 3]);
            response.SetupProperty(r => r.ContentStream, networkStream);
            using var message = CreateMessage(response.Object);
            using var pipelineResponse = new AzurePipelineResponse(message);
            message.Dispose();
            var cancellationToken = new CancellationToken(canceled: true);

            Assert.Throws<OperationCanceledException>(() => pipelineResponse.BufferContent(cancellationToken));
            Assert.IsFalse(networkStream.IsDisposed);
        }

        [Test]
        public async Task BufferContentAsyncDisposesNetworkStream()
        {
            var response = new Mock<Response> { CallBase = true };
            var networkStream = new TrackingStream([1, 2, 3]);
            response.SetupProperty(r => r.ContentStream, networkStream);
            using var message = CreateMessage(response.Object);
            using var pipelineResponse = new AzurePipelineResponse(message);
            message.Dispose();

            BinaryData content = await pipelineResponse.BufferContentAsync();

            Assert.IsTrue(networkStream.IsDisposed);
            Assert.AreEqual(new byte[] { 1, 2, 3 }, content.ToArray());
            Assert.IsInstanceOf<MemoryStream>(pipelineResponse.ContentStream);
        }

        [Test]
        public void DisposeDisposesExtractedStreamOnce()
        {
            var response = new Mock<Response> { CallBase = true };
            var networkStream = new TrackingStream([1, 2, 3]);
            response.SetupProperty(r => r.ContentStream, networkStream);
            using var message = CreateMessage(response.Object);
            var pipelineResponse = new AzurePipelineResponse(message);
            message.Dispose();

            pipelineResponse.Dispose();
            pipelineResponse.Dispose();

            Assert.AreEqual(1, networkStream.DisposeCount);
        }

        private static HttpMessage CreateMessage(Response response)
            => new(new Mock<Request>().Object, new Mock<ResponseClassifier>().Object)
            {
                Response = response
            };

        private sealed class TrackingStream : Stream
        {
            private readonly MemoryStream _inner;

            public TrackingStream(byte[] content)
            {
                _inner = new MemoryStream(content);
            }

            public bool IsDisposed => DisposeCount > 0;

            public int DisposeCount { get; private set; }

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
                    DisposeCount++;
                    _inner.Dispose();
                }

                base.Dispose(disposing);
            }
        }
    }
}
