// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class RetriableStreamTests : SyncAsyncTestBase
    {
        private readonly byte[] _buffer = new byte[256];

        public RetriableStreamTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task MaintainsGlobalLengthAndPosition()
        {
            var stream1 = new MockReadStream(100, throwAfter: 50, canSeek: true);
            var stream2 = new MockReadStream(50, offset: 50);

            MockTransport mockTransport = CreateMockTransport(
                new MockResponse(200) { ContentStream = stream1 },
                new MockResponse(200) { ContentStream = stream2 }
            );
            var pipeline = new HttpPipeline(mockTransport);

            Stream reliableStream = await CreateAsync(
                offset => SendTestRequest(pipeline, offset),
                offset => SendTestRequestAsync(pipeline, offset),
                ResponseClassifier.Shared, maxRetries: 5);

            Assert.That(await ReadAsync(reliableStream, _buffer, 0, 25), Is.EqualTo(25));
            Assert.That(reliableStream.Length, Is.EqualTo(100));
            Assert.That(reliableStream.Position, Is.EqualTo(25));

            Assert.That(await ReadAsync(reliableStream, _buffer, 25, 25), Is.EqualTo(25));
            Assert.That(reliableStream.Length, Is.EqualTo(100));
            Assert.That(reliableStream.Position, Is.EqualTo(50));

            Assert.That(await ReadAsync(reliableStream, _buffer, 50, 50), Is.EqualTo(50));
            Assert.That(reliableStream.Length, Is.EqualTo(100));
            Assert.That(reliableStream.Position, Is.EqualTo(100));

            Assert.That(await ReadAsync(reliableStream, _buffer, 0, 50), Is.EqualTo(0));
            AssertReads(_buffer, 100);
        }

        [Test]
        public async Task DisposesStreams()
        {
            var stream1 = new MockReadStream(100, throwAfter: 50);
            var stream2 = new MockReadStream(50, offset: 50);

            MockTransport mockTransport = CreateMockTransport(
                new MockResponse(200) { ContentStream = stream1 },
                new MockResponse(200) { ContentStream = stream2 }
            );
            var pipeline = new HttpPipeline(mockTransport);

            Stream reliableStream = await CreateAsync(
                offset => SendTestRequest(pipeline, offset),
                offset => SendTestRequestAsync(pipeline, offset),
                ResponseClassifier.Shared, maxRetries: 5);

            Assert.That(await ReadAsync(reliableStream, _buffer, 0, 25), Is.EqualTo(25));
            Assert.That(await ReadAsync(reliableStream, _buffer, 25, 25), Is.EqualTo(25));
            Assert.That(await ReadAsync(reliableStream, _buffer, 50, 50), Is.EqualTo(50));
            Assert.That(stream1.IsDisposed, Is.True);

            Assert.That(await ReadAsync(reliableStream, _buffer, 0, 50), Is.EqualTo(0));
            Assert.That(stream2.IsDisposed, Is.False);

            reliableStream.Dispose();
            Assert.That(stream2.IsDisposed, Is.True);

            AssertReads(_buffer, 100);
        }

        [Test]
        public async Task DoesntRetryNonRetryableExceptions()
        {
            var stream1 = new MockReadStream(100, throwAfter: 50, canSeek: true);
            var stream2 = new MockReadStream(50, offset: 50, throwAfter: 0, exceptionType: typeof(InvalidOperationException));

            MockTransport mockTransport = CreateMockTransport(
                new MockResponse(200) { ContentStream = stream1 },
                new MockResponse(200) { ContentStream = stream2 }
            );
            var pipeline = new HttpPipeline(mockTransport);

            Stream reliableStream = await CreateAsync(
                offset => SendTestRequest(pipeline, offset),
                offset => SendTestRequestAsync(pipeline, offset),
                ResponseClassifier.Shared,
                maxRetries: 5);

            Assert.That(await ReadAsync(reliableStream, _buffer, 0, 25), Is.EqualTo(25));
            Assert.That(reliableStream.Length, Is.EqualTo(100));
            Assert.That(reliableStream.Position, Is.EqualTo(25));

            Assert.That(await ReadAsync(reliableStream, _buffer, 25, 25), Is.EqualTo(25));
            Assert.That(reliableStream.Length, Is.EqualTo(100));
            Assert.That(reliableStream.Position, Is.EqualTo(50));

            Assert.ThrowsAsync<InvalidOperationException>(() => reliableStream.ReadAsync(_buffer, 50, 50));

            AssertReads(_buffer, 50);
        }

        [Test]
        [TestCase(typeof(TaskCanceledException), typeof(TaskCanceledException))]
        [TestCase(typeof(ObjectDisposedException), typeof(TaskCanceledException))]
        [TestCase(typeof(UnauthorizedAccessException), typeof(UnauthorizedAccessException))]
        public async Task ThrowsCorrectExceptionOnCustomerCancellationTokens(Type initial, Type translated)
        {
            // not supported on sync
            if (!IsAsync)
            {
                Assert.Ignore();
            }

            var stream1 = new MockReadStream(100, throwAfter: 25, canSeek: true, exceptionType: initial);

            MockTransport mockTransport = CreateMockTransport(
                new MockResponse(200) { ContentStream = stream1 });
            var pipeline = new HttpPipeline(mockTransport);

            Stream reliableStream = await CreateAsync(
                offset => SendTestRequest(pipeline, offset),
                offset => SendTestRequestAsync(pipeline, offset),
                ResponseClassifier.Shared,
                maxRetries: 5);

            Assert.That(await ReadAsync(reliableStream, _buffer, 0, 25), Is.EqualTo(25));
            Assert.That(reliableStream.Length, Is.EqualTo(100));
            Assert.That(reliableStream.Position, Is.EqualTo(25));

            var exception = await AsyncAssert.ThrowsAsync<Exception>(
                async () => await ReadAsync(reliableStream, _buffer, 25, 25, new CancellationToken(true)));
            Assert.That(exception, Is.InstanceOf(translated));

            AssertReads(_buffer, 25);
        }

        [Test]
        public async Task RetriesOnNonCustomerCancellationToken()
        {
            var stream1 = new MockReadStream(100, throwAfter: 50, exceptionType: typeof(OperationCanceledException), canSeek: true);
            var stream2 = new MockReadStream(50, offset: 50);

            MockTransport mockTransport = CreateMockTransport(
                new MockResponse(200) { ContentStream = stream1 },
                new MockResponse(200) { ContentStream = stream2 }
            );
            var pipeline = new HttpPipeline(mockTransport);

            Stream reliableStream = await CreateAsync(
                offset => SendTestRequest(pipeline, offset),
                offset => SendTestRequestAsync(pipeline, offset),
                ResponseClassifier.Shared,
                maxRetries: 5);

            Assert.That(await ReadAsync(reliableStream, _buffer, 0, 25), Is.EqualTo(25));
            Assert.That(reliableStream.Length, Is.EqualTo(100));
            Assert.That(reliableStream.Position, Is.EqualTo(25));

            Assert.That(await ReadAsync(reliableStream, _buffer, 25, 25), Is.EqualTo(25));
            Assert.That(reliableStream.Length, Is.EqualTo(100));
            Assert.That(reliableStream.Position, Is.EqualTo(50));

            Assert.That(await ReadAsync(reliableStream, _buffer, 50, 50), Is.EqualTo(50));
            Assert.That(reliableStream.Length, Is.EqualTo(100));
            Assert.That(reliableStream.Position, Is.EqualTo(100));

            AssertReads(_buffer, 100);
        }

        [Test]
        public async Task DoesntCallLengthPrematurely()
        {
            var stream1 = new NoLengthStream();
            var stream2 = new MockReadStream(50);

            MockTransport mockTransport = CreateMockTransport(
                new MockResponse(200) { ContentStream = stream1 },
                new MockResponse(200) { ContentStream = stream2 }
            );
            var pipeline = new HttpPipeline(mockTransport);

            Stream reliableStream = RetriableStream.Create(
                IsAsync ? await SendTestRequestAsync(pipeline, 0) : SendTestRequest(pipeline, 0),
                offset => SendTestRequest(pipeline, offset),
                offset => SendTestRequestAsync(pipeline, offset),
                ResponseClassifier.Shared,
                maxRetries: 5);

            Assert.That(await ReadAsync(reliableStream, _buffer, 0, 50), Is.EqualTo(50));
            Assert.That(reliableStream.Position, Is.EqualTo(50));

            Assert.That(await ReadAsync(reliableStream, _buffer, 0, 50), Is.EqualTo(0));

            Assert.Throws<NotSupportedException>(() => _ = reliableStream.Length);

            AssertReads(_buffer, 50);
        }

        [Test]
        public async Task ThrowsIfSendingRetryRequestThrows()
        {
            var stream1 = new MockReadStream(100, throwAfter: 50);
            MockTransport mockTransport = CreateMockTransport(new MockResponse(200) { ContentStream = stream1 });

            var pipeline = new HttpPipeline(mockTransport);

            Stream reliableStream = await CreateAsync(
                offset =>
                {
                    if (offset == 0)
                    {
                        return SendTestRequest(pipeline, offset);
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
                },
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
                }, ResponseClassifier.Shared, maxRetries: 5);

            await ReadAsync(reliableStream, _buffer, 0, 25);
            await ReadAsync(reliableStream, _buffer, 25, 25);

            AssertReads(_buffer, 50);
            Assert.ThrowsAsync<InvalidOperationException>(() => ReadAsync(reliableStream, _buffer, 50, 50));
        }

        [Test]
        public async Task RetriesMaxCountAndThrowsAggregateException()
        {
            MockTransport mockTransport = CreateMockTransport(
                new MockResponse(200) { ContentStream = new MockReadStream(100, throwAfter: 1) },
                new MockResponse(200) { ContentStream = new MockReadStream(100, throwAfter: 1, offset: 1) },
                new MockResponse(200) { ContentStream = new MockReadStream(100, throwAfter: 1, offset: 2) },
                new MockResponse(200) { ContentStream = new MockReadStream(100, throwAfter: 1, offset: 3) }
                );

            var pipeline = new HttpPipeline(mockTransport);

            Stream reliableStream = await CreateAsync(offset =>
                {
                    if (offset == 0)
                    {
                        return SendTestRequest(pipeline, offset);
                    }

                    throw new InvalidOperationException();
                },
                async offset =>
                {
                    if (offset == 0)
                    {
                        return await SendTestRequestAsync(pipeline, offset);
                    }

                    throw new InvalidOperationException();
                }, ResponseClassifier.Shared, maxRetries: 3);

            AggregateException aggregateException = Assert.ThrowsAsync<AggregateException>(() => ReadAsync(reliableStream, _buffer, 0, 4));
            Assert.That(aggregateException.Message, Does.StartWith("Retry failed after 4 tries"));
            Assert.That(aggregateException.InnerExceptions.Count, Is.EqualTo(4));
            Assert.That(aggregateException.InnerExceptions[0].Message, Is.EqualTo("Failed at 0"));
            Assert.That(aggregateException.InnerExceptions[1].Message, Is.EqualTo("Failed at 1"));
            Assert.That(aggregateException.InnerExceptions[2].Message, Is.EqualTo("Failed at 2"));
            Assert.That(aggregateException.InnerExceptions[3].Message, Is.EqualTo("Failed at 3"));
            Assert.That(mockTransport.Requests.Count, Is.EqualTo(4));
        }

        [Test]
        public void ThrowsForLengthOnNonSeekableStream()
        {
            Assert.Throws<NotSupportedException>(() => _ = RetriableStream.Create(
                _ => new MockReadStream(100, canSeek: false),
                _ => default,
                ResponseClassifier.Shared,
                5).Length);
        }

        [Test]
        public void IgnoresMisbehavingStreams()
        {
            Assert.Throws<NotSupportedException>(() => _ = RetriableStream.Create(
                _ => new NoLengthStream(canSeek: true),
                _ => default,
                ResponseClassifier.Shared,
                5).Length);
        }

        [Test]
        public void ThrowsIfInitialRequestThrow()
        {
            Assert.Throws<InvalidOperationException>(() => RetriableStream.Create(
                _ => throw new InvalidOperationException(),
                _ => default,
                ResponseClassifier.Shared,
                5));
        }

        [Test]
        public void ThrowsIfInitialRequestThrowAsync()
        {
            Assert.ThrowsAsync<InvalidOperationException>(() => RetriableStream.CreateAsync(
                _ => null,
                _ => throw new InvalidOperationException(),
                ResponseClassifier.Shared,
                5));
        }

        [Test]
        public async Task FlushDoesntThrow()
        {
            Stream reliableStream = await CreateAsync(
                offset => new MemoryStream(),
                offset => new ValueTask<Stream>(new MemoryStream()),
                ResponseClassifier.Shared, maxRetries: 5);

            await reliableStream.FlushAsync();
        }

        private void AssertReads(byte[] buffer, int length)
        {
            for (int i = 0; i < length; i++)
            {
                Assert.That(buffer[i], Is.EqualTo((byte)i));
            }
        }

        private Task<Stream> CreateAsync(
            Func<long, Stream> streamFactory,
            Func<long, ValueTask<Stream>> asyncStreamFactory,
            ResponseClassifier responseClassifier,
            int maxRetries)
        {
            return IsAsync ?
                RetriableStream.CreateAsync(streamFactory, asyncStreamFactory, responseClassifier, maxRetries) :
                Task.FromResult(RetriableStream.Create(streamFactory, asyncStreamFactory, responseClassifier, maxRetries));
        }

        private Task<int> ReadAsync(Stream stream, byte[] buffer, int offset, int length, CancellationToken cancellationToken = default)
        {
            return IsAsync ? stream.ReadAsync(buffer, offset, length, cancellationToken) : Task.FromResult(stream.Read(buffer, offset, length));
        }

        private static Stream SendTestRequest(HttpPipeline pipeline, long offset)
        {
            using Request request = CreateRequest(pipeline, offset);

            Response response = pipeline.SendRequest(request, CancellationToken.None);
            return response.ContentStream;
        }

        private static async ValueTask<Stream> SendTestRequestAsync(HttpPipeline pipeline, long offset)
        {
            using Request request = CreateRequest(pipeline, offset);

            Response response = await pipeline.SendRequestAsync(request, CancellationToken.None);
            return response.ContentStream;
        }

        private static Request CreateRequest(HttpPipeline pipeline, long offset)
        {
            Request request = pipeline.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("https://example.com"));
            request.Headers.Add("Range", "bytes=" + offset);
            return request;
        }

        private class NoLengthStream : ReadOnlyStream
        {
            public NoLengthStream(bool canSeek = false)
            {
                CanSeek = canSeek;
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                throw new IOException();
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                throw new NotSupportedException();
            }

            public override bool CanRead { get; } = true;
            public override bool CanSeek { get; }
            public override long Length => throw new NotSupportedException();
            public override long Position { get; set; }
        }

        private class MockReadStream : ReadOnlyStream
        {
            private readonly long _throwAfter;

            private byte _offset;
            private readonly Type _exceptionType;

            public MockReadStream(long length, long throwAfter = int.MaxValue, byte offset = 0, Type exceptionType = null, bool canSeek = false)
            {
                _throwAfter = throwAfter;
                _offset = offset;
                _exceptionType = exceptionType ?? typeof(IOException);
                Length = length;
                CanSeek = canSeek;
            }

            public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
            {
                var left = (int)Math.Min(count, Length - Position);

                Position += left;

                if (Position > _throwAfter)
                {
                    throw (Exception)Activator.CreateInstance(_exceptionType, $"Failed at {_offset}");
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
            public override bool CanSeek { get; }
            public override long Length { get; }
            public override long Position { get; set; }
            public bool IsDisposed { get; set; }

            protected override void Dispose(bool disposing)
            {
                base.Dispose(disposing);
                IsDisposed = true;
            }
        }
    }
}
