// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Core.Pipeline.Policies;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class BufferResponsePolicyTests: PolicyTestBase
    {
        [Test]
        public async Task ReadsEntireBodyIntoMemoryStream()
        {
            MockResponse mockResponse = new MockResponse(200);
            var readTrackingStream = new ReadTrackingStream(128, int.MaxValue);
            mockResponse.ResponseContentStream = readTrackingStream;

            var mockTransport = new MockTransport(mockResponse);
            var response = await SendGetRequest(mockTransport, BufferResponsePolicy.Singleton);

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
                ResponseContentStream = new ReadTrackingStream(128, 64)
            };

            var mockTransport = new MockTransport(mockResponse);
            Assert.ThrowsAsync<IOException>(async () => await SendGetRequest(mockTransport, BufferResponsePolicy.Singleton));
        }

        [Test]
        public async Task SkipsResponsesWithoutContent()
        {
            MockResponse mockResponse = new MockResponse(200);

            var mockTransport = new MockTransport(mockResponse);
            var response = await SendGetRequest(mockTransport, BufferResponsePolicy.Singleton);
            Assert.Null(response.ContentStream);
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

            public override bool CanRead { get; } = true;
            public override bool CanSeek { get; }
            public override bool CanWrite { get; }
            public override long Length { get; }
            public override long Position { get; set; }
        }
    }
}
