// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class RetriableStreamTests
    {
        private byte[] _buffer = new byte[256];

        [Test]
        public async Task MaintainsGlobalLengthAndPosition()
        {
            var stream1 = new MockReadStream(100, throwAfter: 50);
            var stream2 = new MockReadStream(50, offset: 50, throwIOException: false);

            var mockTransport = new MockTransport(
                new MockResponse(200) { ResponseContentStream = stream1 },
                new MockResponse(200) { ResponseContentStream = stream2 }
            );
            var pipeline = new HttpPipeline(mockTransport);

            var reliableStream = await RetriableStream.Create(offset => SendTestRequestAsync(pipeline, offset), new ResponseClassifier(), maxRetries: 5);

            Assert.AreEqual(25, await reliableStream.ReadAsync(_buffer, 0, 25));
            Assert.AreEqual(100, reliableStream.Length);
            Assert.AreEqual(25, reliableStream.Position);

            Assert.AreEqual(25, await reliableStream.ReadAsync(_buffer, 25, 25));
            Assert.AreEqual(100, reliableStream.Length);
            Assert.AreEqual(50, reliableStream.Position);

            Assert.AreEqual(50, await reliableStream.ReadAsync(_buffer, 50, 50));
            Assert.AreEqual(100, reliableStream.Length);
            Assert.AreEqual(100, reliableStream.Position);

            Assert.AreEqual(0, await reliableStream.ReadAsync(_buffer, 0, 50));
            AssertReads(_buffer, 100);
        }

        [Test]
        public async Task DoesntRetryNonRetryableExceptions()
        {
            var stream1 = new MockReadStream(100, throwAfter: 50);
            var stream2 = new MockReadStream(50, offset: 50, throwAfter: 0, throwIOException: false);

            var mockTransport = new MockTransport(
                new MockResponse(200) { ResponseContentStream = stream1 },
                new MockResponse(200) { ResponseContentStream = stream2 }
            );
            var pipeline = new HttpPipeline(mockTransport);

            var reliableStream = await RetriableStream.Create(offset => SendTestRequestAsync(pipeline, offset), new ResponseClassifier(), maxRetries: 5);

            Assert.AreEqual(25, await reliableStream.ReadAsync(_buffer, 0, 25));
            Assert.AreEqual(100, reliableStream.Length);
            Assert.AreEqual(25, reliableStream.Position);

            Assert.AreEqual(25, await reliableStream.ReadAsync(_buffer, 25, 25));
            Assert.AreEqual(100, reliableStream.Length);
            Assert.AreEqual(50, reliableStream.Position);

            Assert.ThrowsAsync<InvalidOperationException>(() => reliableStream.ReadAsync(_buffer, 50, 50));

            AssertReads(_buffer, 50);
        }

        [Test]
        public void ThrowsIfInitialRequestThrow()
        {
            Assert.ThrowsAsync<InvalidOperationException>(() => RetriableStream.Create(_ => throw new InvalidOperationException(), new ResponseClassifier(), 5));
        }

        [Test]
        public async Task ThrowsIfSendingRetryRequestThrows()
        {
            var stream1 = new MockReadStream(100, throwAfter: 50);
            var mockTransport = new MockTransport(new MockResponse(200) { ResponseContentStream = stream1 });

            var pipeline = new HttpPipeline(mockTransport);

            var reliableStream = await RetriableStream.Create(
                async offset =>
                {
                    if (offset == 0)
                    {
                        return await SendTestRequestAsync(pipeline, offset);
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
                }, new ResponseClassifier(), maxRetries: 5);

            await reliableStream.ReadAsync(_buffer, 0, 25);
            await reliableStream.ReadAsync(_buffer, 25, 25);

            AssertReads(_buffer, 50);
            Assert.ThrowsAsync<InvalidOperationException>(() => reliableStream.ReadAsync(_buffer, 50, 50));
        }

        [Test]
        public async Task RetriesMaxCountAndThrowsAggregateException()
        {
            var mockTransport = new MockTransport(
                new MockResponse(200) { ResponseContentStream = new MockReadStream(100, throwAfter: 1) },
                new MockResponse(200) { ResponseContentStream = new MockReadStream(100, throwAfter: 1, offset: 1) },
                new MockResponse(200) { ResponseContentStream = new MockReadStream(100, throwAfter: 1, offset: 2) },
                new MockResponse(200) { ResponseContentStream = new MockReadStream(100, throwAfter: 1, offset: 3) }
                );

            var pipeline = new HttpPipeline(mockTransport);

            var reliableStream = await RetriableStream.Create(
                async offset =>
                {
                    if (offset == 0)
                    {
                        return await SendTestRequestAsync(pipeline, offset);
                    }

                    throw new InvalidOperationException();
                }, new ResponseClassifier(), maxRetries: 3);

            var aggregateException = Assert.ThrowsAsync<AggregateException>(() => reliableStream.ReadAsync(_buffer, 0, 4));
            StringAssert.StartsWith("Retry failed after 4 tries", aggregateException.Message);
            Assert.AreEqual(4, aggregateException.InnerExceptions.Count);
            Assert.AreEqual("Failed at 0", aggregateException.InnerExceptions[0].Message);
            Assert.AreEqual("Failed at 1", aggregateException.InnerExceptions[1].Message);
            Assert.AreEqual("Failed at 2", aggregateException.InnerExceptions[2].Message);
            Assert.AreEqual("Failed at 3", aggregateException.InnerExceptions[3].Message);
            Assert.AreEqual(4, mockTransport.Requests.Count);
        }

        private void AssertReads(byte[] buffer, int length)
        {
            for (int i = 0; i < length; i++)
            {
                Assert.AreEqual((byte)i, buffer[i]);
            }
        }

        private static Task<Response> SendTestRequestAsync(HttpPipeline pipeline, long offset)
        {
            using (HttpPipelineRequest request = pipeline.CreateRequest())
            {
                request.SetRequestLine(HttpPipelineMethod.Get, new Uri("http://example.com"));
                request.AddHeader("Range", "bytes=" + offset);

                return pipeline.SendRequestAsync(request, CancellationToken.None);
            }
        }

        private class MockReadStream: ReadOnlyStream
        {
            private readonly long _throwAfter;

            private byte _offset;

            private readonly bool _throwIOException;

            public MockReadStream(long length, long throwAfter = int.MaxValue, byte offset = 0, bool throwIOException = true)
            {
                _throwAfter = throwAfter;
                _offset = offset;
                _throwIOException = throwIOException;
                Length = length;
            }

            public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
            {
                var left = (int)Math.Min(count, Length - Position);

                Position += left;

                if (Position > _throwAfter)
                {
                    if (_throwIOException)
                    {
                        throw new IOException($"Failed at {_offset}");
                    }
                    throw new InvalidOperationException();
                }

                for (int i = 0; i < left; i++)
                {
                    buffer[offset + i] = _offset++;
                }

                return Task.FromResult(left);
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                return ReadAsync(buffer, offset, count).GetAwaiter().GetResult();
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                throw new NotImplementedException();
            }

            public override bool CanRead { get; } = true;
            public override bool CanSeek { get; } = false;
            public override long Length { get; }
            public override long Position { get; set; }
        }
    }
}
