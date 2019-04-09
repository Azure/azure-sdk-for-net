// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Base.Http.Pipeline;
using Azure.Base.Testing;
using NUnit.Framework;

namespace Azure.Base.Tests
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
                Assert.AreEqual(223, b);
            }
            Assert.AreEqual(128, readTrackingStream.BytesRead);
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

        private class ReadTrackingStream : Stream
        {
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
                    span[i] = 223;
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
