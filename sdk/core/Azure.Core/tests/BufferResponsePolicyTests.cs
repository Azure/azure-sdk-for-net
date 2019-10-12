// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class BufferResponsePolicyTests : SyncAsyncPolicyTestBase
    {
        public BufferResponsePolicyTests(bool isAsync) : base(isAsync) { }

        [Test]
        public async Task ReadsEntireBodyIntoMemoryStream()
        {
            MockResponse mockResponse = new MockResponse(200);
            var readTrackingStream = new ReadTrackingStream(128, int.MaxValue);
            mockResponse.ContentStream = readTrackingStream;

            MockTransport mockTransport = CreateMockTransport(mockResponse);
            Response response = await SendGetRequest(mockTransport, BufferResponsePolicy.Shared);

            Assert.IsInstanceOf<MemoryStream>(response.ContentStream);
            var ms = (MemoryStream)response.ContentStream;

            Assert.AreEqual(128, ms.Length);
            foreach (var b in ms.ToArray())
            {
                Assert.AreEqual(ReadTrackingStream.ContentByteValue, b);
            }
            Assert.AreEqual(128, readTrackingStream.BytesRead);
            Assert.AreEqual(0, ms.Position);
        }

        [Test]
        public void SurfacesStreamReadingExceptions()
        {
            MockResponse mockResponse = new MockResponse(200)
            {
                ContentStream = new ReadTrackingStream(128, 64)
            };

            MockTransport mockTransport = CreateMockTransport(mockResponse);
            Assert.ThrowsAsync<IOException>(async () => await SendGetRequest(mockTransport, BufferResponsePolicy.Shared));
        }

        [Test]
        public async Task SkipsResponsesWithoutContent()
        {
            MockResponse mockResponse = new MockResponse(200);

            MockTransport mockTransport = CreateMockTransport(mockResponse);
            Response response = await SendGetRequest(mockTransport, BufferResponsePolicy.Shared);
            Assert.Null(response.ContentStream);
        }

        [Test]
        public async Task ClosesStreamAfterCopying()
        {
            ReadTrackingStream readTrackingStream = new ReadTrackingStream(128, int.MaxValue);
            MockResponse mockResponse = new MockResponse(200)
            {
                ContentStream = readTrackingStream
            };

            MockTransport mockTransport = CreateMockTransport(mockResponse);
            await SendGetRequest(mockTransport, BufferResponsePolicy.Shared);

            Assert.True(readTrackingStream.IsClosed);
        }

        [Test]
        public async Task DoesntBufferWhenDisabled()
        {
            ReadTrackingStream readTrackingStream = new ReadTrackingStream(128, int.MaxValue);
            MockResponse mockResponse = new MockResponse(200)
            {
                ContentStream = readTrackingStream
            };

            MockTransport mockTransport = CreateMockTransport(mockResponse);
            Response response = await SendGetRequest(mockTransport, BufferResponsePolicy.Shared, bufferResponse: false);

            Assert.IsNotInstanceOf<MemoryStream>(response.ContentStream);
        }

        private class ReadTrackingStream : Stream
        {
            public const int ContentByteValue = 233;

            private readonly int _size;

            private readonly int _throwAfter;

            public ReadTrackingStream(int size, int throwAfter)
            {
                _size = size;
                _throwAfter = throwAfter;
            }

            public int BytesRead { get; set; }

            public override void Flush()
            {
                throw new System.NotImplementedException();
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                if (BytesRead == _size)
                {
                    return 0;
                }

                int left = Math.Min(count, _size);
                Span<byte> span = buffer.AsSpan(offset, left);

                for (int i = 0; i < span.Length; i++)
                {
                    span[i] = ContentByteValue;
                }

                BytesRead += left;

                if (BytesRead > _throwAfter)
                {
                    throw new IOException();
                }

                return left;
            }


            public override long Seek(long offset, SeekOrigin origin)
            {
                throw new System.NotImplementedException();
            }

            public override void SetLength(long value)
            {
                throw new System.NotImplementedException();
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                throw new System.NotImplementedException();
            }

            public override void Close()
            {
                IsClosed = true;
                base.Close();
            }

            public bool IsClosed { get; set; }

            public override bool CanRead { get; } = true;
            public override bool CanSeek { get; }
            public override bool CanWrite { get; }
            public override long Length { get; }
            public override long Position { get; set; }
        }
    }
}
